using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AzurePlayground.Function;

public class ProductsFunction(ILogger<ProductsFunction> logger, IOptions<MaxDoctorOutputSettings> settings, DoctorsRepository doctorsRepository)
{
    [Function("GetProducts")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        var doctors = doctorsRepository.GetDoctors(settings.Value.Number);
        return new OkObjectResult(doctors);
    }
}
