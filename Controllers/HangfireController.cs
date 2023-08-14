using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AFFHangfire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        private readonly ITestJob _testJob;
        public HangfireController(ITestJob testJob)
        {
            _testJob = testJob;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Let's test this");
        }

        [HttpPost("welcome")]
        public async Task<IActionResult> Welcome()
        {        
            //var _testJob = new TestJob();

            RecurringJob.AddOrUpdate(() => _testJob.SendWelcomeMessage("Welcome to Africa Fintech Foundry"), "*/15 * * * * *");


            //_testJob.SendWelcomeMessage("Hello");
            return Ok("Job successfully done");
        }
    }
}