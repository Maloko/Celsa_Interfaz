using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOPRJ
    {
        private string _CodigoProyecto;
        private string _DescripcionProyecto;
        private string _EstadoProyecto;

        public string CodigoProyecto
        {
            get { return _CodigoProyecto; }
            set { _CodigoProyecto = value; }
        }

        public string DescripcionProyecto
        {
            get { return _DescripcionProyecto; }
            set { _DescripcionProyecto = value; }
        }

        public string EstadoProyecto
        {
            get { return _EstadoProyecto; }
            set { _EstadoProyecto = value; }
        }
    }

    public class BEOPRJList : List<BEOPRJ>, ICloneable
    {
        public BEOPRJList()
        {
        }

        private BEOPRJList(BEOPRJList listaMembers)
        {
            foreach (BEOPRJ beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOPRJList(this);
        }

    }
}
