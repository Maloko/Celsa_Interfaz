using InterfazMTTO.iSBO_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfazMTTO.iSBO_BE;

namespace TDD_InterfazMTTO
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para OrdenCompra_BLTest y se pretende que
    ///contenga todas las pruebas unitarias OrdenCompra_BLTest.
    ///</summary>
    [TestClass()]
    public class OrdenCompra_BLTest
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


        #region TestActualizaOrdenCompra

        /// <summary>
        ///Una prueba de error de ActualizaOrdenesCompra enviando el parametro NroOrdenCompra en blanco.
        ///</summary>
        [TestMethod()]
        public void ActualizaOrdenesCompraTest001()
        {
            int NroOrdenCompra = 0;
            string NroOrdenTrabajo = "OT0002";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "El Nro. Orden de Compra se encuentra vacio.";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = OrdenCompra_BL.ActualizaOrdenesCompra(NroOrdenCompra, NroOrdenTrabajo);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Una prueba de error de ActualizaOrdenesCompra enviando el parametro NroOrdenTrabajo en blanco.
        ///</summary>
        [TestMethod()]
        public void ActualizaOrdenesCompraTest002()
        {
            int NroOrdenCompra = 817;
            string NroOrdenTrabajo = "";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "El Nro. Orden de Trabajo se encuentra vacio.";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = OrdenCompra_BL.ActualizaOrdenesCompra(NroOrdenCompra, NroOrdenTrabajo);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ActualizaOrdenesCompra sin conexion a SAP (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ActualizaOrdenesCompraTest003()
        {
            int NroOrdenCompra = 817;
            string NroOrdenTrabajo = "OT0002";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            actual = OrdenCompra_BL.ActualizaOrdenesCompra(NroOrdenCompra, NroOrdenTrabajo);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ActualizaOrdenesCompra produciendose un error interno (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ActualizaOrdenesCompraTest004()
        {
            int NroOrdenCompra = 1502;
            string NroOrdenTrabajo = "OT0002";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";
            BERPTA actual;            
            actual = OrdenCompra_BL.ActualizaOrdenesCompra(NroOrdenCompra, NroOrdenTrabajo);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de ActualizaOrdenesCompra.
        ///</summary>
        [TestMethod()]
        public void ActualizaOrdenesCompraTest005()
        {
            int NroOrdenCompra = 1502;
            string NroOrdenTrabajo = "OT0002";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "Operacion OK";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = OrdenCompra_BL.ActualizaOrdenesCompra(NroOrdenCompra, NroOrdenTrabajo);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }

        #endregion


        #region TestConsultaOrdenCompra

        /// <summary>
        ///Una prueba de error de ConsultaOrdenesCompra enviando el parametro CodigoProveedor en blanco.
        ///</summary>
        [TestMethod()]
        public void ConsultaOrdenesCompraTest001()
        {
            string CodigoProveedor = "";
            string IndicadorAplicaMantenimiento = "Y";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();            
            BEOPORList actual;
            RespuestaExpected.DescripcionErrorUsuario = "El Codigo de Proveedor se encuentra vacio.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = OrdenCompra_BL.ConsultaOrdenesCompra(CodigoProveedor, IndicadorAplicaMantenimiento, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);                     
        }


        /// <summary>
        ///Una prueba de error de ConsultaOrdenesCompra enviando el parametro IndicadorAplicaMantenimiento en blanco.
        ///</summary>
        [TestMethod()]
        public void ConsultaOrdenesCompraTest002()
        {
            string CodigoProveedor = "PL20510800410";
            string IndicadorAplicaMantenimiento = "";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOPORList actual;
            RespuestaExpected.DescripcionErrorUsuario = "El Indicador de Mantenimiento se encuentra vacio.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = OrdenCompra_BL.ConsultaOrdenesCompra(CodigoProveedor, IndicadorAplicaMantenimiento, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ConsultaOrdenesCompra enviando el parametro IndicadorAplicaMantenimiento con un valor 
        ///incorrecto.
        ///</summary>
        [TestMethod()]
        public void ConsultaOrdenesCompraTest003()
        {
            string CodigoProveedor = "PL20510800410";
            string IndicadorAplicaMantenimiento = "A";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOPORList actual;
            RespuestaExpected.DescripcionErrorUsuario = "El Indicador de Mantenimiento no es correcto de acuerdo a los valores permitidos (Y/N).";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = OrdenCompra_BL.ConsultaOrdenesCompra(CodigoProveedor, IndicadorAplicaMantenimiento, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ConsultaOrdenesCompra sin conexion a SAP (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ConsultaOrdenesCompraTest004()
        {
            string CodigoProveedor = "PL20510800410";
            string IndicadorAplicaMantenimiento = "Y";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOPORList actual;
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            actual = OrdenCompra_BL.ConsultaOrdenesCompra(CodigoProveedor, IndicadorAplicaMantenimiento, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ConsultaOrdenesCompra produciendose un error interno (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ConsultaOrdenesCompraTest005()
        {
            string CodigoProveedor = "PL20510800410";
            string IndicadorAplicaMantenimiento = "Y";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOPORList actual;
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";            
            actual = OrdenCompra_BL.ConsultaOrdenesCompra(CodigoProveedor, IndicadorAplicaMantenimiento, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ConsultaOrdenesCompra sin obtener resultados (Error: 993)
        ///</summary>
        [TestMethod()]
        public void ConsultaOrdenesCompraTest006()
        {
            string CodigoProveedor = "PL20510800410";
            string IndicadorAplicaMantenimiento = "N";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOPORList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "La consulta no obtuvo resultados.";
            actual = OrdenCompra_BL.ConsultaOrdenesCompra(CodigoProveedor, IndicadorAplicaMantenimiento, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de ConsultaOrdenesCompra
        ///</summary>
        [TestMethod()]
        public void ConsultaOrdenesCompraTest007()
        {
            string CodigoProveedor = "PL20510800410";
            string IndicadorAplicaMantenimiento = "Y";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOPORList actual;
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = OrdenCompra_BL.ConsultaOrdenesCompra(CodigoProveedor, IndicadorAplicaMantenimiento, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        #endregion

    }
}
