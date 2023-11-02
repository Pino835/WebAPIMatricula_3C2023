using API.Bll.Programa;
using API.Bll.Programa.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_3C2023.Controllers
{
    [Route("api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ProgramaController : Controller
    {
        private LnPrograma oLnPrograma;

        public ProgramaController(IAdPrograma accesoAdPrograma)
        {
            oLnPrograma = new LnPrograma(accesoAdPrograma);
        }

        [HttpPost]
        [Route("AgregarPrograma")]
        public IActionResult AgregarPrograma([FromBody] API.Dto.Programa.Entrada.AgregarPrograma pDatos)
        {
            API.Dto.Programa.Salida.AgregarPrograma respuesta = new API.Dto.Programa.Salida.AgregarPrograma();
            try
            {
                respuesta = oLnPrograma.AgregarPrograma(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, ex);
                return Ok(ex.Message);
            }
        }

        [HttpGet]
        [Route("VerTodosPrograma")]
        public IActionResult VerTodosPrograma(API.Dto.Programa.Entrada.VerTodosPrograma pDatos)
        {
            API.Dto.Programa.Salida.VerTodosPrograma respuesta = new API.Dto.Programa.Salida.VerTodosPrograma();

            try
            {
                respuesta = oLnPrograma.VerTodosPrograma(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                //return StatusCode(StatusCodes.Status500InternalServerError, ex);
                return Ok(respuesta);
            }
        }


        [HttpDelete]
        [Route("EliminarPrograma")]
        public IActionResult EliminarPrograma([FromBody] API.Dto.Programa.Entrada.EliminarPrograma pDatos)
        {
            API.Dto.Programa.Salida.EliminarPrograma respuesta = new API.Dto.Programa.Salida.EliminarPrograma();

            try
            {
                respuesta = oLnPrograma.EliminarPrograma(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpGet]
        [Route("VerDetallePrograma")]
        public IActionResult VerDetallePrograma([FromBody] API.Dto.Programa.Entrada.VerDetallePrograma pDatos)
        {
            API.Dto.Programa.Salida.VerDetallePrograma respuesta = new API.Dto.Programa.Salida.VerDetallePrograma();

            try
            {
                respuesta = oLnPrograma.VerDetallePrograma(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPut]
        [Route("EditarPrograma")]
        public IActionResult EditarPrograma([FromBody] API.Dto.Programa.Entrada.EditarPrograma pDatos)
        {
            API.Dto.Programa.Salida.EditarPrograma respuesta = new API.Dto.Programa.Salida.EditarPrograma();

            try
            {
                respuesta = oLnPrograma.EditarPrograma(pDatos);
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
