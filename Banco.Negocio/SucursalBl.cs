using Banco.Entidades;
using Banco.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
   public class SucursalBl
    {
        public bool Registrar(SucursalBe sucursal)
        {
            try
            {
                var da = new SucursalDa();
                return da.Registrar(sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(SucursalBe sucursal)
        {
            try
            {
                var da = new SucursalDa();
                return da.Modificar(sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idSucursal)
        {
            try
            {
                var da = new SucursalDa();
                return da.Eliminar(idSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SucursalBe Seleccionar(int idSucursal)
        {
            try
            {
                var da = new SucursalDa();
                return da.Seleccionar(idSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SucursalBe> Lista()
        {
            try
            {
                var da = new SucursalDa();
                return da.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
