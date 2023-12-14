using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula3C2023.Logica
{
    public class LnPrograma
    {
        LnConsumoAPI lnConsumoAPI;

        public LnPrograma()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Programa.Salida.VerTodosProgramas> VerTodosProgramas(Models.Programa.Entrada.VerTodosProgramas pDatos, string token)
        {
            string encabezado = "Programa/VerTodosPrograma";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Programa.Salida.VerTodosProgramas>(respuesta);
        }


        public async Task<Models.Programa.Salida.VerDetallePrograma> VerDetallePrograma(Models.Programa.Entrada.VerDetallePrograma pDatos, string token)
        {
            string encabezado = "Programa/VerDetallePrograma";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Programa.Salida.VerDetallePrograma>(respuesta);
        }

        public async Task<Models.Programa.Salida.AgregarPrograma> AgregarPrograma(Models.Programa.Entrada.AgregarPrograma pDatos, string token)
        {
            string encabezado = "Programa/AgregarPrograma";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Programa.Salida.AgregarPrograma>(respuesta);
        }

        public async Task<Models.Programa.Salida.EditarPrograma> EditarPrograma(Models.Programa.Entrada.EditarPrograma pDatos, string token)
        {
            string encabezado = "Programa/EditarPrograma";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Programa.Salida.EditarPrograma>(respuesta);
        }

        public async Task<Models.Programa.Salida.EliminarPrograma> EliminarPrograma(Models.Programa.Entrada.EliminarPrograma pDatos, string token)
        {
            string encabezado = "Programa/EliminarPrograma";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Programa.Salida.EliminarPrograma>(respuesta);
        }
    }
}
