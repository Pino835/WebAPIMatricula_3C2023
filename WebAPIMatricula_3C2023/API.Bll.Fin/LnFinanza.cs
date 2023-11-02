using API.Bll.Finanza.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Bll.Finanza
{
    public class LnFinanza
    {
        private IAdFinanza adFinanza;



        public LnFinanza(IAdFinanza accesoDatosFinanza)
        {
            this.adFinanza = accesoDatosFinanza;
        }



        public API.Dto.Finanza.Salida.VerTodosFinanzas VerTodosFinanzas(Dto.Finanza.Entrada.VerTodosFinanzas pInformacion)
        {
            API.Dto.Finanza.Salida.VerTodosFinanzas respuesta = new API.Dto.Finanza.Salida.VerTodosFinanzas();



            try
            {
                respuesta = adFinanza.VerTodosFinanzas();
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Finanza.Salida.VerDetalleFinanza VerDetalleFinanza(Dto.Finanza.Entrada.VerDetalleFinanza pInformacion)
        {
            API.Dto.Finanza.Salida.VerDetalleFinanza respuesta = new Dto.Finanza.Salida.VerDetalleFinanza();



            try
            {
                respuesta = adFinanza.VerDetalleFinanza(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public API.Dto.Finanza.Salida.AgregarFinanza AgregarFinanza(Dto.Finanza.Entrada.AgregarFinanza pInformacion)
        {
            API.Dto.Finanza.Salida.AgregarFinanza respuesta = new API.Dto.Finanza.Salida.AgregarFinanza();



            try
            {
                respuesta = adFinanza.AgregarFinanza(pInformacion);
            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }



        public Dto.Finanza.Salida.EditarFinanza EditarFinanza(Dto.Finanza.Entrada.EditarFinanza pInformacion)
        {
            API.Dto.Finanza.Salida.EditarFinanza respuesta = new API.Dto.Finanza.Salida.EditarFinanza();



            try
            {
                API.Dto.Finanza.Entrada.VerDetalleFinanza entradaVerDetalleFinanza = new API.Dto.Finanza.Entrada.VerDetalleFinanza();
                entradaVerDetalleFinanza.Codigo = pInformacion.Codigo;
                API.Dto.Finanza.Salida.VerDetalleFinanza detalleTrader = adFinanza.VerDetalleFinanza(entradaVerDetalleFinanza);



                respuesta = adFinanza.EditarFinanza(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
        public Dto.Finanza.Salida.EliminarFinanza EliminarFinanza(Dto.Finanza.Entrada.EliminarFinanza pInformacion)
        {
            API.Dto.Finanza.Salida.EliminarFinanza respuesta = new Dto.Finanza.Salida.EliminarFinanza();



            try
            {
                respuesta = adFinanza.EliminarFinanza(pInformacion);



            }
            catch (Exception ex)
            {
                respuesta.setErrorComunicacion(ex.Message.ToString());
            }



            return respuesta;
        }
    }
}

