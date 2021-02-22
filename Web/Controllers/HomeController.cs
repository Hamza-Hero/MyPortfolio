using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portfolio;

        public HomeController(
            IUnitOfWork<Owner> owner,
            IUnitOfWork<PortfolioItem> portfolio)
        {
            _owner = owner;
            _portfolio = portfolio;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                PortfolioItems = _portfolio.Entity.GetAll().ToList()
            };

            return View(homeViewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            var mail = new MailMessage();

            // TODO: password eintragen
            // TODO: Email eintragen
            var loginInfo = new NetworkCredential("Email", "password");

            mail.From = new MailAddress(contact.EMail);
            mail.To.Add(new MailAddress("Email.com"));
            mail.Subject = contact.Subject;
            mail.Body = contact.Message;
            mail.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com", 587); // 587 Gmail Port
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = loginInfo;

            smtpClient.Send(mail);

            return View();
        }
    }
}