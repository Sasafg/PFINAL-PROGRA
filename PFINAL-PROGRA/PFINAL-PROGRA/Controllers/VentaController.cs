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

        private ProycFinalEntities bd = new ProycFinalEntities();
        // GET: Venta

        public ActionResult Index()
        {
            return View(bd.Venta.ToList().OrderBy(x => x.DiaVenta));
        }

        public ActionResult Detail(int id)
        {
            return View(bd.Venta.Find(id));

        }
    }
}
