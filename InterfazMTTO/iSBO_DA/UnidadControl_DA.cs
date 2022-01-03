using System;
using InterfazMTTO.iSBO_BE;
using SAPbobsCOM;

namespace InterfazMTTO.iSBO_DA
{
    public class UnidadControl_DA
    {
        
        public static BETUDUCList ListaTipoUnidadControl(ref BERPTA Respuesta)
        {
            BETUDUCList ListaTipoUnidadControl = new BETUDUCList();           
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_TIPO_UNIDAD_CONTROL_SAP;

                    Result = Conexion.RecordSet_SAP(9, null, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;
                        
                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BETUDUC BETipoUnidadControl = new BETUDUC();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }
                            BETipoUnidadControl.CodigoTipoUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_CODTIPOUNIDAD).Value.ToString();
                            BETipoUnidadControl.DescripcionTipoUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_DESTIPOUNIDAD).Value.ToString();
                            ListaTipoUnidadControl.Add(BETipoUnidadControl);
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

            return ListaTipoUnidadControl;
        }

        public static BEUDUCList ListaUnidadControlxTipo(string TipoUnidadControl, ref BERPTA Respuesta)
        {
            BEUDUCList ListaUnidadControl = new BEUDUCList();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_UNIDAD_CONTROL_X_TIPO_SAP + " '" + TipoUnidadControl.ToString() + "'";

                    Result = Conexion.RecordSet_SAP(10, new string[] { TipoUnidadControl.ToString() }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEUDUC BEUnidadControl = new BEUDUC();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            BEUnidadControl.CodigoUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOUC).Value.ToString();
                            BEUnidadControl.PlacaSerieUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_PLACASERIEUC).Value.ToString();
                            BEUnidadControl.CodigoMarca = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOMARCA).Value.ToString();
                            BEUnidadControl.Marca = Result.Fields.Item(iSBO_Util.Constantes.P_MARCA).Value.ToString();
                            BEUnidadControl.CodigoModelo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOMODELO).Value.ToString();
                            BEUnidadControl.Modelo = Result.Fields.Item(iSBO_Util.Constantes.P_MODELO).Value.ToString();
                            BEUnidadControl.Anho = Result.Fields.Item(iSBO_Util.Constantes.P_ANIO).Value.ToString();
                            BEUnidadControl.CodigoFamilia = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOFAMILIA).Value.ToString();
                            BEUnidadControl.Familia = Result.Fields.Item(iSBO_Util.Constantes.P_FAMILIA).Value.ToString();
                            BEUnidadControl.CodigoSubFamilia = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOSUBFAMILIA).Value.ToString();
                            BEUnidadControl.SubFamilia = Result.Fields.Item(iSBO_Util.Constantes.P_SUBFAMILIA).Value.ToString();
                            BEUnidadControl.CodigoLineaNegocio = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOLINEANEGOCIO).Value.ToString();
                            BEUnidadControl.LineaNegocio = Result.Fields.Item(iSBO_Util.Constantes.P_LINEANEGOCIO).Value.ToString();
                            BEUnidadControl.Propietario = Result.Fields.Item(iSBO_Util.Constantes.P_PROPIETARIO).Value.ToString();
                            BEUnidadControl.Configuracion = Result.Fields.Item(iSBO_Util.Constantes.P_CONFIGURACION).Value.ToString();
                            BEUnidadControl.TipoPropiedad = Result.Fields.Item(iSBO_Util.Constantes.P_TIPOPROPIEDAD).Value.ToString();                            
                            BEUnidadControl.CodigoTipoUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_CODTIPOUNIDAD).Value.ToString();
                            BEUnidadControl.DescripcionTipoUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_DESTIPOUNIDAD).Value.ToString();
                            BEUnidadControl.CentroCosto1 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO1).Value.ToString();
                            BEUnidadControl.CentroCosto2 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO2).Value.ToString();
                            BEUnidadControl.CentroCosto3 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO3).Value.ToString();
                            BEUnidadControl.CentroCosto4 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO4).Value.ToString();
                            BEUnidadControl.CentroCosto5 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO5).Value.ToString();                            
                            ListaUnidadControl.Add(BEUnidadControl);
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

            return ListaUnidadControl;
        }
        
        public static BEUDUCList ListaUnidadControl(string ListCodigoUnidadControl, ref BERPTA Respuesta)
        {
            BEUDUCList ListaUnidadControl = new BEUDUCList();            
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_UNIDAD_CONTROL_SAP + " '" + ListCodigoUnidadControl.ToString() + "'";

                    Result = Conexion.RecordSet_SAP(11, new string[] { ListCodigoUnidadControl.ToString() }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEUDUC UnidadControl = new BEUDUC();
                            UnidadControl.CodigoUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOUC).Value.ToString();
                            UnidadControl.PlacaSerieUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_PLACASERIEUC).Value.ToString();
                            UnidadControl.CodigoMarca = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOMARCA).Value.ToString();
                            UnidadControl.Marca = Result.Fields.Item(iSBO_Util.Constantes.P_MARCA).Value.ToString();
                            UnidadControl.CodigoModelo = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOMODELO).Value.ToString();
                            UnidadControl.Modelo = Result.Fields.Item(iSBO_Util.Constantes.P_MODELO).Value.ToString();
                            UnidadControl.Anho = Result.Fields.Item(iSBO_Util.Constantes.P_ANIO).Value.ToString();
                            UnidadControl.CodigoFamilia = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOFAMILIA).Value.ToString();
                            UnidadControl.Familia = Result.Fields.Item(iSBO_Util.Constantes.P_FAMILIA).Value.ToString();
                            UnidadControl.CodigoSubFamilia = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOSUBFAMILIA).Value.ToString();
                            UnidadControl.SubFamilia = Result.Fields.Item(iSBO_Util.Constantes.P_SUBFAMILIA).Value.ToString();
                            UnidadControl.CodigoLineaNegocio = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOLINEANEGOCIO).Value.ToString();
                            UnidadControl.LineaNegocio = Result.Fields.Item(iSBO_Util.Constantes.P_LINEANEGOCIO).Value.ToString();
                            UnidadControl.Propietario = Result.Fields.Item(iSBO_Util.Constantes.P_PROPIETARIO).Value.ToString();
                            UnidadControl.Configuracion = Result.Fields.Item(iSBO_Util.Constantes.P_CONFIGURACION).Value.ToString();
                            UnidadControl.TipoPropiedad = Result.Fields.Item(iSBO_Util.Constantes.P_TIPOPROPIEDAD).Value.ToString();                           
                            UnidadControl.CodigoTipoUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_CODTIPOUNIDAD).Value.ToString();
                            UnidadControl.DescripcionTipoUnidadControl = Result.Fields.Item(iSBO_Util.Constantes.P_DESTIPOUNIDAD).Value.ToString();
                            UnidadControl.CentroCosto1 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO1).Value.ToString();
                            UnidadControl.CentroCosto2 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO2).Value.ToString();
                            UnidadControl.CentroCosto3 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO3).Value.ToString();
                            UnidadControl.CentroCosto4 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO4).Value.ToString();
                            UnidadControl.CentroCosto5 = Result.Fields.Item(iSBO_Util.Constantes.P_CENTROCOSTO5).Value.ToString(); 
                            UnidadControl.RespuestaValidacion = Result.Fields.Item(iSBO_Util.Constantes.P_RESPUESTAVALIDACION).Value.ToString();
                            ListaUnidadControl.Add(UnidadControl);
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

            return ListaUnidadControl;
        }

        public static BERPTA ActualizaIndicadorExistencia(BEUDUC UDUC)
        {
            BERPTA Respuesta = new BERPTA();
            int CodError=0;
            String DesError=string.Empty;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;
            UserTable UnidadControl = null;
            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    UnidadControl = (SAPbobsCOM.UserTable)Conexion.Sociedad.UserTables.Item(iSBO_Util.Constantes.T_UNIDADCONTROL);
                    Conexion.Sociedad.StartTransaction();
                    UnidadControl.GetByKey(UDUC.CodigoUnidadControl);
                    UnidadControl.UserFields.Fields.Item(iSBO_Util.Constantes.C_INDICADOREXISTENCIA).Value = UDUC.IndicadorExistencia;

                    Respuesta.ResultadoRetorno = UnidadControl.Update();


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

            finally
            {
                if (UnidadControl != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(UnidadControl);
                UnidadControl = null;
                GC.Collect();
            }

            return Respuesta;
        }
    }
}
