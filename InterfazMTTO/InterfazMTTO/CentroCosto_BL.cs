using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO
{
    public class CentroCosto_BL
    {
        public static BEOPRCList ListarCCs(int TipoCC,ref BERPTA Respuesta, string padre = null)
        {
            BEOPRCList ListadoCC = new BEOPRCList();
            BEOPRCList TipoCCs = new BEOPRCList();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (TipoCC <=0)
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_902;
                }
                else
                {
                 
                    ListadoCC = iSBO_DA.CentroCosto_DA.ListarCCs(TipoCC, ref Respuesta, padre);
                }
            
            }

            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();

                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    Error.EscribirError("ControlERROR", Respuesta.CodigoErrorUsuario + '-' + Respuesta.DescripcionErrorUsuario, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");

                }
                else
                {
                    Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            finally
            {
                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2)
                {
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            return ListadoCC;
        }
    }
}
