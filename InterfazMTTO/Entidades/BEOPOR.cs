using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOPOR
    {
        private String _CodigoProveedor;
        private String _IndicadorAplicaMantenimiento;        
        private int _NroOrden;
        private DateTime _FechaOrden;
        private string _Moneda;
        private Double _CostoTotal;        
        private String _NroOrdenTrabajo;

        public String CodigoProveedor
        {
            get { return _CodigoProveedor; }
            set { _CodigoProveedor = value; }
        }

        public String IndicadorAplicaMantenimiento
        {
            get { return _IndicadorAplicaMantenimiento; }
            set { _IndicadorAplicaMantenimiento = value; }
        }        

        public int NroOrden
        {
            get { return _NroOrden; }
            set { _NroOrden = value; }
        }

        public DateTime FechaOrden
        {
            get { return _FechaOrden; }
            set { _FechaOrden = value; }
        }

        public Double CostoTotal
        {
            get { return _CostoTotal; }
            set { _CostoTotal = value; }
        }

        public String Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }

        public String NroOrdenTrabajo
        {
            get { return _NroOrdenTrabajo; }
            set { _NroOrdenTrabajo = value; }
        }

    }

    public class BEOPORList : List<BEOPOR>, ICloneable
    {
        public BEOPORList()
        {
        }

        private BEOPORList(BEOPORList listaMembers)
        {
            foreach (BEOPOR beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOPORList(this);
        }

    }
}
