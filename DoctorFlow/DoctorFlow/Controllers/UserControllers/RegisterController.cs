using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoctorFlow.Models;
using DoctorFlow.DataLogic;

namespace DoctorFlow.Controllers.UserControllers
{
    public class RegisterController : Controller
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
        [AllowAnonymous]
        public ActionResult Create(UserRegisterModel registerModel)
        {
            
         DoctorFlow.DataLogic.UserAccount _userAccount=new UserAccount();

            _userAccount.CreateUser(registerModel.UserName, registerModel.Password, registerModel.Name,
                registerModel.LastName, registerModel.Email);
            return RedirectToAction("Create", "Login");

        }

        
    }
}
