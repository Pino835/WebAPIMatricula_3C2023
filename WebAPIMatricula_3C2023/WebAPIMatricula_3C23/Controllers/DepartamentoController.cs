using API.Bll.Departamento;
using API.Bll.Departamento.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIMatricula_3C2023.Controllers
{
    [Route("api/v1" + "/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class DepartamentoController : Controller
    {
        private LnDepartamento oLnDepartamento;

        public DepartamentoController(IAdDepartamento accesoAdDepartamento)
        {
            oLnDepartamento = new LnDepartamento(accesoAdDepartamento);
        }

        [HttpPost]
        [Route("AgregarDepartamento")]
        public IActionResult AgregarDepartamento([FromBody] API.Dto.Departamento.Entrada.AgregarDepartamento pDatos)
        {
            API.Dto.Departamento.Salida.AgregarDepartamento respuesta = new API.Dto.Departamento.Salida.AgregarDepartamento();
            try
            {
                respuesta = oLnDepartamento.AgregarDepartamento(pDatos);
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
        [Route("VerTodosDepartamento")]
        public IActionResult VerTodosDepartamento(API.Dto.Departamento.Entrada.VerTodosDepartamento pDatos)
        {
            API.Dto.Departamento.Salida.VerTodosDepartamento respuesta = new API.Dto.Departamento.Salida.VerTodosDepartamento();

            try
            {
                respuesta = oLnDepartamento.VerTodosDepartamento(pDatos);
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
        [Route("EliminarDepartamento")]
        public IActionResult EliminarDepartamento([FromBody] API.Dto.Departamento.Entrada.EliminarDepartamento pDatos)
        {
            API.Dto.Departamento.Salida.EliminarDepartamento respuesta = new API.Dto.Departamento.Salida.EliminarDepartamento();

            try
            {
                respuesta = oLnDepartamento.EliminarDepartamento(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }


        [HttpGet]
        [Route("VerDetalleDepartamento")]
        public IActionResult VerDetalleDepartamento([FromBody] API.Dto.Departamento.Entrada.VerDetalleDepartamento pDatos)
        {
            API.Dto.Departamento.Salida.VerDetalleDepartamento respuesta = new API.Dto.Departamento.Salida.VerDetalleDepartamento();

            try
            {
                respuesta = oLnDepartamento.VerDetalleDepartamento(pDatos);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message);
                return Ok(respuesta);
            }
        }

        [HttpPut]
        [Route("EditarDepartamento")]
        public IActionResult EditarDepartamento([FromBody] API.Dto.Departamento.Entrada.EditarDepartamento pDatos)
        {
            API.Dto.Departamento.Salida.EditarDepartamento respuesta = new API.Dto.Departamento.Salida.EditarDepartamento();

            try
            {
                respuesta = oLnDepartamento.EditarDepartamento(pDatos);
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
