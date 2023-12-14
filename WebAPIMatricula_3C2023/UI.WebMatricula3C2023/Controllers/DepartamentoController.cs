using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2023.Logica;

namespace UI.WebMatricula3C2023.Controllers
{
    public class DepartamentoController : Controller
    {
        LnDepartamento lnDepartamento = new LnDepartamento();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Departamento.Entrada.VerTodosDepartamentos parametros =
                new Models.Departamento.Entrada.VerTodosDepartamentos();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaDepartamentos = await lnDepartamento.VerTodosDepartamentos(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaDepartamentos.ListaDepartamentos.GroupBy(e => e.AulaAtencion)
                .Select(group => new {
                    AulaAtencion = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.AulaAtencion))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.AulaAtencion.ToString());
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaDepartamentos.ListaDepartamentos);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarDepartamento(Models.Departamento.Entrada.AgregarDepartamento agregarDepartamento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnDepartamento.AgregarDepartamento(agregarDepartamento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Departamento: {0} ha sido ingresado con éxito.", agregarDepartamento.Nombre));
            else
                return Json(String.Format("El Departamento: {0} no fue ingresado.", agregarDepartamento.Nombre));
        }

        [HttpPost]
        public async Task<JsonResult> EditarDepartamento(Models.Departamento.Entrada.EditarDepartamento editarDepartamento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnDepartamento.EditarDepartamento(editarDepartamento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Departamento: {0} ha sido modificado con éxito.", editarDepartamento.Nombre));
            else
                return Json(String.Format("El Departamento: {0} no fue modificado.", editarDepartamento.Nombre));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarDepartamento(Models.Departamento.Entrada.EliminarDepartamento eliminarDepartamento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnDepartamento.EliminarDepartamento(eliminarDepartamento, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El Departamento: {0} ha sido eliminado con éxito.", eliminarDepartamento.Codigo));
            else
                return Json(String.Format("El Departamento: {0} no fue eliminado.", eliminarDepartamento.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleDepartamento(Models.Departamento.Entrada.VerDetalleDepartamento verDetalleDepartamento)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnDepartamento.VerDetalleDepartamento(verDetalleDepartamento, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
