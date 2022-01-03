using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_DA
{
    public class SocioNegocio_DA
    {
        public static BEOCRDList ConsultaProveedor(string IndicadorProveedor, ref BERPTA Respuesta)
        {
            BEOCRDList ListadoProveedores = new BEOCRDList();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_PROVEEDORES_MANTENIMIENTO_SAP + " '" + IndicadorProveedor.ToString() + "' ";

                    Result = Conexion.RecordSet_SAP(6, new string[] { IndicadorProveedor.ToString() }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOCRD Proveedor = new BEOCRD();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            Proveedor.CodigoProveedor = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOPROVEEDOR).Value.ToString();
                            Proveedor.DescripcionProveedor = Result.Fields.Item(iSBO_Util.Constantes.P_DESCRIPCIONPROVEEDOR).Value.ToString();
                            Proveedor.RucProveedor = Result.Fields.Item(iSBO_Util.Constantes.P_RUCPROVEEDOR).Value.ToString();                            
                            ListadoProveedores.Add(Proveedor);
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

            return ListadoProveedores;
        }

    }
}
