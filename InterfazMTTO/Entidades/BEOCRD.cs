using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOCRD
    {
        private String _IndicadorProveedor;
        private String _CodigoProveedor;
        private String _DescripcionProveedor;
        private String _RucProveedor;

        public String IndicadorProveedor
        {
            get { return _IndicadorProveedor; }
            set { _IndicadorProveedor = value; }
        }

        public String CodigoProveedor
        {
            get { return _CodigoProveedor; }
            set { _CodigoProveedor = value; }
        }

        public String DescripcionProveedor
        {
            get { return _DescripcionProveedor; }
            set { _DescripcionProveedor = value; }
        }

        public String RucProveedor
        {
            get { return _RucProveedor; }
            set { _RucProveedor = value; }
        }

    }

    public class BEOCRDList : List<BEOCRD>, ICloneable
    {
        public BEOCRDList()
        {
        }

        private BEOCRDList(BEOCRDList listaMembers)
        {
            foreach (BEOCRD beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOCRDList(this);
        }

    }

}
