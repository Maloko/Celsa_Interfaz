using System;
using SAPbobsCOM;
using InterfazMTTO.iSBO_BE;
using iSBO_DA;

namespace InterfazMTTO.iSBO_DA
{
    public class Conexion
    {
        private static String _servidor;

        public static String Servidor
        {
            get { return Conexion._servidor; }
            set { Conexion._servidor = value; }
        }

        private static String _licenciaServidor;

        public static String LicenciaServidor
        {
            get { return Conexion._licenciaServidor; }
            set { Conexion._licenciaServidor = value; }
        }

        private static String _bdUser;

        public static String BdUser
        {
            get { return Conexion._bdUser; }
            set { Conexion._bdUser = value; }
        }

        private static String _bdPass;

        public static String BdPass
        {
            get { return Conexion._bdPass; }
            set { Conexion._bdPass = value; }
        }

        private static BoDataServerTypes _tipoServidor;

        public static BoDataServerTypes TipoServidor
        {
            get { return Conexion._tipoServidor; }
            set { Conexion._tipoServidor = value; }
        }

        private static Boolean _conSegura;

        public static Boolean ConSegura
        {
            get { return Conexion._conSegura; }
            set { Conexion._conSegura = value; }
        }

        private static String _user;

        public static String User
        {
            get { return Conexion._user; }
            set { Conexion._user = value; }
        }

        private static String _pass;

        public static String Pass
        {
            get { return Conexion._pass; }
            set { Conexion._pass = value; }
        }

        private static Company _sociedad = null;

        public static Company Sociedad
        {
            get { return Conexion._sociedad; }
        }

        private static String _baseDatos;

        public static String BaseDatos
        {
            get { return Conexion._baseDatos; }
            set { Conexion._baseDatos = value; }
        }

        public static BERPTA Conectar(ref string ErrorSAP)
        {
            BERPTA Result = new BERPTA();
            Result.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;
            _sociedad = null;
            _sociedad = new SAPbobsCOM.Company();
            
            try
            {
                if (_sociedad != null && _sociedad.Connected) _sociedad.Disconnect();                                
                _sociedad.Server = _servidor;
                _sociedad.CompanyDB = _baseDatos; 
                _sociedad.LicenseServer = _licenciaServidor; 
                _sociedad.DbServerType = _tipoServidor;  
                _sociedad.DbUserName = _bdUser; 
                _sociedad.DbPassword = _bdPass; 
                _sociedad.UseTrusted = _conSegura;
                _sociedad.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;
                _sociedad.UserName = _user;    
                _sociedad.Password = _pass; 

                int ret = _sociedad.Connect();

                if (ret != 0)
                {
                    Result.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2;
                    ErrorSAP = Conexion.Sociedad.GetLastErrorCode() + ": " + Conexion.Sociedad.GetLastErrorDescription();
                }
                else
                {
                    Result.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_0;
                }
                
            }
            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();
                Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                Result.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
            }           

            return Result;  
        }       
               
        public static void Desconectar()
        {
            if (Sociedad == null)
            {
                _sociedad.Disconnect();
            }
            if (_sociedad.Connected) _sociedad.Disconnect();
            _sociedad = null;
                
        }

        public static SAPbobsCOM.IRecordset RecordSet_SAP(int numero, String[] paramts, ref BERPTA EstadoConsulta)
        {
            SAPbobsCOM.IRecordset RS_SAP = null;

            try
            {                
                RS_SAP = (SAPbobsCOM.IRecordset)Conexion.Sociedad.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                RS_SAP.DoQuery(VSSQLFactory.GetScript(numero,paramts));
            }

            catch (Exception ex)
            {
                EstadoConsulta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                EstadoConsulta.DescripcionErrorUsuario = iSBO_Util.Constantes.P_TEXTO_ERROR_INTERNO;
                EstadoConsulta = iSBO_Util.DiccionarioErrores.ObtenerError(EstadoConsulta.ResultadoRetorno);                
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();
                Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");                
            }

            return RS_SAP;
        }


        public static SAPbobsCOM.IRecordset EjecutarRecordSet(string Query, ref BERPTA EstadoConsulta)
        {

            SAPbobsCOM.IRecordset RS_SAP = null;
            try
            {
                RS_SAP = (SAPbobsCOM.IRecordset)Conexion.Sociedad.GetBusinessObject(BoObjectTypes.BoRecordset);
                RS_SAP.DoQuery(Query);

            }
            catch (Exception ex)
            {
                EstadoConsulta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                EstadoConsulta.DescripcionErrorUsuario = iSBO_Util.Constantes.P_TEXTO_ERROR_INTERNO;
                EstadoConsulta = iSBO_Util.DiccionarioErrores.ObtenerError(EstadoConsulta.ResultadoRetorno);
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();
                Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
            }

            return RS_SAP;
        }
    }
}
