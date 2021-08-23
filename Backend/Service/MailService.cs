using MimeKit;
using MailKit.Net.Smtp;
using AlbertslundForsyning.Models;
using AlbertslundForsyning.Entities;


namespace AlbertslundForsyning.Service
{
    public class MailService
    {
        public void sendMail(Contact MailInfo){
            var message = new MimeMessage ();
			message.From.Add (new MailboxAddress (MailInfo.SenderEmail, "pdmmailer@gmail.com"));
			message.To.Add (new MailboxAddress ("Peter Melander", "pdmmailer@gmail.com"));
			message.Subject = MailInfo.SenderSubject;
            

			message.Body = new TextPart ("plain") {
				Text = MailInfo.SenderMessage
			};

			using (var client = new SmtpClient ()) {
				client.Connect ("smtp.gmail.com", 587);

				// Note: only needed if the SMTP server requires authentication
				client.Authenticate ("pdmmailer@gmail.com", "nodejspass");

				client.Send (message);
				client.Disconnect (true);
			}
        }
    }
}
