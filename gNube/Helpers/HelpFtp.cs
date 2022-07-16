using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace gNube.Helpers
{
    
    public class HelpFtp
    {

        private string _ftpUsername;
        private string _ftpPassword;


        public HelpFtp() 
        {
            _ftpUsername = "leonuxftp@pitabodegas.com";
            _ftpPassword = "71277128";
        }


        public Result.Resultado BajarArchivo(string origen, string destino)
        {
            var result = new Result.Resultado();

            try 
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(origen);
                request.Credentials = new NetworkCredential(_ftpUsername, _ftpPassword);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(destino))
                {
                    ftpStream.CopyTo(fileStream);
                }
            }
            catch (IOException ex)
            {
                result.Mensaje = ex.Message;
                result.Result = Result.Enumerados.EnumResult.isError;
            }
            catch (WebException ex)
            {
                result.Mensaje = ex.Message;
                result.Result = Result.Enumerados.EnumResult.isError;
            }
            catch(Exception ex)
            {
                result.Mensaje= ex.Message;
                result.Result = Result.Enumerados.EnumResult.isError;
            }

            return result;
        }

    }

}