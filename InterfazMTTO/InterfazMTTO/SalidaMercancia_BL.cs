using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_BL
{
    public class SalidaMercancia_BL
    {

        public static BEIGE1List RegistraSalidaMercancia(BEOIGE OIGE, BEIGE1List IGE1, ref BERPTA Respuesta, ref string DocEntry, Boolean guardarPreliminar = false)
        {
            BEIGE1List ListSalidaMercancia = new BEIGE1List();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {

                if (string.IsNullOrEmpty(OIGE.FechaSolicitud.ToString()) || (OIGE.FechaSolicitud.Date == Convert.ToDateTime("01/01/0001").Date))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_913;
                }
                else
                {
                    if (OIGE.FechaSolicitud.Date > DateTime.Now.Date)
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_917;
                    }
                }

                foreach (BEIGE1 Detalle in IGE1)
                {                    
                    if (string.IsNullOrEmpty(Detalle.CodigoArticulo))
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_903;
                        break;
                    }

                    if (string.IsNullOrEmpty(Detalle.AlmacenSalida))
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_904;
                        break;
                    }

                    if (Detalle.CantidadSalida == 0)
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_905;
                        break;
                    }

                    if (string.IsNullOrEmpty(Detalle.CuentaContable.ToString()))
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_930;
                        break;
                    }

                    if (string.IsNullOrEmpty(Detalle.TipoOperacion.ToString()))
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_929;
                        break;
                    }
                }

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    ListSalidaMercancia = iSBO_DA.SalidaMercancia_DA.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta, ref DocEntry, guardarPreliminar);

                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {
                        throw new Exception();
                    }
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

            return ListSalidaMercancia;
        }
    }
}
