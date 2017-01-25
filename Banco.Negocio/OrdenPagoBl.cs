using Banco.Entidades;
using Banco.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
   public class OrdenPagoBl
    {
        public bool Registrar(OrdenPagoBe orden)
        {
            try
            {
                var da = new OrdenPagoDa();
                return da.Registrar(orden);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(OrdenPagoBe orden)
        {
            try
            {
                var da = new OrdenPagoDa();
                return da.Modificar(orden);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idOrden)
        {
            try
            {
                var da = new OrdenPagoDa();
                return da.Eliminar(idOrden);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrdenPagoBe Seleccionar(int idOrden)
        {
            try
            {
                var da = new OrdenPagoDa();
                return da.Seleccionar(idOrden);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OrdenPagoBe> Lista()
        {
            try
            {
                var da = new OrdenPagoDa();
                return da.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
