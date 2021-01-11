using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopAppDemo.WebUI.EmailServices
{
    public class EmailSender : IEmailSender
    {
        private const string SendGridApiKey = "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";
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(SendGridApiKey, subject, htmlMessage, email);
        }

        private Task Execute(string sendGridApiKey, string subject, string htmlMessage, string email)
        {
            var client = new SendGridClient(sendGridApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("info@shopappdemo.com", "ShopApp Demo"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
