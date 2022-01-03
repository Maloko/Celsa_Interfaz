using System;
using System.Xml;
using System.IO;
using System.Data;
using System.Reflection;

namespace InterfazMTTO.iSBO_Util
{
    public class ErrorHandler
    {
        string NombreArchivo ;       
        string Ruta;                

        DataTable tbl = new DataTable();

        void GetSettings(string Tipo)
        {
            try
            {
                XmlDocument XML_Settings = new XmlDocument();
                XML_Settings.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("iSBO_Util.Settings.xml"));
                XmlNodeList Logs = XML_Settings.GetElementsByTagName("Logs");
                XmlNodeList Log = ((XmlElement)Logs[0]).GetElementsByTagName("Log");

                foreach (XmlElement Nodo in Log)
                {
                    if (Nodo.GetElementsByTagName("Tipo")[0].InnerText == Tipo)
                    {
                        NombreArchivo = Nodo.GetElementsByTagName("NombreArchivo")[0].InnerText;
                        Ruta = Nodo.GetElementsByTagName("Ruta")[0].InnerText;
                    }
                }
            }

            catch { }
        }


        public void EscribirLog(string CompanyName, int Version, int GetLastErrorCode, string GetLastErrorDescription)
        {
            GetSettings("Log_SAP");
            ValidarArchivo();

            tbl = new DataTable();
            try
            {
                tbl.ReadXml(Ruta + NombreArchivo);
            }

            catch
            {
                XmlDocument ErrorXML = new XmlDocument();
                ErrorXML.LoadXml(Log);
                ErrorXML.Save(Ruta + NombreArchivo);
                tbl.ReadXml(Ruta + NombreArchivo);
            }

            DataRow row;
            row = tbl.NewRow();
            row["DateTime"] = DateTime.Now;
            row["CompanyName"] = CompanyName;
            row["Version"] = Convert.ToString(Version);
            row["GetLastErrorCode"] = Convert.ToString(GetLastErrorCode);
            row["GetLastErrorDescription"] = GetLastErrorDescription;
            row["HostName"] = System.Environment.MachineName;
            row["IPAddress"] = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1];
            tbl.Rows.Add(row);
            tbl.TableName = "Table1";
            tbl.WriteXml(Ruta + NombreArchivo, XmlWriteMode.WriteSchema, false);
        }

        public void EscribirError(string Error_Type, string Error_Description, string Error_Source, string Error_Stack_Trace, string Error_Caused_By_Method, string Optional_Text_1, string Optional_Text_2, string Optional_Text_3)
        {

            GetSettings("Log_Error");              
            NombreArchivo = NombreArchivo.Substring(0,NombreArchivo.Length - 4) + "_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".XML"; //Se añade la fecha al nombre del archivo
            
            ValidarArchivo();
            
            tbl = new DataTable();
            try
            {
                tbl.ReadXml(Ruta + NombreArchivo);
            }
            catch 
            {
                XmlDocument ErrorXML = new XmlDocument();
                ErrorXML.LoadXml(Esquema);
                ErrorXML.Save(Ruta + NombreArchivo); 
                tbl.ReadXml(Ruta + NombreArchivo);
            }

            DataRow row;
            row = tbl.NewRow();
            row["Error_Type"] = Error_Type;
            row["Error_DateTime"] = DateTime.Now;
            row["Error_Description"] = Error_Description;
            row["Error_Source"] = Error_Source;
            row["Error_Stack_Trace"] = Error_Stack_Trace;
            row["Error_Caused_By_Method"] = Error_Caused_By_Method;
            row["Optional_Text_1"] = Optional_Text_1;
            row["Optional_Text_2"] = Optional_Text_2;
            row["Optional_Text_3"] = Optional_Text_3;
            row["HostName"] = System.Environment.MachineName;
            row["IPAddress"] = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1];
            tbl.Rows.Add(row);
            tbl.TableName = "Table1";
            tbl.WriteXml(Ruta + NombreArchivo, XmlWriteMode.WriteSchema, false);
        }

        public void ValidarArchivo()
        {
            string RutaCompleta = System.IO.Path.Combine(Ruta, NombreArchivo);

            if (!System.IO.File.Exists(RutaCompleta))
            {
                FileStream fs = new FileStream(RutaCompleta, FileMode.OpenOrCreate);
                StreamWriter str = new StreamWriter(fs);
                str.Flush();
                str.Close();
                fs.Close();  
            }
        }

        string Esquema = "<?xml version='1.0' standalone='yes'?>" +
                                "<NewDataSet>" +
                                 " <xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata'>" +
                                 "   <xs:element name='NewDataSet' msdata:IsDataSet='true' msdata:MainDataTable='Table1' msdata:UseCurrentLocale='true'>" +
                                 "     <xs:complexType>" +
                                 "       <xs:choice minOccurs='0' maxOccurs='unbounded'>" +
                                 "         <xs:element name='Table1'>" +
                                 "           <xs:complexType>" +
                                 "             <xs:sequence>" +
                                 "               <xs:element name='Error_Type' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='Error_DateTime' type='xs:dateTime' minOccurs='0' />" +
                                 "               <xs:element name='Error_Description' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='Error_Source' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='Error_Stack_Trace' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='Error_Caused_By_Method' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='Optional_Text_1' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='Optional_Text_2' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='Optional_Text_3' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='HostName' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='IPAddress' type='xs:string' minOccurs='0' />" +
                                 "             </xs:sequence>" +
                                 "           </xs:complexType>" +
                                 "         </xs:element>" +
                                 "       </xs:choice>" +
                                 "     </xs:complexType>" +
                                 "   </xs:element>" +
                                 " </xs:schema>" +
                                 " </NewDataSet>";


        string Log = "<?xml version='1.0' standalone='yes'?>" +
                                "<NewDataSet>" +
                                 " <xs:schema id='NewDataSet' xmlns='' xmlns:xs='http://www.w3.org/2001/XMLSchema' xmlns:msdata='urn:schemas-microsoft-com:xml-msdata'>" +
                                 "   <xs:element name='NewDataSet' msdata:IsDataSet='true' msdata:MainDataTable='Table1' msdata:UseCurrentLocale='true'>" +
                                 "     <xs:complexType>" +
                                 "       <xs:choice minOccurs='0' maxOccurs='unbounded'>" +
                                 "         <xs:element name='Table1'>" +
                                 "           <xs:complexType>" +
                                 "             <xs:sequence>" +
                                 "               <xs:element name='CompanyName' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='Version' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='GetLastErrorCode' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='GetLastErrorDescription' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='DateTime' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='HostName' type='xs:string' minOccurs='0' />" +
                                 "               <xs:element name='IPAddress' type='xs:string' minOccurs='0' />" +
                                 "             </xs:sequence>" +
                                 "           </xs:complexType>" +
                                 "         </xs:element>" +
                                 "       </xs:choice>" +
                                 "     </xs:complexType>" +
                                 "   </xs:element>" +
                                 " </xs:schema>" +
                                 " </NewDataSet>";

    }

}
