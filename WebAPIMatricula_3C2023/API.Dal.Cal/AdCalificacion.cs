using API.Bll.Calificacion.Interfaces;
using API.Dal.General;
using API.Dto.Calificacion.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace API.Dal.Calificacion
{
    public class AdCalificacion : IAdCalificacion
    {
        private ConexionManager manager;

        public AdCalificacion(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Calificacion.Salida.VerTodosCalificaciones VerTodosCalificaciones()
        {
            IDbConnection oConexion = null;
            API.Dto.Calificacion.Salida.VerTodosCalificaciones resultado = new API.Dto.Calificacion.Salida.VerTodosCalificaciones();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Calificacion");

                DatosCalificacion dato;

                while (objDr.Read())
                {
                    dato = new DatosCalificacion();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.NotaProyecto = Convert.ToInt32(objDr["NotaProyecto"].ToString());
                    dato.NotaTareas = Convert.ToInt32(objDr["NotaTareas"].ToString());
                    dato.NotaTrabajoCotidiano = Convert.ToInt32(objDr["NotaTrabajoCotidiano"].ToString());
                    dato.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    dato.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());
                    dato.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());

                    resultado.ListaCalificaciones.Add(dato);
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

        public Dto.Calificacion.Salida.VerDetalleCalificacion VerDetalleCalificacion(Dto.Calificacion.Entrada.VerDetalleCalificacion pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Calificacion.Salida.VerDetalleCalificacion resultado = new API.Dto.Calificacion.Salida.VerDetalleCalificacion();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Calificacion");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NotaProyecto = Convert.ToInt32(objDr["NotaProyecto"].ToString());
                    resultado.NotaTareas = Convert.ToInt32(objDr["NotaTareas"].ToString());
                    resultado.NotaTrabajoCotidiano = Convert.ToInt32(objDr["NotaTrabajoCotidiano"].ToString());
                    resultado.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    resultado.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());
                    resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());
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

        public Dto.Calificacion.Salida.EditarCalificacion EditarCalificacion(Dto.Calificacion.Entrada.EditarCalificacion pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Calificacion.Salida.EditarCalificacion resultado = new Dto.Calificacion.Salida.EditarCalificacion();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@NotaProyecto", pInformacion.NotaProyecto));
                oComando.Parameters.Add(manager.GetParametro("@NotaTareas", pInformacion.NotaTareas));
                oComando.Parameters.Add(manager.GetParametro("@NotaTrabajoCotidiano", pInformacion.NotaTrabajoCotidiano));
                oComando.Parameters.Add(manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
                oComando.Parameters.Add(manager.GetParametro("@CodigoProfesor", pInformacion.CodigoProfesor));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Calificacion");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NotaProyecto = Convert.ToInt32(objDr["NotaProyecto"].ToString());
                    resultado.NotaTareas = Convert.ToInt32(objDr["NotaTareas"].ToString());
                    resultado.NotaTrabajoCotidiano = Convert.ToInt32(objDr["NotaTrabajoCotidiano"].ToString());
                    resultado.CodigoEstudiante = Convert.ToInt32(objDr["CodigoEstudiante"].ToString());
                    resultado.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());
                    resultado.CodigoCurso = Convert.ToInt32(objDr["CodigoCurso"].ToString());

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

        public Dto.Calificacion.Salida.AgregarCalificacion AgregarCalificacion(Dto.Calificacion.Entrada.AgregarCalificacion pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Calificacion.Salida.AgregarCalificacion resultado = new Dto.Calificacion.Salida.AgregarCalificacion();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@NotaProyecto", pInformacion.NotaProyecto));
                oComando.Parameters.Add(manager.GetParametro("@NotaTareas", pInformacion.NotaTareas));
                oComando.Parameters.Add(manager.GetParametro("@NotaTrabajoCotidiano", pInformacion.NotaTrabajoCotidiano));
                oComando.Parameters.Add(manager.GetParametro("@CodigoEstudiante", pInformacion.CodigoEstudiante));
                oComando.Parameters.Add(manager.GetParametro("@CodigoProfesor", pInformacion.CodigoProfesor));
                oComando.Parameters.Add(manager.GetParametro("@CodigoCurso", pInformacion.CodigoCurso));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Calificacion");

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

        public Dto.Calificacion.Salida.EliminarCalificacion EliminarCalificacion(Dto.Calificacion.Entrada.EliminarCalificacion pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Calificacion.Salida.EliminarCalificacion resultado = new Dto.Calificacion.Salida.EliminarCalificacion();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Calificacion");
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

