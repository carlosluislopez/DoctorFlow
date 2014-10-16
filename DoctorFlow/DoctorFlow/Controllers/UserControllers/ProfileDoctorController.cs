using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using AutoMapper;
using DoctorFlow.Entities.Models;
using DoctorFlow.Models;
using DoctorFlow.Models.UserModels;
using DoctorFlow.DataLogic;
using System.Drawing;
using System.IO;

namespace DoctorFlow.Controllers.UserControllers
{
    public class ProfileDoctorController : Controller
    {
        private IUserRepository _userRepositry;

        public ActionResult Details()
        {
            if (Session == null) return RedirectToAction("index", "Home");
            int userId = int.Parse(Session["USERID"].ToString());
            int isDoctor = int.Parse(Session["ISDOCTOR"].ToString());
            
            if (isDoctor != 1)
                return RedirectToAction("Details", "Profile");

            _userRepositry = new UserRepository();
            Doctor doctor = _userRepositry.getDoctor(userId);

            Mapper.CreateMap<Doctor, DoctorProfileModel>();
            DoctorProfileModel eDoctor = Mapper.Map<Doctor, DoctorProfileModel>(doctor);

            return View(eDoctor);
        }


        public ActionResult Edit(string user)
        {
            int userId = int.Parse(Session["USERID"].ToString());
            int isDoctor = int.Parse(Session["ISDOCTOR"].ToString());

            if (isDoctor != 1)
                return RedirectToAction("Details", "Profile");

            _userRepositry = new UserRepository();
            Doctor editDoctor = _userRepositry.getDoctor(userId);

            Mapper.CreateMap<Doctor, DoctorProfileModel>();
            DoctorProfileModel eDoctor = Mapper.Map<Doctor, DoctorProfileModel>(editDoctor);

            return View(eDoctor);
        }

        [HttpPost]
        public ActionResult Edit(DoctorProfileModel registerModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = int.Parse(Session["USERID"].ToString());
                    

                    Mapper.CreateMap<Doctor, DoctorProfileModel>().ReverseMap();
                    var editDoctor = Mapper.Map<DoctorProfileModel, Doctor>(registerModel);
                    

                    _userRepositry = new UserRepository();
                    var user = _userRepositry.getUser(userId);
                    editDoctor.MyUserData = user;

                    _userRepositry.EditDoctor(editDoctor);

                    return RedirectToAction("Details", "ProfileDoctor");
                }
                catch
                {
                    return View(registerModel);
                }
            }
            return View(registerModel);
        }
    }
}
