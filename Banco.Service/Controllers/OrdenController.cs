using Banco.Entidades;
using Banco.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Banco.Service.Controllers
{
    [RoutePrefix("api/ordenes")]
    public class OrdenController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<OrdenPagoBe> Get()
        {
            var listaOrdenes = new OrdenPagoBl().Lista();
            return listaOrdenes;
        }
    }
}
