using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InterfazMTTO.iSBO_BE;

namespace InterfazMTTO.iSBO_Util
{
    public class OperacionesCadenas
    {
        public static BEOITMList SerializaTipoArticulo(string TipoOperacion, int Length)
        {
            BEOITMList ListaTipoArticulos = new BEOITMList();

            try
            {
                for (int x = 0; x <= Length; x++)
                {
                    BEOITM Articulo = new BEOITM();
                    string TipoArticuloObtenido = string.Empty;

                    TipoArticuloObtenido = TipoOperacion.ToString().Substring(x, 1);
                    Articulo.TipoArticulo = TipoArticuloObtenido;
                    ListaTipoArticulos.Add(Articulo);
                }

            }

            catch { }

            return ListaTipoArticulos;

        }


        public static BEOITMList SerializaArticulo(string CodigoArticulo)
        {
            BEOITMList ListaArticulos = new BEOITMList();

            try
            {                
                string[] ArticuloObtenido;        
                ArticuloObtenido = CodigoArticulo.Split(',');

                for (int x = 0; x <= ArticuloObtenido.Count(); x++)
                {
                    BEOITM Articulo = new BEOITM();                                       
                    Articulo.CodigoArticulo = ArticuloObtenido[x].ToString();
                    ListaArticulos.Add(Articulo);
                }                                                                 
            }

            catch { }

            return ListaArticulos;

        }

        public static bool ComparaCadenas(string ValorBase, string ValorDeseado)
        { 
            bool Comparador = false;

            if (ValorBase == ValorDeseado)
            {
                Comparador = true;            
            }

            return Comparador;
        }

        public static bool ComparaCadenas(string ValorBase, string ValorDeseado, string ValorDeseado2)
        {
            bool Comparador = false;

            if ((ValorBase == ValorDeseado) || (ValorBase == ValorDeseado2))
            {
                Comparador = true;
            }

            return Comparador;
        }

        public static bool ComparaCadenas(string ValorBase, string ValorDeseado, string ValorDeseado2, string ValorDeseado3)
        {
            bool Comparador = false;

            if ((ValorBase == ValorDeseado) || (ValorBase == ValorDeseado2) || (ValorBase==ValorDeseado3))
            {
                Comparador = true;
            }

            return Comparador;
        }

        public static bool ComparaCadenas(string ValorBase, string ValorDeseado, string ValorDeseado2, string ValorDeseado3, string ValorDeseado4)
        {
            bool Comparador = false;

            if ((ValorBase == ValorDeseado) || (ValorBase == ValorDeseado2) || (ValorBase == ValorDeseado3) || (ValorBase == ValorDeseado4))
            {
                Comparador = true;
            }

            return Comparador;
        }

        public static bool ComparaCadenas(string ValorBase, string ValorDeseado, string ValorDeseado2, string ValorDeseado3, string ValorDeseado4, string ValorDeseado5)
        {
            bool Comparador = false;

            if ((ValorBase == ValorDeseado) || (ValorBase == ValorDeseado2) || (ValorBase == ValorDeseado3) || (ValorBase == ValorDeseado4) || (ValorBase == ValorDeseado5))
            {
                Comparador = true;
            }

            return Comparador;
        }

    }
}
