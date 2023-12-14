using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula3C2023.Logica
{
    public class LnEvento
    {
        LnConsumoAPI lnConsumoAPI;

        public LnEvento()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Evento.Salida.VerTodosEventos> VerTodosEventos(Models.Evento.Entrada.VerTodosEventos pDatos, string token)
        {
            string encabezado = "Evento/VerTodosEventos";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Evento.Salida.VerTodosEventos>(respuesta);
        }


        public async Task<Models.Evento.Salida.VerDetalleEvento> VerDetalleEvento(Models.Evento.Entrada.VerDetalleEvento pDatos, string token)
        {
            string encabezado = "Evento/VerDetalleEvento";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Evento.Salida.VerDetalleEvento>(respuesta);
        }

        public async Task<Models.Evento.Salida.AgregarEvento> AgregarEvento(Models.Evento.Entrada.AgregarEvento pDatos, string token)
        {
            string encabezado = "Evento/AgregarEvento";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Evento.Salida.AgregarEvento>(respuesta);
        }

        public async Task<Models.Evento.Salida.EditarEvento> EditarEvento(Models.Evento.Entrada.EditarEvento pDatos, string token)
        {
            string encabezado = "Evento/EditarEvento";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Evento.Salida.EditarEvento>(respuesta);
        }

        public async Task<Models.Evento.Salida.EliminarEvento> EliminarEvento(Models.Evento.Entrada.EliminarEvento pDatos, string token)
        {
            string encabezado = "Evento/EliminarEvento";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Evento.Salida.EliminarEvento>(respuesta);
        }
    }
}
