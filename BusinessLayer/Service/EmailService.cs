namespace BusinessLayer.Service
{
    using DataAccessLayer.Models;
    using DataAccessLayer.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Threading.Tasks;
    using DataAccessLayer.DATA;
    using System.Net;
    using System.Net.Mail;
    using Microsoft.Extensions.Options;

    public class EmailService : IEmailService
    {
        private readonly SMTPConfigModel _smtpConfig = new SMTPConfigModel();
        public EmailService(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }
        public async Task SendTestEmail(UserEmail userEmail)
        {
            userEmail.Subject = "Confirmation Mail";
            userEmail.Body = "This Email is regards confirmation for your regestration on Employee portal";
            await SendEmail(userEmail);

        }
        public async Task SendEmail(UserEmail userEmail)
        {
            MailMessage mail = new MailMessage()
            {
                Subject = userEmail.Subject,
                Body = userEmail.Body,
                From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.IsBodyHTML

            };
            foreach (var toEmail in userEmail.ToEmails)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);
            System.Net.Mail.SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UserDefaultCredentials,
                Credentials = networkCredential
            };
            await smtpClient.SendMailAsync(mail);
        }
    }
}
