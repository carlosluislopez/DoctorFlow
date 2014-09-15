using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DoctorFlow.DataLogic;
using DoctorFlow.Entities.Models;
using DoctorFlow.Models;
using DoctorFlow.Models.UserModels;

namespace DoctorFlow.Controllers.UserControllers
{
    public class RegisterDoctorController : Controller
    {
        private IUserRepository _userRepositry;

        public RegisterDoctorController()
        {
            _userRepositry = new UserRepository();
        }

        public RegisterDoctorController(IUserRepository userRepositry)
        {
            _userRepositry = userRepositry;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(DoctorRegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<User, DoctorRegisterModel>().ReverseMap();
                Mapper.CreateMap<Doctor, DoctorRegisterModel>().ReverseMap();
                var newUser = Mapper.Map<DoctorRegisterModel, User>(registerModel);
                var newDoctor = Mapper.Map<DoctorRegisterModel, Doctor>(registerModel);
                newUser.Status = true;
                newUser.RegisterDate = DateTime.Now;
                newUser.PasswordFlag = DateTime.Now.AddDays(-1);
                newUser.BirthDate = DateTime.Now;
                newDoctor.MyUserData = newUser;


                _userRepositry.CreateDoctor(newUser, newDoctor);
                return RedirectToAction("Create", "Login");
            }
            return View(registerModel);
        }
    }
}