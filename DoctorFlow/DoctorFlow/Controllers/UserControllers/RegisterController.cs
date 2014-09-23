﻿using System;
using System.Web.Mvc;
using AutoMapper;
using DoctorFlow.Entities.Models;
using DoctorFlow.Models;
using DoctorFlow.DataLogic;
using DoctorFlow.Models.UserModels;
using RestSharp;
using System.Web.Security;


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

        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(UserRegisterModel registerModel)
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

                Mapper.CreateMap<User, UserRegisterModel>().ReverseMap();
                var newUser = Mapper.Map<UserRegisterModel, User>(registerModel);                
                newUser.RegisterDate = DateTime.Now;
                newUser.BirthDate = DateTime.Now;
                newUser.PasswordFlag = DateTime.Now.AddDays(-1);

                const int passwordLength = 8;
                const int numberOfNonAlphanumericCharacters = 2;
                var generatePassword = Membership.GeneratePassword(passwordLength, numberOfNonAlphanumericCharacters);

                newUser.ActivateCode = generatePassword;

                if (_userRepositry.CreateUser(newUser))
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

        public ActionResult Activate()
        {
            if (Request.QueryString.Count == 0)
            {
                ViewBag.Errors = new[]
                    {
                        "•No se encontro el ningun registro de este tipo."
                    };
                return View();
            }

            if (Request.QueryString["ActivateCode"] == "")
            {
                ViewBag.Errors = new[]
                    {
                        "•El codigo se encuentra vacio!"
                    };
                return View();
            }
            var userModel = new UserActivateModel {ActivateCode = Request.QueryString["ActivateCode"]};
            return View(userModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Activate(UserActivateModel userModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = new[]
                    {
                        "•Llena todos los campos por favor!"
                    };
                return View(userModel);
            }
            var userAccount = new UserRepository();
            if(userAccount.ActivateUser(userModel.EmailOrUserName, userModel.Password, userModel.ActivateCode))
                return RedirectToAction("Index", "Home");
            ViewBag.Errors = new[]
                    {
                        "•No se encontro tu usuario, o escribiste mal tu contraseña!"
                    };
            return View(userModel);
        }

        public ActionResult Disable()
        {
            var userId = int.Parse(Session["USERID"].ToString());

            var userAccount = new UserRepository();
            var disableUser = userAccount.getUser(userId);

            disableUser.Status = false;


            const int passwordLength = 8;
            const int numberOfNonAlphanumericCharacters = 2;
            var generatePassword = Membership.GeneratePassword(passwordLength, numberOfNonAlphanumericCharacters);

            disableUser.ActivateCode = generatePassword;

            if (_userRepositry.DisableUser(disableUser))
            {
                string temporalDomain = "http://localhost:1744";
                string link = temporalDomain + "/Register/Activate";//TODO
                string message = string.Format("Visite el siguiente enlace: \"{0}?ActivateCode={1}\" para volver activar su cuenta.", link, generatePassword);
                message += Environment.NewLine;
                message += "(Copie el enlace y peguelo en la barra de direcciones de su navegador web).";
                SendSimpleMessage(disableUser.Email, message);

                Session["USERNAME"] = string.Empty;
                Session.Add("USERID", -1);

            }

            return RedirectToAction("Index", "Home");
        }
    }
}
