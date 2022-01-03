using System;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_DA
{
    public class Usuario_DA
    {
        public static bool ValidaSociedad(string ruc, string razonsocial, ref BERPTA Respuesta)
        {
            bool Resultado = false;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {
                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "SELECT * FROM [dbo].[OADM] ";

                    Result = Conexion.RecordSet_SAP(12, null, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {                            
                            if (Result.Fields.Item(iSBO_Util.Constantes.P_COMPANY).Value.ToString() == razonsocial && Result.Fields.Item(iSBO_Util.Constantes.P_RUC).Value.ToString() == ruc)
                            {
                                Resultado = true;
                                break;
                            }

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

            return Resultado;

        }

        public static bool ValidaEstadoConexion(ref BERPTA Respuesta)
        {
            bool StatusConexion = false;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {                
                string Tiempo = Conexion.Sociedad.GetCompanyTime();

                if (string.IsNullOrEmpty(Tiempo)==false)
                {
                    StatusConexion = true;
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_0;
                }                                
            }
            catch (Exception ex)
            {
                StatusConexion = false;                
                Conexion.Desconectar();
                      
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();
                Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
            }


            return StatusConexion;
        }

        public static BEOUSRList ListarUsuarios(ref BERPTA Respuesta)
        {
            BEOUSRList ListadoUsuarios = new BEOUSRList();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {

                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_USUARIOS_SAP + " ";

                    Result = Conexion.RecordSet_SAP(13, null, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOUSR Usuarios = new BEOUSR();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_0;
                            Usuarios.CodigoUsuario = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOUSUARIO).Value.ToString();
                            Usuarios.DescripcionUsuario = Result.Fields.Item(iSBO_Util.Constantes.P_DESCRIPCIONUSUARIO).Value.ToString();
                            Usuarios.Nombres = Result.Fields.Item(iSBO_Util.Constantes.P_NOMBRESUSUARIO).Value.ToString();
                            Usuarios.Apellidos = Result.Fields.Item(iSBO_Util.Constantes.P_APELLIDOSUSUARIO).Value.ToString();
                            Usuarios.Correo = Result.Fields.Item(iSBO_Util.Constantes.P_CORREOUSUARIO).Value.ToString();
                            ListadoUsuarios.Add(Usuarios);
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

            return ListadoUsuarios;
        }

        public static BEOUSRList ListarUsuariosDepartment(int CodeDepartment, ref BERPTA Respuesta)
        {
            BEOUSRList ListadoUsuarios = new BEOUSRList();
            string Query = string.Empty;
            SAPbobsCOM.IRecordset Result = null;
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {

                    BERPTA EstadoConsulta = new BERPTA();

                    Result = Conexion.RecordSet_SAP(17, new string[] { CodeDepartment.ToString()}, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOUSR Usuarios = new BEOUSR();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_0;
                            Usuarios.CodigoUsuario = Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOUSUARIO).Value.ToString();
                            Usuarios.DescripcionUsuario = Result.Fields.Item(iSBO_Util.Constantes.P_DESCRIPCIONUSUARIO).Value.ToString();
                            Usuarios.Nombres = Result.Fields.Item(iSBO_Util.Constantes.P_NOMBRESUSUARIO).Value.ToString();
                            Usuarios.Apellidos = Result.Fields.Item(iSBO_Util.Constantes.P_APELLIDOSUSUARIO).Value.ToString();
                            Usuarios.Correo = Result.Fields.Item(iSBO_Util.Constantes.P_CORREOUSUARIO).Value.ToString();
                            Usuarios.Department = Result.Fields.Item(iSBO_Util.Constantes.P_DEPARTMENTUSUARIO).Value.ToString();
                            ListadoUsuarios.Add(Usuarios);
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

            return ListadoUsuarios;
        }

        public static BEOUSR ValidaUsuario(BEOUSR OUSR, BEPCSAP ParametrosConexion,  ref BERPTA Respuesta)
        {            
            BEOUSR Usuario = new BEOUSR();            
            string ErrorSAP = string.Empty;            
            SAPbobsCOM.BoDataServerTypes TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_MSSQL;

            try
            {                
                Conexion.Servidor = ParametrosConexion.Servidor;
                Conexion.BaseDatos = ParametrosConexion.BaseDatos;
                Conexion.LicenciaServidor = ParametrosConexion.LicenciaServidor;

                switch (ParametrosConexion.TipoServidorBD)
                {
                    case "dst_DB_2": 
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_DB_2;
                        break;
                    case "dst_HANADB": 
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
                        break;
                    case "dst_MAXDB": 
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_MAXDB;
                        break;
                    case "dst_MSSQL": 
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_MSSQL;
                        break;
                    case "dst_MSSQL2005": 
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2005;
                        break;
                    case "dst_MSSQL2008": 
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008;
                        break;
                    case "dst_MSSQL2012": 
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
                        break;
                    case "dst_MSSQL2014":
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014;
                        break;
                    case "dst_SYBASE": 
                        TipoServidor = SAPbobsCOM.BoDataServerTypes.dst_SYBASE;
                        break;
                }

                Conexion.TipoServidor = TipoServidor;
                Conexion.BdUser = ParametrosConexion.BDUser;
                Conexion.BdPass = ParametrosConexion.BDPass;
                Conexion.ConSegura = false;
                Conexion.User = OUSR.CodigoUsuario;
                Conexion.Pass = OUSR.Clave;

                Respuesta = Conexion.Conectar(ref ErrorSAP);

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    Usuario.RespuestaValidacion = iSBO_Util.Constantes.P_RESPUESTA_VALIDACION_SI;
                    Usuario.CodigoUsuario = OUSR.CodigoUsuario;
                    Usuario.Clave = OUSR.Clave;
                    Usuario.DescripcionUsuario = OUSR.DescripcionUsuario;
                }
                else
                {                    
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                    Respuesta.DescripcionErrorUsuario = Respuesta.DescripcionErrorUsuario + "(" + ErrorSAP + ")";
                }
                
            }

            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();
                Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
            }

            return Usuario;
        }
     
        public static int Conecta_Temp()
        {
            int Return = 0;
            BEOUSR OUSRTemp = new BEOUSR();
            BEPCSAP Param = new BEPCSAP();
            BERPTA Respuesta = new BERPTA();

            Param.Servidor = "VS-LT-02";
            Param.BaseDatos = "SBO_DEMO_TRANSPORTE";
            Param.LicenciaServidor = "localhost:30000";
            Param.TipoServidorBD = "dst_MSSQL2008";
            Param.BDUser = "sa";
            Param.BDPass = "B1Admin";
            OUSRTemp.CodigoUsuario = "manager";
            OUSRTemp.Clave = "sbosap";

            OUSRTemp = ValidaUsuario(OUSRTemp, Param, ref Respuesta);

            return Return;
        }

        public static int Conecta_Temp_Error()
        {
            int Return = 0;
            BEOUSR OUSRTemp = new BEOUSR();
            BEPCSAP Param = new BEPCSAP();
            BERPTA Respuesta = new BERPTA();

            Param.Servidor = "HPDV20-PC";
            Param.BaseDatos = "SBO_INNTEC";
            Param.LicenciaServidor = "error:30000";
            Param.TipoServidorBD = "dst_MSSQL2008";
            Param.BDUser = "sa";
            Param.BDPass = "B1Admin";
            OUSRTemp.CodigoUsuario = "manager";
            OUSRTemp.Clave = "sbosap";

            OUSRTemp = ValidaUsuario(OUSRTemp, Param, ref Respuesta);

            return Return;
        }

        public static int Conecta_Temp_MTTO()
        {
            int Return = 0;
            BEOUSR OUSRTemp = new BEOUSR();
            BEPCSAP Param = new BEPCSAP();
            BERPTA Respuesta = new BERPTA();

            Param.Servidor = "HPDV20-PC";
            Param.BaseDatos = "SBO_MTTO";
            Param.LicenciaServidor = "localhost:30000";
            Param.TipoServidorBD = "dst_MSSQL2008";
            Param.BDUser = "sa";
            Param.BDPass = "B1Admin";
            OUSRTemp.CodigoUsuario = "manager";
            OUSRTemp.Clave = "sbosap";

            OUSRTemp = ValidaUsuario(OUSRTemp, Param, ref Respuesta);

            return Return;
        }
    }
}
