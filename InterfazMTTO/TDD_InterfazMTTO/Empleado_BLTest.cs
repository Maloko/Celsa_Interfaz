using InterfazMTTO.iSBO_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfazMTTO.iSBO_BE;

namespace TDD_InterfazMTTO
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para Empleado_BLTest y se pretende que
    ///contenga todas las pruebas unitarias Empleado_BLTest.
    ///</summary>
    [TestClass()]
    public class Empleado_BLTest
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

        #region TestListaEmpleado

        /// <summary>
        ///Una prueba de error del metodo ListaEmpleado enviando como parametro TipoPersona un valor inexistente. (Error: 906)
        ///</summary>
        [TestMethod()]
        public void ListaEmpleadoTest001()
        {
            string TipoPersona = "A";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Tipo de Persona no existe.";            
            BEOHEMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Empleado_BL.ListaEmpleado(TipoPersona, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);                  
        }


        /// <summary>
        ///Una prueba de error del metodo ListaEmpleado enviando como parametro TipoPersona un valor en blanco. (Error: 907)
        ///</summary>
        [TestMethod()]
        public void ListaEmpleadoTest002()
        {
            string TipoPersona = "";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Tipo de Persona se encuentra vacio.";
            BEOHEMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Empleado_BL.ListaEmpleado(TipoPersona, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito del metodo ListaEmpleado enviando como parametro TipoPersona el valor R (Responsable)
        ///</summary>
        [TestMethod()]
        public void ListaEmpleadoTest003()
        {
            string TipoPersona = "R";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            BEOHEMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Empleado_BL.ListaEmpleado(TipoPersona, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito del metodo ListaEmpleado enviando como parametro TipoPersona el valor S (Solicitante)
        ///</summary>
        [TestMethod()]
        public void ListaEmpleadoTest004()
        {
            string TipoPersona = "S";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            BEOHEMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Empleado_BL.ListaEmpleado(TipoPersona, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error del metodo ListaEmpleado cuando no se obtienen resultados (Error: 993)
        ///</summary>
        [TestMethod()]
        public void ListaEmpleadoTest005()
        {
            string TipoPersona = "S";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "La consulta no obtuvo resultados.";
            BEOHEMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_MTTO();
            actual = Empleado_BL.ListaEmpleado(TipoPersona, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        /// <summary>
        ///Una prueba de error del metodo ListaEmpleado sin conexión a SAP (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ListaEmpleadoTest006()
        {
            string TipoPersona = "S";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";          
            BEOHEMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            actual = Empleado_BL.ListaEmpleado(TipoPersona, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error del metodo ListaEmpleado produciendose un error interno (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ListaEmpleadoTest007()
        {
            string TipoPersona = "S";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";    
            BEOHEMList actual;            
            actual = Empleado_BL.ListaEmpleado(TipoPersona, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        #endregion

    }
}
