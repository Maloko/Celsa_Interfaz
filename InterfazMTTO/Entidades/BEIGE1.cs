using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEIGE1
    {
        private String _CodigoArticulo;
        private int _NroLineaOrdenTrabajo;
        private int _NroLineaSalidaMercancia;
        private int _NroSalidaMercancia;
        private String _NroOrdenTrabajo;
        private String _AlmacenSalida;
        private String _AlmacenDestino;
        private int _CantidadSalida;
        private String _CuentaContable;
        private String _TipoOperacion;
        private Double _CostoUnitario;
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

        public String CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }

        public int NroLineaOrdenTrabajo
        {
            get { return _NroLineaOrdenTrabajo; }
            set { _NroLineaOrdenTrabajo = value; }
        }

        public Double CostoUnitario
        {
            get { return _CostoUnitario; }
            set { _CostoUnitario = value; }
        }

        public String NroOrdenTrabajo
        {
            get { return _NroOrdenTrabajo; }
            set { _NroOrdenTrabajo = value; }
        }

        public int NroLineaSalidaMercancia
        {
            get { return _NroLineaSalidaMercancia; }
            set { _NroLineaSalidaMercancia = value; }
        }

        public int NroSalidaMercancia
        {
            get { return _NroSalidaMercancia; }
            set { _NroSalidaMercancia = value; }
        }

        public String AlmacenSalida
        {
            get { return _AlmacenSalida; }
            set { _AlmacenSalida = value; }
        }

        public String AlmacenDestino
        {
            get { return _AlmacenDestino; }
            set { _AlmacenDestino = value; }
        }

        public int CantidadSalida
        {
            get { return _CantidadSalida; }
            set { _CantidadSalida = value; }
        }

        public String CuentaContable
        {
            get { return _CuentaContable; }
            set { _CuentaContable = value; }
        }  
           
    }

    public class BEIGE1List : List<BEIGE1>, ICloneable
    {
        public BEIGE1List()
        {
        }

        private BEIGE1List(BEIGE1List listaMembers)
        {
            foreach (BEIGE1 beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEIGE1List(this);
        }

    }
}
