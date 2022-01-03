using System;
using System.Collections.Generic;
using System.Text;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_DA
{    
    public class Empleado_DA
    {

        public static BEOHEMList ListaEmpleado(string TipoPersona, ref BERPTA Respuesta)
        {
            BEOHEMList ListadoEmpleados = new BEOHEMList();

            string Query = string.Empty;

            SAPbobsCOM.IRecordset Result = null;

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (Conexion.Sociedad.Connected == true)
                {

                    BERPTA EstadoConsulta = new BERPTA();

                    //Query = "EXEC " + iSBO_Util.Constantes.SP_LISTA_EMPLEADOS_SAP + " '" + TipoPersona.ToString() + "'";

                    Result = Conexion.RecordSet_SAP(3, new string[] { TipoPersona.ToString() }, ref EstadoConsulta);

                    Respuesta.ResultadoRetorno = EstadoConsulta.ResultadoRetorno;

                    if (EstadoConsulta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {

                        while (!Result.EoF)
                        {
                            BEOHEM Empleado = new BEOHEM();

                            if (Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_RESULTADORETORNO).Value.ToString()) == iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_1)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_3;
                                break;
                            }

                            Empleado.CodigoPersona = Convert.ToInt16(Result.Fields.Item(iSBO_Util.Constantes.P_CODIGOPERSONA).Value.ToString());
                            Empleado.NombrePersona = Result.Fields.Item(iSBO_Util.Constantes.P_NOMBREPERSONA).Value.ToString();
                            Empleado.TipoPersona = Result.Fields.Item(iSBO_Util.Constantes.P_TIPOPERSONA).Value.ToString();
                            Empleado.CostoHoraHombre = Convert.ToDouble(Result.Fields.Item(iSBO_Util.Constantes.P_COSTOHORAHOMBREPERSONA).Value.ToString());
                            ListadoEmpleados.Add(Empleado);
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

            return ListadoEmpleados;
        }

    }
}
