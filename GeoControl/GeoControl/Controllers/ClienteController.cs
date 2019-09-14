using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.Interfaces;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Cliente;

namespace GeoControl.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteBussines _clienteBussines;
        private string Usuario="usu_prueba";
        public ClienteController(IClienteBussines clienteBussines)
        {
            _clienteBussines = clienteBussines;
        }


        #region cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cliente_Crea([FromBody]ClienteModel clienteModel)
        {
            clienteModel.UsuReg=Usuario;
            var data = await _clienteBussines.Cliente_Crea(clienteModel);
            if (data.Exito)
            {
                if ( string.IsNullOrEmpty(clienteModel.CodCliente))
                {
                    return Ok(new { data = "El Cliente Fue registrado correctamente." });
                }
                else
                {
                    return Ok(new { data = "El Cliente Fue editado correctamente." });
                }

                
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpPost]
        public async Task<ActionResult> Cliente_Elim(string CodCliente)
        {

            if ( String.IsNullOrEmpty(CodCliente))
            {
                return BadRequest(new { data = "No Ingreso ningun codigo a eliminar" });
            }

            var data = await _clienteBussines.Cliente_Elim(CodCliente);
            if (data.Exito)
            {
              return Ok(new { data = "El Cliente fue eliminado correctamente." });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpGet]
        public async Task<ActionResult> Cliente_ConsUn(string CodCliente)
        {
            var data = await _clienteBussines.Cliente_ConsUn(CodCliente);
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
        public async Task<ActionResult> ListarCliente()
        {


            var data = await _clienteBussines.Cliente_Cons();
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

     

        public ActionResult GrupoCorporativo()
        {
            return View();
        }


        public ActionResult Mantenimiento()
        {
            return View();
        }


        [HttpGet]
        public async Task<JsonResult> ListarGrupoCorporativo()
        {
            var data =await _clienteBussines.GrupoCorporativo_Cons();
            return Json(new { data = data.Lista });
        }


        [HttpGet]
        public async Task<ActionResult> CBListarGrupoCorporativo()
        {
            var data = await _clienteBussines.GrupoCorporativo_Cons();
            if (data.Exito)
            {
                return Ok(data.Lista);
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }



        [HttpGet]
        public async Task<ActionResult> ListarTipoDocIdn()
        {
            var data = await _clienteBussines.TipoDocIdn_Cons();
            if (data.Exito)
            {
                return Ok(data.Lista);
            }
            else
            {
                return BadRequest(new { data = data.MsjDB});
            }
        }


        #region Sucursal

        public ActionResult Sucursal()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Sucursal_Crea([FromBody]SucursalModel sucursalModel)
        {
            sucursalModel.UsuReg = Usuario;
            var data = await _clienteBussines.Sucursal_Crea(sucursalModel);
            if (data.Exito)
            {
                if (sucursalModel.IdSucursal==0)
                {
                    return Ok(new { data = "La sucursal fué registrado correctamente." });
                }
                else
                {
                    return Ok(new { data = "La sucursal fué editado correctamente." });
                }
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpPost]
        public async Task<ActionResult> Sucursal_Elim(int IdSucursal)
        {
            if (IdSucursal==0)
            {
                return BadRequest(new { data = "No Ingreso ningun codigo a eliminar" });
            }
            var data = await _clienteBussines.Sucursal_Elim(IdSucursal);
            if (data.Exito)
            {
                return Ok(new { data = "La sucursal fue eliminado correctamente." });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }

        }

        [HttpGet]
        public async Task<ActionResult> Sucursal_ConsUn(int IdSucursal)
        {
            var data = await _clienteBussines.Sucursal_ConsUn(IdSucursal);
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
        public async Task<ActionResult> ListarSucursal()
        {
            var data = await _clienteBussines.Sucursal_Cons();
            if (data.Exito)
            {
                return Ok(new { data = data.Lista });
            }
            else
            {
                return BadRequest(new { data = data.MsjDB });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Sucursal_xcodclienteCons(string CodCliente)
        {
            if (String.IsNullOrEmpty(CodCliente))
            {
                return BadRequest(new { data = "Ingrese codigo de cliente" });
            }

            var data = await _clienteBussines.Sucursal_XCodClienteCons(CodCliente);
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



    }
}