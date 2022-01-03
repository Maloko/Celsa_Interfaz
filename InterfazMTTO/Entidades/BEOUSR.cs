using System;
using System.Collections.Generic;
using System.Text;

namespace InterfazMTTO.iSBO_BE
{
    public class BEOUSR
    {
        private String _CodigoUsuario;        
        private String _Clave;
        private String _RespuestaValidacion;
        private String _DescripcionUsuario;
        private String _Nombres;
        private String _Apellidos;
        private String _Correo;
        private String _Department;


        public String Nombres
        {
            get { return _Nombres; }
            set { _Nombres = value; }
        }

        public String Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        public String Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }


        public String CodigoUsuario
        {
            get { return _CodigoUsuario; }
            set { _CodigoUsuario = value; }
        }

        public String Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        public String RespuestaValidacion
        {
            get { return _RespuestaValidacion; }
            set { _RespuestaValidacion = value; }
        }

        public String DescripcionUsuario
        {
            get { return _DescripcionUsuario; }
            set { _DescripcionUsuario = value; }
        }

        public String Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
    }

    public class BEOUSRList : List<BEOUSR>, ICloneable
    {
        public BEOUSRList()
        {
        }

        private BEOUSRList(BEOUSRList listaMembers)
        {
            foreach (BEOUSR beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEOUSRList(this);
        }

    }
}
