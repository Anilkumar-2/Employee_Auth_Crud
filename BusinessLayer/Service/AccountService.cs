namespace BusinessLayer.Service
{
    using DataAccessLayer.Models;
    using DataAccessLayer.Repositories;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountService:IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IdentityResult> SignUpUser(SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpUser(signUpModel);
            return result;
        }
        public async Task<string> SignInUser(SignInModel signInModel)
        {
            var result = await _accountRepository.SignInUser(signInModel);
            return result;
        }

    }
}
