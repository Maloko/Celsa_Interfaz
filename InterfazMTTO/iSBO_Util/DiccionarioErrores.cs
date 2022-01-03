using System;
using InterfazMTTO.iSBO_BE;
using System.Xml;
using System.Reflection;

namespace InterfazMTTO.iSBO_Util
{
    public class DiccionarioErrores
    {
        public static BERPTA ObtenerError(int ResultadoRetorno)
        {
            BERPTAList ListadoRespuestas = new BERPTAList();
            BERPTA Resultado = new BERPTA();
            XmlDocument XML_Diccionario = new XmlDocument();

            try
            {
                Resultado.ResultadoRetorno = ResultadoRetorno;
                XML_Diccionario.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("iSBO_Util.DiccionarioErrores.xml"));
                XmlNodeList Errores = XML_Diccionario.GetElementsByTagName("Errores");
                XmlNodeList Error = ((XmlElement)Errores[0]).GetElementsByTagName("Error");

                foreach (XmlElement Nodo in Error)
                {
                    if (Resultado.ResultadoRetorno == Convert.ToInt16(Nodo.GetElementsByTagName("ResultadoRetorno")[0].InnerText))
                    {
                        Resultado.CodigoErrorUsuario = Nodo.GetElementsByTagName("CodigoErrorUsuario")[0].InnerText;
                        Resultado.DescripcionErrorUsuario = Nodo.GetElementsByTagName("DescripcionErrorUsuario")[0].InnerText;
                    }
                }

            }

            catch
            { }

            return Resultado;
        }
    }
}
