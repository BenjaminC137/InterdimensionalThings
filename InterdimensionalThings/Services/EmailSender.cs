using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace InterdimensionalThings.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        private string _apiKey;

        public EmailSender(string apiKey){
            this._apiKey = apiKey;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            SendGridClient client = new SendGridClient(_apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("admin@interdimensionalthings.com", "Interdimensional Things"),
                Subject = subject,
                PlainTextContent = message,
                //HtmlContent = message
                HtmlContent = "<body style = \"border-width: 25px 3px; display: inline-block; border-style: solid; Background-color: rgba(195, 228, 239, .9); color: rgb(56,62, 77)\" <div style = \"border-width: 25px 3px; display: inline-block; border-style: solid; Background-color: rgba(195, 228, 239, .9); color: rgb(56,62, 77)\">"+ message + "</div></body>"
            };
            msg.AddTo(new EmailAddress(email));
            
            msg.TrackingSettings = new TrackingSettings
            {
                ClickTracking = new ClickTracking { Enable = false }
            };
            return client.SendEmailAsync(msg);
        }
    }
}
