using InterfazMTTO.iSBO_DA;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InterfazMTTO.iSBO_BE;

namespace TDD_InterfazMTTO
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para SolicitudTransferencia_DATest y se pretende que
    ///contenga todas las pruebas unitarias SolicitudTransferencia_DATest.
    ///</summary>
    [TestClass()]
    public class SolicitudTransferencia_DATest
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

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de RegistraSolicitudTransferencia
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT0004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("20/07/2014");
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "0902";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000004";
            WTQ1_1.CantidadSalida = 400;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSalida = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSalida = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);

            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.ResultadoRetorno = 0;
            int expected = 3; 

            BEWTQ1List actual;
            Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_DA.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.ResultadoRetorno, Respuesta.ResultadoRetorno);
            Assert.AreEqual(expected, actual.Count);            
        }
    }
}
