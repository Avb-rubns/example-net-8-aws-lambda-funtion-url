var builder = WebApplication.CreateBuilder(args);

// Configurar servicios compartidos
ServiceConfigurations.ConfigureServicesShared(builder.Services, builder.Configuration);

// Agregar soporte para AWS Lambda (detecta automáticamente el tipo de evento)
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

// Configurar middlewares compartidos
MiddlewaresConfigurations.ConfigureMiddlewaresShared(app, app.Environment);

app.Run();
