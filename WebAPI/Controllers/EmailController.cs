using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;
using WebAPI.Models;
using WebAPI.Validators;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            var validator = new EmailRequestValidator();

            var results = validator.Validate(request);

            if (!results.IsValid)
            {
                return BadRequest(results.Errors);
            }

            await _emailService.SendEmailAsync(request);
            return Ok(new { message = "Email sent successfully." });
        }
    }
}
