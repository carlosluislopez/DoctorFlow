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
            DoctorFlow.DataLogic.UserAccount _userAccount=new UserAccount();

            if (_userAccount.Login(loginModel.EmailOrUserName, loginModel.Password))
            {
                return RedirectToAction("Create", "Login"); 
            }

            return RedirectToAction("Index","Login");
        }

       
    }
}
