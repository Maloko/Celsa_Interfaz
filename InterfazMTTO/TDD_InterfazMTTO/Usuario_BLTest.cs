using InterfazMTTO.iSBO_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfazMTTO.iSBO_BE;
using InterfazMTTO.iSBO_DA;

namespace TDD_InterfazMTTO
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para Usuario_BLTest y se pretende que
    ///contenga todas las pruebas unitarias Usuario_BLTest.
    ///</summary>
    [TestClass()]
    public class Usuario_BLTest
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

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Usuario_DA.Conecta_Temp();
        }

        /// <summary>
        ///Una prueba de DesconectaUsuario
        ///</summary>
        [TestMethod()]
        public void DesconectaUsuarioTest()
        {
            BERPTA expected = null; // TODO: Inicializar en un valor adecuado
            BERPTA actual;
            actual = Usuario_BL.DesconectaUsuario();
            Assert.AreEqual(expected, actual);            
        }

        /// <summary>
        ///Una prueba de ListarUsuarios
        ///</summary>
        [TestMethod()]
        public void ListarUsuariosTest()
        {
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            int expected = 58;
            BEOUSRList actual;            
            actual = Usuario_BL.ListarUsuarios(ref Respuesta);
            Assert.AreEqual(RespuestaExpected.ResultadoRetorno, Respuesta.ResultadoRetorno);
            Assert.AreEqual(expected, actual.Count);            
        }

        /// <summary>
        ///Una prueba de ValidaUsuario
        ///</summary>
        [TestMethod()]
        public void ValidaUsuarioTest()
        {
            BEOUSR OUSR = new BEOUSR();
            BEPCSAP ParametrosConexion = new BEPCSAP();
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEOUSR expected = new BEOUSR();
            BEOUSR actual;

            ParametrosConexion.Servidor = "MGRAU";
            ParametrosConexion.BaseDatos = "SBO_INNTEC";
            ParametrosConexion.LicenciaServidor = "192.168.1.6:30000";
            ParametrosConexion.TipoServidorBD = "dst_MSSQL2008";
            ParametrosConexion.BDUser = "sa";
            ParametrosConexion.BDPass = "B1Admin";
            OUSR.CodigoUsuario = "manager";
            OUSR.Clave = "sbosap";
            expected.RespuestaValidacion = "Y";

            actual = Usuario_BL.ValidaUsuario(OUSR, ParametrosConexion, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.ResultadoRetorno, Respuesta.ResultadoRetorno);
            Assert.AreEqual(expected.RespuestaValidacion, actual.RespuestaValidacion);            
        }

        /// <summary>
        ///Una prueba de ValidaSociedad
        ///</summary>
        [TestMethod()]
        public void ValidaSociedadTest()
        {
            string ruc = "20492912302";
            string razonsocial = "SUPERMAQ SAC";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            bool expected = true; 
            bool actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Usuario_BL.ValidaSociedad(ruc, razonsocial, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.ResultadoRetorno, Respuesta.ResultadoRetorno);
            Assert.AreEqual(expected, actual);                   
        }
    }
}
