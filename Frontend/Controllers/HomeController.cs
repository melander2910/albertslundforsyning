using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AlbertslundForsyning.Entities;
using AlbertslundForsyning.Models;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace AlbertslundForsyning.Controllers
{
    public class HomeController : Controller
    {

        Service.UserService userService = new Service.UserService();
        Service.MailService mailService = new Service.MailService();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BaseViewModel model = new BaseViewModel();
            model.User = getSessionUser();
            return View(model);
        }

        public IActionResult About()
        {
            BaseViewModel model = new BaseViewModel();
            model.User = getSessionUser();
            return View(model);
        }

        public IActionResult TAO()
        {
            BaseViewModel model = new BaseViewModel();
            model.User = getSessionUser();
            return View(model);
        }

        public IActionResult Databehandling()
        {
            BaseViewModel model = new BaseViewModel();
            model.User = getSessionUser();
            return View(model);
        }

        public IActionResult Contact()
        {
            ContactViewModel model = new ContactViewModel();
            model.User = getSessionUser();
            return View(model);
        }

        [HttpPost]
        public IActionResult SendMail([Bind("SenderName, SenderEmail, SenderPhoneNumber, SenderSubject, SenderMessage")] Contact MailInfo)
        {    
            mailService.sendMail(MailInfo);
            return RedirectToAction("Contact", "Home"); // redirect to a specific cshtml page  
        }
        public IActionResult Login()
        {
            BaseViewModel model = new BaseViewModel();
            model.User = getSessionUser();
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("password", "");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            BaseViewModel model = new BaseViewModel();
            model.User = getSessionUser();
            return View(model);
        }

        public IActionResult IFrameTilskud()
        {
            BaseViewModel model = new BaseViewModel();
            model.User = getSessionUser();
            return View(model);
        }

        public User getSessionUser(){
            User tempUser = new User();
            tempUser.Username = HttpContext.Session.GetString("username");
            tempUser.Password = HttpContext.Session.GetString("password");
        
            var user = userService.ValidateLogin(tempUser);
            return user;
        }

        public IActionResult UserPage()
        {
            User tempUser = new User();

            tempUser.Username = HttpContext.Session.GetString("username");
            tempUser.Password = HttpContext.Session.GetString("password");
            
            var user = userService.ValidateLogin(tempUser);

            if (user is not null){
                BaseViewModel model = new BaseViewModel();
                model.User = user;
                return View(model); // redirect to a specific cshtml page 
            }

            return RedirectToAction("Login", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
