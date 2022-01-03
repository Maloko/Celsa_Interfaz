using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOITW
    {
        private string _CodigoArticulo;
        private double _CostoArticulo;
        private string whsCode;
        public string CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }

        public double CostoArticulo
        {
            get { return _CostoArticulo; }
            set { _CostoArticulo = value; }
        }
        public string WhsCode { get => whsCode; set => whsCode = value; }
    }

    public class BEOITWList : List<BEOITW>, ICloneable
    {
        public BEOITWList()
        {
        }

        private BEOITWList(BEOITWList listaMembers)
        {
            foreach (BEOITW beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOITWList(this);
        }

    }
}
