namespace API.AWS
{
    internal static class MiddlewaresConfigurations
    {
        /// <summary>
        /// Método original para WebApplication
        /// </summary>
        public static WebApplication ConfigureMiddlewares(this WebApplication app)
        {
            ConfigureMiddlewaresShared(app, app.Environment);
            return app;
        }

        public static void ConfigureMiddlewaresShared(IApplicationBuilder app,
            IWebHostEnvironment env)
        {

            // IMPORTANTE: NO uses UseHttpsRedirection en Lambda
            // API Gateway maneja HTTPS automáticamente
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AWS_LAMBDA_FUNCTION_NAME")))
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.MapWhen(context =>
            {
                var path = context.Request.Path.Value?.ToLower() ?? "";
                return path.StartsWith("/api");
            },
            apiApp =>
            {
                apiApp.UseRouting();
                apiApp.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            });
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
