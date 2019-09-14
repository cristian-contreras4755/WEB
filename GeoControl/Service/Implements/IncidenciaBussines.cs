using Bussines.Interfaces;
using Common;
using Model.Incidencia;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Implements
{
    public  class IncidenciaBussines : IIncidenciaBussines
    {
        private readonly IIncidenciaRepository _IncidenciaRepository;
        public IncidenciaBussines(IIncidenciaRepository IncidenciaRepository)
        {
            _IncidenciaRepository = IncidenciaRepository;
        }

        #region Incidencia web
        public Task<CommonResult<Incidencia>> Incidencia_CreaMdf(Incidencia incidenciaModel) {
            return _IncidenciaRepository.Incidencia_CreaMdf(incidenciaModel);
        }

        public Task<CommonResult<IncidenciaListModel>> Incidencia_xEstado_Cons(int IdEstIncidencia)
        {
            return _IncidenciaRepository.Incidencia_xEstado_Cons(IdEstIncidencia);
        }

        #endregion






        #region EstadoIncidencia
        public Task<CommonResult<EstadoIncidenciaListModel>> EstadoIncidencia_Cons()
        {
            return _IncidenciaRepository.EstadoIncidencia_Cons();
        }

        public Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_ConsUn(int? IdEstIncidencia)
        {
            return _IncidenciaRepository.EstadoIncidencia_ConsUn(IdEstIncidencia);
        }

        public Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_CreaMdf(EstadoIncidencia estadoIncidenciaModel)
        {
            return _IncidenciaRepository.EstadoIncidencia_CreaMdf(estadoIncidenciaModel);
        }

        public Task<CommonResult<EstadoIncidencia>> EstadoIncidencia_Elim(int? IdEstIncidencia)
        {
            return _IncidenciaRepository.EstadoIncidencia_Elim(IdEstIncidencia);
        }

        #endregion

        #region TipoIncindencia
        public Task<CommonResult<TipoIncindenciaListModel>> TipoIncindencia_Cons()
        {
            return _IncidenciaRepository.TipoIncindencia_Cons();
        }

        public Task<CommonResult<TipoIncindencia>> TipoIncindencia_ConsUn(int? IdTipoIncidencia)
        {
            return _IncidenciaRepository.TipoIncindencia_ConsUn(IdTipoIncidencia);
        }

        public Task<CommonResult<TipoIncindencia>> TipoIncindencia_CreaMdf(TipoIncindencia tipoIncindenciaModel)
        {
            return _IncidenciaRepository.TipoIncindencia_CreaMdf(tipoIncindenciaModel);
        }

        public Task<CommonResult<TipoIncindencia>> TipoIncindencia_Elim(int? IdTipoIncidencia)
        {
            return _IncidenciaRepository.TipoIncindencia_Elim(IdTipoIncidencia);
        }

        #endregion

        #region Nivel
        public Task<CommonResult<NivelListModel>> Nivel_Cons()
        {
            return _IncidenciaRepository.Nivel_Cons();
        }

        public Task<CommonResult<Nivel>> Nivel_ConsUn(int? IdNivel)
        {
            return _IncidenciaRepository.Nivel_ConsUn(IdNivel);
        }

        public Task<CommonResult<Nivel>> Nivel_CreaMdf(Nivel nivelModel)
        {
            return _IncidenciaRepository.Nivel_CreaMdf(nivelModel);
        }

        public Task<CommonResult<Nivel>> Nivel_Elim(int? IdNivel)
        {
            return _IncidenciaRepository.Nivel_Elim(IdNivel);
        }


        #endregion

        #region MedioSolicitud
        public Task<CommonResult<MedioSolicitudListModel>> MedioSolicitud_Cons()
        {
            return _IncidenciaRepository.MedioSolicitud_Cons();
        }

        public Task<CommonResult<MedioSolicitud>> MedioSolicitud_ConsUn(int? IdMedSol)
        {
            return _IncidenciaRepository.MedioSolicitud_ConsUn(IdMedSol);
        }

        public Task<CommonResult<MedioSolicitud>> MedioSolicitud_CreaMdf(MedioSolicitud medioSolicitudModel)
        {
            return _IncidenciaRepository.MedioSolicitud_CreaMdf(medioSolicitudModel);
        }

        public Task<CommonResult<MedioSolicitud>> MedioSolicitud_Elim(int? IdMedSol)
        {
            return _IncidenciaRepository.MedioSolicitud_Elim(IdMedSol);
        }

   


        #endregion


    }
}
