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
    public class SucursalDa
    {
        private string _cadenaConexion = "";
        public SucursalDa()
        {
            _cadenaConexion = Util.Config.CadenaConexion;
        }
        public bool Registrar(SucursalBe sucursal)
        {

            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_SucursalInsert", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {
                            new SqlParameter("@IdBanco", SqlDbType.Int) {Value = (object)sucursal.IdBanco ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Nombre", SqlDbType.Int) {Value = (object)sucursal.Nombre ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Direccion", SqlDbType.VarChar) {Value = (object)sucursal.Direccion ?? DBNull.Value,Direction = ParameterDirection.Input}
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
        public bool Modificar(SucursalBe sucursal)
        {

            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_SucursalUpdate", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {

                            new SqlParameter("@IdSucursal", SqlDbType.Int) {Value = (object)sucursal.IdSucursal ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@IdBanco", SqlDbType.Int) {Value = (object)sucursal.IdBanco ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Nombre", SqlDbType.VarChar) {Value = (object)sucursal.Nombre ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Direccion", SqlDbType.VarChar) {Value = (object)sucursal.Direccion ?? DBNull.Value,Direction = ParameterDirection.Input}
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
        public bool Eliminar(int idSucursal)
        {

            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_SucursalDelete", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {

                            new SqlParameter("@IdSucursal", SqlDbType.Int) {Value = idSucursal,Direction = ParameterDirection.Input}
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
        public SucursalBe Seleccionar(int idSucursal)
        {
            try
            {
                SucursalBe sucursal = null;
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_SucursalSelect", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {
                            new SqlParameter("@IdSucursal", SqlDbType.Int) {Value = idSucursal ,Direction = ParameterDirection.Input}
                        };
                        cmd.Parameters.AddRange(parametros);
                        cn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            var pIdSucursal = reader.GetOrdinal("IdSucursal");
                            var pIdBanco = reader.GetOrdinal("IdBanco");
                            var pNombre = reader.GetOrdinal("Nombre");
                            var pNombreBanco = reader.GetOrdinal("NombreBanco");
                            var pDireccion = reader.GetOrdinal("Direccion");
                            var pFechaRegistro = reader.GetOrdinal("FechaRegistro");
                            while (reader.Read())
                            {
                                sucursal = (new SucursalBe
                                {
                                    IdSucursal = reader.GetValueInt32(pIdSucursal),
                                    IdBanco = reader.GetValueInt32(pIdBanco),
                                    Nombre = reader.GetValueString(pNombre),
                                    NombreBanco = reader.GetValueString(pNombreBanco),
                                    Direccion = reader.GetValueString(pDireccion),
                                    FechaRegistro = reader.GetDateTime(pFechaRegistro)
                                });
                            }
                        }
                    }
                }
                return sucursal;
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
                var sucursales = new List<SucursalBe>();
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_SucursalList", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            var pIdSucursal = reader.GetOrdinal("IdSucursal");
                            var pIdBanco = reader.GetOrdinal("IdBanco");
                            var pNombre = reader.GetOrdinal("Nombre");
                            var pNombreBanco = reader.GetOrdinal("NombreBanco");
                            var pDireccion = reader.GetOrdinal("Direccion");
                            var pFechaRegistro = reader.GetOrdinal("FechaRegistro");
                            while (reader.Read())
                            {
                                sucursales.Add(new SucursalBe
                                {
                                    IdSucursal = reader.GetValueInt32(pIdSucursal),
                                    IdBanco = reader.GetValueInt32(pIdBanco),
                                    Nombre = reader.GetValueString(pNombre),
                                    NombreBanco = reader.GetValueString(pNombreBanco),
                                    Direccion = reader.GetValueString(pDireccion),
                                    FechaRegistro = reader.GetDateTime(pFechaRegistro)
                                });
                            }
                        }
                    }
                }
                return sucursales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
