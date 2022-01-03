using System;
using InterfazMTTO.iSBO_BE;
namespace InterfazMTTO.iSBO_BL
{     
    public class Articulo_BL
    {
        public static BEOITMList ListarArticulos(string TipoArticulo, ref BERPTA Respuesta)
        {
            BEOITMList ListadoArticulos = new BEOITMList();
            BEOITMList TipoArticulos = new BEOITMList();            

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (string.IsNullOrEmpty(TipoArticulo))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_902;
                }
                else
                {
                    int LengthTipoArticulo = TipoArticulo.Length;

                    if (LengthTipoArticulo > iSBO_Util.Constantes.P_VALOR_RESULT_1)
                    {

                        TipoArticulos = iSBO_Util.OperacionesCadenas.SerializaTipoArticulo(TipoArticulo, LengthTipoArticulo);

                        foreach (BEOITM Articulo in TipoArticulos)
                        {
                            bool Valida = iSBO_Util.OperacionesCadenas.ComparaCadenas(Articulo.TipoArticulo.ToString(), iSBO_Util.Constantes.P_TIPO_ARTICULO_COMPONENTE, iSBO_Util.Constantes.P_TIPO_ARTICULO_CONSUMIBLE, iSBO_Util.Constantes.P_TIPO_ARTICULO_NEUMATICO, iSBO_Util.Constantes.P_TIPO_ARTICULO_REPUESTO,iSBO_Util.Constantes.P_TIPO_ARTICULO_REPUESTOCOMPONENTE);

                            if (Valida == false)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_901;
                                break;
                            }
                        }
                    }

                    if (LengthTipoArticulo == iSBO_Util.Constantes.P_VALOR_RESULT_1)
                    {

                        bool Valida = iSBO_Util.OperacionesCadenas.ComparaCadenas(TipoArticulo.ToString(), iSBO_Util.Constantes.P_TIPO_ARTICULO_COMPONENTE, iSBO_Util.Constantes.P_TIPO_ARTICULO_CONSUMIBLE, iSBO_Util.Constantes.P_TIPO_ARTICULO_NEUMATICO, iSBO_Util.Constantes.P_TIPO_ARTICULO_REPUESTO, iSBO_Util.Constantes.P_TIPO_ARTICULO_REPUESTOCOMPONENTE);

                        if (Valida == false)
                        {
                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_901;
                        }
                    }
                }

