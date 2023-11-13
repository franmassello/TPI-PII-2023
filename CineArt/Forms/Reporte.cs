using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineArt.Forms
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        public void cargarCrystal(string consulta)
        {

            CrystalReport1 miReporte = new CrystalReport1();
            DataTable dt = new DataTable();
            AccesoDatos oDato = new AccesoDatos();
            //MessageBox.Show(consulta); LINEA DE TESTEO
            dt = oDato.consultar(consulta);
            miReporte.SetDataSource(dt);
            Reporte300.ReportSource = miReporte;
            Reporte300.Refresh();
            Reporte300.Show();
        }

        private void Reporte_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar el informe?", "SALIENDO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
}
