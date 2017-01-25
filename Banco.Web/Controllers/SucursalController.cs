using Banco.Entidades;
using Banco.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banco.Web.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            var sucursales = new SucursalBl().Lista();
            return View(sucursales);
        }

        // GET: Sucursal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sucursal/Create
        public ActionResult Create()
        {
            var bancos = new BancoBl().Lista();
            IEnumerable<SelectListItem> bancosList = bancos.Select(m => new SelectListItem()
            {
                Value = m.IdBanco.ToString(),
                Text = m.Nombre
            }); 
            
            var sucursal = new SucursalBe()
            {
                IdBanco=0,
                BancoList = bancosList
            };
            return View(sucursal);
        }

        // POST: Sucursal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var sucursal = new SucursalBe()
                    {
                        Nombre = Request.Form["Nombre"],
                        IdBanco = int.Parse(Request.Form["IdBanco"]),
                        Direccion = Request.Form["Direccion"]
                    };
                    var registro = new SucursalBl().Registrar(sucursal);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Edit/5
        public ActionResult Edit(int id)
        {
            var bancos = new BancoBl().Lista();
            IEnumerable<SelectListItem> bancosList = bancos.Select(m => new SelectListItem()
            {
                Value = m.IdBanco.ToString(),
                Text = m.Nombre
            });

            var sucursal = new SucursalBl().Seleccionar(id);
            if (sucursal == null)
                return RedirectToAction("Index");

            sucursal.BancoList = bancosList;
            return View(sucursal);
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit( FormCollection collection)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var sucursal = new SucursalBe()
                        {
                            IdBanco = int.Parse(Request.Form["IdBanco"]),
                            IdSucursal = int.Parse(Request.Form["IdSucursal"]),
                            Nombre = Request.Form["Nombre"],
                            Direccion = Request.Form["Direccion"]
                        };
                        var registro = new SucursalBl().Modificar(sucursal);
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sucursal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
