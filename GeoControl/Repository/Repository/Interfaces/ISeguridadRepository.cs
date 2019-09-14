using Common;
using Model.Seguridad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISeguridadRepository
    {
        Task<CommonResult<Persona>> Persona_CreaMdf(Persona personaModel);
        Task<CommonResult<Persona>> Persona_Elim(int IdPersona);
        Task<CommonResult<Persona>> Persona_ConsUn(int IdPersona);
    }
}
