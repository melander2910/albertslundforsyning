using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlbertslundForsyning.Entities;
using System.Collections.Generic;
using AlbertslundForsyning.Service;
using Microsoft.AspNetCore.Http;


namespace AlbertslundForsyning.Controllers
{
   public class UserController : Controller
   {
       
        Service.UserService userService = new Service.UserService();

        [HttpPost]
        public async Task<IActionResult> SignUp([Bind("Username, Password, FirstName, LastName, PhoneNumber, Email, Zipcode, StreetName, StreetNumber")] User user)
        {    
            await userService.Create(user);
            return RedirectToAction("Login", "Home"); // redirect to a specific cshtml page  
        }

        [HttpPost]
        public IActionResult Login([Bind("Username, Password")] User user)
        {    
            var valid = userService.ValidateLogin(user);

            if (valid is not null){
                HttpContext.Session.SetString("username", user.Username);
                HttpContext.Session.SetString("password", user.Password);
                return RedirectToAction("UserPage", "Home");
            }

            return RedirectToAction("Login", "Home");
        }
    } 
}