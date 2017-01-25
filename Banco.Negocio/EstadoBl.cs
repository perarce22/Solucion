using Banco.AccesoDatos;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public class EstadoBl
    {
        public List<EstadoBe> Lista()
        {
            try
            {
                var da = new EstadoDa();
                return da.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
