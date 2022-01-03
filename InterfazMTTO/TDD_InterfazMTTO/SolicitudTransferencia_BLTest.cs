using InterfazMTTO.iSBO_BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using InterfazMTTO.iSBO_BE;

namespace TDD_InterfazMTTO
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para SolicitudTransferencia_BLTest y se pretende que
    ///contenga todas las pruebas unitarias SolicitudTransferencia_BLTest.
    ///</summary>
    [TestClass()]
    public class SolicitudTransferencia_BLTest
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


        #region TestActualizaSolicitudTransferencia

        /// <summary>
        ///Una prueba de error de ActualizarSolicitudTransferencia enviando la Fecha del Documento en blanco.
        ///</summary>
        [TestMethod()]
        public void ActualizarSolicitudTransferenciaTest001()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.Estado = "U";
            OWTQ.NroSolicitudTransferencia = 1;
            OWTQ.FechaSolicitud = Convert.ToDateTime(null);
            OWTQ.Comentarios = "Actualizacion 30/07";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "La Fecha del Documento se encuentra vacio.";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.ActualizarSolicitudTransferencia(OWTQ);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Una prueba de error de ActualizarSolicitudTransferencia enviando el Nro. Solicitud de Transferencia en blanco.
        ///</summary>
        [TestMethod()]
        public void ActualizarSolicitudTransferenciaTest002()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.Estado = "U";
            OWTQ.NroSolicitudTransferencia = 0;
            OWTQ.FechaSolicitud = Convert.ToDateTime("30/07/2014");
            OWTQ.Comentarios = "Actualizacion 30/07";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "El Nro. Solicitud de Transferencia se encuentra vacio.";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.ActualizarSolicitudTransferencia(OWTQ);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ActualizarSolicitudTransferencia sin conexion a SAP.
        ///</summary>
        [TestMethod()]
        public void ActualizarSolicitudTransferenciaTest003()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.Estado = "U";
            OWTQ.NroSolicitudTransferencia = 1;
            OWTQ.FechaSolicitud = Convert.ToDateTime("30/07/2014");
            OWTQ.Comentarios = "Actualizacion 30/07";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            actual = SolicitudTransferencia_BL.ActualizarSolicitudTransferencia(OWTQ);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ActualizarSolicitudTransferencia produciendose un error interno del sistema.
        ///</summary>
        [TestMethod()]
        public void ActualizarSolicitudTransferenciaTest004()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.Estado = "U";
            OWTQ.NroSolicitudTransferencia = 1;
            OWTQ.FechaSolicitud = Convert.ToDateTime("30/07/2014");
            OWTQ.Comentarios = "Actualizacion 30/07";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";
            BERPTA actual;            
            actual = SolicitudTransferencia_BL.ActualizarSolicitudTransferencia(OWTQ);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de ActualizarSolicitudTransferencia.
        ///</summary>
        [TestMethod()]
        public void ActualizarSolicitudTransferenciaTest005()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.Estado = "U";
            OWTQ.NroSolicitudTransferencia = 1;
            OWTQ.FechaSolicitud = Convert.ToDateTime("30/07/2014");
            OWTQ.Comentarios = "Actualizacion 30/07";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "Operacion OK";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();                
            actual = SolicitudTransferencia_BL.ActualizarSolicitudTransferencia(OWTQ);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de ActualizarSolicitudTransferencia cancelando la Solicitud de Transferencia existente.
        ///</summary>
        [TestMethod()]
        public void ActualizarSolicitudTransferenciaTest006()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.Estado = "C";
            OWTQ.NroSolicitudTransferencia = 1;
            OWTQ.FechaSolicitud = Convert.ToDateTime("30/07/2014");
            OWTQ.Comentarios = "Cancelacion 30/07";
            BERPTA expected = new BERPTA();
            expected.DescripcionErrorUsuario = "Operacion OK";
            BERPTA actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.ActualizarSolicitudTransferencia(OWTQ);
            Assert.AreEqual(expected.DescripcionErrorUsuario, actual.DescripcionErrorUsuario);
        }


        #endregion


        #region TestRegistraSolicitudTransferencia

        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia enviando un Codigo de Articulo en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest001()
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

            WTQ1_1.CodigoArticulo = "";
            WTQ1_1.CantidadSolicitada = 400;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Codigo de Articulo se encuentra vacio.";            
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);            
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia enviando un Almacen de Salida en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest002()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT0004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("20/07/2014");
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 400;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Almacén de Salida se encuentra vacio.";
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia enviando un Nro. Orden de Trabajo en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest003()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "";
            OWTQ.FechaSolicitud = Convert.ToDateTime("08/08/2014");
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "1006";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 400;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Nro. Orden de Trabajo se encuentra vacio.";
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia enviando una Fecha de Documento en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest004()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT004";
            OWTQ.FechaSolicitud = Convert.ToDateTime(null);
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "1006";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 400;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "La Fecha del Documento se encuentra vacio.";
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia enviando un Numero de Linea en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest005()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("30/07/2014");
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "1006";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 400;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 0;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Numero de Linea del documento se encuentra vacio.";
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia enviando una fecha menor a la actual.
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest006()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("20/07/2014");
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "1006";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 400;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "La Fecha del Documento es menor a la fecha actual.";
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia enviando una linea con una cantidad en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest007()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("20/07/2014");
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "1006";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 0;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "La cantidad solicitada se encuentra vacio.";
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia enviando el Almacen de Entrada en blanco.
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest008()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("20/07/2014");
            OWTQ.AlmacenEntrada = "";
            OWTQ.AlmacenSalida = "1006";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 10;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "El Almacen de Entrada se encuentra vacio.";
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia sin conexion a SAP. (Error: 992)
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest009()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("08/08/2014");
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "1006";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 10;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de RegistraSolicitudTransferencia produciendose un error interno del sistema (Error: 999)
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest010()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("08/08/2014");
            OWTQ.AlmacenEntrada = "1006";
            OWTQ.AlmacenSalida = "1006";
            OWTQ.Comentarios = "Prueba de Interfaz 21/07";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "IN02002000001";
            WTQ1_1.CantidadSolicitada = 10;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "IN02002000003";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "IN02002000002";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";
            BEWTQ1List actual;            
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de RegistraSolicitudTransferencia
        ///</summary>
        [TestMethod()]
        public void RegistraSolicitudTransferenciaTest011()
        {
            BEOWTQ OWTQ = new BEOWTQ();
            OWTQ.NroOrdenTrabajo = "OT004";
            OWTQ.FechaSolicitud = Convert.ToDateTime("25/09/2014");
            OWTQ.AlmacenEntrada = "ALM.SM01";
            OWTQ.AlmacenSalida = "ALM.SM01";
            OWTQ.Comentarios = "Prueba de Interfaz 06/08";

            BEWTQ1List WTQ1List = new BEWTQ1List();
            BEWTQ1 WTQ1_1 = new BEWTQ1();
            BEWTQ1 WTQ1_2 = new BEWTQ1();
            BEWTQ1 WTQ1_3 = new BEWTQ1();

            WTQ1_1.CodigoArticulo = "COMB0000001";
            WTQ1_1.CantidadSolicitada = 10;
            WTQ1_1.TipoOperacion = "11";
            WTQ1_1.NroLinea = 1;            
            WTQ1_1.NroOrdenTrabajo = "OT0004";


            WTQ1_2.CodigoArticulo = "0100002";
            WTQ1_2.CantidadSolicitada = 200;
            WTQ1_2.TipoOperacion = "11";
            WTQ1_2.NroLinea = 2;
            WTQ1_1.CCosto1 = "VOLQ 12";
            WTQ1_1.CCosto2 = "UNADMYFI";            
            WTQ1_2.NroOrdenTrabajo = "OT0004";

            WTQ1_3.CodigoArticulo = "0100003";
            WTQ1_3.CantidadSolicitada = 50;
            WTQ1_3.TipoOperacion = "11";
            WTQ1_3.NroLinea = 3;
            WTQ1_3.NroOrdenTrabajo = "OT0004";

            WTQ1List.Add(WTQ1_1);
            WTQ1List.Add(WTQ1_2);
            WTQ1List.Add(WTQ1_3);


            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            BEWTQ1List actual;            
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.RegistraSolicitudTransferencia(OWTQ, WTQ1List, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        #endregion


        #region TestObtenerSolicitudTransferencia

        /// <summary>
        ///Una prueba de error del metodo ObtenerTransferencia enviando un Numero de Solicitud de Transferencia vacio.
        ///</summary>
        [TestMethod()]
        public void ObtenerSolicitudTransferenciaTest001()
        {
            int NroSolicitudTransferencia = 0;
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();            
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "El Nro. Solicitud de Transferencia se encuentra vacio.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.ObtenerSolicitudTransferencia(NroSolicitudTransferencia, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);                   
        }


        /// <summary>
        ///Una prueba de error del metodo ObtenerTransferencia sin conexion a SAP (Error 992)
        ///</summary>
        [TestMethod()]
        public void ObtenerSolicitudTransferenciaTest002()
        {
            int NroSolicitudTransferencia = 1;
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            actual = SolicitudTransferencia_BL.ObtenerSolicitudTransferencia(NroSolicitudTransferencia, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error del metodo ObtenerTransferencia sin resultados de la consulta (Error 993)
        ///</summary>
        [TestMethod()]
        public void ObtenerSolicitudTransferenciaTest003()
        {
            int NroSolicitudTransferencia = 999;
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "La consulta no obtuvo resultados.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.ObtenerSolicitudTransferencia(NroSolicitudTransferencia, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        /// <summary>
        ///Una prueba de error del metodo ObtenerTransferencia produciendose un error interno del sistema (Error 999)
        ///</summary>
        [TestMethod()]
        public void ObtenerSolicitudTransferenciaTest004()
        {
            int NroSolicitudTransferencia = 999;
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";            
            actual = SolicitudTransferencia_BL.ObtenerSolicitudTransferencia(NroSolicitudTransferencia, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        /// <summary>
        ///Una prueba de exito del metodo ObtenerTransferencia
        ///</summary>
        [TestMethod()]
        public void ObtenerSolicitudTransferenciaTest005()
        {
            int NroSolicitudTransferencia = 1;
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.ObtenerSolicitudTransferencia(NroSolicitudTransferencia, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }

        #endregion


        #region TestObtenerTransferencia

        /// <summary>
        ///Una prueba de error de ObtenerTransferencia enviando el parametro NroOT en blanco.
        ///</summary>
        [TestMethod()]
        public void ObtenerTransferenciaTest001()
        {
            string NroOT = "";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();            
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "El Nro. Orden de Trabajo se encuentra vacio.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.ObtenerTransferencia(NroOT, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ObtenerTransferencia sin conexion a SAP. (Error: 992)
        ///</summary>
        [TestMethod()]
        public void ObtenerTransferenciaTest002()
        {
            string NroOT = "OT0004";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error en la operación. Error SAP SDK: La sociedad no esta conectada";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp_Error();
            actual = SolicitudTransferencia_BL.ObtenerTransferencia(NroOT, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ObtenerTransferencia sin conexion a SAP. (Error: 993)
        ///</summary>
        [TestMethod()]
        public void ObtenerTransferenciaTest003()
        {
            string NroOT = "OT999";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "La consulta no obtuvo resultados.";
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            actual = SolicitudTransferencia_BL.ObtenerTransferencia(NroOT, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de error de ObtenerTransferencia produciendose un error interno. (Error: 999)
        ///</summary>
        [TestMethod()]
        public void ObtenerTransferenciaTest004()
        {
            string NroOT = "OT999";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEWTQ1List actual;
            RespuestaExpected.DescripcionErrorUsuario = "Se produjo un error interno del sistema.";          
            actual = SolicitudTransferencia_BL.ObtenerTransferencia(NroOT, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        /// <summary>
        ///Una prueba de exito de ObtenerTransferencia.
        ///</summary>
        [TestMethod()]
        public void ObtenerTransferenciaTest005()
        {
            string NroOT = "OT004";
            BERPTA Respuesta = new BERPTA();
            BERPTA RespuestaExpected = new BERPTA();
            BEWTQ1List actual;
            InterfazMTTO.iSBO_DA.Usuario_DA.Conecta_Temp();
            RespuestaExpected.DescripcionErrorUsuario = "Operacion OK";
            actual = SolicitudTransferencia_BL.ObtenerTransferencia(NroOT, ref Respuesta);
            Assert.AreEqual(RespuestaExpected.DescripcionErrorUsuario, Respuesta.DescripcionErrorUsuario);
        }


        #endregion


    }
}
