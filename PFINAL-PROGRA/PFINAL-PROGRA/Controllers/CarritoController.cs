using PFINAL_PROGRA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFINAL_PROGRA.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        private ProycFinalEntities db = new ProycFinalEntities();
        [Authorize]
        public ActionResult AgregarCarrito(int id)

            {
                try
                {
                    if (Session["Carrito"] == null)
                    {
                        List<cCarrito> compras = new List<cCarrito>();
                        compras.Add(new cCarrito(db.Producto.Find(id), 1));
                        Session["Carrito"] = compras;
                    }
                    else
                    {
                        //Si ya existe la sesion solo agrega al carrito
                        List<cCarrito> compras = (List<cCarrito>)Session["Carrito"];
                        int IndexExistente = getIndex(id);// comprueba que el id del producto no este ya agregado
                        if (IndexExistente == -1)
                        {
                            compras.Add(new cCarrito(db.Producto.Find(id), 1));
                        }
                        else

                            compras[IndexExistente]._cantidad++;
                        Session["Carrito"] = compras;
                    }
                }
                catch { }
                return View();
            }
            //Funcion para comprobar que ya el articulo este en el carrito y solo aumente la cantidad del mismo
            private int getIndex(int id)
            {
                List<cCarrito> compras = (List<cCarrito>)Session["Carrito"];
                for (int i = 0; i < compras.Count; i++)
                {
                    if (compras[i]._producto.IdProducto == id)
                        return i;

                }
                return -1;
            }


            // POST: Carrito/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {
                    List<cCarrito> compras = (List<cCarrito>)Session["Carrito"];
                    compras.RemoveAt(getIndex(id));

                    return View("AgregarCarrito");
                }
                catch
                {
                    return View();
                }
            }

            public ActionResult FinalizaCompra()
            {
                List<cCarrito> compras = (List<cCarrito>)Session["Carrito"];
                if (compras != null && compras.Count > 0)
                {
                    Venta nuevaVenta = new Venta();
                    nuevaVenta.DiaVenta = DateTime.Now;
                    nuevaVenta.Subtotal = compras.Sum(x => x._producto.precio * x._cantidad);
                    nuevaVenta.Iva = nuevaVenta.Subtotal * 0.13;
                    nuevaVenta.Total = nuevaVenta.Subtotal + nuevaVenta.Iva;

                    //Listar los productos que lleva la venta 
                    nuevaVenta.ListaVenta = (from producto in compras
                                             select new ListaVenta
                                             {
                                                 ProductoId = producto._producto.IdProducto,
                                                 Cantidad = producto._cantidad,
                                                 Total = producto._cantidad * producto._producto.precio,
                                             }).ToList();
                    db.Venta.Add(nuevaVenta);
                    db.SaveChanges();
                }
                return View();
            }
        }
    }
