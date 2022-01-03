using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_BL
{
    public class Empleado_BL
    {

        public static BEOHEMList ListaEmpleado(string TipoPersona, ref BERPTA Respuesta)
        {
            BEOHEMList ListadoEmpleados = new BEOHEMList();            
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (string.IsNullOrEmpty(TipoPersona))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_907;
                }
                else
                {
                    bool Valida = iSBO_Util.OperacionesCadenas.ComparaCadenas(TipoPersona.ToString(), iSBO_Util.Constantes.P_TIPO_PERSONA_RESPONSABLE, iSBO_Util.Constantes.P_TIPO_PERSONA_SOLICITANTE);

                    if (Valida == false)
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_906;
                    }
                }
                
                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                    ListadoEmpleados = iSBO_DA.Empleado_DA.ListaEmpleado(TipoPersona, ref Respuesta);

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

            return ListadoEmpleados;
        }

    }
}
