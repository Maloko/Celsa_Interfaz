using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOWTQ
    {
        private String _NroOrdenTrabajo;
        private DateTime _FechaSolicitud;
        private String _AlmacenSalida;
        private String _AlmacenEntrada;
        private String _Comentarios;
        private int _NroSolicitudTransferencia;
        private DateTime _FechaReprogramacion;
        private String _Estado;

        public String NroOrdenTrabajo
        {
            get { return _NroOrdenTrabajo; }
            set { _NroOrdenTrabajo = value; }
        }

        public String Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public DateTime FechaSolicitud
        {
            get { return _FechaSolicitud; }
            set { _FechaSolicitud = value; }
        }

        public String AlmacenSalida
        {
            get { return _AlmacenSalida; }
            set { _AlmacenSalida = value; }
        }

        public String AlmacenEntrada
        {
            get { return _AlmacenEntrada; }
            set { _AlmacenEntrada = value; }
        }

        public String Comentarios
        {
            get { return _Comentarios; }
            set { _Comentarios = value; }
        }

        public int NroSolicitudTransferencia
        {
            get { return _NroSolicitudTransferencia; }
            set { _NroSolicitudTransferencia = value; }
        }

        public DateTime FechaReprogramacion
        {
            get { return _FechaReprogramacion; }
            set { _FechaReprogramacion = value; }
        }
    }

    public class BEOWTQList : List<BEOWTQ>, ICloneable
    {
        public BEOWTQList()
        {
        }

        private BEOWTQList(BEOWTQList listaMembers)
        {
            foreach (BEOWTQ beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOWTQList(this);
        }

    }
}
