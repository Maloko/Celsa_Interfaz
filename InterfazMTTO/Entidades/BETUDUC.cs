using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BETUDUC
    {
        private String _CodigoTipoUnidadControl;
        private String _DescripcionTipoUnidadControl;
        

        public String CodigoTipoUnidadControl
        {
            get { return _CodigoTipoUnidadControl; }
            set { _CodigoTipoUnidadControl = value; }
        }

        public String DescripcionTipoUnidadControl
        {
            get { return _DescripcionTipoUnidadControl; }
            set { _DescripcionTipoUnidadControl = value; }
        }
                

    }

    public class BETUDUCList : List<BETUDUC>, ICloneable
    {
        public BETUDUCList()
        {
        }

        private BETUDUCList(BETUDUCList listaMembers) 
        {
            foreach (BETUDUC beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BETUDUCList(this);
        }

    }
}
