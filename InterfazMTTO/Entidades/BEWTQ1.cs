using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEWTQ1
    {
        private String _NroOrdenTrabajo;
        private int _NroLinea;
        private int _NroLineaOT;
        private String _CodigoArticulo;
        private int _CantidadSolicitada;
        private int _CantidadTransferida;
        private int _NroSolicitudTransferencia;
        private Double _CostoUnitario;
        private String _TipoOperacion;
        private String _CCosto1;
        private String _CCosto2;
        private String _CCosto3;
        private String _CCosto4;
        private String _CCosto5;


        public String CCosto1
        {
            get { return _CCosto1; }
            set { _CCosto1 = value; }
        }

        public String CCosto2
        {
            get { return _CCosto2; }
            set { _CCosto2 = value; }
        }
        

        public String CCosto3
        {
            get { return _CCosto3; }
            set { _CCosto3 = value; }
        }

        public String CCosto4
        {
            get { return _CCosto4; }
            set { _CCosto4 = value; }
        }

        public String CCosto5
        {
            get { return _CCosto5; }
            set { _CCosto5 = value; }
        }

        public String TipoOperacion
        {
            get { return _TipoOperacion; }
            set { _TipoOperacion = value; }
        }

        public String NroOrdenTrabajo
        {
            get { return _NroOrdenTrabajo; }
            set { _NroOrdenTrabajo = value; }
        }

        public int NroLinea
        {
            get { return _NroLinea; }
            set { _NroLinea = value; }
        }

        public int NroLineaOT
        {
            get { return _NroLineaOT; }
            set { _NroLineaOT = value; }
        }

        public String CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }

        public int CantidadSolicitada
        {
            get { return _CantidadSolicitada; }
            set { _CantidadSolicitada = value; }
        }

        public int CantidadTransferida
        {
            get { return _CantidadTransferida; }
            set { _CantidadTransferida = value; }
        }

        public int NroSolicitudTransferencia
        {
            get { return _NroSolicitudTransferencia; }
            set { _NroSolicitudTransferencia = value; }
        }

        public Double CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }
    }

    public class BEWTQ1List : List<BEWTQ1>, ICloneable
    {
        public BEWTQ1List()
        {
        }

        private BEWTQ1List(BEWTQ1List listaMembers)
        {
            foreach (BEWTQ1 beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEWTQ1List(this);
        }

    }

}
