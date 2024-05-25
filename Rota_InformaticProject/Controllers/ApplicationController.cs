using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Rota_InformaticProject.Models;

namespace Rota_InformaticProject.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ApplicationViewModel app)
        {
            if (ModelState.IsValid)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Rota Yazılım Teklif Formu", "sinancivak385@gmail.com"));
                message.To.Add(new MailboxAddress("Alıcı Adı", "sinancivak00@gmail.com"));
                message.Subject = "Teklif Formu Gelen";
                message.Body = new TextPart("plain")
                {
                    Text="FullName: "+app.FullName+"\n"+
                    "Email: " + app.Email + "\n" +
                    "Phone: " + app.Phone + "\n" +
                    "CompanyName: " + app.CompanyName + "\n" +
                    "Body: " + app.Body + "\n" 

                };
                using (var client=new MailKit.Net.Smtp.SmtpClient())
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
