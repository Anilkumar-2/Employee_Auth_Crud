namespace BusinessLayer.Service
{
    using DataAccessLayer.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IEmailService
    {
        public Task SendTestEmail(UserEmail userEmail);
        public Task SendEmail(UserEmail userEmail);
    }
}
