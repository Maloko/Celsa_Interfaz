using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfazMTTO.iSBO_BE;
using InterfazMTTO.iSBO_DA;

namespace InterfazMTTO.iSBO_BL
{
    public class Proyecto_BL
    {
        public static BEOPRJList ListarProyectos(string CodigoProyecto, string EstadoProyecto, ref BERPTA Respuesta)
        {
            BEOPRJList ListadoProyectos = new BEOPRJList();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                //Validaciones de capa de negocio OK. Invoca la clase DA

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    ListadoProyectos = iSBO_DA.Proyecto_DA.ListarProyectos(CodigoProyecto, EstadoProyecto, ref Respuesta);

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

            return ListadoProyectos;
        }
    }
}
