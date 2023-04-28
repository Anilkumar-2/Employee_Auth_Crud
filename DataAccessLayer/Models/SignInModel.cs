namespace DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class SignInModel
    {
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
