using Common;
using Dapper;
using Model.Seguridad;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements
{
  public  class SeguridadRepository : ISeguridadRepository
    {
        private readonly IConexion _Iconexion;
        public SeguridadRepository(IConexion conexion)
        {
            _Iconexion = conexion;
        }      
   
        #region Persona
        public async Task<CommonResult<Persona>> Persona_CreaMdf(Persona personaModel)
        {

            CommonResult<Persona> _commonResult = new CommonResult<Persona>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdPersona", personaModel.IdPersona, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IdTipPersona", personaModel.IdTipPersona, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IdSucursal", personaModel.IdSucursal, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@CodCliente", personaModel.CodCliente, dbType: DbType.String, direction: ParameterDirection.Input,size:10);
                    Parameters.Add("@Nombres", personaModel.Nombres, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@ApPat", personaModel.ApPat, dbType: DbType.String, direction: ParameterDirection.Input , size: 100);
                    Parameters.Add("@ApMat", personaModel.ApMat, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@Cd_TDI", personaModel.Cd_TDI, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@NroDoc", personaModel.NroDoc, dbType: DbType.String, direction: ParameterDirection.Input, size: 15);
                    Parameters.Add("@Tlf_pesonal", personaModel.Tlf_pesonal, dbType: DbType.String, direction: ParameterDirection.Input, size: 15);
                    Parameters.Add("@Tlf_corporativo", personaModel.Tlf_pesonal, dbType: DbType.String, direction: ParameterDirection.Input, size: 15);
                    Parameters.Add("@CorreoPersonal", personaModel.CorreoPersonal, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@CorreoCorporativo", personaModel.CorreoCorporativo, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@Direccion", personaModel.Direccion, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@IdUsuReg", personaModel.IdUsuReg, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@img", personaModel.img, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);            
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_Persona_CreaMdf", param: Parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<CommonResult<Persona>> Persona_Elim(int IdPersona)
        {
            CommonResult<Persona> _commonResult = new CommonResult<Persona>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {

                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdPersona", IdPersona, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_PersonaElim", param: Parameters, commandType: CommandType.StoredProcedure);
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
        public async Task<CommonResult<Persona>> Persona_ConsUn(int IdPersona)
        {
            CommonResult<Persona> _commonResult = new CommonResult<Persona>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdPersona", IdPersona, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    Persona Result = await conexion.QueryFirstAsync<Persona>("SP_PersonaConsUn", param: Parameters, commandType: CommandType.StoredProcedure);

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

        #endregion


    }
}
