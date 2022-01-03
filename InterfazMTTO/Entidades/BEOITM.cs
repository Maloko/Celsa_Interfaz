using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOITM
    {
        private String  _TipoArticulo;
        private String _CodigoArticulo;
        private String _DescripcionArticulo;
        private String _AlmacenSalida;
        private int _CantidadDisponible;                
        private String _RespuestaValidacion;
        private String _Bloqueado;

        



        public String TipoArticulo
        {
            get { return _TipoArticulo; }
            set { _TipoArticulo = value; }
        }

        public String CodigoArticulo
        {
            get { return _CodigoArticulo; }
            set { _CodigoArticulo = value; }
        }

        public String DescripcionArticulo
        {
            get { return _DescripcionArticulo; }
            set { _DescripcionArticulo = value; }
        }

        public String AlmacenSalida
        {
            get { return _AlmacenSalida; }
            set { _AlmacenSalida = value; }
        }

        public int CantidadDisponible
        {
            get { return _CantidadDisponible; }
            set { _CantidadDisponible = value; }
        }
       
        public String RespuestaValidacion
        {
            get { return _RespuestaValidacion; }
            set { _RespuestaValidacion = value; }
        }

        public String Bloqueado
        {
            get { return _Bloqueado; }
            set { _Bloqueado = value; }
        }

    }

    public class BEOITMList : List<BEOITM>, ICloneable
    {
        public BEOITMList()
        {
        }

        private BEOITMList(BEOITMList listaMembers)
        {
            foreach (BEOITM beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOITMList(this);
        }

    }
  
}
