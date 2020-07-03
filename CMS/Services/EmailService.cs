using CMS.Areas.Admin.Models.Db.Settings;
using CMS.Areas.Admin.Models.View.Article;
using CMS.Areas.Home.Models;
using CMS.Context;
using CMS.Services.interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailModel _email;
        public EmailService(CMSContext context)
        {
            _email = context.EmailSettings.FirstOrDefault();
        }

        public async Task<bool> SendEmail(string reciver, string subject, string emailBody)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(reciver);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(_email.EmailTo);
            message.To.Add(to);

            message.Subject = subject;

            BodyBuilder bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody = emailBody;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            await client.ConnectAsync(_email.Host, _email.Port, true);
            await client.AuthenticateAsync(_email.EmailFrom, _email.Password);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            client.Dispose();

            return true;
        }

        public async Task<bool> SendCommentConfirmation(CommentView result)
        {
            var subject = $"[ Nowy komentarz ] Od {result.Name}";
            var text = $"Nowa komentarz \n\nOD: {result.Name} \nEMAIL: {result.Email} \n\nTREŚĆ: {result.Content}";
            
            return await SendEmail(result.Email, subject, text);

        }

        public async Task<bool> SendContactForm(ContactView result)
        {        
            var subject = $"[ Wiadomość z formularza ] {result.Subject}";
            var text = $"Nowa wiadomość z formularza \n\nTEMAT: {result.Subject} \nEMAIL: {result.Email} \nIMIĘ: {result.Name} \nTELEFON: {result.Phone} \n\n WIADOMOŚĆ: \n{result.Message} ";

            return await SendEmail(result.Email, subject, text);
        }
    }
}
