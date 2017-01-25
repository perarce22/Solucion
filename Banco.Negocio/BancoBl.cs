using Banco.AccesoDatos;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public class BancoBl
    {
        public bool Registrar(BancoBe banco)
        {
            try
            {
                var da = new BancoDa();
                return da.Registrar(banco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(BancoBe banco)
        {
            try
            {
                var da = new BancoDa();
                return da.Modificar(banco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int idBanco)
        {
            try
            {
                var da = new BancoDa();
                return da.Eliminar(idBanco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BancoBe Seleccionar(int idBanco)
        {
            try
            {
                var da = new BancoDa();
                return da.Seleccionar(idBanco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BancoBe> Lista()
        {
            try
            {
                var da = new BancoDa();
                return da.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
