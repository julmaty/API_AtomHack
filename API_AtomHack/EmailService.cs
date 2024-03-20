using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzScheduler
{
    public class EmailService
    {
        private readonly IConfiguration Configuration;
        public EmailService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {

            var mailSettings = Configuration.GetSection("mailSettings");

            var emailMessage = new MimeMessage();

            //emailMessage.From.Add(new MailboxAddress("Администрация сайта", "pravo.demetra@gmail.com"));
            emailMessage.From.Add(new MailboxAddress("ПомощникиТут.рф", mailSettings["Email"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            var headers = new HeaderId[] { HeaderId.From, HeaderId.Subject, HeaderId.To };
            emailMessage.Prepare(EncodingConstraint.SevenBit);

            using (var client = new SmtpClient())
            {

                client.CheckCertificateRevocation = false;
                //await client.ConnectAsync("smtp.gmail.com", 587, false);
                //await client.AuthenticateAsync("pravo.demetra@gmail.com", "11-Viktoria");
                await client.ConnectAsync(mailSettings["Host"], Convert.ToInt32(mailSettings["Port"]), true);
                await client.AuthenticateAsync(mailSettings["Email"], mailSettings["Password"]);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
