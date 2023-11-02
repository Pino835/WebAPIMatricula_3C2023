using API.Bll.Calificacion.Interfaces;
using API.Bll.Calificacion;
using API.Dal.Calificacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebAPIMatricula_3C2023.Controllers
{
    [Route("api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class CalificacionController : Controller
    {
        private LnCalificacion oLnCalificacion;

        public CalificacionController(IAdCalificacion accesoAdCalificacion)
        {
            oLnCalificacion = new LnCalificacion(accesoAdCalificacion);
        }

        [HttpPost]
        [Route("AgregarCalificacion")]
        public IActionResult AgregarCalificacion([FromBody] API.Dto.Calificacion.Entrada.AgregarCalificacion pDatos)
        {
            API.Dto.Calificacion.Salida.AgregarCalificacion respuesta = new API.Dto.Calificacion.Salida.AgregarCalificacion();
            try
            {
                respuesta = oLnCalificacion.AgregarCalificacion(pDatos);
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
        [Route("VerTodosCalificaciones")]
        public IActionResult VerTodosCalificaciones(API.Dto.Calificacion.Entrada.VerTodosCalificaciones pDatos)
        {
            API.Dto.Calificacion.Salida.VerTodosCalificaciones respuesta = new API.Dto.Calificacion.Salida.VerTodosCalificaciones();

            try
            {
                respuesta = oLnCalificacion.VerTodosCalificaciones(pDatos);
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
        [Route("EliminarCalificacion")]
        public IActionResult EliminarCalificacion([FromBody] API.Dto.Calificacion.Entrada.EliminarCalificacion pDatos)
        {
            API.Dto.Calificacion.Salida.EliminarCalificacion respuesta = new API.Dto.Calificacion.Salida.EliminarCalificacion();

            try
            {
                respuesta = oLnCalificacion.EliminarCalificacion(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpPost]
        [Route("VerDetalleCalificacion")]
        public IActionResult VerDetalleCalificacion([FromBody] API.Dto.Calificacion.Entrada.VerDetalleCalificacion pDatos)
        {
            API.Dto.Calificacion.Salida.VerDetalleCalificacion respuesta = new API.Dto.Calificacion.Salida.VerDetalleCalificacion();

            try
            {
                respuesta = oLnCalificacion.VerDetalleCalificacion(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPost]
        [Route("EditarCalificacion")]
        public IActionResult EditarCalificacion([FromBody] API.Dto.Calificacion.Entrada.EditarCalificacion pDatos)
        {
            API.Dto.Calificacion.Salida.EditarCalificacion respuesta = new API.Dto.Calificacion.Salida.EditarCalificacion();

            try
            {
                respuesta = oLnCalificacion.EditarCalificacion(pDatos);
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
