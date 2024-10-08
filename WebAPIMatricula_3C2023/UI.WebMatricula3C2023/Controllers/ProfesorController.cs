﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UI.WebMatricula3C2023.Logica;

namespace UI.WebMatricula3C2023.Controllers
{
    public class ProfesorController : Controller
    {
        LnProfesor lnProfesor = new LnProfesor();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Index()
        {
            Models.Profesor.Entrada.VerTodosProfesores parametros =
                new Models.Profesor.Entrada.VerTodosProfesores();

            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");

            var listaProfesores = await lnProfesor.VerTodosProfesores(parametros, usuarioActual.Token);

            ////////////////***********GRAFICOS CHART JS//////////////////////*********/
            var random = new Random();

            var etiquetas = new List<string>();
            var colores = new List<string>();
            var valores = new List<string>();

            foreach (var estado in listaProfesores.ListaProfesores.GroupBy(e => e.Estado)
                .Select(group => new {
                    Estado = group.Key,
                    Cantidad = group.Count()
                }).OrderBy(x => x.Estado))
            {
                string color = String.Format("#{0:X6}", random.Next(0x1000000));

                etiquetas.Add(estado.Estado);
                valores.Add(estado.Cantidad.ToString());
                colores.Add(color);
            }

            ViewBag.Etiquetas = JsonConvert.SerializeObject(etiquetas);
            ViewBag.Valores = JsonConvert.SerializeObject(valores);
            ViewBag.Colores = JsonConvert.SerializeObject(colores);
            ////////////////***********GRAFICOS CHART JS//////////////////////*********/

            return View(listaProfesores.ListaProfesores);
        }

        [HttpPost]
        public async Task<JsonResult> AgregarProfesor(Models.Profesor.Entrada.AgregarProfesor agregarProfesor)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnProfesor.AgregarProfesor(agregarProfesor, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El profesor: {0} ha sido ingresado con éxito.", agregarProfesor.NombreCompleto));
            else
                return Json(String.Format("El profesor: {0} no fue ingresado.", agregarProfesor.NombreCompleto));
        }

        [HttpPost]
        public async Task<JsonResult> EditarProfesor(Models.Profesor.Entrada.EditarProfesor editarProfesor)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnProfesor.EditarProfesor(editarProfesor, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El profesor: {0} ha sido modificado con éxito.", editarProfesor.NombreCompleto));
            else
                return Json(String.Format("El profesor: {0} no fue modificado.", editarProfesor.NombreCompleto));
        }

        [HttpPost]
        public async Task<JsonResult> EliminarProfesor(Models.Profesor.Entrada.EliminarProfesor eliminarProfesor)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var codigo = await lnProfesor.EliminarProfesor(eliminarProfesor, usuarioActual.Token);

            if (codigo != null)
                return Json(String.Format("El profesor: {0} ha sido eliminado con éxito.", eliminarProfesor.Codigo));
            else
                return Json(String.Format("El profesor: {0} no fue eliminado.", eliminarProfesor.Codigo));
        }

        [HttpPost]
        public async Task<JsonResult> VerDetalleProfesor(Models.Profesor.Entrada.VerDetalleProfesor verDetalleProfesor)
        {
            var usuarioActual = HttpContext.Session.GetObjectFromJson<Models.Users.User>("UsuarioActual");
            var respuesta = await lnProfesor.VerDetalleProfesor(verDetalleProfesor, usuarioActual.Token);

            return Json(respuesta);
        }


    }
}
