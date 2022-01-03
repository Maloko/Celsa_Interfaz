using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEUDUC
    {
        private String _CodigoUnidadControl;
        private String _PlacaSerieUnidadControl;
        private String _IndicadorExistencia;
        private String _CodigoMarca;
        private String _Marca;
        private String _CodigoModelo;
        private String _Modelo;
        private String _Anho;
        private String _CodigoFamilia;
        private String _Familia;
        private String _CodigoSubFamilia;
        private String _SubFamilia;
        private String _LineaNegocio;
        private String _CodigoLineaNegocio;
        private String _Propietario;
        private String _Configuracion;
        private String _TipoPropiedad;        
        private String _RespuestaValidacion;        
        private String _CodigoTipoUnidadControl;
        private String _DescripcionTipoUnidadControl;
        private String _CentroCosto1;
        private String _CentroCosto2;
        private String _CentroCosto3;
        private String _CentroCosto4;
        private String _CentroCosto5;



        public String CodigoUnidadControl
        {
            get { return _CodigoUnidadControl; }
            set { _CodigoUnidadControl = value; }
        }

        public String PlacaSerieUnidadControl
        {
            get { return _PlacaSerieUnidadControl; }
            set { _PlacaSerieUnidadControl = value; }
        }

        public String IndicadorExistencia
        {
            get { return _IndicadorExistencia; }
            set { _IndicadorExistencia = value; }
        }

        public String CodigoMarca
        {
            get { return _CodigoMarca; }
            set { _CodigoMarca = value; }
        }

        public String Marca
        {
            get { return _Marca; }
            set { _Marca = value; }
        }

        public String CodigoModelo
        {
            get { return _CodigoModelo; }
            set { _CodigoModelo = value; }
        }

        public String Modelo
        {
            get { return _Modelo; }
            set { _Modelo = value; }
        }

        public String Anho
        {
            get { return _Anho; }
            set { _Anho = value; }
        }

        public String CodigoFamilia
        {
            get { return _CodigoFamilia; }
            set { _CodigoFamilia = value; }
        }

        public String Familia
        {
            get { return _Familia; }
            set { _Familia = value; }
        }

        public String CodigoSubFamilia
        {
            get { return _CodigoSubFamilia; }
            set { _CodigoSubFamilia = value; }
        }

        public String SubFamilia
        {
            get { return _SubFamilia; }
            set { _SubFamilia = value; }
        }

        public String CodigoLineaNegocio
        {
            get { return _CodigoLineaNegocio; }
            set { _CodigoLineaNegocio = value; }
        }

        public String LineaNegocio
        {
            get { return _LineaNegocio; }
            set { _LineaNegocio = value; }
        }

        public String Propietario
        {
            get { return _Propietario; }
            set { _Propietario = value; }
        }

        public String Configuracion
        {
            get { return _Configuracion; }
            set { _Configuracion = value; }
        }

        public String TipoPropiedad
        {
            get { return _TipoPropiedad; }
            set { _TipoPropiedad = value; }
        }

        public String RespuestaValidacion
        {
            get { return _RespuestaValidacion; }
            set { _RespuestaValidacion = value; }
        }

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

        public String CentroCosto1
        {
            get { return _CentroCosto1; }
            set { _CentroCosto1 = value; }
        }

        public String CentroCosto2
        {
            get { return _CentroCosto2; }
            set { _CentroCosto2 = value; }
        }

        public String CentroCosto3
        {
            get { return _CentroCosto3; }
            set { _CentroCosto3 = value; }
        }

        public String CentroCosto4
        {
            get { return _CentroCosto4; }
            set { _CentroCosto4 = value; }
        }

        public String CentroCosto5
        {
            get { return _CentroCosto5; }
            set { _CentroCosto5 = value; }
        }
                
    }

    public class BEUDUCList : List<BEUDUC>, ICloneable
    {
        public BEUDUCList()
        {
        }

        private BEUDUCList(BEUDUCList listaMembers) 
        {
            foreach (BEUDUC beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEUDUCList(this);
        }

    }
}
