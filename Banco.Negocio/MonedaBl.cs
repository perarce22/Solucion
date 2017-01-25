using Banco.AccesoDatos;
using Banco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Negocio
{
    public class MonedaBl
    {
        public List<MonedaBe> Lista()
        {
            try
            {
                var da = new MonedaDa();
                return da.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
