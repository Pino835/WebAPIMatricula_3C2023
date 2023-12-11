using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace UI.WebMatricula3C2023.Logica
{
    public class LnFinanza
    {
        LnConsumoAPI lnConsumoAPI;

        public LnFinanza()
        {
            lnConsumoAPI = new LnConsumoAPI();
        }

        public async Task<Models.Finanza.Salida.VerTodosFinanzas> VerTodosFinanzas(Models.Finanza.Entrada.VerTodosFinanzas pDatos, string token)
        {
            string encabezado = "Finanza/VerTodosFinanzas";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Finanza.Salida.VerTodosFinanzas>(respuesta);
        }


        public async Task<Models.Finanza.Salida.VerDetalleFinanza> VerDetalleFinanza(Models.Finanza.Entrada.VerDetalleFinanza pDatos, string token)
        {
            string encabezado = "Finanza/VerDetalleFinanza";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Finanza.Salida.VerDetalleFinanza>(respuesta);
        }

        public async Task<Models.Finanza.Salida.AgregarFinanza> AgregarFinanza(Models.Finanza.Entrada.AgregarFinanza pDatos, string token)
        {
            string encabezado = "Finanza/AgregarFinanza";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Finanza.Salida.AgregarFinanza>(respuesta);
        }

        public async Task<Models.Finanza.Salida.EditarFinanza> EditarFinanza(Models.Finanza.Entrada.EditarFinanza pDatos, string token)
        {
            string encabezado = "Finanza/EditarFinanza";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Finanza.Salida.EditarFinanza>(respuesta);
        }

        public async Task<Models.Finanza.Salida.EliminarFinanza> EliminarFinanza(Models.Finanza.Entrada.EliminarFinanza pDatos, string token)
        {
            string encabezado = "Finanza/EliminarFinanza";
            string cuerpo = JsonConvert.SerializeObject(pDatos);

            string respuesta = await lnConsumoAPI.ConsumirAPI(encabezado, cuerpo, token);

            return JsonConvert.DeserializeObject<Models.Finanza.Salida.EliminarFinanza>(respuesta);
        }
    }
}

