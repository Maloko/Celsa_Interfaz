using System;
using System.Collections.Generic;
namespace InterfazMTTO.iSBO_BE
{
    public class BEOIGE
    {
        private String _NroOrdenTrabajo;
        private int _NroSolicitudTransferencia;
        private DateTime _FechaSolicitud;

        public String NroOrdenTrabajo
        {
            get { return _NroOrdenTrabajo; }
            set { _NroOrdenTrabajo = value; }
        }

        public int NroSolicitudTransferencia
        {
            get { return _NroSolicitudTransferencia; }
            set { _NroSolicitudTransferencia = value; }
        }

        public DateTime FechaSolicitud
        {
            get { return _FechaSolicitud; }
            set { _FechaSolicitud = value; }
        }

    }

    public class BEOIGEList : List<BEOIGE>, ICloneable
    {
        public BEOIGEList()
        {
        }

        private BEOIGEList(BEOIGEList listaMembers)
        {
            foreach (BEOIGE beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOIGEList(this);
        }

    }
}
