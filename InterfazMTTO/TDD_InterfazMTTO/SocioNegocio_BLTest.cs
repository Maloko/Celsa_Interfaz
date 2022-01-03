using InterfazMTTO.iSBO_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfazMTTO.iSBO_BE;

namespace TDD_InterfazMTTO
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para SocioNegocio_BLTest y se pretende que
    ///contenga todas las pruebas unitarias SocioNegocio_BLTest.
    ///</summary>
    [TestClass()]
    public class SocioNegocio_BLTest
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

        #region TestConsultaProveedor

        /// <summary>
        ///Una prueba de error de ConsultaProveedor enviando el parametro IndicadorProveedor en blanco.
        ///</summary>
        [TestMethod()]
        public void ConsultaProveedorTest001()
        {
            string IndicadorProveedor = "";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();            
            BEOCRDList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "El Indicador de Proveedor se encuentra vacio.";
            actual = SocioNegocio_BL.ConsultaProveedor(IndicadorProveedor, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);                        
        }


        /// <summary>
        ///Una prueba de error de ConsultaProveedor enviando el parametro IndicadorProveedor con un valor incorrecto.
        ///</summary>
        [TestMethod()]
        public void ConsultaProveedorTest002()
        {
            string IndicadorProveedor = "A";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOCRDList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "El Indicador de Proveedor no existe.";
            actual = SocioNegocio_BL.ConsultaProveedor(IndicadorProveedor, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ConsultaProveedor sin conexion a SAP (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ConsultaProveedorTest003()
        {
            string IndicadorProveedor = "Y";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOCRDList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            actual = SocioNegocio_BL.ConsultaProveedor(IndicadorProveedor, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ConsultaProveedor produciendose un error interno (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ConsultaProveedorTest004()
        {
            string IndicadorProveedor = "Y";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOCRDList actual;
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";
            actual = SocioNegocio_BL.ConsultaProveedor(IndicadorProveedor, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ConsultaProveedor sin obtener resultados (Error: 993)
        ///</summary>
        [TestMethod()]
        public void ConsultaProveedorTest005()
        {
            string IndicadorProveedor = "Y";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOCRDList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_MTTO();
            RespuestaExpected.DescripcionErrorUsuario = "La consulta no obtuvo resultados.";
            actual = SocioNegocio_BL.ConsultaProveedor(IndicadorProveedor, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de ConsultaProveedor enviando el IndicadorProveedor con valor Y
        ///</summary>
        [TestMethod()]
        public void ConsultaProveedorTest006()
        {
            string IndicadorProveedor = "Y";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOCRDList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            actual = SocioNegocio_BL.ConsultaProveedor(IndicadorProveedor, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de ConsultaProveedor enviando el IndicadorProveedor con valor N
        ///</summary>
        [TestMethod()]
        public void ConsultaProveedorTest007()
        {
            string IndicadorProveedor = "N";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOCRDList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            actual = SocioNegocio_BL.ConsultaProveedor(IndicadorProveedor, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        #endregion

    }
}
