using Banco.Entidades;
using Banco.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Banco.Web.Controllers
{
    public class OrdenPagoController : Controller
    {
        // GET: OrdenPago
        public ActionResult Index()
        {
            var ordenes = new OrdenPagoBl().Lista();
            return View(ordenes);
        }

        // GET: OrdenPago/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenPago/Create
        public ActionResult Create()
        {
            var bancos = new BancoBl().Lista();
            var monedas = new MonedaBl().Lista();
            var estados = new EstadoBl().Lista();

            IEnumerable<SelectListItem> bancosList = bancos.Select(m => new SelectListItem()
            {
                Value = m.IdBanco.ToString(),
                Text = m.Nombre
            });
            IEnumerable<SelectListItem> monedasList = monedas.Select(m => new SelectListItem()
            {
                Value = m.IdMoneda.ToString(),
                Text = m.Moneda
            });
            IEnumerable<SelectListItem> estadosList = estados.Select(m => new SelectListItem()
            {
                Value = m.IdEstado.ToString(),
                Text = m.Estado
            });
            var idBanco = bancos[0].IdBanco;
            var sucursales = new SucursalBl().Lista().Where(p => p.IdBanco == idBanco).ToList();
            IEnumerable<SelectListItem> sucursalesList = sucursales.Select(m => new SelectListItem()
            {
                Value = m.IdSucursal.ToString(),
                Text = m.Nombre
            });


            var orden = new OrdenPagoBe()
            {
                IdOrden = 0,
                BancosList = bancosList,
                MonedaList = monedasList,
                EstadoList = estadosList,
                SucursalList = sucursalesList
            };
            return View(orden);
        }

        // POST: OrdenPago/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid && decimal.Parse(Request.Form["Monto"]) > 0)
                {
                    var orden = new OrdenPagoBe()
                    {
                        IdSucursal = int.Parse(Request.Form["IdSucursal"]),
                        IdBanco = int.Parse(Request.Form["IdBanco"]),
                        IdMoneda = int.Parse(Request.Form["IdMoneda"]),
                        IdEstado = int.Parse(Request.Form["IdEstado"]),
                        Monto = decimal.Parse(Request.Form["Monto"])
                    };
                    var registro = new OrdenPagoBl().Registrar(orden);
                    return RedirectToAction("Index");
                }
                else
                {
                    var idBanco = int.Parse(Request.Form["IdBanco"]);
                    var bancos = new BancoBl().Lista();
                    var monedas = new MonedaBl().Lista();
                    var estados = new EstadoBl().Lista();
                    var sucursales = new SucursalBl().Lista().Where(p => p.IdBanco == idBanco).ToList();
                    IEnumerable<SelectListItem> sucursalesList = sucursales.Select(m => new SelectListItem()
                    {
                        Value = m.IdSucursal.ToString(),
                        Text = m.Nombre
                    });

                    IEnumerable<SelectListItem> bancosList = bancos.Select(m => new SelectListItem()
                    {
                        Value = m.IdBanco.ToString(),
                        Text = m.Nombre
                    });
                    IEnumerable<SelectListItem> monedasList = monedas.Select(m => new SelectListItem()
                    {
                        Value = m.IdMoneda.ToString(),
                        Text = m.Moneda
                    });
                    IEnumerable<SelectListItem> estadosList = estados.Select(m => new SelectListItem()
                    {
                        Value = m.IdEstado.ToString(),
                        Text = m.Estado
                    });

                    var orden = new OrdenPagoBe()
                    {
                        IdOrden = 0,
                        IdBanco = idBanco,
                        BancosList = bancosList,
                        MonedaList = monedasList,
                        EstadoList = estadosList,
                        SucursalList = sucursalesList
                    };
                    return View(orden);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: OrdenPago/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var orden = new OrdenPagoBl().Seleccionar(id);
            if (orden == null)
                return RedirectToAction("Index");


            var bancos = new BancoBl().Lista();
            var monedas = new MonedaBl().Lista();
            var estados = new EstadoBl().Lista();
            var sucursales = new SucursalBl().Lista().Where(p => p.IdBanco == orden.IdBanco).ToList();
            IEnumerable<SelectListItem> sucursalesList = sucursales.Select(m => new SelectListItem()
            {
                Value = m.IdSucursal.ToString(),
                Text = m.Nombre
            });

            IEnumerable<SelectListItem> bancosList = bancos.Select(m => new SelectListItem()
            {
                Value = m.IdBanco.ToString(),
                Text = m.Nombre
            });
            IEnumerable<SelectListItem> monedasList = monedas.Select(m => new SelectListItem()
            {
                Value = m.IdMoneda.ToString(),
                Text = m.Moneda
            });
            IEnumerable<SelectListItem> estadosList = estados.Select(m => new SelectListItem()
            {
                Value = m.IdEstado.ToString(),
                Text = m.Estado
            });

            orden.BancosList = bancosList;
            orden.MonedaList = monedasList;
            orden.EstadoList = estadosList;
            orden.SucursalList = sucursalesList;

            return View(orden);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: OrdenPago/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var orden = new OrdenPagoBe()
                    {
                        IdOrden = int.Parse(Request.Form["IdOrden"]),
                        IdSucursal = int.Parse(Request.Form["IdSucursal"]),
                        IdBanco = int.Parse(Request.Form["IdBanco"]),
                        IdMoneda = int.Parse(Request.Form["IdMoneda"]),
                        IdEstado = int.Parse(Request.Form["IdEstado"]),
                        Monto = decimal.Parse(Request.Form["Monto"])
                    };
                    var registro = new OrdenPagoBl().Modificar(orden);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Delete/5
        public ActionResult Delete(int id)
        {
            var orden = new OrdenPagoBl().Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
