using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using AutoMapper;
using DoctorFlow.Entities.Models;
using DoctorFlow.Models;
using DoctorFlow.DataLogic;

namespace DoctorFlow.Controllers.UserControllers
{
    public class RegisterController : Controller
    {
        private IUserRepository _userRepositry;
        public RegisterController()
        {
            _userRepositry = new UserRepository();
        }
        public RegisterController(IUserRepository userRepositry)
        {
            _userRepositry = userRepositry;
        }
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
            Mapper.CreateMap<User, UserRegisterModel>().ReverseMap();
            var newUser = Mapper.Map<UserRegisterModel,User>(registerModel);
            newUser.Status = true;
            newUser.RegisterDate = DateTime.Now;
            newUser.PasswordFlag = DateTime.Now.AddDays(-1);
            _userRepositry.CreateUser(newUser);
            return RedirectToAction("Create", "Login");
        }                                      
    }
}
