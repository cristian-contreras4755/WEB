using Common;
using Dapper;
using Model.Cliente;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements
{
  public  class ClienteRepository:IClienteRepository
    {
        private readonly IConexion _Iconexion;
        public ClienteRepository(IConexion conexion)
        {
            _Iconexion = conexion;
        }
        public async  Task<CommonResult<ClienteModel>> Cliente_Crea(ClienteModel clienteModel)
        {
            CommonResult<ClienteModel> _commonResult = new CommonResult<ClienteModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@CodCliente", clienteModel.CodCliente, dbType: DbType.String, direction: ParameterDirection.Input, size: 10);
                    Parameters.Add("@IdGrCorp", clienteModel.IdGrCorp, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@Cd_TDI", clienteModel.Cd_TDI, dbType: DbType.String, direction: ParameterDirection.Input, size: 02);
                    Parameters.Add("@RucE", clienteModel.RucE, dbType: DbType.String, direction: ParameterDirection.Input, size: 11);
                    Parameters.Add("@RSocial", clienteModel.RSocial, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@NomComercial", clienteModel.NomComercial, dbType: DbType.String, direction: ParameterDirection.Input, size: 200);
                    Parameters.Add("@NomInterno", clienteModel.NomInterno, dbType: DbType.String, direction: ParameterDirection.Input, size: 200);
                    Parameters.Add("@Nombres", clienteModel.Nombres, dbType: DbType.String, direction: ParameterDirection.Input, size: 200);
                    Parameters.Add("@ApPaterno", clienteModel.ApPaterno, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@ApMaterno", clienteModel.ApMaterno, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@Direccion", clienteModel.Direccion, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@Direccion2", clienteModel.Direccion2, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@IB_Geolocalizacion", clienteModel.IB_Geolocalizacion, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    Parameters.Add("@Lng", clienteModel.Lng, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@Lat", clienteModel.Lat, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@UsuReg", clienteModel.UsuReg, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@Telef", clienteModel.Telef, dbType: DbType.String, direction: ParameterDirection.Input, size: 15);
                    Parameters.Add("@Color", clienteModel.Color, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@Telef", clienteModel.Telef, dbType: DbType.String, direction: ParameterDirection.Input, size: 15);
                    Parameters.Add("@TipoCliente", clienteModel.TipoCliente, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    
                    var Result = await conexion.ExecuteScalarAsync("SP_Cliente_CreaMdf", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            { 
                _commonResult.Exito = false;
                _commonResult.MsjDB = "";
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async  Task<CommonResult<ClienteModel>> Cliente_Elim(string CodCliente)
        {
            CommonResult<ClienteModel> _commonResult = new CommonResult<ClienteModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@CodCliente",CodCliente, dbType: DbType.String, direction: ParameterDirection.Input, size: 10);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_ClienteElim", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = ex.Message;
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async Task<CommonResult<GrupoCorpListModel>> GrupoCorporativo_Cons()
        {
            CommonResult<GrupoCorpListModel> _commonResult = new CommonResult<GrupoCorpListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();


                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<GrupoCorpListModel> Result = await conexion.QueryAsync<GrupoCorpListModel>("SP_GrupoCorpCons", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        _commonResult.Lista = Result.AsList();
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = "";
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async Task<CommonResult<TipDocIdnListModel>> TipoDocIdn_Cons()
        {
            CommonResult<TipDocIdnListModel> _commonResult = new CommonResult<TipDocIdnListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();


                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<TipDocIdnListModel> Result = await conexion.QueryAsync<TipDocIdnListModel>("SP_TipDocIdnCons", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        _commonResult.Lista = Result.AsList();
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = "";
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async Task<CommonResult<ClienteListModel>> Cliente_Cons()
        {
            CommonResult<ClienteListModel> _commonResult = new CommonResult<ClienteListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();

                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<ClienteListModel> Result = await conexion.QueryAsync<ClienteListModel>("SP_ClienteCons", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        _commonResult.Lista =Result.AsList();
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = "";
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async Task<CommonResult<ClienteModel>> Cliente_ConsUn(string CodCliente)
        {
            CommonResult<ClienteModel> _commonResult = new CommonResult<ClienteModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@CodCliente",CodCliente, dbType: DbType.String, direction: ParameterDirection.Input, size: 10);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                   ClienteModel Result = await conexion.QueryFirstAsync<ClienteModel>("SP_ClienteConsUn", param: Parameters, commandType: CommandType.StoredProcedure);

                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        _commonResult.Entidad = Result;
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = "";
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }




        public async Task<CommonResult<SucursalModel>> Sucursal_Crea(SucursalModel sucursalModel)
        {
            CommonResult<SucursalModel> _commonResult = new CommonResult<SucursalModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdSucursal", sucursalModel.IdSucursal, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@CodCliente", sucursalModel.CodCliente, dbType: DbType.String, direction: ParameterDirection.Input, size: 10);
                    Parameters.Add("@NombreInterno", sucursalModel.NombreInterno, dbType: DbType.String, direction: ParameterDirection.Input, size: 200);
                    Parameters.Add("@Direccion", sucursalModel.Direccion, dbType: DbType.String, direction: ParameterDirection.Input, size: 200);
                    Parameters.Add("@Telefono", sucursalModel.Telefono, dbType: DbType.String, direction: ParameterDirection.Input, size: 15);
                    Parameters.Add("@Telefono2", sucursalModel.Telefono2, dbType: DbType.String, direction: ParameterDirection.Input, size: 15);
                    Parameters.Add("@Correo", sucursalModel.Correo, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@IB_Geolocalizacion", sucursalModel.IB_Geolocalizacion, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    Parameters.Add("@Lng", sucursalModel.Lng, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@Lat", sucursalModel.Lat, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@UsuReg", sucursalModel.UsuReg, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@IB_EsPrinc", sucursalModel.IB_EsPrinc, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_Sucursal_CreaMdf", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = ex.Message;
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async Task<CommonResult<SucursalModel>> Sucursal_ConsUn(int IdSucursal)
        {
            CommonResult<SucursalModel> _commonResult = new CommonResult<SucursalModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdSucursal", IdSucursal, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    SucursalModel Result = await conexion.QueryFirstAsync<SucursalModel>("SP_SucursalConsUn", param: Parameters, commandType: CommandType.StoredProcedure);

                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        _commonResult.Entidad = Result;
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = "";
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async Task<CommonResult<SucursalModel>> Sucursal_Elim(int IdSucursal)
        {
            CommonResult<SucursalModel> _commonResult = new CommonResult<SucursalModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdSucursal", IdSucursal, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_SucursalElim", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = ex.Message;
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async Task<CommonResult<SucursalListModel>> Sucursal_Cons()
        {
            CommonResult<SucursalListModel> _commonResult = new CommonResult<SucursalListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();

                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<SucursalListModel> Result = await conexion.QueryAsync<SucursalListModel>("SP_SucursalCons", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        _commonResult.Lista = Result.AsList();
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = "";
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }
        public async Task<CommonResult<SucursalxcodcliListModel>> Sucursal_XCodClienteCons( string CodCliente)
        {
            CommonResult<SucursalxcodcliListModel> _commonResult = new CommonResult<SucursalxcodcliListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@CodCliente", CodCliente, dbType: DbType.String, direction: ParameterDirection.Input, size: 10);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<SucursalxcodcliListModel> Result = await conexion.QueryAsync<SucursalxcodcliListModel>("SP_Sucursal_XCodClienteCons", param: Parameters, commandType: CommandType.StoredProcedure);
                    string PCmsj = Parameters.Get<string>("@msj");
                    if (String.IsNullOrEmpty(PCmsj))
                    {
                        _commonResult.Exito = true;
                        _commonResult.Lista = Result.AsList();
                        return _commonResult;
                    }
                    else
                    {
                        _commonResult.Exito = false;
                        _commonResult.MsjDB = PCmsj;
                        _commonResult.MsjError = "";
                        return _commonResult;
                    }
                }

            }
            catch (Exception ex)
            {
                _commonResult.Exito = false;
                _commonResult.MsjDB = "";
                _commonResult.MsjError = ex.Message;
                return _commonResult;

            }
        }


    }
}
