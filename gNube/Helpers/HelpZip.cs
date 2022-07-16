using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gNube.Helpers
{
    
    public class HelpZip
    {

        public static Result.Resultado DesComprimir(string _archivoDescomprimir, string _rutaDestino)
        {
            var result = new Result.Resultado();
            try
            {
                ZipFile.ExtractToDirectory(_archivoDescomprimir, _rutaDestino);
            }
            catch (Exception ex) 
            {
                result.Mensaje = ex.Message;
                result.Result = Result.Enumerados.EnumResult.isError;
            }
            return result;
        }

    }

}