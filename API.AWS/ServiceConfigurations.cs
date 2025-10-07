namespace API.AWS
{
    internal static class ServiceConfigurations
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            ConfigureServicesShared(builder.Services, builder.Configuration);

            return builder.Build();
        }

        /// <summary>
        /// Método compartido que puede usar tanto Kestrel como Lambda
        /// </summary>
        public static void ConfigureServicesShared(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

        }
    }
}
