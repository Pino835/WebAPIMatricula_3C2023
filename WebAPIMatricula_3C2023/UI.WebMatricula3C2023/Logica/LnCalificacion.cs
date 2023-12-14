using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula3C2023.Logica
{
    public class LnCalificacion
    {
        LnConsumoAPI lnConsumoAPI;

        public LnCalificacion()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Calificacion.Salida.VerTodosCalificaciones> VerTodosCalificacions(Models.Calificacion.Entrada.VerTodosCalificaciones pDatos, string token)
        {
            string encabezado = "Calificacion/VerTodosCalificaciones";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Calificacion.Salida.VerTodosCalificaciones>(respuesta);
        }


        public async Task<Models.Calificacion.Salida.VerDetalleCalificacion> VerDetalleCalificacion(Models.Calificacion.Entrada.VerDetalleCalificacion pDatos, string token)
        {
            string encabezado = "Calificacion/VerDetalleCalificacion";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Calificacion.Salida.VerDetalleCalificacion>(respuesta);
        }

        public async Task<Models.Calificacion.Salida.AgregarCalificacion> AgregarCalificacion(Models.Calificacion.Entrada.AgregarCalificacion pDatos, string token)
        {
            string encabezado = "Calificacion/AgregarCalificacion";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Calificacion.Salida.AgregarCalificacion>(respuesta);
        }

        public async Task<Models.Calificacion.Salida.EditarCalificacion> EditarCalificacion(Models.Calificacion.Entrada.EditarCalificacion pDatos, string token)
        {
            string encabezado = "Calificacion/EditarCalificacion";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Calificacion.Salida.EditarCalificacion>(respuesta);
        }

        public async Task<Models.Calificacion.Salida.EliminarCalificacion> EliminarCalificacion(Models.Calificacion.Entrada.EliminarCalificacion pDatos, string token)
        {
            string encabezado = "Calificacion/EliminarCalificacion";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Calificacion.Salida.EliminarCalificacion>(respuesta);
        }
    }
}
