using InterfazMTTO.iSBO_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfazMTTO.iSBO_BE;

namespace TDD_InterfazMTTO
{        
    /// <summary>
    ///Se trata de una clase de prueba para Articulo_BLTest y se pretende que
    ///contenga todas las pruebas unitarias Articulo_BLTest.
    ///</summary>
    [TestClass()]
    public class Articulo_BLTest
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


        # region TestListarArticulos

        /// <summary>
        ///Prueba de error de Listado de Articulos SAP enviando un parametro Tipo de Articulo que no existe de acuerdo 
        ///a los especificados (R,P,N,O,C). (Error:901)
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest001()
        {
            string TipoArticulo = "X";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "El Tipo de Articulo no existe.";            
            BEOITMList actual;
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Prueba de error de Listado de Articulos SAP enviando un parametro Tipo de Articulo en blanco (Error: 902)
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest002()
        {
            string TipoArticulo = "";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "El Tipo de Articulo se encuentra vacio.";             
            BEOITMList actual;
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Prueba de error Listado de Articulos SAP enviando un Tipo de Articulo pero no obteniendo resultados. (Error: 993)
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest003()
        {
            string TipoArticulo = "C";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "La consulta no obtuvo resultados.";           
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_MTTO();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Prueba de Listado de Articulos SAP enviando un Tipo de Articulo sin conexión a SAP. (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest004()
        {
            string TipoArticulo = "C";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";          
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();                            
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);           
        }


        /// <summary>
        ///Prueba de Listado de Articulos SAP enviando un Tipo de Articulo y produciendose un error interno. (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest005()
        {
            string TipoArticulo = "C";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";            
            BEOITMList actual;
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto
        ///de Articulos de Tipo "C".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest006()
        {
            string TipoArticulo = "C";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 354;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "R".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest007()
        {
            string TipoArticulo = "R";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 159;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "O".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest008()
        {
            string TipoArticulo = "O";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 937;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "P".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest009()
        {
            string TipoArticulo = "P";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 133;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "N".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest010()
        {
            string TipoArticulo = "N";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 61;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "RC".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest011()
        {
            string TipoArticulo = "RC";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 513;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "RO".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest012()
        {
            string TipoArticulo = "RO";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 937;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "RP".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest013()
        {
            string TipoArticulo = "RP";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 292;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "RN".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest014()
        {
            string TipoArticulo = "RN";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 220;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "CO".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest015()
        {
            string TipoArticulo = "CO";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 937;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "CP".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest016()
        {
            string TipoArticulo = "CP";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 487;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "CN".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest017()
        {
            string TipoArticulo = "CN";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 415;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "OP".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest018()
        {
            string TipoArticulo = "OP";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 1070;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "ON".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest019()
        {
            string TipoArticulo = "ON";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 998;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }


        /// <summary>
        ///Prueba de exito de Listado de Articulos SAP enviando un Tipo de Articulo obteniendo un listado correcto 
        ///de Articulos de Tipo "PN".
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest020()
        {
            string TipoArticulo = "PN";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            int expected = 194;
            BEOITMList actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = Articulo_BL.ListarArticulos(TipoArticulo, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
            Assert.AreEqual(expected, actual.Count);
        }

        #endregion


        /// <summary>
        ///Una prueba de error ListarArticulos enviando un(os) Codigo(s) Articulo(s) en blanco. (Error: 903)
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest021()
        {
            string CodigoArticulo = "";
            string AlmacenSalida = "0100";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "El Codigo de Articulo se encuentra vacio.";            
            BEOITMList actual;
            actual = Articulo_BL.ListarArticulos(CodigoArticulo, AlmacenSalida, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }

        /// <summary>
        ///Una prueba de error ListarArticulos enviando un Almacen de Salida en blanco. (Error: 904)
        ///</summary>
        [TestMethod()]
        public void ListarArticulosTest022()
        {
            string CodigoArticulo = "AF31310200001|AF31310200002|AF31310200003|AF32320400001|AF32320400002|AF32320400003|AF32320400004|AF32320400005|AF32320400006|AF32320400007";
            string AlmacenSalida = "";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "El Almacén de Salida se encuentra vacio.";            
            BEOITMList actual;
            actual = Articulo_BL.ListarArticulos(CodigoArticulo, AlmacenSalida, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }
        

        

    }
}
