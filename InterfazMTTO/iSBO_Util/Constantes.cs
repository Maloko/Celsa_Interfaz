namespace InterfazMTTO.iSBO_Util
{
    public class Constantes
    {
        /* Declaración de Stored Procedures a utilizar */

        public static readonly string SP_LISTA_ARTICULOS_SAP = "VS_SP_ListaArticulosSAP";//
        public static readonly string SP_VERIFICA_STOCK_EXISTENCIA_SAP = "VS_SP_VerificaStockExistenciaSAP";//
        public static readonly string SP_LISTA_UNIDAD_CONTROL_SAP = "VS_SP_ObtieneUnidadesControlSAP";//
        public static readonly string SP_LISTA_TIPO_UNIDAD_CONTROL_SAP = "VS_SP_ListaTipoUnidadControlSAP";//
        public static readonly string SP_LISTA_UNIDAD_CONTROL_X_TIPO_SAP = "VS_SP_ListaUnidadControlxTipoSAP";//
        public static readonly string SP_OBTIENE_SOLICITUD_TRANSFERENCIA_SAP = "VS_SP_ObtieneSolicitudTransferenciaSAP";//
        public static readonly string SP_OBTIENE_TRANSFERENCIA_SAP = "VS_SP_ObtieneTransferenciaSAP";//
        public static readonly string SP_OBTIENE_SALIDA_MERCANCIA_SAP = "VS_SP_ObtieneSalidaMercanciaSAP";//
        public static readonly string SP_LISTA_ORDENES_COMPRA_SAP = "VS_SP_ListaOrdenesCompraSAP";//
        public static readonly string SP_LISTA_PROVEEDORES_MANTENIMIENTO_SAP = "VS_SP_ListaProveedoresMantenimientoSAP";//
        public static readonly string SP_LISTA_USUARIOS_SAP = "VS_SP_ListaUsuariosSAP";//
        public static readonly string SP_LISTA_EMPLEADOS_SAP = "VS_SP_ListaPersonasxTipoSAP";//

        /* Declaración de valores asociados a parametros */

        public static readonly string P_STATUSDOCCANCEL = "C";
        public static readonly string P_STATUSDOCUPDATE = "U";
        public static readonly string P_TIPO_ARTICULO_REPUESTO = "R";
        public static readonly string P_TIPO_ARTICULO_CONSUMIBLE = "C";
        public static readonly string P_TIPO_ARTICULO_NEUMATICO = "N";
        public static readonly string P_TIPO_ARTICULO_COMPONENTE = "P";
        public static readonly string P_TIPO_ARTICULO_REPUESTOCOMPONENTE = "O";

        public static readonly string P_TIPO_OPERACION_1 = "1";
        public static readonly string P_TIPO_OPERACION_2 = "2";
        public static readonly string P_TIPO_OPERACION_3 = "3";
        public static readonly string P_TIPO_OPERACION_4 = "4";

        public static readonly string P_INDICADOR_EXISTENCIA_SI = "Y";
        public static readonly string P_INDICADOR_EXISTENCIA_NO = "N";

        public static readonly string P_INDICADOR_APLICA_MANTENIMIENTO_SI = "Y";
        public static readonly string P_INDICADOR_APLICA_MANTENIMIENTO_NO = "N";

        public static readonly string P_INDICADOR_PROVEEDOR_SI = "Y";
        public static readonly string P_INDICADOR_PROVEEDOR_NO = "N";

        public static readonly string P_TIPO_PERSONA_SOLICITANTE = "S";
        public static readonly string P_TIPO_PERSONA_RESPONSABLE = "R";        

        public static readonly string P_RESPUESTA_VALIDACION_SI = "Y";
        public static readonly string P_RESPUESTA_VALIDACION_NO = "N";

        public static readonly int P_VALOR_INICIO_RESULT = 1000;
        public static readonly int P_VALOR_RESULT_0 = 0;
        public static readonly int P_VALOR_RESULT_1 = 1;
        public static readonly int P_VALOR_RESULT_NEGATIVO_1 = -1;
        public static readonly int P_VALOR_RESULT_NEGATIVO_2 = -2;
        public static readonly int P_VALOR_RESULT_NEGATIVO_3 = -3;
        public static readonly int P_VALOR_RESULT_NEGATIVO_9 = -9;

        public static readonly int P_VALOR_RESULT_901 = 901;
        public static readonly int P_VALOR_RESULT_902 = 902;
        public static readonly int P_VALOR_RESULT_903 = 903;
        public static readonly int P_VALOR_RESULT_904 = 904;
        public static readonly int P_VALOR_RESULT_905 = 905;
        public static readonly int P_VALOR_RESULT_906 = 906;
        public static readonly int P_VALOR_RESULT_907 = 907;
        public static readonly int P_VALOR_RESULT_908 = 908;
        public static readonly int P_VALOR_RESULT_909 = 909;
        public static readonly int P_VALOR_RESULT_910 = 910;
        public static readonly int P_VALOR_RESULT_911 = 911;
        public static readonly int P_VALOR_RESULT_912 = 912;
        public static readonly int P_VALOR_RESULT_913 = 913;
        public static readonly int P_VALOR_RESULT_914 = 914;
        public static readonly int P_VALOR_RESULT_915 = 915;
        public static readonly int P_VALOR_RESULT_916 = 916;
        public static readonly int P_VALOR_RESULT_917 = 917;
        public static readonly int P_VALOR_RESULT_918 = 918;
        public static readonly int P_VALOR_RESULT_919 = 919;
        public static readonly int P_VALOR_RESULT_920 = 920;
        public static readonly int P_VALOR_RESULT_921 = 921;
        public static readonly int P_VALOR_RESULT_922 = 922;
        public static readonly int P_VALOR_RESULT_923 = 923;
        public static readonly int P_VALOR_RESULT_924 = 924;
        public static readonly int P_VALOR_RESULT_925 = 925;
        public static readonly int P_VALOR_RESULT_926 = 926;
        public static readonly int P_VALOR_RESULT_927 = 927;
        public static readonly int P_VALOR_RESULT_928 = 928;
        public static readonly int P_VALOR_RESULT_929 = 929;
        public static readonly int P_VALOR_RESULT_930 = 930;
        public static readonly int P_VALOR_RESULT_931 = 931;
        public static readonly int P_VALOR_RESULT_932 = 932;
        public static readonly int P_VALOR_RESULT_992 = 992;
        public static readonly int P_VALOR_RESULT_933 = 933;
        #region CAMBIO_REQ_NRO2
        public static readonly int P_VALOR_RESULT_993 = 993;
        #endregion

        /* Campos de Personas */
        public static readonly string P_CODIGOPERSONA = "CodigoPersona";
        public static readonly string P_NOMBREPERSONA = "NombrePersona";
        public static readonly string P_TIPOPERSONA = "TipoPersona";
        public static readonly string P_COSTOHORAHOMBREPERSONA = "CostoHoraHombre";

        /* Campos de Ordenes de Compra */
        public static readonly string P_NROORDENCOMPRA = "NroOrden";
        public static readonly string P_FECHAORDENCOMPRA = "FechaOrden";
        public static readonly string P_MONEDA = "Moneda";
        public static readonly string P_COSTOTOTAL = "CostoTotal";

        /* Campos de Proveedores */
        public static readonly string P_CODIGOPROVEEDOR = "CodigoProveedor";
        public static readonly string P_DESCRIPCIONPROVEEDOR = "DescripcionProveedor";
        public static readonly string P_RUCPROVEEDOR = "RucProveedor";

        /* Campos de Usuarios */
        public static readonly string P_CODIGOUSUARIO = "CodigoUsuario";
        public static readonly string P_DESCRIPCIONUSUARIO = "DescripcionUsuario";
        public static readonly string P_NOMBRESUSUARIO = "Nombres";
        public static readonly string P_APELLIDOSUSUARIO = "Apellidos";
        public static readonly string P_CORREOUSUARIO = "Correo";
        public static readonly string P_DEPARTMENTUSUARIO = "Department";

        /* Campos de Articulos */
        public static readonly string P_CODIGOARTICULO = "CodigoArticulo";
        public static readonly string P_DESCRIPCIONARTICULO = "DescripcionArticulo";
        public static readonly string P_BLOQUEADO = "Bloqueado";
        public static readonly string P_CANTIDADDISPONIBLE = "CantidadDisponible";
        public static readonly string P_TIPOARTICULO = "TipoArticulo";
        public static readonly string P_COSTOARTICULO = "CostoArticulo";

        /* Campos de Unidad de Control */

        public static readonly string P_CODIGOUC = "CodigoUnidadControl";
        public static readonly string P_PLACASERIEUC = "PlacaSerie";
        public static readonly string P_CODIGOMARCA = "CodigoMarca";
        public static readonly string P_MARCA = "Marca";
        public static readonly string P_CODIGOMODELO = "CodigoModelo";
        public static readonly string P_MODELO = "Modelo";
        public static readonly string P_ANIO = "Anio";
        public static readonly string P_CODIGOFAMILIA = "CodigoFamilia";
        public static readonly string P_FAMILIA = "Familia";
        public static readonly string P_CODIGOSUBFAMILIA = "CodigoSubFamilia";
        public static readonly string P_SUBFAMILIA = "SubFamilia";
        public static readonly string P_CODIGOLINEANEGOCIO = "CodigoLineaNegocio";
        public static readonly string P_LINEANEGOCIO = "LineaNegocio";
        public static readonly string P_PROPIETARIO = "Propietario";
        public static readonly string P_CONFIGURACION = "Configuracion";
        public static readonly string P_TIPOPROPIEDAD = "TipoPropiedad";
        public static readonly string P_TIPOUNIDAD = "TipoUnidad";
        public static readonly string P_CODTIPOUNIDAD = "CodigoTipoUnidad";
        public static readonly string P_DESTIPOUNIDAD = "DescripcionTipoUnidad";
        public static readonly string P_CENTROCOSTO1 = "CentroCosto1";
        public static readonly string P_CENTROCOSTO2 = "CentroCosto2";
        public static readonly string P_CENTROCOSTO3 = "CentroCosto3";
        public static readonly string P_CENTROCOSTO4 = "CentroCosto4";
        public static readonly string P_CENTROCOSTO5 = "CentroCosto5";


        public static readonly string C_INDICADOREXISTENCIA = "U_VS_MNTTO";
         
        /* Campos de Solicitud de Transferencia */

        public static readonly string P_NROSOLICITUDTRANSFERENCIA = "NroSolicitudTransferencia";
        public static readonly string P_NROORDENTRABAJO = "NroOrdenTrabajo";
        public static readonly string P_NROLINEA = "NroLineaSolicitudTransferencia";
        public static readonly string P_NROLINEAOT = "NroLineaOT";
        public static readonly string P_CANTIDADSOLICITADA = "CantidadSolicitada";
        public static readonly string P_CANTIDADTRANSFERIDA = "CantidadTransferida";
        public static readonly string P_COSTOUNITARIO = "CostoUnitario";

        public static readonly string C_NROORDENTRABAJO = "U_VS_ORDTRA";
        public static readonly string C_NROLINEAORDENTRABAJO = "U_VS_LINORDTRA";
        public static readonly string C_TIPOOPERACION = "U_tipoOpT12";

        /* Campos de Sociedad */

        public static readonly string P_COMPANY = "PrintHeadr";
        public static readonly string P_RUC = "TaxIdNum";

        /*Campos generales */

        public static readonly string P_RESPUESTAVALIDACION = "RespuestaValidacion";
        public static readonly string P_NROSALIDAMERCANCIA = "NroSalidaMercancia";
        public static readonly string P_NROLINEASALIDAMERCANCIA = "NroLineaSalidaMercancia";
        public static readonly string P_CANTIDADSALIDA = "CantidadSalida";
        public static readonly string P_RESULTADORETORNO = "ResultadoRetorno";

        /* Tablas SAP */

        public static readonly string T_UNIDADCONTROL = "VS_OUCT";

        public static readonly string P_TEXTO_ERROR_INTERNO = "Se produjo un error interno en la aplicación";
        public static readonly string P_TEXTO_ERROR_SOCIEDAD = "La sociedad no esta conectada";


        /* Campos de Proyecto */
        public static readonly string P_CODIGOPROYECTO = "CodigoProyecto";
        public static readonly string P_DESCRIPCIONPROYECTO = "DescripcionProyecto";
        public static readonly string P_ESTADOPROYECTO = "EstadoProyecto";
    }



}
