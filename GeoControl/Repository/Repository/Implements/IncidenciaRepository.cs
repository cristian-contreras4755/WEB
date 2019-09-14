using Common;
using Dapper;
using Model.Incidencia;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements
{
    public class IncidenciaRepository : IIncidenciaRepository
    {
        private readonly IConexion _Iconexion;
        public IncidenciaRepository(IConexion conexion)
        {
            _Iconexion = conexion;
        }

        #region Incidencia
        public async   Task<CommonResult<Incidencia>> Incidencia_CreaMdf(Incidencia incidenciaModel)
        {
            CommonResult<Incidencia> _commonResult = new CommonResult<Incidencia>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdIncidencia", incidenciaModel.IdIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@CodCliente", incidenciaModel.CodCliente, dbType: DbType.String, direction: ParameterDirection.Input, size: 10);
                    Parameters.Add("@IdSucursal", incidenciaModel.IdSucursal, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IdTipoIncidencia", incidenciaModel.IdTipoIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IdEstIncidencia", incidenciaModel.IdEstIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IdMedSol", incidenciaModel.IdMedSol, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IdNivel", incidenciaModel.IdNivel, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@Resumen", incidenciaModel.Resumen, dbType: DbType.String, direction: ParameterDirection.Input, size: 2500);
                    Parameters.Add("@Descrip", incidenciaModel.Descrip, dbType: DbType.String, direction: ParameterDirection.Input, size: 2500);
                    Parameters.Add("@DescripTec", incidenciaModel.DescripTec, dbType: DbType.String, direction: ParameterDirection.Input, size: 2500);
                    Parameters.Add("@DescripCancel", incidenciaModel.DescripCancel, dbType: DbType.String, direction: ParameterDirection.Input, size: 2500);
                    Parameters.Add("@NombreContacto", incidenciaModel.NombreContacto, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
                    Parameters.Add("@IdUsuReg", incidenciaModel.IdUsuReg, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IB_Geo", incidenciaModel.IB_Geo, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    Parameters.Add("@Lng", incidenciaModel.Lng, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@Lat", incidenciaModel.Lat, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_Incidencia_CreaMdf", param: Parameters, commandType: CommandType.StoredProcedure);
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
        #endregion

        #region EstadoIncidencia
        public async Task<CommonResult<EstadoIncidenciaListModel>> EstadoIncidencia_Cons()
        {
            CommonResult<EstadoIncidenciaListModel> _commonResult = new CommonResult<EstadoIncidenciaListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();

                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<EstadoIncidenciaListModel> Result = await conexion.QueryAsync<EstadoIncidenciaListModel>("SP_EstadoIncidenciaCons", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_ConsUn(int? IdEstIncidencia)
        {
            CommonResult<EstadoIncidencia> _commonResult = new CommonResult<EstadoIncidencia>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdEstIncidencia", IdEstIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    EstadoIncidencia Result = await conexion.QueryFirstAsync<EstadoIncidencia>("SP_EstadoIncidenciaConsUn", param: Parameters, commandType: CommandType.StoredProcedure);

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

        public async Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_CreaMdf(EstadoIncidencia estadoIncidenciaModel)
        {
            CommonResult<EstadoIncidencia> _commonResult = new CommonResult<EstadoIncidencia>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdEstIncidencia", estadoIncidenciaModel.IdEstIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@Descripcion", estadoIncidenciaModel.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input, size: 2500);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                    var Result = await conexion.ExecuteScalarAsync("SP_EstadoIncidencia_CreaMdf", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_Elim(int? IdEstIncidencia)
        {
            CommonResult<EstadoIncidencia> _commonResult = new CommonResult<EstadoIncidencia>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdEstIncidencia", IdEstIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_EstadoIncidenciaElim", param: Parameters, commandType: CommandType.StoredProcedure);
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

        #endregion

        #region TipoIncindencia
        public async Task<CommonResult<TipoIncindenciaListModel>> TipoIncindencia_Cons()
        {

            CommonResult<TipoIncindenciaListModel> _commonResult = new CommonResult<TipoIncindenciaListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();

                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<TipoIncindenciaListModel> Result = await conexion.QueryAsync<TipoIncindenciaListModel>("SP_TipoIncindenciaCons", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<CommonResult<TipoIncindencia>> TipoIncindencia_ConsUn(int? IdTipoIncidencia)
        {
            CommonResult<TipoIncindencia> _commonResult = new CommonResult<TipoIncindencia>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdTipoIncidencia", IdTipoIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    TipoIncindencia Result = await conexion.QueryFirstAsync<TipoIncindencia>("SP_TipoIncindenciaConsUn", param: Parameters, commandType: CommandType.StoredProcedure);

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

        public async Task<CommonResult<TipoIncindencia>> TipoIncindencia_CreaMdf(TipoIncindencia tipoIncindenciaModel)
        {
            CommonResult<TipoIncindencia> _commonResult = new CommonResult<TipoIncindencia>();
            try
            {
       
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdTipoIncidencia", tipoIncindenciaModel.IdTipoIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@Descripcion", tipoIncindenciaModel.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input, size: 2500);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                    var Result = await conexion.ExecuteScalarAsync("SP_TipoIncindencia_CreaMdf", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<CommonResult<TipoIncindencia>> TipoIncindencia_Elim(int? IdTipoIncidencia)
        {

            CommonResult<TipoIncindencia> _commonResult = new CommonResult<TipoIncindencia>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdTipoIncidencia", IdTipoIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_TipoIncindenciaElim", param: Parameters, commandType: CommandType.StoredProcedure);
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

        #endregion

        #region Nivel
        public async Task<CommonResult<NivelListModel>> Nivel_Cons()
        {
              CommonResult<NivelListModel> _commonResult = new CommonResult<NivelListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();

                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<NivelListModel> Result = await conexion.QueryAsync<NivelListModel>("SP_NivelCons", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<CommonResult<Nivel>> Nivel_ConsUn(int? IdNivel)
        {
            CommonResult<Nivel> _commonResult = new CommonResult<Nivel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdNivel", IdNivel, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    Nivel Result = await conexion.QueryFirstAsync<Nivel>("SP_NivelConsUn", param: Parameters, commandType: CommandType.StoredProcedure);

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

        public async Task<CommonResult<Nivel>> Nivel_CreaMdf(Nivel nivelModel)
        {
            CommonResult<Nivel> _commonResult = new CommonResult<Nivel>();
            try
            {

                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdNivel", nivelModel.IdNivel, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@Descrip", nivelModel.Descrip, dbType: DbType.String, direction: ParameterDirection.Input, size: 2500);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                    var Result = await conexion.ExecuteScalarAsync("SP_Nivel_CreaMdf", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<CommonResult<Nivel>> Nivel_Elim(int? IdNivel)
        {
            CommonResult<Nivel> _commonResult = new CommonResult<Nivel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdNivel", IdNivel, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_NivelElim", param: Parameters, commandType: CommandType.StoredProcedure);
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


        #endregion

        #region MedioSolicitud
        public async Task<CommonResult<MedioSolicitudListModel>> MedioSolicitud_Cons()
        {
            CommonResult<MedioSolicitudListModel> _commonResult = new CommonResult<MedioSolicitudListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();

                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    IEnumerable<MedioSolicitudListModel> Result = await conexion.QueryAsync<MedioSolicitudListModel>("SP_MedioSolicitudCons", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<CommonResult<MedioSolicitud>> MedioSolicitud_ConsUn(int? IdMedSol)
        {
            CommonResult<MedioSolicitud> _commonResult = new CommonResult<MedioSolicitud>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdMedSol", IdMedSol, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    MedioSolicitud Result = await conexion.QueryFirstAsync<MedioSolicitud>("SP_MedioSolicitudConsUn", param: Parameters, commandType: CommandType.StoredProcedure);

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

        public async Task<CommonResult<MedioSolicitud>> MedioSolicitud_CreaMdf(MedioSolicitud medioSolicitudModel)
        {
            CommonResult<MedioSolicitud> _commonResult = new CommonResult<MedioSolicitud>();
            try
            {

                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdMedSol", medioSolicitudModel.IdMedSol, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@Descripcion", medioSolicitudModel.Descripcion, dbType: DbType.String, direction: ParameterDirection.Input, size: 2500);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                    var Result = await conexion.ExecuteScalarAsync("SP_MedioSolicitud_CreaMdf", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public async Task<CommonResult<MedioSolicitud>> MedioSolicitud_Elim(int? IdMedSol)
        {
            CommonResult<MedioSolicitud> _commonResult = new CommonResult<MedioSolicitud>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdMedSol", IdMedSol, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_MedioSolicitudElim", param: Parameters, commandType: CommandType.StoredProcedure);
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


        #endregion
  

        public async Task<CommonResult<IncidenciaListModel>> Incidencia_xEstado_Cons(int IdEstIncidencia)
        {
            CommonResult<IncidenciaListModel> _commonResult = new CommonResult<IncidenciaListModel>();
            try
            {
                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();

                   Parameters.Add("@IdEstIncidencia", IdEstIncidencia, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.QueryAsync<IncidenciaListModel>("SP_Incidencia_xEstado_Cons", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public Task<CommonResult<Incidencia>> Incidencia_Crea_Service(Incidencia incidenciaModel)
        {
            throw new NotImplementedException();
        }




        #region Asignacion

        public async Task<CommonResult<AsignacionModel>> Asignacion_Crea(AsignacionModel asignacion)
        {

            CommonResult<AsignacionModel> _commonResult = new CommonResult<AsignacionModel>();
            try
            {

                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdPersona", asignacion.IdPersona, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IdIncidencia", asignacion.IdIncidencia, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IdUsuReg", asignacion.IdUsuReg, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    Parameters.Add("@IB_principal", asignacion.IB_principal, dbType: DbType.Boolean, direction: ParameterDirection.Input);
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_Asignacion_crea", param: Parameters, commandType: CommandType.StoredProcedure);
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

        public  async Task<CommonResult<AsignacionModel>> Asignacion_Elim(AsignacionModel asignacion)
        {
            CommonResult<AsignacionModel> _commonResult = new CommonResult<AsignacionModel>();
            try
            {

                using (IDbConnection conexion = new SqlConnection(_Iconexion.GetConexion()))
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@IdAsignacion", asignacion.IdAsignacion, dbType: DbType.Int32, direction: ParameterDirection.Input);               
                    Parameters.Add("@msj", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                    var Result = await conexion.ExecuteScalarAsync("SP_Asignacion_Elim", param: Parameters, commandType: CommandType.StoredProcedure);
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

        #endregion

    }
}
