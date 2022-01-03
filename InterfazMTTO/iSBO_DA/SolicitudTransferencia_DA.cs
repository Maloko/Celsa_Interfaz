using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_DA
{
    public class SolicitudTransferencia_DA
    {

        public static BEWTQ1List RegistraSolicitudTransferencia(BEOWTQ OWTQ, BEWTQ1List WTQ1List, ref BERPTA Respuesta)
        {
            BEWTQ1List SolicitudTransferencia = new BEWTQ1List();            
            SAPbobsCOM.IStockTransfer DocSolicitud = null;
            int CodError=0;
            String DesError=string.Empty;                           
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    Conexion.Sociedad.StartTransaction();
                    DocSolicitud = (SAPbobsCOM.IStockTransfer)Conexion.Sociedad.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryTransferRequest);
                    DocSolicitud.UserFields.Fields.Item(iSBO_Util.Constantes.C_NROORDENTRABAJO).Value = OWTQ.NroOrdenTrabajo;
                    DocSolicitud.DocDate = DateTime.Now;
                    DocSolicitud.TaxDate = DateTime.Now;
                    DocSolicitud.DueDate = OWTQ.FechaSolicitud;
                    DocSolicitud.FromWarehouse = OWTQ.AlmacenSalida;
                    DocSolicitud.ToWarehouse = OWTQ.AlmacenEntrada;
                    DocSolicitud.Comments = OWTQ.Comentarios;                    

                    SAPbobsCOM.IStockTransfer_Lines DocSolicitud_Lineas = DocSolicitud.Lines;
                    int i = 0;

                    foreach (BEWTQ1 DetSolicitud in WTQ1List)
                    {
                        DocSolicitud_Lineas.SetCurrentLine(i);
                        DocSolicitud_Lineas.UserFields.Fields.Item(iSBO_Util.Constantes.C_NROLINEAORDENTRABAJO).Value = DetSolicitud.NroLinea.ToString();
                        DocSolicitud_Lineas.ItemCode = DetSolicitud.CodigoArticulo;
                        DocSolicitud_Lineas.Quantity = DetSolicitud.CantidadSolicitada;
                        DocSolicitud_Lineas.UserFields.Fields.Item(iSBO_Util.Constantes.C_TIPOOPERACION).Value = DetSolicitud.TipoOperacion;
                        DocSolicitud_Lineas.FromWarehouseCode = OWTQ.AlmacenSalida;
                        DocSolicitud_Lineas.WarehouseCode = OWTQ.AlmacenEntrada;

                        if (DetSolicitud.CCosto1 != null && DetSolicitud.CCosto1 != "") DocSolicitud_Lineas.DistributionRule = DetSolicitud.CCosto1;
                        if (DetSolicitud.CCosto2 != null && DetSolicitud.CCosto2 != "") DocSolicitud_Lineas.DistributionRule2 = DetSolicitud.CCosto2;
                        if (DetSolicitud.CCosto3 != null && DetSolicitud.CCosto3 != "") DocSolicitud_Lineas.DistributionRule3 = DetSolicitud.CCosto3;
                        if (DetSolicitud.CCosto4 != null && DetSolicitud.CCosto4 != "") DocSolicitud_Lineas.DistributionRule4 = DetSolicitud.CCosto4;
                        if (DetSolicitud.CCosto5 != null && DetSolicitud.CCosto5 != "") DocSolicitud_Lineas.DistributionRule5 = DetSolicitud.CCosto5;

                        DocSolicitud_Lineas.Add();
                        i++;
                    }

                    Respuesta.ResultadoRetorno = DocSolicitud.Add();

                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        Conexion.Sociedad.GetLastError(out CodError, out DesError);
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                        Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                        Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + " " + CodError + " - " + DesError;                        
                    }
                    else
                    {
                        Conexion.Sociedad.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                        int NroSolicituTransferencia = Convert.ToInt16(Conexion.Sociedad.GetNewObjectKey());
                        SolicitudTransferencia = ObtenerSolicitudTransferencia(NroSolicituTransferencia, ref Respuesta);

                        if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                        {                            
                            Conexion.Sociedad.GetLastError(out CodError, out DesError);
                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                            Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                            Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + " " + CodError + " - " + DesError;                            
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
                Conexion.Sociedad.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
            }

            return SolicitudTransferencia;
        }

        public static BEWTQ1List ObtenerSolicitudTransferencia(int NroSolicituTransferencia, ref BERPTA Respuesta)
        {
            BEWTQ1List ListadoSolicitudTransferencia = new BEWTQ1List();            
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_OBTIENE_SOLICITUD_TRANSFERENCIA_SAP + " " + NroSolicituTransferencia.ToString() + " ";

                    Result = Conexion.RecordSet_SAP(7, new string[] { NroSolicituTransferencia.ToString() }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEWTQ1 DetalleSolicitudTransferencia = new BEWTQ1();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            DetalleSolicitudTransferencia.NroSolicitudTransferencia = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROSOLICITUDTRANSFERENCIA).Value.ToString());
                            DetalleSolicitudTransferencia.NroOrdenTrabajo = Result.Fields.Item(iSBO_Util.Constantes.P_NROORDENTRABAJO).Value.ToString();
                            DetalleSolicitudTransferencia.NroLinea = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROLINEA).Value.ToString());
                            DetalleSolicitudTransferencia.NroLineaOT = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROLINEAOT).Value.ToString());
                            DetalleSolicitudTransferencia.CodigoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOARTICULO).Value.ToString();
                            DetalleSolicitudTransferencia.CantidadSolicitada = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CANTIDADSOLICITADA).Value.ToString());
                            DetalleSolicitudTransferencia.CantidadTransferida = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CANTIDADTRANSFERIDA).Value.ToString());
                            DetalleSolicitudTransferencia.CostoUnitario = Convert.ToDouble(Result.Fields.Item(iSBO_Util.Constantes.P_COSTOUNITARIO).Value.ToString());
                            ListadoSolicitudTransferencia.Add(DetalleSolicitudTransferencia);
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

            return ListadoSolicitudTransferencia;
        }

        public static BEWTQ1List ObtenerTransferencia(string NroOT, ref BERPTA Respuesta)
        {
            BEWTQ1List ListadoSolicitudTransferencia = new BEWTQ1List();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_OBTIENE_TRANSFERENCIA_SAP + " '" + NroOT.ToString() + "' ";

                    Result = Conexion.RecordSet_SAP(8, new string[] { NroOT.ToString() }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEWTQ1 DetalleSolicitudTransferencia = new BEWTQ1();
                            
                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            DetalleSolicitudTransferencia.NroSolicitudTransferencia = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROSOLICITUDTRANSFERENCIA).Value.ToString());
                            DetalleSolicitudTransferencia.NroOrdenTrabajo = Result.Fields.Item(iSBO_Util.Constantes.P_NROORDENTRABAJO).Value.ToString();
                            DetalleSolicitudTransferencia.NroLinea = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROLINEA).Value.ToString());
                            DetalleSolicitudTransferencia.NroLineaOT = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROLINEAOT).Value.ToString());
                            DetalleSolicitudTransferencia.CodigoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOARTICULO).Value.ToString();
                            DetalleSolicitudTransferencia.CantidadSolicitada = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CANTIDADSOLICITADA).Value.ToString());
                            DetalleSolicitudTransferencia.CantidadTransferida = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CANTIDADTRANSFERIDA).Value.ToString());
                            DetalleSolicitudTransferencia.CostoUnitario = Convert.ToDouble(Result.Fields.Item(iSBO_Util.Constantes.P_COSTOUNITARIO).Value.ToString());
                            ListadoSolicitudTransferencia.Add(DetalleSolicitudTransferencia);
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

            return ListadoSolicitudTransferencia;
        }

        public static BERPTA ActualizarSolicitudTransferencia(BEOWTQ OWTQ)
        {                     
            BERPTA Respuesta = new BERPTA();            
            SAPbobsCOM.IStockTransfer DocSolicitud = null;
            int CodError=0;
            String DesError=string.Empty;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;
            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    Conexion.Sociedad.StartTransaction();
                    DocSolicitud = (SAPbobsCOM.IStockTransfer)Conexion.Sociedad.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryTransferRequest);
                    DocSolicitud.GetByKey(OWTQ.NroSolicitudTransferencia);
                    DocSolicitud.DueDate = OWTQ.FechaSolicitud;
                    DocSolicitud.Comments = OWTQ.Comentarios;

                    if (OWTQ.Estado == iSBO_Util.Constantes.P_STATUSDOCCANCEL)
                    {
                        Respuesta.ResultadoRetorno = DocSolicitud.Cancel();
                    }
                    else
                    {
                        Respuesta.ResultadoRetorno = DocSolicitud.Update();
                    }

                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {
                        Conexion.Sociedad.GetLastError(out CodError, out DesError);
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                        Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                        Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + " " + CodError + " - " + DesError;                        
                    }
                    else
                    {
                        Conexion.Sociedad.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
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
                Conexion.Sociedad.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_RollBack);
            }
            
            return Respuesta;
        }       
    }


}
