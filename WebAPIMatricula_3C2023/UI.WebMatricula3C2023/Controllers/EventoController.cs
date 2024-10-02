using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2023.Logica;

namespace UI.WebMatricula3C2023.Controllers
{
    public class EventoController : Controller
    {
        LnEvento lnEvento = new LnEvento();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Evento.Entrada.VerTodosEventos parametros =
                new Models.Evento.Entrada.VerTodosEventos();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaEventos = await lnEvento.VerTodosEventos(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaEventos.ListaEventos.GroupBy(e => e.CodigoDepartamento)
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

            return View(listaEventos.ListaEventos);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarEvento(Models.Evento.Entrada.AgregarEvento agregarEvento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEvento.AgregarEvento(agregarEvento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido ingresado con éxito.", agregarEvento.NombreEvento));
            else
                return Json(String.Format("El estudiante: {0} no fue ingresado.", agregarEvento.NombreEvento));
        }

        [HttpPost]
        public async Task<JsonResult> EditarEvento(Models.Evento.Entrada.EditarEvento editarEvento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEvento.EditarEvento(editarEvento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido modificado con éxito.", editarEvento.NombreEvento));
            else
                return Json(String.Format("El estudiante: {0} no fue modificado.", editarEvento.NombreEvento));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarEvento(Models.Evento.Entrada.EliminarEvento eliminarEvento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnEvento.EliminarEvento(eliminarEvento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El estudiante: {0} ha sido eliminado con éxito.", eliminarEvento.Codigo));
            else
                return Json(String.Format("El estudiante: {0} no fue eliminado.", eliminarEvento.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleEvento(Models.Evento.Entrada.VerDetalleEvento verDetalleEvento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnEvento.VerDetalleEvento(verDetalleEvento, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
