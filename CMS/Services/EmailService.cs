using CMS.Areas.Admin.Models.Db.Settings;
using CMS.Areas.Admin.Models.View.Article;
using CMS.Areas.Home.Models;
using CMS.Context;
using CMS.Services.interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using System.Linq;

namespace CMS.Services
{
    public class EmailService : IEmailService
    {
        private readonly CMSContext _context;
        private readonly EmailModel _email;
        public EmailService(CMSContext context)
        {
            _email = context.EmailSettings.FirstOrDefault();
            _context = context;
        }

        public bool SendCommentConfirmation(CommentView result)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(result.Email);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(_email.EmailTo);
            message.To.Add(to);

            message.Subject = $"[ Nowy komentarz ] Od {result.Name}";

            BodyBuilder bodyBuilder = new BodyBuilder();

            var text = $"Nowa komentarz \n\nOD: {result.Name} \nEMAIL: {result.Email} \n\nTREŚĆ: {result.Content}";

            bodyBuilder.HtmlBody = text;
            bodyBuilder.TextBody = text;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect(_email.Host, _email.Port, true);
            client.Authenticate(_email.EmailFrom, _email.Password);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return true;
        }
        public bool SendContactForm(ContactView result)
        {
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(result.Email);
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress(_email.EmailTo);
            message.To.Add(to);

            message.Subject = $"[ Wiadomość z formularza ] {result.Subject}";

            BodyBuilder bodyBuilder = new BodyBuilder();

            var text = $"Nowa wiadomość z formularza \n\nTEMAT: {result.Subject} \nEMAIL: {result.Email} \nIMIĘ: {result.Name} \nTELEFON: {result.Phone} \n\n WIADOMOŚĆ: \n{result.Message} ";

            bodyBuilder.HtmlBody = text;
            bodyBuilder.TextBody = text;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect(_email.Host, _email.Port, true);
            client.Authenticate(_email.EmailFrom, _email.Password);

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return true;
        }


    }
}
