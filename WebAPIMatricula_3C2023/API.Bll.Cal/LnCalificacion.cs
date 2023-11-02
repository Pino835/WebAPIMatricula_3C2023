using API.Bll.Calificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Calificacion
{
    public class LnCalificacion
    {
        private IAdCalificacion adCalificacion;


        public LnCalificacion(IAdCalificacion accesoDatosCalificacion)
        {
            this.adCalificacion = accesoDatosCalificacion;
        }


        public API.Dto.Calificacion.Salida.VerTodosCalificaciones VerTodosCalificaciones(Dto.Calificacion.Entrada.VerTodosCalificaciones pInformacion)
        {
            API.Dto.Calificacion.Salida.VerTodosCalificaciones respuesta = new API.Dto.Calificacion.Salida.VerTodosCalificaciones();


            try
            {
                respuesta = adCalificacion.VerTodosCalificaciones();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }


        public Dto.Calificacion.Salida.VerDetalleCalificacion VerDetalleCalificacion(Dto.Calificacion.Entrada.VerDetalleCalificacion pInformacion)
        {
            API.Dto.Calificacion.Salida.VerDetalleCalificacion respuesta = new Dto.Calificacion.Salida.VerDetalleCalificacion();


            try
            {
                respuesta = adCalificacion.VerDetalleCalificacion(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }


        public API.Dto.Calificacion.Salida.AgregarCalificacion AgregarCalificacion(Dto.Calificacion.Entrada.AgregarCalificacion pInformacion)
        {
            API.Dto.Calificacion.Salida.AgregarCalificacion respuesta = new API.Dto.Calificacion.Salida.AgregarCalificacion();


            try
            {
                respuesta = adCalificacion.AgregarCalificacion(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }


        public Dto.Calificacion.Salida.EditarCalificacion EditarCalificacion(Dto.Calificacion.Entrada.EditarCalificacion pInformacion)
        {
            API.Dto.Calificacion.Salida.EditarCalificacion respuesta = new API.Dto.Calificacion.Salida.EditarCalificacion();


            try
            {
                API.Dto.Calificacion.Entrada.VerDetalleCalificacion entradaVerDetalleCalificacion = new API.Dto.Calificacion.Entrada.VerDetalleCalificacion();
                entradaVerDetalleCalificacion.Codigo = pInformacion.Codigo;
                API.Dto.Calificacion.Salida.VerDetalleCalificacion detalleTrader = adCalificacion.VerDetalleCalificacion(entradaVerDetalleCalificacion);


                respuesta = adCalificacion.EditarCalificacion(pInformacion);


            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }
        public Dto.Calificacion.Salida.EliminarCalificacion EliminarCalificacion(Dto.Calificacion.Entrada.EliminarCalificacion pInformacion)
        {
            API.Dto.Calificacion.Salida.EliminarCalificacion respuesta = new Dto.Calificacion.Salida.EliminarCalificacion();


            try
            {
                respuesta = adCalificacion.EliminarCalificacion(pInformacion);


            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }


            return respuesta;
        }

    }

}

