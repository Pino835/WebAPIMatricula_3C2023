using API.Bll.Evento.Interfaces;
using API.Dal.General;
using API.Dto.Evento.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Evento
{
    public class AdEvento : IAdEvento
    {
        private ConexionManager manager;

        public AdEvento(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Evento.Salida.VerTodosEventos VerTodosEventos()
        {
            IDbConnection oConexion = null;
            API.Dto.Evento.Salida.VerTodosEventos resultado = new API.Dto.Evento.Salida.VerTodosEventos();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Eventos");

                DatosEvento dato;

                while (objDr.Read())
                {
                    dato = new DatosEvento();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.NombreEvento = objDr["NombreEvento"].ToString();
                    dato.NombreInvitado = objDr["NombreInvitado"].ToString();
                    dato.Horario = Convert.ToDateTime(objDr["Horario"].ToString());
                    dato.Lugar = objDr["Lugar"].ToString();
                    dato.TipoSello = objDr["TipoSello"].ToString();
                    dato.CodigoDepartamento = Convert.ToInt32(objDr["CodigoDepartamento"].ToString());

                    resultado.ListaEventos.Add(dato);
                }
            }
            catch (Exception)
            {
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }

            return resultado;
        }

        public Dto.Evento.Salida.VerDetalleEvento VerDetalleEvento(Dto.Evento.Entrada.VerDetalleEvento pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Evento.Salida.VerDetalleEvento resultado = new API.Dto.Evento.Salida.VerDetalleEvento();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Eventos");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreEvento = objDr["NombreEvento"].ToString();
                    resultado.NombreInvitado = objDr["NombreInvitado"].ToString();
                    resultado.Horario = Convert.ToDateTime(objDr["Horario"].ToString());
                    resultado.Lugar = objDr["Lugar"].ToString();
                    resultado.TipoSello = objDr["TipoSello"].ToString();
                    resultado.CodigoDepartamento = Convert.ToInt32(objDr["CodigoDepartamento"].ToString());
                }
            }
            catch (Exception)
            {
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }

            return resultado;
        }

        public Dto.Evento.Salida.EditarEvento EditarEvento(Dto.Evento.Entrada.EditarEvento pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Evento.Salida.EditarEvento resultado = new Dto.Evento.Salida.EditarEvento();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@NombreEvento", pInformacion.NombreEvento));
                oComando.Parameters.Add(manager.GetParametro("@NombreInvitado", pInformacion.NombreInvitado));
                oComando.Parameters.Add(manager.GetParametro("@Horario", pInformacion.Horario));
                oComando.Parameters.Add(manager.GetParametro("@Lugar", pInformacion.Lugar));
                oComando.Parameters.Add(manager.GetParametro("@TipoSello", pInformacion.TipoSello));
                oComando.Parameters.Add(manager.GetParametro("@CodigoDepartamento", pInformacion.CodigoDepartamento));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Eventos");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreEvento = objDr["NombreEvento"].ToString();
                    resultado.NombreInvitado = objDr["NombreInvitado"].ToString();
                    resultado.Horario = Convert.ToDateTime(objDr["Horario"].ToString());
                    resultado.Lugar = objDr["Lugar"].ToString();
                    resultado.TipoSello = objDr["TipoSello"].ToString();
                    resultado.CodigoDepartamento = Convert.ToInt32(objDr["CodigoDepartamento"].ToString());

                }

            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }

            return resultado;
        }

        public Dto.Evento.Salida.AgregarEvento AgregarEvento(Dto.Evento.Entrada.AgregarEvento pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Evento.Salida.AgregarEvento resultado = new Dto.Evento.Salida.AgregarEvento();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@NombreEvento", pInformacion.NombreEvento));
                oComando.Parameters.Add(manager.GetParametro("@NombreInvitado", pInformacion.NombreInvitado));
                oComando.Parameters.Add(manager.GetParametro("@Horario", pInformacion.Horario));
                oComando.Parameters.Add(manager.GetParametro("@Lugar", pInformacion.Lugar));
                oComando.Parameters.Add(manager.GetParametro("@TipoSello", pInformacion.TipoSello));
                oComando.Parameters.Add(manager.GetParametro("@CodigoDepartamento", pInformacion.CodigoDepartamento));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Eventos");

                if (objDr.Read())
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());

            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }

            return resultado;
        }

        public Dto.Evento.Salida.EliminarEvento EliminarEvento(Dto.Evento.Entrada.EliminarEvento pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Evento.Salida.EliminarEvento resultado = new Dto.Evento.Salida.EliminarEvento();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Eventos");
            }
            catch (Exception ex)
            {
                resultado.DetalleRespuesta = ex.Message;
                manager.CerrarConexion(oConexion);
            }
            finally
            {
                manager.CerrarConexion(oConexion);
            }

            return resultado;
        }

    }
}

