using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfazMTTO.iSBO_BE;
using InterfazMTTO.iSBO_Util;

namespace InterfazMTTO.iSBO_DA
{
    public class Proyecto_DA
    {
        public static BEOPRJList ListarProyectos(string CodigoProyecto, string EstadoProyecto, ref BERPTA Respuesta)
        {
            BEOPRJList ListaProyectos = new BEOPRJList();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();
                    Result = Conexion.RecordSet_SAP(15, new string[] { CodigoProyecto.ToString(), EstadoProyecto.ToString() }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOPRJ Proyecto = new BEOPRJ();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            Proyecto.CodigoProyecto = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOPROYECTO).Value.ToString();
                            Proyecto.DescripcionProyecto = Result.Fields.Item(iSBO_Util.Constantes.P_DESCRIPCIONPROYECTO).Value.ToString();
                            Proyecto.EstadoProyecto = Result.Fields.Item(iSBO_Util.Constantes.P_ESTADOPROYECTO).Value.ToString();
                            ListaProyectos.Add(Proyecto);
                            Result.MoveNext();

                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_0;
                        }
                    }
                }
                else
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                    Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + iSBO_Util.Constantes.P_TEXTO_ERROR_SOCIEDAD;
                }
            }


            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();
                Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
            }

            finally
            {
                if (Result != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(Result);
                }

                Result = null;
                GC.Collect();
            }

            return ListaProyectos;
        }

    }
}
