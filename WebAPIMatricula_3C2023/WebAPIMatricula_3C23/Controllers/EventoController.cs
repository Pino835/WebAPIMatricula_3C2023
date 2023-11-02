using API.Bll.Evento;
using API.Bll.Evento.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_3C2023.Controllers
{
    [Route("api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class EventoController : Controller
    {
        private LnEvento oLnEvento;

        public EventoController(IAdEvento accesoAdEvento)
        {
            oLnEvento = new LnEvento(accesoAdEvento);
        }

        [HttpPost]
        [Route("AgregarEvento")]
        public IActionResult AgregarEvento([FromBody] API.Dto.Evento.Entrada.AgregarEvento pDatos)
        {
            API.Dto.Evento.Salida.AgregarEvento respuesta = new API.Dto.Evento.Salida.AgregarEvento();
            try
            {
                respuesta = oLnEvento.AgregarEvento(pDatos);
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
        [Route("VerTodosEventos")]
        public IActionResult VerTodosEventos(API.Dto.Evento.Entrada.VerTodosEventos pDatos)
        {
            API.Dto.Evento.Salida.VerTodosEventos respuesta = new API.Dto.Evento.Salida.VerTodosEventos();

            try
            {
                respuesta = oLnEvento.VerTodosEventos(pDatos);
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
        [Route("EliminarEvento")]
        public IActionResult EliminarEvento([FromBody] API.Dto.Evento.Entrada.EliminarEvento pDatos)
        {
            API.Dto.Evento.Salida.EliminarEvento respuesta = new API.Dto.Evento.Salida.EliminarEvento();

            try
            {
                respuesta = oLnEvento.EliminarEvento(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleEvento")]
        public IActionResult VerDetalleEvento([FromBody] API.Dto.Evento.Entrada.VerDetalleEvento pDatos)
        {
            API.Dto.Evento.Salida.VerDetalleEvento respuesta = new API.Dto.Evento.Salida.VerDetalleEvento();

            try
            {
                respuesta = oLnEvento.VerDetalleEvento(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarEvento")]
        public IActionResult EditarEvento([FromBody] API.Dto.Evento.Entrada.EditarEvento pDatos)
        {
            API.Dto.Evento.Salida.EditarEvento respuesta = new API.Dto.Evento.Salida.EditarEvento();

            try
            {
                respuesta = oLnEvento.EditarEvento(pDatos);
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
