using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace gNube
{
    
    public class Principal
    {

        public static string RutaPosOnLine;


        const string _pathOrigen = @"ftp://pitabodegas.com//PosOnLineNew//";
        const string _pathDestino = @"C://DescargaTemp//";
        private Helpers.HelpFtp _ftp;
        private DataProvider.IData _dataP;
        private StringBuilder _st;


        public string GetVersion { get { return "Ver. " + Application.ProductVersion; } }


        public Principal() 
        {
            _dataP = new DataProvider.Data();
            _ftp = new Helpers.HelpFtp();
            _st = new StringBuilder();
        }


        public void Inicializa()
        {
        }
        PrincipalFrm frm;
        public void Inicia()
        {
            var rt = Helpers.HelpXml.CargarXml();
            if (rt.Result == Result.Enumerados.EnumResult.isError)
            {
                Helpers.HelpMsg.Error(rt.Mensaje);
                Application.Exit();
            }
            else 
            {
                if (CargarData())
                {
                    frm = new PrincipalFrm();
                    frm.setControlador(this);
                    Application.Run(frm);
                }
            }
        }


        public void Actualizar_PosOnLineNew()
        {
            _st.Clear();
            
            MsgDebug("Conectando Con BD");
            var _archivo = "";
            var rt = _dataP.MonitorSistemaPosOnLine_Info();
            if (rt.Result == Result.Enumerados.EnumResult.isError)
            {
                Helpers.HelpMsg.Error(rt.Mensaje);
                return;
            }
            MsgDebug("Info Sist/Actualizar: " + rt.Entidad);
            _archivo = rt.Entidad;
            var _archivoBajar = _pathOrigen + _archivo;
            var _destino = _pathDestino + _archivo;

            MsgDebug("Borrando Carpeta Destino");
            var rt0 = Helpers.HelpFiles.BorrarCrearDirectorio(_pathDestino);
            if (rt0.Result == Result.Enumerados.EnumResult.isError)
            {
                Helpers.HelpMsg.Error(rt0.Mensaje);
                return;
            }

            MsgDebug("Conectado Con Hosting");
            var rt1= _ftp.BajarArchivo(_archivoBajar, _destino);
            if (rt1.Result == Result.Enumerados.EnumResult.isError)
            {
                Helpers.HelpMsg.Error(rt1.Mensaje);
                return;
            }
            MsgDebug("Descargando Actualizacion");

            MsgDebug("UnZip Archivo");
            var _archivoDescomprimir = _destino;
            var rt2 = Helpers.HelpZip.DesComprimir(_archivoDescomprimir, _pathDestino);
            if (rt2.Result == Result.Enumerados.EnumResult.isError)
            {
                Helpers.HelpMsg.Error(rt2.Mensaje);
                return;
            }

            MsgDebug("Reemplazando Archivos En Carpeta Destino");
            var _rutaOrigen = _destino.Substring(0,_destino.IndexOf(".zip"));
            var _rutaPosOnLine = RutaPosOnLine;
            var rt3 = Helpers.HelpFiles.CopiarArchivos(_rutaOrigen, _rutaPosOnLine);
            if (rt3.Result == Result.Enumerados.EnumResult.isError)
            {
                Helpers.HelpMsg.Error(rt3.Mensaje);
                return;
            }
            MsgDebug("Proceso Finalizado");

            Helpers.HelpMsg.OK("PROCESO REALIZADO CON EXITO");
        }

        public void SubirCambios()
        {
            var _arch = "PosOnLine New ver 2022.07.02.14.zip";
            var rt = _dataP.MonitorSistemaPosOnLine_ActualizarVer(_arch);
            if (rt.Result == Result.Enumerados.EnumResult.isError)
            {
                Helpers.HelpMsg.Error(rt.Mensaje);
                return;
            }
            Helpers.HelpMsg.OK("CAMBIOS ACTUALIZADO EXITOSAMENTE");
        }


        private void MsgDebug(string msg)
        {
            _st.AppendLine(msg);
            frm.MuestraMensaje(_st.ToString());
        }
        private bool CargarData()
        {
            return true;
        }

    }

}