using API.Bll.Programa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace API.Bll.Programa
{
    public class LnPrograma
    {
        private IAdPrograma adPrograma;



        public LnPrograma(IAdPrograma accesoDatosPrograma)
        {
            this.adPrograma = accesoDatosPrograma;
        }



        public API.Dto.Programa.Salida.VerTodosPrograma VerTodosPrograma(Dto.Programa.Entrada.VerTodosPrograma pInformacion)
        {
            API.Dto.Programa.Salida.VerTodosPrograma respuesta = new API.Dto.Programa.Salida.VerTodosPrograma();



            try
            {
                respuesta = adPrograma.VerTodosPrograma();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Programa.Salida.VerDetallePrograma VerDetallePrograma(Dto.Programa.Entrada.VerDetallePrograma pInformacion)
        {
            API.Dto.Programa.Salida.VerDetallePrograma respuesta = new Dto.Programa.Salida.VerDetallePrograma();



            try
            {
                respuesta = adPrograma.VerDetallePrograma(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Programa.Salida.AgregarPrograma AgregarPrograma(Dto.Programa.Entrada.AgregarPrograma pInformacion)
        {
            API.Dto.Programa.Salida.AgregarPrograma respuesta = new API.Dto.Programa.Salida.AgregarPrograma();



            try
            {
                respuesta = adPrograma.AgregarPrograma(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Programa.Salida.EditarPrograma EditarPrograma(Dto.Programa.Entrada.EditarPrograma pInformacion)
        {
            API.Dto.Programa.Salida.EditarPrograma respuesta = new API.Dto.Programa.Salida.EditarPrograma();



            try
            {
                API.Dto.Programa.Entrada.VerDetallePrograma entradaVerDetallePrograma = new API.Dto.Programa.Entrada.VerDetallePrograma();
                entradaVerDetallePrograma.Codigo = pInformacion.Codigo;
                API.Dto.Programa.Salida.VerDetallePrograma detalleTrader = adPrograma.VerDetallePrograma(entradaVerDetallePrograma);



                respuesta = adPrograma.EditarPrograma(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Programa.Salida.EliminarPrograma EliminarPrograma(Dto.Programa.Entrada.EliminarPrograma pInformacion)
        {
            API.Dto.Programa.Salida.EliminarPrograma respuesta = new Dto.Programa.Salida.EliminarPrograma();



            try
            {
                respuesta = adPrograma.EliminarPrograma(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
    }
}
