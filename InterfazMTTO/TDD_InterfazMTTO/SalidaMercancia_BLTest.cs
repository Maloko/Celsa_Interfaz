using InterfazMTTO.iSBO_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InterfazMTTO.iSBO_BE;

namespace TDD_InterfazMTTO
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para SalidaMercancia_BLTest y se pretende que
    ///contenga todas las pruebas unitarias SalidaMercancia_BLTest.
    ///</summary>
    [TestClass()]
    public class SalidaMercancia_BLTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        #region TestRegistraSalidaMercancia

        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia enviando un Codigo de Articulo en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest001()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("23/07/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;
            IGE1_1.CCosto1 = "AZUL";
            IGE1_1.CCosto2 = "UNMQCHUN";

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "El Codigo de Articulo se encuentra vacio.";
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia enviando un Almacen de Salida en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest002()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("23/07/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "El Almacén de Salida se encuentra vacio.";
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia enviando una cantidad de salida en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest003()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("23/07/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 0;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "La cantidad de salida se encuentra vacia.";
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia enviando una fecha de documento en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest004()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime(null);
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "La Fecha del Documento se encuentra vacio.";
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia enviando una fecha del documento menor a la actual.
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest005()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("01/08/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "La Fecha del Documento es menor a la fecha actual.";
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia enviando un tipo de operacion en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest006()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("06/08/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "El Tipo de Operación se encuentra vacio.";
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia enviando una cuenta contable en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest007()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("06/08/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "";
            IGE1_1.NroLineaOrdenTrabajo = 1;

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "La Cuenta Contable se encuentra vacia.";
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }



        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia sin conexion a SAP (Error: 992)
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest008()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("08/08/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSalidaMercancia produciendose un error interno en el sistema (Error: 999)
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest009()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("08/08/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;

            IGE1.Add(IGE1_1);

            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";
            BEIGE1List actual;            
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        /// <summary>
        ///Una prueba de exito de RegistraSalidaMercancia
        ///</summary>
        [TestMethod()]
        public void RegistraSalidaMercanciaTest010()
        {
            BEOIGE OIGE = new BEOIGE();
            BEIGE1List IGE1 = new BEIGE1List();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();

            OIGE.FechaSolicitud = Convert.ToDateTime("08/08/2014");
            OIGE.NroOrdenTrabajo = "OT0006";
            OIGE.NroSolicitudTransferencia = 1679;

            BEIGE1 IGE1_1 = new BEIGE1();

            IGE1_1.CodigoArticulo = "SOLDA000008";
            IGE1_1.CantidadSalida = 1;
            IGE1_1.AlmacenSalida = "ALM.SM01";
            IGE1_1.TipoOperacion = "12";
            IGE1_1.CuentaContable = "93561101";
            IGE1_1.NroLineaOrdenTrabajo = 1;
            IGE1_1.CCosto1 = "AZUL";
            IGE1_1.CCosto2 = "UNMQCHUN";

            IGE1.Add(IGE1_1);
            
            BEIGE1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            //actual = SalidaMercancia_BL.RegistraSalidaMercancia(OIGE, IGE1, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        #endregion

    }
}
