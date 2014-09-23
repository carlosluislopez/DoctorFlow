using System.Web.Mvc;
using DoctorFlow.DataLogic;
using DoctorFlow.Models.UserModels;
using System.Web.Security;

namespace DoctorFlow.Controllers.UserControllers
{
    public class PasswordRecoveryController : Controller
    {

        private IUserRepository _userRepository;

        public PasswordRecoveryController() 
        {
            _userRepository = new UserRepository();
        }
        public PasswordRecoveryController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Restore()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(UserPasswordRecoveryModel userPasswordRecoveryModel)
        {
            if (ModelState.IsValid)
            {
                var email = userPasswordRecoveryModel.Email;
                const int passwordLength = 8;
                const int numberOfNonAlphanumericCharacters = 2;
                var generatePassword = Membership.GeneratePassword(passwordLength, numberOfNonAlphanumericCharacters);
                if (!_userRepository.InitiatePasswordRecovery(email, generatePassword))
                {

                    return View("Error");
                }
                string temporalDomain = "http://localhost:1744";
                string link = temporalDomain + "/PasswordRecovery/Restore";//TODO
                string message = string.Format("Visite el siguiente enlace: {0} para recuperar su contraseña y " +
                                               "utilice esta clave para hacer el cambio:\n {1} \nSi usted no pidio " +
                                               "esto por favor ignore este correo.", link, generatePassword);
                Mailer.SendSimpleMessage(userPasswordRecoveryModel.Email, message);

                return RedirectToAction("Create", "Login");
            }
            return View(userPasswordRecoveryModel);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Restore(UserPasswordResetModel userPasswordResetModel)
        {
            if (ModelState.IsValid)
            {
                var email = userPasswordResetModel.Email;
                var newPassword = userPasswordResetModel.NewPassword;
                var passkey = userPasswordResetModel.PassKey;
                if (newPassword != userPasswordResetModel.ConfirmNewPassword)
                {
                    ViewBag.Message =
                        "•No hay conincidencia entre el campon de Contraseña y el campo de Confirmación de contraseña";
                    return View("RestoreError");
                }
                if (!_userRepository.ResetPassword(email, newPassword, passkey))
                {
                    ViewBag.Errors = new[]
                {
                    "Ha ocurrido un error al intentar restaurar su contraseña, esto puede ocurrir debido a varios factores:",
                    "•El correo que ingresó no existe en nuestro servidor",
                    "•La restauración solicitada ya expiró:",
                    "Vuelva a iniciar el proceso de restauración."
                };
                    return View("RestoreError");
                }
                return RedirectToAction("Create", "Login");
            }
            return View(userPasswordResetModel);
        }
    }
}