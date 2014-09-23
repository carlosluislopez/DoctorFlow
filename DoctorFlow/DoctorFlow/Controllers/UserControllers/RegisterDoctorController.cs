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
using RestSharp;
using System.Web.Security;

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
                ViewBag.Errors = null;
                var user = _userRepositry.getUser(registerModel.Email);
                if (user != null)
                {
                    registerModel.Email = "";
                    ViewBag.Errors = new[]
                    {
                        "•El correo que ingreso ya existe"
                    };
                    return View();
                }

                user = _userRepositry.getUser(registerModel.UserName);
                if (user != null)
                {
                    registerModel.UserName = "";
                    ViewBag.Errors = new[]
                    {
                        "•El nombre de usuario que ingreso ya existe"
                    };
                    return View();
                }

                Mapper.CreateMap<User, DoctorRegisterModel>().ReverseMap();
                Mapper.CreateMap<Doctor, DoctorRegisterModel>().ReverseMap();
                var newUser = Mapper.Map<DoctorRegisterModel, User>(registerModel);
                var newDoctor = Mapper.Map<DoctorRegisterModel, Doctor>(registerModel);
                newUser.Status = true;
                newUser.RegisterDate = DateTime.Now;
                newUser.PasswordFlag = DateTime.Now.AddDays(-1);
                newUser.BirthDate = DateTime.Now;

                const int passwordLength = 8;
                const int numberOfNonAlphanumericCharacters = 2;
                var generatePassword = Membership.GeneratePassword(passwordLength, numberOfNonAlphanumericCharacters);

                newUser.ActivateCode = generatePassword;

                newDoctor.MyUserData = newUser;

                if (_userRepositry.CreateDoctor(newUser, newDoctor))
                {
                    string temporalDomain = "http://localhost:1744";
                    string link = temporalDomain + "/Register/Activate";//TODO
                    string message = string.Format(@"Visite el siguiente enlace: {0}?ActivateCode={1} para activar su cuenta.", link, generatePassword);
                    SendSimpleMessage(newUser.Email, message);
                }

                return RedirectToAction("Create", "Login");
            }
            return View(registerModel);
        }

        public static IRestResponse SendSimpleMessage(string email, string message)
        {
            var client = new RestClient
            {
                BaseUrl = "https://api.mailgun.net/v2",
                Authenticator = new HttpBasicAuthenticator(
                    "api", "key-5sbcxpwm9avrbeds-35y2i5hmda4y8k1")
            };
            var request = new RestRequest();
            request.AddParameter("domain",
                                "sandbox37840.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Doctor Flow <Drflow@sandbox37840.mailgun.org>");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Activacion de Cuenta");
            request.AddParameter("text", message);
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}