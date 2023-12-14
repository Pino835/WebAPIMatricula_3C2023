using API.Bll.Departamento.Interfaces;
using API.Dal.General;
using API.Dto.Departamento.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Departamento
{
    public class AdDepartamento : IAdDepartamento
    {
        private ConexionManager manager;

        public AdDepartamento(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Departamento.Salida.VerTodosDepartamento VerTodosDepartamento()
        {
            IDbConnection oConexion = null;
            API.Dto.Departamento.Salida.VerTodosDepartamento resultado = new API.Dto.Departamento.Salida.VerTodosDepartamento();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Departamento");

                DatosDepartamento dato;

                while (objDr.Read())
                {
                    dato = new DatosDepartamento();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.Nombre = objDr["Nombre"].ToString();
                    dato.NombreDirector = objDr["NombreDirector"].ToString();
                    dato.HorarioAtencion = objDr["HorarioAtencion"].ToString();
                    dato.AulaAtencion = Convert.ToInt32(objDr["AulaAtencion"].ToString());
                    dato.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());

                    resultado.ListaDepartamentos.Add(dato);
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

        public Dto.Departamento.Salida.VerDetalleDepartamento VerDetalleDepartamento(Dto.Departamento.Entrada.VerDetalleDepartamento pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Departamento.Salida.VerDetalleDepartamento resultado = new API.Dto.Departamento.Salida.VerDetalleDepartamento();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Departamento");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.NombreDirector = objDr["NombreDirector"].ToString();
                    resultado.HorarioAtencion = objDr["HorarioAtencion"].ToString();
                    resultado.AulaAtencion = Convert.ToInt32(objDr["AulaAtencion"].ToString());
                    resultado.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());
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

        public Dto.Departamento.Salida.EditarDepartamento EditarDepartamento(Dto.Departamento.Entrada.EditarDepartamento pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Departamento.Salida.EditarDepartamento resultado = new Dto.Departamento.Salida.EditarDepartamento();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@NombreDirector", pInformacion.NombreDirector));
                oComando.Parameters.Add(manager.GetParametro("@HorarioAtencion", pInformacion.HorarioAtencion));
                oComando.Parameters.Add(manager.GetParametro("@AulaAtencion", pInformacion.AulaAtencion));
                oComando.Parameters.Add(manager.GetParametro("@CodigoProfesor", pInformacion.CodigoProfesor));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Departamento");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.Nombre = objDr["Nombre"].ToString();
                    resultado.NombreDirector = objDr["NombreDirector"].ToString();
                    resultado.HorarioAtencion = objDr["HorarioAtencion"].ToString();
                    resultado.AulaAtencion = Convert.ToInt32(objDr["AulaAtencion"].ToString());
                    resultado.CodigoProfesor = Convert.ToInt32(objDr["CodigoProfesor"].ToString());
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

        public Dto.Departamento.Salida.AgregarDepartamento AgregarDepartamento(Dto.Departamento.Entrada.AgregarDepartamento pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Departamento.Salida.AgregarDepartamento resultado = new Dto.Departamento.Salida.AgregarDepartamento();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Nombre", pInformacion.Nombre));
                oComando.Parameters.Add(manager.GetParametro("@NombreDirector", pInformacion.NombreDirector));
                oComando.Parameters.Add(manager.GetParametro("@HorarioAtencion", pInformacion.HorarioAtencion));
                oComando.Parameters.Add(manager.GetParametro("@AulaAtencion", pInformacion.AulaAtencion));
                oComando.Parameters.Add(manager.GetParametro("@CodigoProfesor", pInformacion.CodigoProfesor));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Departamento");

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

        public Dto.Departamento.Salida.EliminarDepartamento EliminarDepartamento(Dto.Departamento.Entrada.EliminarDepartamento pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Departamento.Salida.EliminarDepartamento resultado = new Dto.Departamento.Salida.EliminarDepartamento();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Departamento");
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
