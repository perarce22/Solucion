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
    public class EstadoDa
    {
        private string _cadenaConexion = "";
        public EstadoDa()
        {
            _cadenaConexion = Util.Config.CadenaConexion;
        }
        
        public List<EstadoBe> Lista()
        {
            try
            {
                var estados =new List<EstadoBe>() ;
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_EstadoList", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            var p1 = reader.GetOrdinal("IdEstado");
                            var p2 = reader.GetOrdinal("Estado");
                            while (reader.Read())
                            {
                                estados.Add(new EstadoBe
                                {
                                    IdEstado = reader.GetValueInt32(p1),
                                    Estado = reader.GetValueString(p2)
                                });
                            }
                        }
                    }
                }
                return estados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
