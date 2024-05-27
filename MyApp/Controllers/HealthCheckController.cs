using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("Service is running");
}
