using kevin_main.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace kevin_main.com.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("kevmain@outlook.com")); 
                message.From = new MailAddress("kevmain@outlook.com");
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

//                using (var smtp = new SmtpClient())
//                {
//                    var credential = new NetworkCredential
//                    {
//                        UserName = "user@outlook.com",  // replace with valid value
//                        Password = "password"  // replace with valid value
//                    };
//                    smtp.Credentials = credential;
//                    smtp.Host = "smtp-mail.outlook.com";
//                    smtp.Port = 587;
//                    smtp.EnableSsl = true;
//                    await smtp.SendMailAsync(message);
//                    return RedirectToAction("Sent");
//                }
            }
            
            return View(model);
        }
    }
}