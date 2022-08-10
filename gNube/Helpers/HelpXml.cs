using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace gNube.Helpers
{
    
    public class HelpXml
    {

        static public Result.Resultado CargarXml()
        {
            var result = new Result.Resultado();

            try
            {
                var doc = new XmlDocument();
                doc.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Conf.XML");
                if (doc.HasChildNodes)
                {
                    foreach (XmlNode nd in doc)
                    {
                        if (nd.LocalName.ToUpper().Trim() == "CONFIGURACION")
                        {
                            foreach (XmlNode nv in nd.ChildNodes)
                            {
                                if (nv.LocalName.ToUpper().Trim() == "RUTA_POS_ON_LINE_NEW")
                                {
                                    Principal.RutaPosOnLine = nv.InnerText.Trim();
                                }
                                if (nv.LocalName.ToUpper().Trim() == "RUTA_GESTION_FTP")
                                {
                                    Principal.RutaGestionFtp = nv.InnerText.Trim();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Result = Result.Enumerados.EnumResult.isError;
                result.Mensaje = e.Message;
            }

            return result;
        }

    }

}