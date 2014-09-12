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
    public class ProfileController : Controller
    {
        private IUserRepository _userRepositry;
        //
        // GET: /Profile/
        public ActionResult Index()
        {

            return View();
        }

        //
        // GET: /Profile/Details/5
        public ActionResult Details(User user)
        {
            
            return View(user);
        }
        
        //
        // GET: /Profile/Edit/5
        public ActionResult Edit(User user)
        {
            return View(user);
        }

        //
        // POST: /Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(UserProfileModel registerModel)
        {
            //UserRegisterModel registerModel
            try
            {
                Mapper.CreateMap<User, UserRegisterModel>().ReverseMap();
                var newUser = Mapper.Map<UserProfileModel, User>(registerModel);
                newUser.Status = true;
                newUser.RegisterDate = DateTime.Now;
                newUser.PasswordFlag = DateTime.Now.AddDays(-1);
                _userRepositry.CreateUser(newUser);
                return RedirectToAction("Edit", "Profile");
            }
            catch
            {
                return View();
            }
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
