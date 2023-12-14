using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2023.Logica;

namespace UI.WebMatricula3C2023.Controllers
{
    public class CalificacionController : Controller
    {
        LnCalificacion lnCalificacion = new LnCalificacion();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Calificacion.Entrada.VerTodosCalificaciones parametros =
                new Models.Calificacion.Entrada.VerTodosCalificaciones();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaCalificaciones = await lnCalificacion.VerTodosCalificacions(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaCalificaciones.ListaCalificaciones.GroupBy(e => e.CodigoCurso)
                .Select(group => new {
                    Estado = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Estado))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.Estado.ToString());
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaCalificaciones.ListaCalificaciones);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarCalificacion(Models.Calificacion.Entrada.AgregarCalificacion agregarCalificacion)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCalificacion.AgregarCalificacion(agregarCalificacion, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido ingresado con éxito.", agregarCalificacion.CodigoCurso));
            else
                return Json(String.Format("El estudiante: {0} no fue ingresado.", agregarCalificacion.CodigoCurso));
        }

        [HttpPost]
        public async Task<JsonResult> EditarCalificacion(Models.Calificacion.Entrada.EditarCalificacion editarCalificacion)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCalificacion.EditarCalificacion(editarCalificacion, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido modificado con éxito.", editarCalificacion.CodigoCurso));
            else
                return Json(String.Format("El estudiante: {0} no fue modificado.", editarCalificacion.CodigoCurso));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarCalificacion(Models.Calificacion.Entrada.EliminarCalificacion eliminarCalificacion)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnCalificacion.EliminarCalificacion(eliminarCalificacion, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido eliminado con éxito.", eliminarCalificacion.Codigo));
            else
                return Json(String.Format("El estudiante: {0} no fue eliminado.", eliminarCalificacion.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleCalificacion(Models.Calificacion.Entrada.VerDetalleCalificacion verDetalleCalificacion)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnCalificacion.VerDetalleCalificacion(verDetalleCalificacion, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
