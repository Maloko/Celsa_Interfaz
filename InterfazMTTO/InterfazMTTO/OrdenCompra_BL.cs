using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_BL
{
    public class OrdenCompra_BL
    {

        public static BEOPORList ConsultaOrdenesCompra(string CodigoProveedor, string IndicadorAplicaMantenimiento, ref BERPTA Respuesta)
        {
            BEOPORList ListadoOrdenesCompra = new BEOPORList();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (string.IsNullOrEmpty(CodigoProveedor))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_908;
                }

                if (string.IsNullOrEmpty(IndicadorAplicaMantenimiento))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_910;
                }
                else
                {
                    bool Valida = iSBO_Util.OperacionesCadenas.ComparaCadenas(IndicadorAplicaMantenimiento, iSBO_Util.Constantes.P_INDICADOR_APLICA_MANTENIMIENTO_SI, iSBO_Util.Constantes.P_INDICADOR_APLICA_MANTENIMIENTO_NO);

                    if (Valida == false)
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_909;
                    }
                }


                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    ListadoOrdenesCompra = iSBO_DA.OrdenCompra_DA.ConsultaOrdenesCompra(CodigoProveedor, IndicadorAplicaMantenimiento, ref Respuesta);

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

            return ListadoOrdenesCompra;
        }


        public static BERPTA ActualizaOrdenesCompra(int NroOrdenCompra, string NroOrdenTrabajo)
        {
            BERPTA Respuesta = new BERPTA();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (NroOrdenCompra == 0)
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_911;
                }


                if (string.IsNullOrEmpty(NroOrdenTrabajo))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_912;
                }

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    Respuesta = iSBO_DA.OrdenCompra_DA.ActualizaOrdenesCompra(NroOrdenCompra,NroOrdenTrabajo);

                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {
                        throw new Exception();
                    }
                }                
            }

            catch  (Exception ex)
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
