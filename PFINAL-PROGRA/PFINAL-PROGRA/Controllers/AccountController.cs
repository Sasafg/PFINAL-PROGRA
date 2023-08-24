using System;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PFINAL_PROGRA.Models;

namespace PFINAL_PROGRA.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ProycFinalEntities db = new ProycFinalEntities();

        //
        // GET: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Autenticación basada en ProycFinalEntities
            using (var context = new ProycFinalEntities())
            {
                var user = context.Usuario.SingleOrDefault(u => u.correo == model.correo && u.contrasena == model.contrasena);
                if (user == null)
                {
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View(model);
                }
            }

            // Si llegamos aquí, el inicio de sesión fue exitoso
            Session["UltimaConexión"] = DateTime.Now; //ultima conx
            return RedirectToLocal(returnUrl);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Register(Usuario model)
            {
                if (ModelState.IsValid)
                {
                    var newUser = new Usuario
                    {
                        nombreUsuario = model.nombreUsuario,
                        correo = model.correo,
                        contrasena = model.contrasena,
                        Rol = model.Rol // Asigna el rol del modelo
                    };

                    db.Usuario.Add(newUser);
                    await db.SaveChangesAsync();

                    // Resto del código de registro exitoso
                    return RedirectToAction("Index", "Home");
                }

                return View(model);
            }

      
    }
}


