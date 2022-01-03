using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_BL
{
    public class SocioNegocio_BL
    {

        public static BEOCRDList ConsultaProveedor(string IndicadorProveedor, ref BERPTA Respuesta)
        {
            BEOCRDList ListadoProveedores = new BEOCRDList();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (string.IsNullOrEmpty(IndicadorProveedor))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_916;
                }
                else
                {
                    bool Valida = iSBO_Util.OperacionesCadenas.ComparaCadenas(IndicadorProveedor.ToString(), iSBO_Util.Constantes.P_INDICADOR_PROVEEDOR_SI, iSBO_Util.Constantes.P_INDICADOR_PROVEEDOR_NO);

                    if (Valida == false)
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_915;
                    }
                }

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    ListadoProveedores = iSBO_DA.SocioNegocio_DA.ConsultaProveedor(IndicadorProveedor, ref Respuesta);

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

            return ListadoProveedores;
        }

    }
}
