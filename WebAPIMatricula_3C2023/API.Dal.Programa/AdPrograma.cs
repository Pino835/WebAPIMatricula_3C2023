using API.Bll.Programa.Interfaces;
using API.Dal.General;
using API.Dto.Programa.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Programa
{
    public class AdPrograma : IAdPrograma
    {
        private ConexionManager manager;

        public AdPrograma(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Programa.Salida.VerTodosPrograma VerTodosPrograma()
        {
            IDbConnection oConexion = null;
            API.Dto.Programa.Salida.VerTodosPrograma resultado = new API.Dto.Programa.Salida.VerTodosPrograma();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Programa");

                DatosPrograma dato;

                while (objDr.Read())
                {
                    dato = new DatosPrograma();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.NombreCarrera = objDr["NombreCarrera"].ToString();
                    dato.Modalidad = objDr["Modalidad"].ToString();
                    dato.Idioma = objDr["Idioma"].ToString();
                    dato.CantidadCuatrimestres = Convert.ToInt32(objDr["CantidadCuatrimestres"].ToString());

                    resultado.ListaProgramas.Add(dato);
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

        public Dto.Programa.Salida.VerDetallePrograma VerDetallePrograma(Dto.Programa.Entrada.VerDetallePrograma pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Programa.Salida.VerDetallePrograma resultado = new API.Dto.Programa.Salida.VerDetallePrograma();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Programa");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreCarrera = objDr["NombreCarrera"].ToString();
                    resultado.Modalidad = objDr["Modalidad"].ToString();
                    resultado.Idioma = objDr["Idioma"].ToString();
                    resultado.CantidadCuatrimestres = Convert.ToInt32(objDr["CantidadCuatrimestres"].ToString());
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

        public Dto.Programa.Salida.EditarPrograma EditarPrograma(Dto.Programa.Entrada.EditarPrograma pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Programa.Salida.EditarPrograma resultado = new Dto.Programa.Salida.EditarPrograma();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@NombreCarrera", pInformacion.NombreCarrera));
                oComando.Parameters.Add(manager.GetParametro("@Modalidad", pInformacion.Modalidad));
                oComando.Parameters.Add(manager.GetParametro("@Idioma", pInformacion.Idioma));
                oComando.Parameters.Add(manager.GetParametro("@CantidadCuatrimestres", pInformacion.CantidadCuatrimestres));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Programa");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.NombreCarrera = objDr["NombreCarrera"].ToString();
                    resultado.Modalidad = objDr["Modalidad"].ToString();
                    resultado.Idioma = objDr["Idioma"].ToString();
                    resultado.CantidadCuatrimestres = Convert.ToInt32(objDr["CantidadCuatrimestres"].ToString());
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

        public Dto.Programa.Salida.AgregarPrograma AgregarPrograma(Dto.Programa.Entrada.AgregarPrograma pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Programa.Salida.AgregarPrograma resultado = new Dto.Programa.Salida.AgregarPrograma();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@NombreCarrera", pInformacion.NombreCarrera));
                oComando.Parameters.Add(manager.GetParametro("@Modalidad", pInformacion.Modalidad));
                oComando.Parameters.Add(manager.GetParametro("@Idioma", pInformacion.Idioma));
                oComando.Parameters.Add(manager.GetParametro("@CantidadCuatrimestres", pInformacion.CantidadCuatrimestres));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Programa");

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

        public Dto.Programa.Salida.EliminarPrograma EliminarPrograma(Dto.Programa.Entrada.EliminarPrograma pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Programa.Salida.EliminarPrograma resultado = new Dto.Programa.Salida.EliminarPrograma();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Programa");
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
