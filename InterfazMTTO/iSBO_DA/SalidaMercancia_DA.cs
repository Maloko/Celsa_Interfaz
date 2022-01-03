using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_DA
{
    public class SalidaMercancia_DA
    {

        public static BEIGE1List RegistraSalidaMercancia(BEOIGE OIGE, BEIGE1List IGE1, ref BERPTA Respuesta, ref string DocEntry, Boolean guardarPreliminar = false)
        {
            BEIGE1List ListSalidaMercancia = new BEIGE1List();
            SAPbobsCOM.IDocuments DocSalidaM = null;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            int CodError=0;
            String DesError= string.Empty;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    Conexion.Sociedad.StartTransaction();
                    DocSalidaM = (SAPbobsCOM.IDocuments)Conexion.Sociedad.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oInventoryGenExit);
                    if(guardarPreliminar)
                    {
                        DocSalidaM = (SAPbobsCOM.IDocuments)Conexion.Sociedad.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oDrafts);
                        DocSalidaM.DocObjectCode = SAPbobsCOM.BoObjectTypes.oInventoryGenExit;
                    }
                    DocSalidaM.DocDate = OIGE.FechaSolicitud;
                    DocSalidaM.TaxDate = OIGE.FechaSolicitud;
                    DocSalidaM.UserFields.Fields.Item(iSBO_Util.Constantes.C_NROORDENTRABAJO).Value = OIGE.NroOrdenTrabajo;
                    DocSalidaM.Reference2 = Convert.ToString(OIGE.NroSolicitudTransferencia);

                    SAPbobsCOM.IDocument_Lines DocSalidaM_Lineas = DocSalidaM.Lines;

                    int i = 0;
                    foreach (BEIGE1 DetSalida in IGE1)
                    {
                        DocSalidaM_Lineas.SetCurrentLine(i);
                        DocSalidaM_Lineas.UserFields.Fields.Item(iSBO_Util.Constantes.C_NROLINEAORDENTRABAJO).Value = DetSalida.NroLineaOrdenTrabajo;
                        DocSalidaM_Lineas.ItemCode = DetSalida.CodigoArticulo;
                        DocSalidaM_Lineas.WarehouseCode = DetSalida.AlmacenSalida;
                        DocSalidaM_Lineas.Quantity = DetSalida.CantidadSalida;
                        DocSalidaM_Lineas.UserFields.Fields.Item(iSBO_Util.Constantes.C_TIPOOPERACION).Value = DetSalida.TipoOperacion;
                        DocSalidaM_Lineas.AccountCode = DetSalida.CuentaContable;
                        DocSalidaM_Lineas.CostingCode = DetSalida.CCosto1;
                        DocSalidaM_Lineas.CostingCode2 = DetSalida.CCosto2;
                        DocSalidaM_Lineas.CostingCode3 = DetSalida.CCosto3;
                        DocSalidaM_Lineas.CostingCode4 = DetSalida.CCosto4;
                        DocSalidaM_Lineas.CostingCode5 = DetSalida.CCosto5;
                        DocSalidaM_Lineas.Add();
                        i++;
                    }

                    Respuesta.ResultadoRetorno = DocSalidaM.Add();

                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        Conexion.Sociedad.GetLastError(out CodError, out DesError);
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                        Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                        Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + " " + CodError + " " + DesError;                        
                    }
                    else
                    {
                        Conexion.Sociedad.EndTransaction(SAPbobsCOM.BoWfTransOpt.wf_Commit);
                        int NroSalidaMercancia = Convert.ToInt16(Conexion.Sociedad.GetNewObjectKey());
                        ListSalidaMercancia = ObtenerSalidaMercancia(NroSalidaMercancia, ref Respuesta);

                        if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                        {
                            Conexion.Sociedad.GetLastError(out CodError, out DesError);                            
                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                            Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                            Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + " " + CodError + " " + DesError;                            
                        }

                        #region COSTO_ARTICULO_SALIDA
                        DocEntry = Conexion.Sociedad.GetNewObjectKey();
                        #endregion
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

            return ListSalidaMercancia;
        }

        public static BEIGE1List ObtenerSalidaMercancia(int NroSalidaMercancia, ref BERPTA Respuesta)
        {
            BEIGE1List ListadoSalidaMercancia = new BEIGE1List();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_OBTIENE_SALIDA_MERCANCIA_SAP + " " + NroSalidaMercancia + " ";

                    Result = Conexion.RecordSet_SAP(5, new string[] { NroSalidaMercancia.ToString()}, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEIGE1 DetalleSalidaMercancia = new BEIGE1();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            DetalleSalidaMercancia.NroSalidaMercancia = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROSALIDAMERCANCIA).Value.ToString());
                            DetalleSalidaMercancia.NroOrdenTrabajo = Result.Fields.Item(iSBO_Util.Constantes.P_NROORDENTRABAJO).Value.ToString();
                            DetalleSalidaMercancia.NroLineaSalidaMercancia = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROLINEASALIDAMERCANCIA).Value.ToString());
                            DetalleSalidaMercancia.NroLineaOrdenTrabajo = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_NROLINEAOT).Value.ToString());
                            DetalleSalidaMercancia.CodigoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOARTICULO).Value.ToString();
                            DetalleSalidaMercancia.CantidadSalida = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CANTIDADSALIDA).Value.ToString());
                            DetalleSalidaMercancia.CostoUnitario = Convert.ToDouble(Result.Fields.Item(iSBO_Util.Constantes.P_COSTOUNITARIO).Value.ToString());
                            ListadoSalidaMercancia.Add(DetalleSalidaMercancia);
                            Result.MoveNext();
                        }

                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_0;
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

            return ListadoSalidaMercancia;
        }


    }
}
