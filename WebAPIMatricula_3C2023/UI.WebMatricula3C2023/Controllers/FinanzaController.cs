using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2023.Logica;

namespace UI.WebMatricula3C2023.Controllers
{
    public class FinanzaController : Controller
    {
        LnFinanza lnFinanza = new LnFinanza();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Finanza.Entrada.VerTodosFinanzas parametros =
                new Models.Finanza.Entrada.VerTodosFinanzas();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaFinanzas = await lnFinanza.VerTodosFinanzas(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaFinanzas.ListaFinanzas.GroupBy(e => e.CodigoMatricula)
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

            return View(listaFinanzas.ListaFinanzas);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarFinanza(Models.Finanza.Entrada.AgregarFinanza agregarFinanza)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnFinanza.AgregarFinanza(agregarFinanza, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El financiamiento: {0} ha sido ingresado con éxito.", agregarFinanza.CodigoMatricula));
            else
                return Json(String.Format("El financiamiento: {0} no fue ingresado.", agregarFinanza.CodigoMatricula));
        }

        [HttpPost]
        public async Task<JsonResult> EditarFinanza(Models.Finanza.Entrada.EditarFinanza editarFinanza)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnFinanza.EditarFinanza(editarFinanza, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El financiamiento: {0} ha sido modificado con éxito.", editarFinanza.CodigoMatricula));
            else
                return Json(String.Format("El financiamiento: {0} no fue modificado.", editarFinanza.CodigoMatricula));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarFinanza(Models.Finanza.Entrada.EliminarFinanza eliminarFinanza)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnFinanza.EliminarFinanza(eliminarFinanza, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El financiamiento: {0} ha sido eliminado con éxito.", eliminarFinanza.Codigo));
            else
                return Json(String.Format("El financiamiento: {0} no fue eliminado.", eliminarFinanza.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleFinanza(Models.Finanza.Entrada.VerDetalleFinanza verDetalleFinanza)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnFinanza.VerDetalleFinanza(verDetalleFinanza, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
