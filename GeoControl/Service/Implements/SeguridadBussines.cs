using Bussines.Interfaces;
using Common;
using Model.Seguridad;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Implements
{
    public class SeguridadBussines : ISeguridadBussines
    {
        private readonly ISeguridadRepository _seguridadRepository;
        public SeguridadBussines(ISeguridadRepository  seguridadRepository)
        {
            _seguridadRepository = seguridadRepository;
        }
        #region Persona

        public Task<CommonResult<Persona>> Persona_ConsUn(int IdPersona)
        {
            return _seguridadRepository.Persona_ConsUn(IdPersona);
        }

        public Task<CommonResult<Persona>> Persona_CreaMdf(Persona personaModel)
        {
            return _seguridadRepository.Persona_CreaMdf(personaModel);
        }

        public Task<CommonResult<Persona>> Persona_Elim(int IdPersona)
        {
            return _seguridadRepository.Persona_Elim(IdPersona);
        }
        #endregion

    }
}
