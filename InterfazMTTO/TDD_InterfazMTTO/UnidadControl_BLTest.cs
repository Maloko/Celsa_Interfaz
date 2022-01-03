using InterfazMTTO.iSBO_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfazMTTO.iSBO_BE;
using InterfazMTTO.iSBO_DA;


namespace TDD_InterfazMTTO
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para UnidadControl_BLTest y se pretende que
    ///contenga todas las pruebas unitarias UnidadControl_BLTest.
    ///</summary>
    [TestClass()]
    public class UnidadControl_BLTest
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

        #region TestListaTipoUnidadControl

        /// <summary>
        ///Una prueba de error de ListaTipoUnidadControl sin conexión a SAP. (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ListaTipoUnidadControlTest001()
        {
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();            
            BETUDUCList actual;               
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error(); 
            actual = UnidadControl_BL.ListaTipoUnidadControl(ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);               
        }

        /// <summary>
        ///Una prueba de error de ListaTipoUnidadControl pero no obteniendo resultados. (Error: 993)
        ///</summary>
        [TestMethod()]
        public void ListaTipoUnidadControlTest002()
        {
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BETUDUCList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_MTTO();
            RespuestaExpected.DescripcionErrorUsuario = "La consulta no obtuvo resultados.";
            actual = UnidadControl_BL.ListaTipoUnidadControl(ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        /// <summary>
        ///Una prueba de error de ListaTipoUnidadControl y produciendose un error interno. (Error: 999) 
        ///</summary>
        [TestMethod()]
        public void ListaTipoUnidadControlTest003()
        {
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BETUDUCList actual;            
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";
            actual = UnidadControl_BL.ListaTipoUnidadControl(ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        /// <summary>
        ///Una prueba de exito de ListaTipoUnidadControl.
        ///</summary>
        [TestMethod()]
        public void ListaTipoUnidadControlTest004()
        {
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BETUDUCList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 5;
            actual = UnidadControl_BL.ListaTipoUnidadControl(ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }

        #endregion

        #region TestListaUnidadControlxTipo

        /// <summary>
        ///Una prueba de error de ListaUnidadControlxTipo sin conexion a SAP. (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlxTipoTest001()
        {
            string TipoUnidadControl = "B2K868";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error(); 
            BEUDUCList actual;
            actual = UnidadControl_BL.ListaUnidadControlxTipo(TipoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);                      
        }


        /// <summary>
        ///Una prueba de error de ListaUnidadControlxTipo pero no obteniendo resultados. (Error: 993)
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlxTipoTest002()
        {
            string TipoUnidadControl = "B2K868";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_MTTO();
            RespuestaExpected.DescripcionErrorUsuario = "La consulta no obtuvo resultados.";
            BEUDUCList actual;
            actual = UnidadControl_BL.ListaUnidadControlxTipo(TipoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ListaUnidadControlxTipo y produciendose un error interno. (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlxTipoTest003()
        {
            string TipoUnidadControl = "B2K868";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();            
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";
            BEUDUCList actual;
            actual = UnidadControl_BL.ListaUnidadControlxTipo(TipoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de ListaUnidadControlxTipo
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlxTipoTest004()
        {
            string TipoUnidadControl = "A";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            BEUDUCList actual;
            actual = UnidadControl_BL.ListaUnidadControlxTipo(TipoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ListaUnidadControlxTipo cuando se envia el TipoUnidadControl en blanco.
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlxTipoTest005()
        {
            string TipoUnidadControl = "";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Tipo de Unidad de Control se encuentra vacio.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            BEUDUCList actual;
            actual = UnidadControl_BL.ListaUnidadControlxTipo(TipoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        #endregion

        #region TestListaUnidadControl


        /// <summary>
        ///Una prueba de ListaUnidadControl sin conexión a SAP. (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlTest001()
        {
            string ListCodigoUnidadControl = "B7S943|B7S947|C1N778|C3X700|DOA889|RECOGE|T5Z914|ASAD#@|DSFEQ@#";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();            
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";                   
            BEUDUCList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error(); 
            actual = UnidadControl_BL.ListaUnidadControl(ListCodigoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);                        
        }


        /// <summary>
        ///Una prueba de ListaUnidadControl y produciendose un error interno. (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlTest002()
        {
            string ListCodigoUnidadControl = "B7S943|B7S947|C1N778|C3X700|DOA889|RECOGE|T5Z914|ASAD#@|DSFEQ@#";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();            
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";
            BEUDUCList actual;            
            actual = UnidadControl_BL.ListaUnidadControl(ListCodigoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Una prueba de exito de ListaUnidadControl
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlTest003()
        {
            string ListCodigoUnidadControl = "A3U998|A4P970|A4Z971|A5V941|A6O986|A6O998|A7F986|ASAD#@|DSFEQ@#";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";            
            BEUDUCList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = UnidadControl_BL.ListaUnidadControl(ListCodigoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Una prueba de error de ListaUnidadControl enviando el parametro ListCodigoUnidadControl en blanco.
        ///</summary>
        [TestMethod()]
        public void ListaUnidadControlTest004()
        {
            string ListCodigoUnidadControl = "";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Codigo de la Unidad de Control se encuentra vacio.";            
            BEUDUCList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = UnidadControl_BL.ListaUnidadControl(ListCodigoUnidadControl, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        #endregion

        #region TestActualizaIndicadorExistencia

        /// <summary>
        ///Una prueba de error del metodo ActualizaIndicadorExistencia enviando el CodigoUnidadControl en blanco.
        ///</summary>
        [TestMethod()]
        public void ActualizaIndicadorExistenciaTest001()
        {
            BEUDUC UDUC = new BEUDUC();
            UDUC.CodigoUnidadControl = "";
            UDUC.IndicadorExistencia = "Y";
            BERPTA expected = new BERPTA();
            BERPTA actual;
            expected.DescripcionErrorUsuario = "El Codigo de la Unidad de Control se encuentra vacio.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = UnidadControl_BL.ActualizaIndicadorExistencia(UDUC);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error del metodo ActualizaIndicadorExistencia enviando el IndicadorExistencia en blanco.
        ///</summary>
        [TestMethod()]
        public void ActualizaIndicadorExistenciaTest002()
        {
            BEUDUC UDUC = new BEUDUC();
            UDUC.CodigoUnidadControl = "#@$#@";
            UDUC.IndicadorExistencia = "";
            BERPTA expected = new BERPTA();
            BERPTA actual;
            expected.DescripcionErrorUsuario = "El Indicador de Existencia se encuentra vacio.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = UnidadControl_BL.ActualizaIndicadorExistencia(UDUC);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error del metodo ActualizaIndicadorExistencia cuando el IndicadorExistencia no existe.
        ///</summary>
        [TestMethod()]
        public void ActualizaIndicadorExistenciaTest003()
        {
            BEUDUC UDUC = new BEUDUC();
            UDUC.CodigoUnidadControl = "#@$#@";
            UDUC.IndicadorExistencia = "A";
            BERPTA expected = new BERPTA();
            BERPTA actual;
            expected.DescripcionErrorUsuario = "El Indicador de Existencia no es correcto de acuerdo a los valores permitidos (Y/N).";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = UnidadControl_BL.ActualizaIndicadorExistencia(UDUC);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error del metodo ActualizaIndicadorExistencia sin conexion a SAP. (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ActualizaIndicadorExistenciaTest004()
        {
            BEUDUC UDUC = new BEUDUC();
            UDUC.CodigoUnidadControl = "#@$#@";
            UDUC.IndicadorExistencia = "Y";
            BERPTA expected = new BERPTA();
            BERPTA actual;
            expected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error(); 
            actual = UnidadControl_BL.ActualizaIndicadorExistencia(UDUC);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error del metodo ActualizaIndicadorExistencia  produciendose un error interno. (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ActualizaIndicadorExistenciaTest005()
        {
            BEUDUC UDUC = new BEUDUC();
            UDUC.CodigoUnidadControl = "#@$#@";
            UDUC.IndicadorExistencia = "Y";
            BERPTA expected = new BERPTA();
            BERPTA actual;
            expected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";            
            actual = UnidadControl_BL.ActualizaIndicadorExistencia(UDUC);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);        
        }


        /// <summary>
        ///Una prueba de exito del metodo ActualizaIndicadorExistencia
        ///</summary>
        [TestMethod()]
        public void ActualizaIndicadorExistenciaTest006()
        {
            BEUDUC UDUC = new BEUDUC();
            UDUC.CodigoUnidadControl = "A1C785";
            UDUC.IndicadorExistencia = "Y";
            BERPTA expected = new BERPTA();
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            expected.DescripcionErrorUsuario = "Operacion OK";
            actual = UnidadControl_BL.ActualizaIndicadorExistencia(UDUC);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }

        #endregion

    }
}
