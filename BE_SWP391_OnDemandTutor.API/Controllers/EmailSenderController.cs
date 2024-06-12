using System;
using BE_SWP391_OnDemandTutor.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BE_SWP391_OnDemandTutor.API.Controllers
{
	public class EmailSenderController  : ControllerBase
	{
        private readonly IEmailServices _emailServices;

        public EmailSenderController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpPost("SendMail")]
        public async Task<IActionResult> SendMail(string to)
        {

            await _emailServices.SendEmailAsync(to, "Register for Good Exchange platfom.");
            return Ok();
        }
    }
}

