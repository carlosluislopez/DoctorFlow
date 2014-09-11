using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorFlow.Models;
using DoctorFlow.DataLogic;

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
            var userId = userAccount.Login(loginModel.EmailOrUserName, loginModel.Password);
            if (userId == -1)
            {
                return RedirectToAction("Index", "Login"); 
            }
            return RedirectToAction("Details", "Profile", userId); 
            
        }

       
    }
}
