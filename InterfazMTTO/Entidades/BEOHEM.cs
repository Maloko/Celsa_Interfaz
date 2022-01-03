using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOHEM
    {
        private String _TipoPersona;      
        private int _CodigoPersona;
        private String _NombrePersona;
        private Double _CostoHoraHombre;

        public String TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        public int CodigoPersona
        {
            get { return _CodigoPersona; }
            set { _CodigoPersona = value; }
        }

        public String NombrePersona
        {
            get { return _NombrePersona; }
            set { _NombrePersona = value; }
        }

        public Double CostoHoraHombre
        {
            get { return _CostoHoraHombre; }
            set { _CostoHoraHombre = value; }
        }
    }

    public class BEOHEMList : List<BEOHEM>, ICloneable
    {
        public BEOHEMList()
        {
        }

        private BEOHEMList(BEOHEMList listaMembers)
        {
            foreach (BEOHEM beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOHEMList(this);
        }

    }
}
