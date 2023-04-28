namespace BusinessLayer.Service
{
    using DataAccessLayer.Models;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAccountService
    {
        Task<IdentityResult> SignUpUser(SignUpModel signUpModel);
        Task<string> SignInUser(SignInModel signInModel);
    }
}
