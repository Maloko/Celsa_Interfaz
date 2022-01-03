using InterfazMTTO.iSBO_DA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iSBO_DA
{
    class VSSQLFactory
    {
        public static String GetScript(int numero, String[] paramts)// String[] Paramts)
        {
            String archivo = numero.ToString().PadLeft(5, '0');
            String Tipo = "";


            switch (Conexion.TipoServidor)
            {
                case SAPbobsCOM.BoDataServerTypes.dst_MSSQL:
                    Tipo = "MSSQL";
                    break;
                case SAPbobsCOM.BoDataServerTypes.dst_DB_2:
                    Tipo = "";
                    break;
                case SAPbobsCOM.BoDataServerTypes.dst_SYBASE:
                    Tipo = "";
                    break;
                case SAPbobsCOM.BoDataServerTypes.dst_MSSQL2005:
                    Tipo = "MSSQL";
                    break;
                case SAPbobsCOM.BoDataServerTypes.dst_MAXDB:
                    Tipo = "";
                    break;
                case SAPbobsCOM.BoDataServerTypes.dst_MSSQL2008:
                    Tipo = "MSSQL";
                    break;
                case SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012:
                    Tipo = "MSSQL";
                    break;
                case SAPbobsCOM.BoDataServerTypes.dst_MSSQL2014:
                    Tipo = "MSSQL";
                    break;
                case SAPbobsCOM.BoDataServerTypes.dst_HANADB:
                    Tipo = "HANA";
                    break;

            }


            archivo = archivo + "_" + Tipo + ".sql";

            System.Reflection.Assembly thisTxt = System.Reflection.Assembly.GetExecutingAssembly();
            string nombre = thisTxt.GetName().Name + ".Resources.Scripts." + archivo.Replace('\\', '.');
            System.IO.Stream file = thisTxt.GetManifestResourceStream(nombre);
            StreamReader reader = null;
            string Consulta = "";
            try
            {

                reader = new System.IO.StreamReader(file);



                while (!reader.EndOfStream)
                {
                    Consulta += reader.ReadLine() + " ";
                }
                if (paramts != null)
                {
                    for (int i = 0; i < paramts.Length; i++)
                    {
                        Consulta = Consulta.Replace("${param" + (i + 1) + "}", paramts[i]);
                    }
                    //System.Windows.Forms.MessageBox.Show(Consulta);
                }

            }
            catch (Exception ex)
            {
                Consulta = "Error. " + ex.Message;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return Consulta;
        }
    }
}
