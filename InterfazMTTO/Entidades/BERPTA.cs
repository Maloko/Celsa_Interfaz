using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BERPTA
    {
        private int _ResultadoRetorno;
        private String _CodigoErrorUsuario;
        private String _DescripcionErrorUsuario;
        

        public String DescripcionErrorUsuario
        {
            get { return _DescripcionErrorUsuario; }
            set { _DescripcionErrorUsuario = value; }
        }

        public String CodigoErrorUsuario
        {
            get { return _CodigoErrorUsuario; }
            set { _CodigoErrorUsuario = value; }
        }

        public int ResultadoRetorno
        {
            get { return _ResultadoRetorno; }
            set { _ResultadoRetorno = value; }
        }
    }

    public class BERPTAList : List<BERPTA>, ICloneable
    {
        public BERPTAList()
        {
        }

        private BERPTAList(BERPTAList listaMembers)
        {
            foreach (BERPTA beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BERPTAList(this);
        }

    }



}
