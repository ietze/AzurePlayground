using Azure.Monitor.OpenTelemetry.Exporter;
using AzurePlayground.Function;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.Functions.Worker.OpenTelemetry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")))
{
    builder.Services.AddOpenTelemetry()
        .UseFunctionsWorkerDefaults()
        .UseAzureMonitorExporter();
}
else
{
    throw new Exception("Environment variable APPLICATIONINSIGHTS_CONNECTION_STRING is not set.");
}

builder.Services.AddOptions<MaxDoctorOutputSettings>()
    .BindConfiguration("MaxDoctorOutput")
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddScoped<DoctorsRepository>();

builder.Build().Run();