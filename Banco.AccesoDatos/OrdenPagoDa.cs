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
    public class OrdenPagoDa
    {
        private string _cadenaConexion = "";
        public OrdenPagoDa()
        {
            _cadenaConexion = Util.Config.CadenaConexion;
        }
        public bool Registrar(OrdenPagoBe ordenpago)
        {
            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_OrdenPagoInsert", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {
                            new SqlParameter("@IdSucursal", SqlDbType.Int) {Value = (object)ordenpago.IdSucursal ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@IdMoneda", SqlDbType.Int) {Value = (object)ordenpago.IdMoneda ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@IdEstado", SqlDbType.Int) {Value = (object)ordenpago.IdEstado ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Monto", SqlDbType.Decimal) {Value = (object)ordenpago.Monto ?? DBNull.Value,Direction = ParameterDirection.Input}
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
        public bool Modificar(OrdenPagoBe ordenpago)
        {

            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_OrdenPagoUpdate", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {

                            new SqlParameter("@IdOrden", SqlDbType.Int) {Value = (object)ordenpago.IdOrden ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@IdSucursal", SqlDbType.Int) {Value = (object)ordenpago.IdSucursal ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@IdMoneda", SqlDbType.Int) {Value = (object)ordenpago.IdMoneda ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@IdEstado", SqlDbType.Int) {Value = (object)ordenpago.IdEstado ?? DBNull.Value,Direction = ParameterDirection.Input},
                            new SqlParameter("@Monto", SqlDbType.Decimal) {Value = (object)ordenpago.Monto ?? DBNull.Value,Direction = ParameterDirection.Input}
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
        public bool Eliminar(int idOrden)
        {

            try
            {
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_OrdenPagoDelete", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {

                            new SqlParameter("@idOrden", SqlDbType.Int) {Value = idOrden,Direction = ParameterDirection.Input}
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
        public OrdenPagoBe Seleccionar(int idOrden)
        {
            try
            {
                OrdenPagoBe orden = null;
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_OrdenPagoSelect", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parametros = new[]
                        {
                            new SqlParameter("@idOrden", SqlDbType.Int) {Value = idOrden,Direction = ParameterDirection.Input}
                        };
                        cmd.Parameters.AddRange(parametros);
                        cn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            var pIdSucursal = reader.GetOrdinal("IdSucursal");
                            var pSucursal = reader.GetOrdinal("NombreSucursal");
                            var pIdBanco = reader.GetOrdinal("IdBanco");
                            var pBanco = reader.GetOrdinal("NombreBanco");
                            var pIdOrden = reader.GetOrdinal("IdOrden");
                            var pIdMoneda = reader.GetOrdinal("IdMoneda");
                            var pMoneda = reader.GetOrdinal("Moneda");
                            var pIdEstado = reader.GetOrdinal("IdEstado");
                            var pEstado = reader.GetOrdinal("Estado");
                            var pMonto = reader.GetOrdinal("Monto");
                            var pFechaRegistro = reader.GetOrdinal("FechaRegistro");
                            while (reader.Read())
                            {
                                orden = (new OrdenPagoBe
                                {
                                    IdSucursal = reader.GetValueInt32(pIdSucursal),
                                    Sucursal = reader.GetValueString(pSucursal),
                                    IdOrden = reader.GetValueInt32(pIdOrden),
                                    IdMoneda = reader.GetValueInt32(pIdMoneda),
                                    Moneda = reader.GetValueString(pMoneda ),
                                    IdEstado = reader.GetValueInt32(pIdEstado),
                                    Estado = reader.GetValueString(pEstado),
                                    IdBanco = reader.GetValueInt32(pIdBanco),
                                    Banco = reader.GetValueString(pBanco),
                                    Monto = reader.GetDecimal(pMonto),
                                    FechaRegistro = reader.GetDateTime(pFechaRegistro)
                                });
                            }
                        }
                    }
                }
                return orden;
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
                var ordenes = new List<OrdenPagoBe>();
                using (var cn = new SqlConnection(_cadenaConexion))
                {
                    using (var cmd = new SqlCommand("sproc_OrdenPagoList", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            var pIdSucursal = reader.GetOrdinal("IdSucursal");
                            var pSucursal = reader.GetOrdinal("NombreSucursal");
                            var pIdBanco = reader.GetOrdinal("IdBanco");
                            var pBanco = reader.GetOrdinal("NombreBanco");
                            var pIdOrden = reader.GetOrdinal("IdOrden");
                            var pIdMoneda = reader.GetOrdinal("IdMoneda");
                            var pMoneda = reader.GetOrdinal("Moneda");
                            var pIdEstado = reader.GetOrdinal("IdEstado");
                            var pEstado = reader.GetOrdinal("Estado");
                            var pMonto = reader.GetOrdinal("Monto");
                            var pFechaRegistro = reader.GetOrdinal("FechaRegistro");
                            while (reader.Read())
                            {
                                ordenes.Add(new OrdenPagoBe
                                {
                                    IdSucursal = reader.GetValueInt32(pIdSucursal),
                                    Sucursal = reader.GetValueString(pSucursal),
                                    IdOrden = reader.GetValueInt32(pIdOrden),
                                    IdMoneda = reader.GetValueInt32(pIdMoneda),
                                    Moneda = reader.GetValueString(pMoneda),
                                    IdEstado = reader.GetValueInt32(pIdEstado),
                                    Estado = reader.GetValueString(pEstado),
                                    IdBanco = reader.GetValueInt32(pIdBanco),
                                    Banco = reader.GetValueString(pBanco),
                                    Monto = reader.GetDecimal(pMonto),
                                    FechaRegistro = reader.GetDateTime(pFechaRegistro)
                                });
                            }
                        }
                    }
                }
                return ordenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
