using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{

[ApiController]
[Route("api/emails")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] SendEmailRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.From) || string.IsNullOrEmpty(request.Subject) || string.IsNullOrEmpty(request.Body))
        {
            return BadRequest("Invalid email request.");
        }

        await _emailService.SendEmailAsync(request);
        return Ok("Email sent successfully.");
    }
}

}

