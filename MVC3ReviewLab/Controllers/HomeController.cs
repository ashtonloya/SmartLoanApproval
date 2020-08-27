﻿using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using MVC3ReviewLab.Models;//added for CVM

namespace MVC3ReviewLab.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Property()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult BlogGrid()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult PropertySingle()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult AgentsSingle()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult BlogSingle()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            //validation check - if they did not pass, send them back to the Creat view, with the form still
            //filled out
            //This is done by passing the object back to the view (cvm)
            if (!ModelState.IsValid)
            {
                return View(cvm);
            }


            //Create the message (email body text)
            string message = $"You have received an email from {cvm.Name} with a subject <strong>{cvm.Subject}</strong>.  Please respond to <em>{cvm.Email}</em> with your response to the following message: <br><br> {cvm.Message}";

            //Create the MailMessage object
            MailMessage msg = new MailMessage("noreply@loyadev.net", "ashtonloya@outlook.com", /*$"{System.DateTime.Now.Date} - {cvm.Subject}", message);*/

                cvm.Subject,

                message

                );

            //Customize MailMessage
            //msg.CC.Add("tboone@centriq.com");
            msg.Priority = MailPriority.High;
            msg.IsBodyHtml = true;

            //Create SmtpClient
            SmtpClient client = new SmtpClient("mail.loyadev.net");

            //Verify Credentials for client
            client.Credentials = new NetworkCredential("noreply@loyadev.net", "Jaguars70!");

            //For AT&T or XFinity
            client.Port = 8889;

            //Attempt to send email
            try
            {
                client.Send(msg);
            }
            catch (System.Exception)
            {
                ViewBag.Error = "Sorry, there was an error handling your request.  Please try again.";
                return View(cvm);
            }

            return View("EmailConfirmation", cvm);
        }
    }
}
