using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Banco.Entidades;
using Banco.Negocio;
namespace Banco.Web.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            var bancos = new BancoBl().Lista();
            return View(bancos);
        }

        // GET: Banco/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var banco = new BancoBe()
                    {
                        Nombre = Request.Form["Nombre"],
                        Direccion = Request.Form["Direccion"]
                    };
                    var registro = new BancoBl().Registrar(banco);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(int id)
        {
            var banco = new BancoBl().Seleccionar(id);
            if (banco == null)
                return RedirectToAction("Index");
            return View(banco);
        }

        // POST: Banco/Edit/5
        [HttpPost]
        public ActionResult Edit( FormCollection collection)
        {
            try
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var banco = new BancoBe()
                        {
                            IdBanco = int.Parse(Request.Form["IdBanco"]),
                            Nombre = Request.Form["Nombre"],
                            Direccion = Request.Form["Direccion"]
                        };
                        var registro = new BancoBl().Modificar(banco);
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

        // GET: Banco/Delete/5
        public ActionResult Delete(int id)
        {
            var banco = new BancoBl().Eliminar(id);
            return RedirectToAction("Index");
        }

        
    }
}
