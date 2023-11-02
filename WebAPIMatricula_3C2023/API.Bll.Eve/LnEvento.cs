using API.Bll.Evento.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Evento
{
    public class LnEvento
    {
        private IAdEvento adEvento;


        public LnEvento(IAdEvento accesoDatosEventos)
        {
            this.adEvento = accesoDatosEventos;
        }


        public API.Dto.Evento.Salida.VerTodosEventos VerTodosEventos(Dto.Evento.Entrada.VerTodosEventos pInformacion)
        {
            API.Dto.Evento.Salida.VerTodosEventos respuesta = new API.Dto.Evento.Salida.VerTodosEventos();


            try
            {
                respuesta = adEvento.VerTodosEventos();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }


        public Dto.Evento.Salida.VerDetalleEvento VerDetalleEvento(Dto.Evento.Entrada.VerDetalleEvento pInformacion)
        {
            API.Dto.Evento.Salida.VerDetalleEvento respuesta = new Dto.Evento.Salida.VerDetalleEvento();


            try
            {
                respuesta = adEvento.VerDetalleEvento(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }


        public API.Dto.Evento.Salida.AgregarEvento AgregarEvento(Dto.Evento.Entrada.AgregarEvento pInformacion)
        {
            API.Dto.Evento.Salida.AgregarEvento respuesta = new API.Dto.Evento.Salida.AgregarEvento();


            try
            {
                respuesta = adEvento.AgregarEvento(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }


        public Dto.Evento.Salida.EditarEvento EditarEvento(Dto.Evento.Entrada.EditarEvento pInformacion)
        {
            API.Dto.Evento.Salida.EditarEvento respuesta = new API.Dto.Evento.Salida.EditarEvento();


            try
            {
                API.Dto.Evento.Entrada.VerDetalleEvento entradaVerDetalleEvento = new API.Dto.Evento.Entrada.VerDetalleEvento();
                entradaVerDetalleEvento.Codigo = pInformacion.Codigo;
                API.Dto.Evento.Salida.VerDetalleEvento detalleTrader = adEvento.VerDetalleEvento(entradaVerDetalleEvento);


                respuesta = adEvento.EditarEvento(pInformacion);


            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }
        public Dto.Evento.Salida.EliminarEvento EliminarEvento(Dto.Evento.Entrada.EliminarEvento pInformacion)
        {
            API.Dto.Evento.Salida.EliminarEvento respuesta = new Dto.Evento.Salida.EliminarEvento();


            try
            {
                respuesta = adEvento.EliminarEvento(pInformacion);


            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }


    }
}

