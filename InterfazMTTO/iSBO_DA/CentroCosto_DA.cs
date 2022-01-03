using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_DA
{
    public class CentroCosto_DA
    {
        public static BEOPRCList ListarCCs(int TipoCC,  ref BERPTA Respuesta, string padre = null)
        {
            BEOPRCList ListaCCs = new BEOPRCList();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = InterfazMTTO.iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (InterfazMTTO.iSBO_DA.Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();
                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_ARTICULOS_SAP + " '" + TipoArticulo.ToString() + "'," + iSBO_Util.Constantes.P_VALOR_RESULT_0 + ",''";

                    Result = InterfazMTTO.iSBO_DA.Conexion.RecordSet_SAP(14, new string[] { TipoCC.ToString(), padre.ToString() }, ref EstadoConsulta);


                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == InterfazMTTO.iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOPRC CentroCosto = new BEOPRC();

                            //if (Convert.ToInt16(Result.Fields.Item(InterfazMTTO.iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == InterfazMTTO.iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            //{
                            //    Respuesta.ResultadoRetorno = InterfazMTTO.iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                            //    break;
                            //}

                            CentroCosto.codigo = Result.Fields.Item("PrcCode").Value.ToString();
                            CentroCosto.nombre = Result.Fields.Item("PrcName").Value.ToString();
                            CentroCosto.dimcode = Convert.ToInt32(Result.Fields.Item("DimCode").Value.ToString());
                            CentroCosto.padre = Result.Fields.Item("U_GR_UNEGORG").Value.ToString();

                            ListaCCs.Add(CentroCosto);
                            Result.MoveNext();

                            Respuesta.ResultadoRetorno = InterfazMTTO.iSBO_Util.Constantes.P_VALOR_RESULT_0;
                        }
                    }
                }
                else
                {
                    Respuesta.ResultadoRetorno = InterfazMTTO.iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                    Respuesta = InterfazMTTO.iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                    Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + InterfazMTTO.iSBO_Util.Constantes.P_TEXTO_ERROR_SOCIEDAD;
                }
            }


            catch (Exception ex)
            {
                InterfazMTTO.iSBO_Util.ErrorHandler Error = new InterfazMTTO.iSBO_Util.ErrorHandler();
                Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                Respuesta.ResultadoRetorno = InterfazMTTO.iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                Respuesta = InterfazMTTO.iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
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

            return ListaCCs;
        }
    }
}
