using Common;
using Model.Incidencia;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interfaces
{
    public interface IIncidenciaBussines
    {
        #region Incidencia
        Task<CommonResult<Incidencia>> Incidencia_CreaMdf(Incidencia incidenciaModel);
        Task<CommonResult<IncidenciaListModel>> Incidencia_xEstado_Cons(int IdEstIncidencia);
        #endregion

        #region EstadoIncidencia
        Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_CreaMdf(EstadoIncidencia estadoIncidenciaModel);
        Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_Elim(int? IdEstIncidencia);
        Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_ConsUn(int? IdEstIncidencia);
        Task<CommonResult<EstadoIncidenciaListModel>> EstadoIncidencia_Cons();
        #endregion


        #region TipoIncindencia
        Task<CommonResult<TipoIncindencia>> TipoIncindencia_CreaMdf(TipoIncindencia tipoIncindenciaModel);
        Task<CommonResult<TipoIncindencia>> TipoIncindencia_Elim(int? IdTipoIncidencia);
        Task<CommonResult<TipoIncindencia>> TipoIncindencia_ConsUn(int? IdTipoIncidencia);
        Task<CommonResult<TipoIncindenciaListModel>> TipoIncindencia_Cons();
        #endregion


        #region Nivel
        Task<CommonResult<Nivel>> Nivel_CreaMdf(Nivel nivelModel);
        Task<CommonResult<Nivel>> Nivel_Elim(int? IdNivel);
        Task<CommonResult<Nivel>> Nivel_ConsUn(int? IdNivel);
        Task<CommonResult<NivelListModel>> Nivel_Cons();
        #endregion



        #region MedioSolicitud
        Task<CommonResult<MedioSolicitud>> MedioSolicitud_CreaMdf(MedioSolicitud medioSolicitudModel);
        Task<CommonResult<MedioSolicitud>> MedioSolicitud_Elim(int? IdMedSol);
        Task<CommonResult<MedioSolicitud>> MedioSolicitud_ConsUn(int? IdMedSol);
        Task<CommonResult<MedioSolicitudListModel>> MedioSolicitud_Cons();
        #endregion



        #region Asignacion

        Task<CommonResult<AsignacionModel>> Asignacion_Crea(AsignacionModel asignacion);
        Task<CommonResult<AsignacionModel>> Asignacion_Elim(AsignacionModel asignacion);
        #endregion

    }
}
