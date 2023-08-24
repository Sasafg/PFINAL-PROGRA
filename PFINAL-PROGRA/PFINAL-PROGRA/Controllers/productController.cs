using System;
using PFINAL_PROGRA.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.Net;
using System.Security;

namespace PFINAL_PROGRA.Controllers
{
    public class ProductController : Controller
    {
       
        private ProycFinalEntities db = new ProycFinalEntities();



        // GET: Products

        public ActionResult Index()
        {

            var products = db.Producto.Include(p => p.Categoria);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto product = db.Producto.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }





        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        
        public ActionResult Create(Producto product)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5

        public ActionResult Edit(int id)
        {
            Producto prodcuto = db.Producto.Find(id);
            if (prodcuto == null)
            {
                return HttpNotFound();
            }

            return View(prodcuto);
        }

        // POST: prodcuto/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto prodcuto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(prodcuto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(prodcuto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        [HttpPost, ActionName("Eliminar")]
        public ActionResult ConfirmarEliminar(int id)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }

            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
