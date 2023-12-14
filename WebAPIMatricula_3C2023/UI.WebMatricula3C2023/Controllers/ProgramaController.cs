using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2023.Logica;

namespace UI.WebMatricula3C2023.Controllers
{
    public class ProgramaController : Controller
    {
        LnPrograma lnPrograma = new LnPrograma();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Programa.Entrada.VerTodosProgramas parametros =
                new Models.Programa.Entrada.VerTodosProgramas();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaProgramas = await lnPrograma.VerTodosProgramas(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaProgramas.ListaProgramas.GroupBy(e => e.CantidadCuatrimestres)
                .Select(group => new {
                    CantidadCuatrimestres = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.CantidadCuatrimestres))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.CantidadCuatrimestres.ToString());
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaProgramas.ListaProgramas);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarPrograma(Models.Programa.Entrada.AgregarPrograma agregarPrograma)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnPrograma.AgregarPrograma(agregarPrograma, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Programa: {0} ha sido ingresado con éxito.", agregarPrograma.NombreCarrera));
            else
                return Json(String.Format("El Programa: {0} no fue ingresado.", agregarPrograma.NombreCarrera));
        }

        [HttpPost]
        public async Task<JsonResult> EditarPrograma(Models.Programa.Entrada.EditarPrograma editarPrograma)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnPrograma.EditarPrograma(editarPrograma, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Programa: {0} ha sido modificado con éxito.", editarPrograma.NombreCarrera));
            else
                return Json(String.Format("El Programa: {0} no fue modificado.", editarPrograma.NombreCarrera));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarPrograma(Models.Programa.Entrada.EliminarPrograma eliminarPrograma)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnPrograma.EliminarPrograma(eliminarPrograma, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Programa: {0} ha sido eliminado con éxito.", eliminarPrograma.Codigo));
            else
                return Json(String.Format("El Programa: {0} no fue eliminado.", eliminarPrograma.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetallePrograma(Models.Programa.Entrada.VerDetallePrograma verDetallePrograma)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnPrograma.VerDetallePrograma(verDetallePrograma, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
