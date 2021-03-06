﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalSiteMVC3.Models;
using System.Net;
using System.Net.Mail;

namespace PersonalSiteMVC3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Link()
        {
            return View();
        }

        public ActionResult Project()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactEmailModel cem)
        {
            if (!ModelState.IsValid)
            {
                return View(cem);
            }

            string message = $"Name: {cem.Name}<br/>Email: {cem.Email}<br/>Subject: {cem.Subject}<br/>Message: {cem.Message}";

            MailMessage mm = new MailMessage("admin@ianwhitehill.com", "whitehill.ian@outlook.com", cem.Subject, message);

            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            mm.ReplyToList.Add(cem.Email);

            SmtpClient client = new SmtpClient("mail.ianwhitehill.com");
            client.Credentials = new NetworkCredential("admin@ianwhitehill.com", "1@TopGear@1");
            client.Port = 8889;

            try
            {
                client.Send(mm);
            }
            catch (Exception ex)
            {
                ViewBag.CustomerMessage = $"We are sorry your request could not be completed at this time please try again late <br/>Error Message:<br/>{ex.StackTrace}";
                return View(cem);
            }
            return View("EmailConfirmation", cem);
        }
    }
}