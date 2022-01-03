using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_DA
{

    public class Articulo_DA
    {     
        public static BEOITMList ListarArticulos(string TipoArticulo, ref BERPTA Respuesta)
        {
            BEOITMList ListaArticulos = new BEOITMList();                        
            string Query = string.Empty;            
            SAPbobsCOM.IRecordset Result = null;            

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();
                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_ARTICULOS_SAP + " '" + TipoArticulo.ToString() + "'," + iSBO_Util.Constantes.P_VALOR_RESULT_0 + ",''";

                    Result = Conexion.RecordSet_SAP(1, new string[] { TipoArticulo.ToString(), iSBO_Util.Constantes.P_VALOR_RESULT_0.ToString(),"" }, ref EstadoConsulta);
                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOITM Articulo = new BEOITM();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            Articulo.CodigoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOARTICULO).Value.ToString();
                            Articulo.DescripcionArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_DESCRIPCIONARTICULO).Value.ToString();
                            Articulo.Bloqueado = Result.Fields.Item(iSBO_Util.Constantes.P_BLOQUEADO).Value.ToString();
                            Articulo.CantidadDisponible = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CANTIDADDISPONIBLE).Value.ToString());
                            Articulo.TipoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_TIPOARTICULO).Value.ToString();
                            ListaArticulos.Add(Articulo);
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

            return ListaArticulos;
        }


        public static BEOITMList ListarArticulos(string TipoArticulo, bool FlagStock, string AlmacenStock, ref BERPTA Respuesta)
        {
            BEOITMList ListaArticulos = new BEOITMList();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();
                    int Flag = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1;

                    if (FlagStock == true)
                    {
                        Flag = 1;
                    }
                    else
                    {
                        Flag = 0;
                    }

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_ARTICULOS_SAP + " '" + TipoArticulo.ToString() + "'," + Flag + ",'" + AlmacenStock +"'";

                    Result = Conexion.RecordSet_SAP(1, new string[] { TipoArticulo.ToString(), Flag.ToString(), AlmacenStock }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOITM Articulo = new BEOITM();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            Articulo.CodigoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOARTICULO).Value.ToString();
                            Articulo.DescripcionArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_DESCRIPCIONARTICULO).Value.ToString();
                            Articulo.Bloqueado = Result.Fields.Item(iSBO_Util.Constantes.P_BLOQUEADO).Value.ToString();
                            Articulo.CantidadDisponible = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CANTIDADDISPONIBLE).Value.ToString());
                            Articulo.TipoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_TIPOARTICULO).Value.ToString();
                            ListaArticulos.Add(Articulo);
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

            return ListaArticulos;
        }


        
        public static BEOITMList ListarArticulos(string CodigoArticulo, string AlmacenSalida, ref BERPTA Respuesta)
        {                        
            BEOITMList ListaArticulosSAP = new BEOITMList();
            string Query = string.Empty;            
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();
                    //Query = "EXEC " + iSBO_Util.Constantes.SP_VERIFICA_STOCK_EXISTENCIA_SAP + " '" + CodigoArticulo.ToString() + "','" + AlmacenSalida.ToString() + "'";
                    Result = Conexion.RecordSet_SAP(2, new string[] { CodigoArticulo.ToString(), AlmacenSalida.ToString() }, ref EstadoConsulta);
                    
                    if(Result.RecordCount > 0)
                    {
                        Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;
                        if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                        {

                            while (!Result.EoF)
                            {
                                BEOITM Articulo = new BEOITM();
                                Articulo.CodigoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOARTICULO).Value.ToString();
                                Articulo.DescripcionArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_DESCRIPCIONARTICULO).Value.ToString();
                                Articulo.Bloqueado = Result.Fields.Item(iSBO_Util.Constantes.P_BLOQUEADO).Value.ToString();
                                Articulo.CantidadDisponible = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CANTIDADDISPONIBLE).Value.ToString());
                                Articulo.TipoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_TIPOARTICULO).Value.ToString();
                                Articulo.RespuestaValidacion = Result.Fields.Item(iSBO_Util.Constantes.P_RESPUESTAVALIDACION).Value.ToString();
                                ListaArticulosSAP.Add(Articulo);
                                Result.MoveNext();
                            }

                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_0;
                        }
                    }
                    else
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_993;
                        Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
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

            return ListaArticulosSAP;   
        }

        public static BEOITWList ObtenerCostoArticulo(string IdArticulo, int TipoProceso, int DocEntry, ref BERPTA Respuesta)
        {
            BEOITWList ListaCosto = new BEOITWList();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();
                    Result = Conexion.RecordSet_SAP(16, new string[] { IdArticulo.ToString(), TipoProceso.ToString(), DocEntry.ToString()}, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOITW CostoArticulo = new BEOITW();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            CostoArticulo.CodigoArticulo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOARTICULO).Value.ToString();
                            CostoArticulo.CostoArticulo = Convert.ToDouble(Result.Fields.Item(iSBO_Util.Constantes.P_COSTOARTICULO).Value.ToString());
                            ListaCosto.Add(CostoArticulo);
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

            return ListaCosto;
        }

        public static BEOITWList ObtenerAlmacenEntradaSalidaArticulo(string idArticulo,string almacenEntrada,string almacenSalida, ref BERPTA Respuesta)
        {
            SAPbobsCOM.IRecordset Result = null;
            BEOITWList oitwList = new BEOITWList();
            BEOITW oitw = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    string query = "SELECT \"ItemCode\",\"WhsCode\" FROM OITW WHERE \"ItemCode\"='" + idArticulo+"' AND \"WhsCode\" IN('"+almacenSalida+"','"+almacenEntrada+"')";
                    Result = Conexion.EjecutarRecordSet(query, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {
                        if (Result.EoF)
                        {
                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                            Respuesta.DescripcionErrorUsuario = "El articulo "+ idArticulo +" no tiene almacen de entrada y salida";
                            return null;
                        }

                        while (!Result.EoF)
                        {
                            oitw = new BEOITW();

                            oitw.CodigoArticulo = Result.Fields.Item("ItemCode").Value.ToString();
                            oitw.WhsCode = Result.Fields.Item("WhsCode").Value.ToString();
                            oitwList.Add(oitw);
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
            return oitwList;
        }
    }
}
