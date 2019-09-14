using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.Interfaces;
using GeoControl.Models.Incidencias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Incidencia;

namespace GeoControl.Controllers
{
    public class IncidenciaController : Controller
    {
        private int idusuario=1;
        private readonly IIncidenciaBussines _incidenciaBussines;
        public IncidenciaController(IIncidenciaBussines incidenciaBussines)
        {
            _incidenciaBussines = incidenciaBussines;
        }


        // GET: Incidencia
        public ActionResult Mantenimiento()
        {
            return View();
        }

        // GET: Incidencia
        public ActionResult Gestion()
        {
            return View();
        }



        #region Incidencia web
        [HttpPost]
        public async Task<ActionResult> Incidencia_CreaMdf([FromBody]Incidencia IncidenciaModel)
        {

            IncidenciaModel.IdUsuReg = idusuario;
            IncidenciaModel.IdEstIncidencia = 1;

            var data = await _incidenciaBussines.Incidencia_CreaMdf(IncidenciaModel);
            if (data.Exito)
            {
                if (IncidenciaModel.IdIncidencia == null)
                {
                    return Ok(new { data = "La Incidendia registrado ." });
                }
                else
                {
                    return Ok(new { data = " editado correctamente." });
                }
            }
            else
            {
                return BadRequest(  new { data= data.MsjDB }  );
            }

        }

