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
            int userId = int.Parse(Session["USERID"].ToString());

            UserRepository userAccount = new UserRepository();
            User user = userAccount.getUser(userId);

            Mapper.CreateMap<User, UserProfileModel>();
            UserProfileModel eUser = Mapper.Map<User, UserProfileModel>(user);

            return View(eUser);
        }
        

        public ActionResult Edit(string user)
        {
            int userId = int.Parse(Session["USERID"].ToString());
            
            UserRepository userAccount = new UserRepository();
            User editUser = userAccount.getUser(userId);

            Mapper.CreateMap<User, UserProfileModel>();
            UserProfileModel eUser = Mapper.Map<User, UserProfileModel>(editUser);

            return View(eUser);
        }

        [HttpPost]
        public ActionResult Edit(UserProfileModel registerModel)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/pjpeg",
                "image/png"
            };

            if (registerModel.UpladPhoto != null && registerModel.UpladPhoto.ContentLength > 0)
            {
                //ModelState.AddModelError("UpladPhoto", "This field is required");
                if (!validImageTypes.Contains(registerModel.UpladPhoto.ContentType))
                {
                    ModelState.AddModelError("UpladPhoto", "Por favr seleccione entre una imagen GIF, JPG o PNG");
                }
            }
            //else if (!validImageTypes.Contains(registerModel.UpladPhoto.ContentType))
            //{
            //    ModelState.AddModelError("UpladPhoto", "Please choose either a GIF, JPG or PNG image.");
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    //byte[] fileBytes = new byte[registerModel.UpladPhoto.ContentLength];

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
                    return View(registerModel);
                }
            }
            return View(registerModel);
        }

        //
        // GET: /Profile/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /Profile/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
