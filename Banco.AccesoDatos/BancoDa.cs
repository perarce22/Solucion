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
    public class BancoDa
    {
        private string _cadenaConexion = "";
        public BancoDa()
        {
            _cadenaConexion = Util.Config.CadenaConexion;
        }
        public bool Registrar(BancoBe banco)
        {

            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_BancoInsert", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {

                            new SqlParameter("@Nombre", SqlDbType.VarChar) {Value = (object)banco.Nombre ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Direccion", SqlDbType.VarChar) {Value = (object)banco.Direccion ?? DBNull.Value,Direction = ParameterDirection.Input}
                        };
                        cmd.Parameters.AddRange(parametros);
                        cn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
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
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_BancoUpdate", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {

                            new SqlParameter("@IdBanco", SqlDbType.Int) {Value = (object)banco.IdBanco ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Nombre", SqlDbType.VarChar) {Value = (object)banco.Nombre ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Direccion", SqlDbType.VarChar) {Value = (object)banco.Direccion ?? DBNull.Value,Direction = ParameterDirection.Input}
                        };
                        cmd.Parameters.AddRange(parametros);
                        cn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
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
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_BancoDelete", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {

                            new SqlParameter("@IdBanco", SqlDbType.Int) {Value = idBanco,Direction = ParameterDirection.Input}
                        };
                        cmd.Parameters.AddRange(parametros);
                        cn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
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
                BancoBe banco = null;
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_BancoSelect", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {
                            new SqlParameter("@IdBanco", SqlDbType.Int) {Value = idBanco ,Direction = ParameterDirection.Input}
                        };
                        cmd.Parameters.AddRange(parametros);
                        cn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            var pIdBanco = reader.GetOrdinal("IdBanco");
                            var pNombre = reader.GetOrdinal("Nombre");
                            var pDireccion = reader.GetOrdinal("Direccion");
                            var pFechaRegistro = reader.GetOrdinal("FechaRegistro");
                            while (reader.Read())
                            {
                                banco=(new BancoBe
                                {
                                    IdBanco = reader.GetValueInt32(pIdBanco),
                                    Nombre = reader.GetValueString(pNombre),
                                    Direccion = reader.GetValueString(pDireccion),
                                    FechaRegistro = reader.GetDateTime(pFechaRegistro)
                                });
                            }
                        }
                    }
                }
                return banco;
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
                var bancos =new List<BancoBe>() ;
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_BancoList", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;                        
                        cn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            var pIdBanco = reader.GetOrdinal("IdBanco");
                            var pNombre = reader.GetOrdinal("Nombre");
                            var pDireccion = reader.GetOrdinal("Direccion");
                            var pFechaRegistro = reader.GetOrdinal("FechaRegistro");
                            while (reader.Read())
                            {
                                bancos.Add(new BancoBe
                                {
                                    IdBanco = reader.GetValueInt32(pIdBanco),
                                    Nombre = reader.GetValueString(pNombre),
                                    Direccion = reader.GetValueString(pDireccion),
                                    FechaRegistro = reader.GetDateTime(pFechaRegistro)
                                });
                            }
                        }
                    }
                }
                return bancos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