        [HttpGet]
        public async Task<ActionResult> ListarIncidencia( int id)
        {
            var data = await _incidenciaBussines.Incidencia_xEstado_Cons(id);
            if (data.Exito)
            {
                return Ok(new { data = data.Lista });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }

        #endregion
        #region EstadoIncidencia
        [HttpPost]
        public async Task<ActionResult> EstadoIncidencia_CreaMdf([FromBody]EstadoIncidencia estadoIncidenciaModel)
        {
            var data = await _incidenciaBussines.EstadoIncidencia_CreaMdf(estadoIncidenciaModel);
            if (data.Exito)
            {
                if (estadoIncidenciaModel.IdEstIncidencia == null)
                {
                    return Ok(new { data = "El Estado Fue registrado correctamente." });
                }
                else
                {
                    return Ok(new { data = "El Estado Fue editado correctamente." });
                }
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpPost]
        public async Task<ActionResult> EstadoIncidencia_Elim(int? IdEstIncidencia)
        {
            if (IdEstIncidencia == null)
            {
                return BadRequest(new { data = "No Ingreso ningun codigo a eliminar" });
            }

            var data = await _incidenciaBussines.EstadoIncidencia_Elim(IdEstIncidencia);
            if (data.Exito)
            {
                return Ok(new { data = "El Estado fue eliminado correctamente." });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpGet]
        public async Task<ActionResult> EstadoIncidencia_ConsUn(int? IdEstIncidencia)
        {
            var data = await _incidenciaBussines.EstadoIncidencia_ConsUn(IdEstIncidencia);
            if (data.Exito)
            {
                return Ok(data.Entidad);
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }

        [HttpGet]
        public async Task<ActionResult> EstadoIncidencia_Cons()
        {
            var data = await _incidenciaBussines.EstadoIncidencia_Cons();
            if (data.Exito)
            {
                return Ok(new { data = data.Lista });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }
        #endregion
        #region TipoIncindencia
        [HttpPost]
        public async Task<ActionResult> TipoIncindencia_CreaMdf([FromBody]TipoIncindencia tipoIncindenciaModel)
        {
            var data = await _incidenciaBussines.TipoIncindencia_CreaMdf(tipoIncindenciaModel);
            if (data.Exito)
            {
                if (tipoIncindenciaModel.IdTipoIncidencia == null)
                {
                    return Ok(new { data = "Tipo incidencia Fue registrado correctamente." });
                }
                else
                {
                    return Ok(new { data = "Tipo incidencia Fue editado correctamente." });
                }
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpPost]
        public async Task<ActionResult> TipoIncindencia_Elim(int? IdTipoIncidencia)
        {
            if (IdTipoIncidencia == null)
            {
                return BadRequest(new { data = "No Ingreso ningun codigo a eliminar" });
            }

            var data = await _incidenciaBussines.TipoIncindencia_Elim(IdTipoIncidencia);
            if (data.Exito)
            {
                return Ok(new { data = "Tipo Incidencia  fue eliminado correctamente." });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpGet]
        public async Task<ActionResult> TipoIncindencia_ConsUn(int? IdTipoIncidencia)
        {
            var data = await _incidenciaBussines.TipoIncindencia_ConsUn(IdTipoIncidencia);
            if (data.Exito)
            {
                return Ok(data.Entidad);
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }

        [HttpGet]
        public async Task<ActionResult> TipoIncindencia_Cons()
        {
            var data = await _incidenciaBussines.TipoIncindencia_Cons();
            if (data.Exito)
            {
                return Ok(new { data = data.Lista });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }
        #endregion
        #region Nivel
        [HttpPost]
        public async Task<ActionResult> Nivel_CreaMdf([FromBody]Nivel nivelModel)
        {
            var data = await _incidenciaBussines.Nivel_CreaMdf(nivelModel);
            if (data.Exito)
            {
                if (nivelModel.IdNivel == null)
                {
                    return Ok(new { data = "El nivel Fue registrado correctamente." });
                }
                else
                {
                    return Ok(new { data = "El nivel Fue editado correctamente." });
                }
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpPost]
        public async Task<ActionResult> Nivel_Elim(int? IdNivel)
        {
            if (IdNivel == null)
            {
                return BadRequest(new { data = "No Ingreso ningun codigo a eliminar" });
            }

            var data = await _incidenciaBussines.Nivel_Elim(IdNivel);
            if (data.Exito)
            {
                return Ok(new { data = "El Estado fue eliminado correctamente." });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpGet]
        public async Task<ActionResult> Nivel_ConsUn(int? IdNivel)
        {
            var data = await _incidenciaBussines.Nivel_ConsUn(IdNivel);
            if (data.Exito)
            {
                return Ok(data.Entidad);
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Nivel_Cons()
        {
            var data = await _incidenciaBussines.Nivel_Cons();
            if (data.Exito)
            {
                return Ok(new { data = data.Lista });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }
        #endregion
        #region MedioSolicitud
        [HttpPost]
        public async Task<ActionResult> MedioSolicitud_CreaMdf([FromBody]MedioSolicitud medioSolicitudModel)
        {
            var data = await _incidenciaBussines.MedioSolicitud_CreaMdf(medioSolicitudModel);
            if (data.Exito)
            {
                if (medioSolicitudModel.IdMedSol == null)
                {
                    return Ok(new { data = "MedioSolicitud Fue registrado correctamente." });
                }
                else
                {
                    return Ok(new { data = "MedioSolicitud Fue editado correctamente." });
                }
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpPost]
        public async Task<ActionResult> MedioSolicitud_Elim(int? IdMedSol)
        {
            if (IdMedSol == null)
            {
                return BadRequest(new { data = "No Ingreso ningun codigo a eliminar" });
            }

            var data = await _incidenciaBussines.MedioSolicitud_Elim(IdMedSol);
            if (data.Exito)
            {
                return Ok(new { data = "El registro fue eliminado correctamente." });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpGet]
        public async Task<ActionResult> MedioSolicitud_ConsUn(int? IdMedSol)
        {
            var data = await _incidenciaBussines.MedioSolicitud_ConsUn(IdMedSol);
            if (data.Exito)
            {
                return Ok(data.Entidad);
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }

        [HttpGet]
        public async Task<ActionResult> MedioSolicitud_Cons()
        {
            var data = await _incidenciaBussines.MedioSolicitud_Cons();
            if (data.Exito)
            {
                return Ok(new { data = data.Lista });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }
        #endregion

        #region Incidencia API
        [HttpPost]
        public async Task<ActionResult> Incidencia_API([FromBody]Incidencia IncidenciaModel)
        {

            IncidenciaModel.IdUsuReg = idusuario;
            IncidenciaModel.IdEstIncidencia = 1;

            var data = await _incidenciaBussines.Incidencia_CreaMdf(IncidenciaModel);
            if (data.Exito)
            {
                if (IncidenciaModel.IdIncidencia == null)
                {
                    return Ok(new { data = "La Incidendia registrada ." });
                }
                else
                {
                    return Ok(new { data = " editado correctamente." });
                }
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }
        #endregion



        #region asignacion


        [HttpPost]
        public async Task<ActionResult> Asignacion_Crea([FromBody]AsignacionViewModel asignacionViewModel)
        {

            AsignacionModel asignacion = new AsignacionModel();
            asignacion.IdAsignacion=0;
         asignacion.IdPersona = asignacionViewModel.IdPersona;
        asignacion.IdIncidencia = asignacionViewModel.IdIncidencia;
       asignacion.IdUsuReg = idusuario;
            asignacion.IB_principal = asignacionViewModel.IB_principal;
         

            var data = await _incidenciaBussines.Asignacion_Crea(asignacion);
            if (data.Exito)
            {

                    return Ok(new { data = "Asignación registrada." });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpDelete]
        public async Task<ActionResult> Asignacion_Elim([FromBody]int IdAsignacion)
        {

            AsignacionModel asignacion = new AsignacionModel();
            asignacion.IdAsignacion = IdAsignacion;
            var data = await _incidenciaBussines.Asignacion_Elim(asignacion);
            if (data.Exito)
            {
                return Ok(new { data = "Asignación Elminada" });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }




        #endregion


    }
}