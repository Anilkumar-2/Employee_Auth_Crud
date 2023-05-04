namespace demopractice.Controllers
{
    using BusinessLayer.Service;
    using DataAccessLayer.Models;
    using DataAccessLayer.Repositories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService emailService;

        public AccountController(IAccountService accountService, IEmailService _emailService)
        {
            _accountService = accountService;
            emailService = _emailService;
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {

            var result = await _accountService.SignUpUser(signUpModel);
            UserEmail userEmail = new UserEmail
            {
                ToEmails = new List<string> { signUpModel.Email }
            };

            if (result.Succeeded)
            {
                await emailService.SendTestEmail(userEmail);
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }


        [HttpPost("LogIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInModel signInModel)
        {
            var result = await _accountService.SignInUser(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

    }
}
