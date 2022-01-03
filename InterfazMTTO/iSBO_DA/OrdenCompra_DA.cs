using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_DA
{
    public class OrdenCompra_DA
    {
        public static BEOPORList ConsultaOrdenesCompra(string CodigoProveedor, string IndicadorAplicaMantenimiento, ref BERPTA Respuesta)
        {
            BEOPORList ListaOrdenesCompra = new BEOPORList();            
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_ORDENES_COMPRA_SAP + " '" + IndicadorAplicaMantenimiento.ToString() + "', " + " '" + CodigoProveedor.ToString() + "' ";

                    Result = Conexion.RecordSet_SAP(4, new string[] { IndicadorAplicaMantenimiento.ToString(), CodigoProveedor.ToString() }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOPOR OrdenCompra = new BEOPOR();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }
                            OrdenCompra.NroOrden = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROORDENCOMPRA).Value.ToString());
                            OrdenCompra.FechaOrden = Convert.ToDateTime(Result.Fields.Item(iSBO_Util.Constantes.P_FECHAORDENCOMPRA).Value.ToString());
                            OrdenCompra.Moneda = Result.Fields.Item(iSBO_Util.Constantes.P_MONEDA).Value.ToString();
                            OrdenCompra.CostoTotal = Convert.ToDouble(Result.Fields.Item(iSBO_Util.Constantes.P_COSTOTOTAL).Value.ToString());
                            ListaOrdenesCompra.Add(OrdenCompra);
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

            return ListaOrdenesCompra;
        }

        public static BERPTA ActualizaOrdenesCompra(int NroOrdenCompra, string NroOrdenTrabajo)
        {            
            BERPTA Respuesta = new BERPTA();
            SAPbobsCOM.IDocuments OrdenCompra = null;   
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;
            int CodError=0;
            String DesError=string.Empty;
         
            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    Conexion.Sociedad.StartTransaction();
                    OrdenCompra = (SAPbobsCOM.IDocuments)Conexion.Sociedad.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders);
                    OrdenCompra.GetByKey(NroOrdenCompra);
                    OrdenCompra.UserFields.Fields.Item(iSBO_Util.Constantes.C_NROORDENTRABAJO).Value = NroOrdenTrabajo;
                    Respuesta.ResultadoRetorno = OrdenCompra.Update();
                    Conexion.Sociedad.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);


                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        Conexion.Sociedad.GetLastError(out CodError, out DesError);
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                        Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                        Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + " " + CodError + " " + DesError;                        
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

                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    Error.EscribirError("ControlERROR", CodError + '-' + DesError, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");

                }
                else
                {
                    Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                    Conexion.Sociedad.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
                }
            }
            

            return Respuesta;
        }
    }
}
