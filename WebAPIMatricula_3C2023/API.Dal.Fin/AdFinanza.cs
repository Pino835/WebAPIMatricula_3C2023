using API.Bll.Finanza.Interfaces;
using API.Dal.General;
using API.Dto.Finanza.Salida;
using API.Dto.General;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dal.Finanza
{
    public class AdFinanza : IAdFinanza
    {
        private ConexionManager manager;

        public AdFinanza(IOptions<AppSettings> oConfiguraciones)
        {
            manager = new ConexionManager(oConfiguraciones);
        }

        public Dto.Finanza.Salida.VerTodosFinanzas VerTodosFinanzas()
        {
            IDbConnection oConexion = null;
            API.Dto.Finanza.Salida.VerTodosFinanzas resultado = new API.Dto.Finanza.Salida.VerTodosFinanzas();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Todos_Finanzas");

                DatosFinanza dato;

                while (objDr.Read())
                {
                    dato = new DatosFinanza();
                    dato.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    dato.TotalMaterias = Convert.ToInt32(objDr["TotalMaterias"].ToString());
                    dato.CobroMatricula = (float)Convert.ToDouble(objDr["CobroMatricula"].ToString());
                    dato.CobroPoliza = (float)Convert.ToDouble(objDr["CobroPoliza"].ToString());
                    dato.CobroTechFee = (float)Convert.ToDouble(objDr["CobroTechFee"].ToString());
                    dato.CodigoMatricula = Convert.ToInt32(objDr["CodigoMatricula"].ToString());

                    resultado.ListaFinanzas.Add(dato);
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

        public Dto.Finanza.Salida.VerDetalleFinanza VerDetalleFinanza(Dto.Finanza.Entrada.VerDetalleFinanza pInformacion)
        {
            IDbConnection oConexion = null;
            API.Dto.Finanza.Salida.VerDetalleFinanza resultado = new API.Dto.Finanza.Salida.VerDetalleFinanza();

            oConexion = manager.GetConexion();
            oConexion.Open();
            IDbCommand oComando = manager.GetComando();

            try
            {
                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Ver_Detalle_Finanza");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.TotalMaterias = Convert.ToInt32(objDr["TotalMaterias"].ToString());
                    resultado.CobroMatricula = (float)Convert.ToDouble(objDr["CobroMatricula"].ToString());
                    resultado.CobroPoliza = (float)Convert.ToDouble(objDr["CobroPoliza"].ToString());
                    resultado.CobroTechFee = (float)Convert.ToDouble(objDr["CobroTechFee"].ToString());
                    resultado.CodigoMatricula = Convert.ToInt32(objDr["CodigoMatricula"].ToString());
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

        public Dto.Finanza.Salida.EditarFinanza EditarFinanza(Dto.Finanza.Entrada.EditarFinanza pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Finanza.Salida.EditarFinanza resultado = new Dto.Finanza.Salida.EditarFinanza();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));
                oComando.Parameters.Add(manager.GetParametro("@TotalMaterias", pInformacion.TotalMaterias));
                oComando.Parameters.Add(manager.GetParametro("@CobroMatricula", pInformacion.CobroMatricula));
                oComando.Parameters.Add(manager.GetParametro("@CobroPoliza", pInformacion.CobroPoliza));
                oComando.Parameters.Add(manager.GetParametro("@CobroTechFee", pInformacion.CobroTechFee));
                oComando.Parameters.Add(manager.GetParametro("@CodigoMatricula", pInformacion.CodigoMatricula));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Editar_Finanza");

                if (objDr.Read())
                {
                    resultado.Codigo = Convert.ToInt32(objDr["Codigo"].ToString());
                    resultado.TotalMaterias = Convert.ToInt32(objDr["TotalMaterias"].ToString());
                    resultado.CobroMatricula = (float)Convert.ToDouble(objDr["CobroMatricula"].ToString());
                    resultado.CobroPoliza = (float)Convert.ToDouble(objDr["CobroPoliza"].ToString());
                    resultado.CobroTechFee = (float)Convert.ToDouble(objDr["CobroTechFee"].ToString());
                    resultado.CodigoMatricula = Convert.ToInt32(objDr["CodigoMatricula"].ToString());
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

        public Dto.Finanza.Salida.AgregarFinanza AgregarFinanza(Dto.Finanza.Entrada.AgregarFinanza pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Finanza.Salida.AgregarFinanza resultado = new Dto.Finanza.Salida.AgregarFinanza();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@TotalMaterias", pInformacion.TotalMaterias));
                oComando.Parameters.Add(manager.GetParametro("@CobroMatricula", pInformacion.CobroMatricula));
                oComando.Parameters.Add(manager.GetParametro("@CobroPoliza", pInformacion.CobroPoliza));
                oComando.Parameters.Add(manager.GetParametro("@CobroTechFee", pInformacion.CobroTechFee));
                oComando.Parameters.Add(manager.GetParametro("@CodigoMatricula", pInformacion.CodigoMatricula));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Agregar_Finanza");

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

        public Dto.Finanza.Salida.EliminarFinanza EliminarFinanza(Dto.Finanza.Entrada.EliminarFinanza pInformacion)
        {
            IDbConnection oConexion = null;
            IDbCommand oComando = manager.GetComando();
            Dto.Finanza.Salida.EliminarFinanza resultado = new Dto.Finanza.Salida.EliminarFinanza();

            try
            {
                oConexion = manager.GetConexion();
                oConexion.Open();

                oComando.Parameters.Add(manager.GetParametro("@Codigo", pInformacion.Codigo));

                IDataReader objDr = manager.GetDataReader(oComando, oConexion, "dbo.Eliminar_Finanza");
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