                //Validaciones de capa de negocio OK. Invoca la clase DA

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    ListadoArticulos = iSBO_DA.Articulo_DA.ListarArticulos(TipoArticulo, ref Respuesta);

                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {
                        throw new Exception();
                    }
                }
            }

            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();

                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    Error.EscribirError("ControlERROR", Respuesta.CodigoErrorUsuario + '-' + Respuesta.DescripcionErrorUsuario, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");

                }
                else
                {
                    Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            finally
            {
                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2)
                {
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }
          
            return ListadoArticulos;
        }


        public static BEOITMList ListarArticulos(string TipoArticulo, bool FlagStock, string AlmacenStock, ref BERPTA Respuesta)
        {
            BEOITMList ListadoArticulos = new BEOITMList();
            BEOITMList TipoArticulos = new BEOITMList();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                if (string.IsNullOrEmpty(AlmacenStock))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_904;
                } 

                if (string.IsNullOrEmpty(TipoArticulo))
                {
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_902;
                }
                else
                {
                    int LengthTipoArticulo = TipoArticulo.Length;

                    if (LengthTipoArticulo > iSBO_Util.Constantes.P_VALOR_RESULT_1)
                    {

                        TipoArticulos = iSBO_Util.OperacionesCadenas.SerializaTipoArticulo(TipoArticulo, LengthTipoArticulo);

                        foreach (BEOITM Articulo in TipoArticulos)
                        {
                            bool Valida = iSBO_Util.OperacionesCadenas.ComparaCadenas(Articulo.TipoArticulo.ToString(), iSBO_Util.Constantes.P_TIPO_ARTICULO_COMPONENTE, iSBO_Util.Constantes.P_TIPO_ARTICULO_CONSUMIBLE, iSBO_Util.Constantes.P_TIPO_ARTICULO_NEUMATICO, iSBO_Util.Constantes.P_TIPO_ARTICULO_REPUESTO, iSBO_Util.Constantes.P_TIPO_ARTICULO_REPUESTOCOMPONENTE);

                            if (Valida == false)
                            {
                                Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_901;
                                break;
                            }
                        }
                    }

                    if (LengthTipoArticulo == iSBO_Util.Constantes.P_VALOR_RESULT_1)
                    {

                        bool Valida = iSBO_Util.OperacionesCadenas.ComparaCadenas(TipoArticulo.ToString(), iSBO_Util.Constantes.P_TIPO_ARTICULO_COMPONENTE, iSBO_Util.Constantes.P_TIPO_ARTICULO_CONSUMIBLE, iSBO_Util.Constantes.P_TIPO_ARTICULO_NEUMATICO, iSBO_Util.Constantes.P_TIPO_ARTICULO_REPUESTO, iSBO_Util.Constantes.P_TIPO_ARTICULO_REPUESTOCOMPONENTE);

                        if (Valida == false)
                        {
                            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_901;
                        }
                    }
                }

                //Validaciones de capa de negocio OK. Invoca la clase DA

                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    ListadoArticulos = iSBO_DA.Articulo_DA.ListarArticulos(TipoArticulo,FlagStock,AlmacenStock, ref Respuesta);

                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {
                        throw new Exception();
                    }
                }
            }

            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();

                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    Error.EscribirError("ControlERROR", Respuesta.CodigoErrorUsuario + '-' + Respuesta.DescripcionErrorUsuario, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");

                }
                else
                {
                    Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            finally
            {
                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2)
                {
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            return ListadoArticulos;
        }


        public static BEOITMList ListarArticulos(string CodigoArticulo, string AlmacenSalida, ref BERPTA Respuesta) 
        {            
            BEOITMList ListaArticulos = new BEOITMList();
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;            

            try
            {
                    if (string.IsNullOrEmpty(CodigoArticulo))
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_903;                        
                    }
                
                    if (string.IsNullOrEmpty(AlmacenSalida))
                    {
                        Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_904;                        
                    }     
                
                    if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                    {
                    //Validaciones de capa de negocio OK. Invoca la clase DA
                        ListaArticulos = iSBO_DA.Articulo_DA.ListarArticulos(CodigoArticulo,AlmacenSalida, ref Respuesta);

                        if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                        {
                            throw new Exception();
                        }
                    }
            }

            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();

                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    Error.EscribirError("ControlERROR", Respuesta.CodigoErrorUsuario + '-' + Respuesta.DescripcionErrorUsuario, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");

                }
                else
                {
                    Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            finally
            {
                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2)
                {
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            return ListaArticulos;   
        }


        public static BEOITWList ObtenerCostoArticulo(string IdArticulo, int TipoProceso, int DocEntry, ref BERPTA Respuesta)
        {
            BEOITWList ListadoCosto = new BEOITWList();

            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {              
                if (Respuesta.ResultadoRetorno == iSBO_Util.Constantes.P_VALOR_INICIO_RESULT)
                {
                    ListadoCosto = iSBO_DA.Articulo_DA.ObtenerCostoArticulo(IdArticulo, TipoProceso, DocEntry, ref Respuesta);
                    
                    if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                    {
                        throw new Exception();
                    }
                }
            }

            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();

                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    Error.EscribirError("ControlERROR", Respuesta.CodigoErrorUsuario + '-' + Respuesta.DescripcionErrorUsuario, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");

                }
                else
                {
                    Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            finally
            {
                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2)
                {
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }

            return ListadoCosto;
        }

        public static BEOITWList ObtenerAlmacenEntradaSalidaArticulo(string IdArticulo,string almacenEntrada,string almacenSalida, ref BERPTA Respuesta)
        {

            BEOITWList oitwList = new BEOITWList();
            Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_INICIO_RESULT;

            try
            {
                oitwList = iSBO_DA.Articulo_DA.ObtenerAlmacenEntradaSalidaArticulo(IdArticulo, almacenEntrada,almacenSalida ,ref Respuesta);

                /*
                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    throw new Exception();
                }*/
            }
            catch (Exception ex)
            {
                iSBO_Util.ErrorHandler Error = new iSBO_Util.ErrorHandler();

                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_0)
                {
                    Error.EscribirError("ControlERROR", Respuesta.CodigoErrorUsuario + '-' + Respuesta.DescripcionErrorUsuario, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                }
                else
                {
                    Error.EscribirError(ex.Data.ToString(), ex.Message, ex.Source, ex.StackTrace, ex.TargetSite.ToString(), "", "", "");
                    Respuesta.ResultadoRetorno = iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_9;
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }
            finally
            {
                if (Respuesta.ResultadoRetorno != iSBO_Util.Constantes.P_VALOR_RESULT_NEGATIVO_2)
                {
                    Respuesta = iSBO_Util.DiccionarioErrores.ObtenerError(Respuesta.ResultadoRetorno);
                }
            }
            return oitwList;
        }


    }
}