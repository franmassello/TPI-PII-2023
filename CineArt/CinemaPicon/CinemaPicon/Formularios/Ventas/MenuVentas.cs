using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CinemaPicon.Formularios;
using System.Diagnostics;
using CinemaPicon.Clases;

namespace CinemaPicon {

    public partial class MenuVentas : Form {

        Pelicula p;
        string consulta;
        bool banderaFiltro = false;
        AccesoDatos oDato = new AccesoDatos();
        APIMethods APIMethods = new APIMethods();
        public string pConsulta { get => consulta; set => consulta = value; }

        public MenuVentas() {
            InitializeComponent();
        }


        //DLL PARA PODER MOVER LA VENTANA CON EL MOUSE DOWN
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        // ACA TERMINA EL DLL

        //EVENTOS PARA MOVER LA VENTANA
        private void Panel1_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Principal_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }





        private async void Principal_Load(object sender, EventArgs e) {
            try {
                refrescarDG();
                //deshabilitarEdicionDG(true);
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }

        //CARGA COMBOBOX
        private async void cargarCombo(ComboBox combo, string nombreTabla) {
            DataTable tabla = new DataTable();
            tabla = await APIMethods.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;

            
        }
        //VALIDACION PARA QUE NO PUEDA ESCRIBIR EN EL DATAGRID
        private void deshabilitarEdicionDG(bool estado) {
            dataGridView1.Columns[0].ReadOnly = estado;
            dataGridView1.Columns[1].ReadOnly = estado;
            dataGridView1.Columns[2].ReadOnly = estado;
            dataGridView1.Columns[3].ReadOnly = estado;
            dataGridView1.Columns[4].ReadOnly = estado;
            dataGridView1.Columns[5].ReadOnly = estado;
            dataGridView1.Columns[6].ReadOnly = estado;
        }

        private void BtnNuevoPrincipal_Click(object sender, EventArgs e) {
            NuevaVenta nv = new NuevaVenta();
            nv.ShowDialog();
            refrescarDG();
        }

        //BOTON MINIMIZAR
        private void BtnMinimizarse_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        //BOTON CERRAR SESION
        private void BtnCerrarPrincipal_Click(object sender, EventArgs e) {
            if (MessageBox.Show("¿Esta Seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                Application.Exit();

            }


        }

        //CRUZ SUPERIOR DERECHA
        private void BtnCerrarSesion_Click(object sender, EventArgs e) {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        //REFRESCAR DATAGRID
        public async void refrescarDG()
        {

            this.dataGridView1.DataSource = oDato.ConsultarTablaConSP("SP_GET_FACTURAS");
            this.dataGridView1.Refresh();
        }
        private void BtnEliminarPrincipal_Click(object sender, EventArgs e) {

            if (this.p == null) {
                MessageBox.Show("Seleccione una pelicula de la lista para eliminar");

            } else {

                try {
                    if (MessageBox.Show("Usted esta por eliminar esta pelicula, Esta seguro?", "ELIMINANDO PELICULA",
    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                        string consulta;
                        consulta = "DELETE PELICULAS WHERE ID_PELICULA = " + p.pId;
                        oDato.actualizarBD(consulta);
                        MessageBox.Show("Pelicula Eliminada");
                        dataGridView1.DataSource = oDato.consultarTabla("Peliculas");
                        dataGridView1.Refresh();

                    }
                }
                catch (Exception ex) {
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show("Esta pelicula no puede ser eliminada para proteger la integridad de la base de datos");
                }
                finally {
                    oDato.desconectar();
                }

            }
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (dataGridView1.SelectedRows.Count > 0) {
                DataGridViewRow row = dataGridView1.CurrentRow;

                if (row != null) {

                    this.p = new Pelicula();

                    /** 
                    p.pId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    p.pTitulo = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    p.pDescripcion = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    p.pGenero = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                    p.pFechaEstreno = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
                    p.pIdioma = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                    p.pFormato = Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value);
                    **/
                    //LINEA PARA TESTEO
                    //MessageBox.Show(p.ToString());
                }

            }
        }

        private void BtnEditarPrincipal_Click(object sender, EventArgs e) {
            
        }


        private void BtnSalirse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro que desea cerrar la pestaña Ventas?", "Salir", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        //FILTROS

        public string filtrar() {
            string condicion = "";

            string[] arrayFiltros = new string[7];
            int contI = 0;
           
            var sb = new System.Text.StringBuilder();

            if (contI == 0) {
                return null;
            } else if (contI == 1) {
                sb.Append(arrayFiltros[0]);
            } else {
                sb.Append(arrayFiltros[0]);
                for (int i = 1; i < contI; i++) {
                    sb.Append(" and");
                    sb.Append(arrayFiltros[i]);

                }
            }

            return sb.ToString();
        }

        private void BtnFiltrar_Click(object sender, EventArgs e) {

            this.consulta = filtrar();



            if (this.consulta == null) {
                
                this.dataGridView1.DataSource = oDato.consultarTabla("Peliculas");
                this.dataGridView1.Refresh();

                //validaciones para el crystal report
                this.consulta = "SELECT * FROM PELICULAS";
                banderaFiltro = false;
            } else {
                this.consulta = "SELECT * FROM PELICULAS WHERE " + filtrar();

                this.dataGridView1.DataSource = oDato.consultar(consulta);
                this.dataGridView1.Refresh();
            }



            /**
            txtCodigo.Clear();
            txtTitulo.Clear();
            txtSinopsis.Clear();
            cboIdioma.SelectedIndex = -1;
            cboFormato.SelectedIndex = -1;
            cboGenero.SelectedIndex = -1;
            **/

            //validacion para el crystal report
            banderaFiltro = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
