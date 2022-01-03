using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOPRC
    {
        private String _codigo;
        private String _nombre;
        private Int32 _dimcode;
        private String _padre;
  

        public String codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public String nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public Int32 dimcode
        {
            get { return _dimcode; }
            set { _dimcode = value; }
        }

        public String padre
        {
            get { return _padre; }
            set { _padre = value; }
        }


    }

    public class BEOPRCList : List<BEOPRC>, ICloneable
    {
        public BEOPRCList()
        {
        }

        private BEOPRCList(BEOPRCList listaMembers)
        {
            foreach (BEOPRC beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOPRCList(this);
        }

    }
}
