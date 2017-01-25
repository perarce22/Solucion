using Banco.Entidades;
using Banco.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.AccesoDatos
{
    public class MonedaDa
    {
        private string _cadenaConexion = "";
        public MonedaDa()
        {
            _cadenaConexion = Util.Config.CadenaConexion;
        }
        
        public List<MonedaBe> Lista()
        {
            try
            {
                var monedas =new List<MonedaBe>() ;
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_MonedaList", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            var p1 = reader.GetOrdinal("IdMoneda");
                            var p2 = reader.GetOrdinal("Moneda");
                            while (reader.Read())
                            {
                                monedas.Add(new MonedaBe
                                {
                                    IdMoneda = reader.GetValueInt32(p1),
                                    Moneda = reader.GetValueString(p2)
                                });
                            }
                        }
                    }
                }
                return monedas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
