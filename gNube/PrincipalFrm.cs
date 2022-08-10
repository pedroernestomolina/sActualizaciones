using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gNube
{

    public partial class PrincipalFrm : Form
    {

        Principal _controlador;


        public PrincipalFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Principal ctr)
        {
            _controlador = ctr;
        }

        private void BT_ACTUALIZAR_PosOnLineNew_Click(object sender, EventArgs e)
        {
            Actualizar_PosOnLineNew();
        }
        private void Actualizar_PosOnLineNew()
        {
            _controlador.Actualizar_PosOnLineNew();
        }


        private void PrincipalFrm_Load(object sender, EventArgs e)
        {
            L_DEBUG.Text = "";
            L_VERSION.Text = _controlador.GetVersion;
        }

        public void MuestraMensaje(string msg)
        {
            L_DEBUG.Text = msg;
            this.Refresh();
        }

        private void BT_SUBIR_CAMBIOS_Click(object sender, EventArgs e)
        {
            SubirCambios();
        }
        private void SubirCambios()
        {
            _controlador.SubirCambios();
        }

        private void BT_ACTUALIZAR_GESTION_FTP_Click(object sender, EventArgs e)
        {
            Actualizar_GestionFtp();
        }
        private void Actualizar_GestionFtp()
        {
            _controlador.Actualizar_GestionFtp();
        }

    }

}