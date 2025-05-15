using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Medical_record.Domain.Interfaces;

namespace Medical_record.Infrastructure.Repositories
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587) // cổng 465, khoong bảo mật bằng 587
            {
                EnableSsl = true, //bật bảo mật
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("haidangftest@gmail.com", "xmqggvixbxeveoix")
            };

            return client.SendMailAsync(
                new MailMessage(from: "haidangftest@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
