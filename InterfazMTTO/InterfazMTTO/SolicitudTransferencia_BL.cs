using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_BL
{
    public class SolicitudTransferencia_BL
    {

        public static BEWTQ1List RegistraSolicitudTransferencia(BEOWTQ OWTQ, BEWTQ1List WTQ1List, ref BERPTA Respuesta)
        {
            BEWTQ1List SolicitudTransferencia = new BEWTQ1List();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (string.IsNullOrEmpty(OWTQ.NroOrdenTrabajo))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_912;
                }

                if (string.IsNullOrEmpty(OWTQ.FechaSolicitud.ToString()) || (OWTQ.FechaSolicitud.Date == Convert.ToDateTime("01/01/0001").Date))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_913;
                }


                if (string.IsNullOrEmpty(OWTQ.AlmacenEntrada))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_928;
                }

                if (string.IsNullOrEmpty(OWTQ.AlmacenSalida))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_904;
                }

                foreach (BEWTQ1 WTQ1 in WTQ1List)
                {                    
                    if (string.IsNullOrEmpty(WTQ1.NroOrdenTrabajo))
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_912;
                        break;
                    }

                    if (WTQ1.NroLinea == 0)
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_914;
                        break;
                    }

                    if (string.IsNullOrEmpty(WTQ1.CodigoArticulo))
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_903;
                        break;
                    }

                    if (WTQ1.CantidadSolicitada == 0)
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_918;
                        break;
                    }                    
                }

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    SolicitudTransferencia = iSBO_DA.SolicitudTransferencia_DA.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);

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

            return SolicitudTransferencia;
        }

        public static BEWTQ1List ObtenerSolicitudTransferencia(int NroSolicitudTransferencia, ref BERPTA Respuesta)
        {
            BEWTQ1List ListadoSolicitudTransferencia = new BEWTQ1List();            
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (NroSolicitudTransferencia==0)
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_919;
                }

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    ListadoSolicitudTransferencia = iSBO_DA.SolicitudTransferencia_DA.ObtenerSolicitudTransferencia(NroSolicitudTransferencia, ref Respuesta);

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
            
            return ListadoSolicitudTransferencia;
        }

        public static BEWTQ1List ObtenerTransferencia(string NroOT, ref BERPTA Respuesta)
        {
            BEWTQ1List ListadoSolicitudTransferencia = new BEWTQ1List();
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (string.IsNullOrEmpty(NroOT.ToString()))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_912;
                }

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    ListadoSolicitudTransferencia = iSBO_DA.SolicitudTransferencia_DA.ObtenerTransferencia(NroOT, ref Respuesta);

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

            return ListadoSolicitudTransferencia;
        }

        public static BERPTA ActualizarSolicitudTransferencia(BEOWTQ OWTQ)
        {
            BERPTA Respuesta = new BERPTA();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (OWTQ.NroSolicitudTransferencia == 0)                                        
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_919;
                }
                    
                if (string.IsNullOrEmpty(OWTQ.FechaSolicitud.ToString()) || (OWTQ.FechaSolicitud.Date == Convert.ToDateTime("01/01/0001").Date))   
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_913;
                }
                
                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    Respuesta = iSBO_DA.SolicitudTransferencia_DA.ActualizarSolicitudTransferencia(OWTQ);

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

            return Respuesta;
        }                     
    }
}
