using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Rota_InformaticProject.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Rota_InformaticProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Rota Yazılım İletişim", "sinancivak385@gmail.com"));
                message.To.Add(new MailboxAddress("Alıcı Adı", "sinancivak00@gmail.com"));
                message.Subject=contact.Subject;
                message.Body = new TextPart("plain")
                {
                    Text = "FullName: " + contact.FullName + "\n" +
                        "Email: " + contact.Email + "\n" +
                        "Phone: " + contact.Phone + "\n" +
                        "Subject: " + contact.Subject + "\n" +
                        "Body: " + contact.Body
                };

                using (var client =new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("sinancivak385@gmail.com", "abjmstmnmpzrvvno");
                    client.Send(message);
                    client.Disconnect(true);

                }

                return Ok();
            }

            return View();

        }

    }
}
