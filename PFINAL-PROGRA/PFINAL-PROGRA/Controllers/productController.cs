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
       
        private ProyFinalEntities db = new ProyFinalEntities();



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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Precio,CategoriaId")] Producto product)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categoria, "Id", "Nombre", product.categoriaId);
            return View(product);
        }











        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Nombre", product.categoriaId);
            return View(product);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Precio,CategoriaId,Disponible")] Producto product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "Id", "Nombre", product.categoriaId);
            return View(product);
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
