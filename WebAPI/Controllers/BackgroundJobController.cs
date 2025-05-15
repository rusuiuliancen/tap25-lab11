using Hangfire;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundJobController : ControllerBase
    {
        private const string Job1 = "Job1";
        private readonly IJobService _jobService;

        public BackgroundJobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpPost("start")]
        public IActionResult StartBackgroundJob()
        {
            RecurringJob.AddOrUpdate(Job1, () => _jobService.LogJobRun(Job1), "*/10 * * * * *");

            return Ok(new { message = "Background job started!" });
        }
    }
}
