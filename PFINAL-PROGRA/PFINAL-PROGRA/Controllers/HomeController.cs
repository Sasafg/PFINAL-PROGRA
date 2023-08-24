using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using PFINAL_PROGRA.Models;


namespace PFINAL_PROGRA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {


            using (var db = new ProycFinalEntities())
            {
                List<Producto> productos = db.Producto.ToList();
                return View(productos);

                //List<Producto> products = db.Producto.ToList();
                //return View(products);

            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult IniciarSesion()
        {
            return View(); 
        }



    }
}