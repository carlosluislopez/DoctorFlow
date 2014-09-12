using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Windows.Forms;
using DoctorFlow.Models;
using DoctorFlow.DataLogic;
using Microsoft.JScript;

namespace DoctorFlow.Controllers.UserControllers
{
    public class LoginController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserLoginModel loginModel)
        {
            var userAccount=new UserRepository();
            var user = userAccount.Login(loginModel.EmailOrUserName, loginModel.Password);
            
            
            if (user==null)
            {
                return RedirectToAction("Index", "Login"); 
            }
            Console.WriteLine(user.Name);
            return RedirectToAction("Details", "Profile",user); 
            
        }

       
    }
}
