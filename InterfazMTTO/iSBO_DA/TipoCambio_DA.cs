using InterfazMTTO.iSBO_BE;
using System;

namespace InterfazMTTO.iSBO_DA
{
    public class TipoCambio_DA
    {

        public static BEORTT ObtenerTipoCambioPorFecha(DateTime fecha, ref BERPTA Respuesta)
        {
            SAPbobsCOM.IRecordset Result = null;

            BEORTT tipoCambio = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;
            string fechaCambio = fecha.ToString("yyyy-MM-dd");

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Result = Conexion.RecordSet_SAP(18, new string[] { fechaCambio }, ref EstadoConsulta);
                    string query = "SELECT \"RateDate\",\"Currency\",\"Rate\" FROM ORTT WHERE \"RateDate\"='"+fechaCambio+"' AND \"Currency\"='USD'";
                    Result = Conexion.EjecutarRecordSet(query, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        if(Result.EoF)
                        {
                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_933;
                            return null;
                        }

                        while (!Result.EoF)
                        {
                            tipoCambio = new BEORTT();

                            tipoCambio.RateDate = Result.Fields.Item("RateDate").Value;
                            tipoCambio.Currency = Result.Fields.Item("Currency").Value.ToString();
                            tipoCambio.Rate = Convert.ToDecimal(Result.Fields.Item("Rate").Value);
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
            return tipoCambio;
        }
    }
}
