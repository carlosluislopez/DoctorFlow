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
using System.Drawing;
using System.IO;

namespace DoctorFlow.Controllers.UserControllers
{
    public class ProfileController : Controller
    {
        private IUserRepository _userRepositry;

        public ActionResult Details()
        {
            if (Session == null) return RedirectToAction("index", "Home");
            
            var userId = int.Parse(s: Session["USERID"].ToString());

            var userAccount = new UserRepository();
            var user = userAccount.getUser(userId);

            Mapper.CreateMap<User, UserProfileModel>();
            var eUser = Mapper.Map<User, UserProfileModel>(user);

            return View(eUser);
        }
        

        public ActionResult Edit()
        {
            if (Session == null)
            {
                ViewBag.Errors = new[]
                    {
                        "•Ha ocurrido un error! Por Favor vuelve a ingresar."
                    };
                return View();
            }
            var userId = int.Parse(Session["USERID"].ToString());
            
            var userAccount = new UserRepository();
            var editUser = userAccount.getUser(userId);

            Mapper.CreateMap<User, UserProfileModel>();
            var eUser = Mapper.Map<User, UserProfileModel>(editUser);

            return View(eUser);
        }

        [HttpPost]
        public ActionResult Edit(UserProfileModel registerModel)
        {
            var validImageTypes = new[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (registerModel.UpladPhoto != null && registerModel.UpladPhoto.ContentLength > 0 
                && !validImageTypes.Contains(registerModel.UpladPhoto.ContentType))
            {
                ModelState.AddModelError("UpladPhoto", "Por favor seleccione una imagen de tipo GIF, JPG o PNG");
            }
            if (!ModelState.IsValid) return View(registerModel);
            try
            {
                byte[] fileBytes = null;
                if (registerModel.UpladPhoto != null)
                {
                    using (var binaryReader = new BinaryReader(registerModel.UpladPhoto.InputStream))
                    {
                        fileBytes = binaryReader.ReadBytes(registerModel.UpladPhoto.ContentLength);
                    }
                }

                var userId = int.Parse(Session["USERID"].ToString());
                registerModel.Id = userId;
                registerModel.UpladPhoto = null;

                Mapper.CreateMap<User, UserProfileModel>().ReverseMap();
                var editUser = Mapper.Map<UserProfileModel, User>(registerModel);

                if(fileBytes != null)
                    editUser.Photo = fileBytes;

                _userRepositry = new UserRepository();
                _userRepositry.EditUser(editUser);

                return RedirectToAction("Details", "Profile");
            }
            catch
            {
                ViewBag.Errors = new[]
                    {
                        "•Ha ocurrido un error inesperado al intentar subir la imagen!"
                    };
                return View(registerModel);
            }
        }

        //TODO: Add delete logic here
    }
}
