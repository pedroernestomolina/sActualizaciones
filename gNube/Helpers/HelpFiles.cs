using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace gNube.Helpers
{
    
    public class HelpFiles
    {

        public static Result.Resultado BorrarArchivos(string pathSource, string archivo)
        {
            var rt = new Result.Resultado();
            try
            {
                DirectoryInfo d = new DirectoryInfo(pathSource);
                FileInfo[] Files = d.GetFiles(archivo);
                foreach (FileInfo file in Files)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                rt.Mensaje = ex.Message;
                rt.Result = Result.Enumerados.EnumResult.isError ;
            }
            return rt;
        }

        public static Result.Resultado BorrarCrearDirectorio(string pathSource)
        {
            var rt = new Result.Resultado();
            try
            {
                if (Directory.Exists(pathSource))
                {
                    System.IO.Directory.Delete(pathSource, true);
                }
                System.IO.Directory.CreateDirectory(pathSource);
            }
            catch (Exception ex)
            {
                rt.Mensaje = ex.Message;
                rt.Result = Result.Enumerados.EnumResult.isError;
            }
            return rt;
        }

        public static Result.Resultado CopiarArchivos(string pathOrigen , string pathDestino)
        {
            var rt = new Result.Resultado();
            try 
            {
                foreach (var srcPath in Directory.GetFiles(pathOrigen))
                {
                    //Copy the file from sourcepath and place into mentioned target path, 
                    //Overwrite the file if same file is exist in target path
                    File.Copy(srcPath, srcPath.Replace(pathOrigen, pathDestino), true);
                }
            }
            catch (Exception ex)
            {
                rt.Mensaje = ex.Message;
                rt.Result = Result.Enumerados.EnumResult.isError;
            }
            return rt;
        }

    }

}