using PFINAL_PROGRA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFINAL_PROGRA.Controllers
{
    public class VentaController : Controller
    {
        private ProyFinalEntities db = new ProyFinalEntities();
        public ActionResult Index()
        {
            return View(db.Venta.ToList().OrderBy(x => x.DiaVenta));
        }


        public ActionResult Detail(int id)
        {
            return View(db.Venta.Find(id));

        }
    }
}