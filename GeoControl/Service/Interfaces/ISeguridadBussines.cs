using Common;
using Model.Seguridad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Interfaces
{
    public interface ISeguridadBussines
    {

        #region Persona    
        Task<CommonResult<Persona>> Persona_CreaMdf(Persona personaModel);
        Task<CommonResult<Persona>> Persona_Elim(int IdPersona);
        Task<CommonResult<Persona>> Persona_ConsUn(int IdPersona);

        #endregion


    }
}
