using System;
using System.Collections.Generic;

namespace InterfazMTTO.iSBO_BE
{
    public class BEPCSAP
    {
        private String _Servidor;
        private String _BaseDatos;
        private String _LicenciaServidor;
        private String _TipoServidorBD;
        private String _BDUser;
        private String _BDPass;       
        private String _Usuario;
        private String _Password;


        public String Servidor
        {
            get { return _Servidor; }
            set { _Servidor = value; }
        }

        public String TipoServidorBD
        {
            get { return _TipoServidorBD; }
            set { _TipoServidorBD = value; }
        }

        public String BaseDatos
        {
            get { return _BaseDatos; }
            set { _BaseDatos = value; }
        }

        public String LicenciaServidor
        {
            get { return _LicenciaServidor; }
            set { _LicenciaServidor = value; }
        }
            
        public String BDUser
        {
            get { return _BDUser; }
            set { _BDUser = value; }
        }

        public String BDPass
        {
            get { return _BDPass; }
            set { _BDPass = value; }
        }       

        public String Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public String Password
        {
            get { return _Password; }
            set { _Password = value; }
        }  
           
    }

    public class BEPCSAPList : List<BEPCSAP>, ICloneable
    {
        public BEPCSAPList()
        {
        }

        private BEPCSAPList(BEPCSAPList listaMembers)
        {
            foreach (BEPCSAP beValor in listaMembers)
            {
                this.Add(beValor);
            }
        }

        public object Clone()
        {
            return new BEPCSAPList(this);
        }

    }
}
