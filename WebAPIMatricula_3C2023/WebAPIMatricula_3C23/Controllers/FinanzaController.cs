using API.Bll.Finanza;
using API.Bll.Finanza.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_3C2023.Controllers
{
    [Route("api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class FinanzaController : Controller
    {
        private LnFinanza oLnFinanza;

        public FinanzaController(IAdFinanza accesoAdFinanza)
        {
            oLnFinanza = new LnFinanza(accesoAdFinanza);
        }

        [HttpPost]
        [Route("AgregarFinanza")]
        public IActionResult AgregarFinanza([FromBody] API.Dto.Finanza.Entrada.AgregarFinanza pDatos)
        {
            API.Dto.Finanza.Salida.AgregarFinanza respuesta = new API.Dto.Finanza.Salida.AgregarFinanza();
            try
            {
                respuesta = oLnFinanza.AgregarFinanza(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, ex);
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        [Route("VerTodosFinanzas")]
        public IActionResult VerTodosFinanzas(API.Dto.Finanza.Entrada.VerTodosFinanzas pDatos)
        {
            API.Dto.Finanza.Salida.VerTodosFinanzas respuesta = new API.Dto.Finanza.Salida.VerTodosFinanzas();

            try
            {
                respuesta = oLnFinanza.VerTodosFinanzas(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, ex);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("EliminarFinanza")]
        public IActionResult EliminarFinanza([FromBody] API.Dto.Finanza.Entrada.EliminarFinanza pDatos)
        {
            API.Dto.Finanza.Salida.EliminarFinanza respuesta = new API.Dto.Finanza.Salida.EliminarFinanza();

            try
            {
                respuesta = oLnFinanza.EliminarFinanza(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleFinanza")]
        public IActionResult VerDetalleFinanza([FromBody] API.Dto.Finanza.Entrada.VerDetalleFinanza pDatos)
        {
            API.Dto.Finanza.Salida.VerDetalleFinanza respuesta = new API.Dto.Finanza.Salida.VerDetalleFinanza();

            try
            {
                respuesta = oLnFinanza.VerDetalleFinanza(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarFinanza")]
        public IActionResult EditarFinanza([FromBody] API.Dto.Finanza.Entrada.EditarFinanza pDatos)
        {
            API.Dto.Finanza.Salida.EditarFinanza respuesta = new API.Dto.Finanza.Salida.EditarFinanza();

            try
            {
                respuesta = oLnFinanza.EditarFinanza(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }
    }
}
