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

    public partial class Principal : Form {

        Pelicula p;
        string consulta;
        bool banderaFiltro = false;
        AccesoDatos oDato = new AccesoDatos();
        APIMethods APIMethods = new APIMethods();
        public string pConsulta { get => consulta; set => consulta = value; }

        public Principal() {
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





        private void Principal_Load(object sender, EventArgs e) {
            try {
                //deshabilitarEdicionDG(true);
                /** 
                cargarCombo(cboFormato, "getFormatos");
                cargarCombo(cboGenero, "getGeneros");
                cargarCombo(cboIdioma, "getIdiomas");
                dtpFechaEstreno.Enabled = false;
                **/
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

        /**
        private void deshabilitarEdicionDG(bool estado) {
            dataGridView1.Columns[0].ReadOnly = estado;
            dataGridView1.Columns[1].ReadOnly = estado;
            dataGridView1.Columns[2].ReadOnly = estado;
            dataGridView1.Columns[3].ReadOnly = estado;
            dataGridView1.Columns[4].ReadOnly = estado;
            dataGridView1.Columns[5].ReadOnly = estado;
            dataGridView1.Columns[6].ReadOnly = estado;
        }**/

        private void BtnNuevoPrincipal_Click(object sender, EventArgs e) {
            NuevaPelicula np = new NuevaPelicula();
            np.ShowDialog();
        }

        //BOTON MINIMIZAR
        private void BtnMinimizarse_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        //BOTON CERRAR SESION
        private void BtnCerrarPrincipal_Click(object sender, EventArgs e) {
            if (MessageBox.Show("¿Esta seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo,
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

   
        private void BtnEditarPrincipal_Click(object sender, EventArgs e) {
            
        }


        private void BtnSalirse_Click(object sender, EventArgs e) {
            if (MessageBox.Show("¿Esta seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo,
MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                Application.Exit();

            }
        }


        //FILTROS

        public string filtrar() {
            string condicion = "";

            string[] arrayFiltros = new string[7];
            int contI = 0;
            /** 
            if (!string.IsNullOrEmpty(txtCodigo.Text)) {
                condicion = " id_pelicula = " + txtCodigo.Text;
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (txtTitulo.Text != string.Empty) {
                condicion = " titulo like '" + txtTitulo.Text + "%'";
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (txtSinopsis.Text != string.Empty) {
                condicion = " descripcion like '" + txtSinopsis.Text + "%'";
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (dtpFechaEstreno.Enabled) {
                condicion = " fecha_estreno = '" + dtpFechaEstreno.Value.ToString("yyyy-MM-dd") + "'";
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (cboIdioma.SelectedIndex != -1) {
                condicion = " id_idioma = " + cboIdioma.SelectedValue;
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (cboGenero.SelectedIndex != -1) {
                condicion = " id_genero = " + cboGenero.SelectedValue;
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (cboFormato.SelectedIndex != -1) {
                condicion = " id_formato = " + cboFormato.SelectedValue;
                arrayFiltros[contI] = condicion;
                contI++;

            }


            **/
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
        /**
        private void cbxFecha_CheckStateChanged(object sender, EventArgs e) {
            if (cbxFecha.Checked) {
                dtpFechaEstreno.Enabled = true;
            } else {
                dtpFechaEstreno.Enabled = false;
            }
        }
        **/


        private void BtnFiltrar_Click(object sender, EventArgs e) {

            this.consulta = filtrar();

            /**
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



            txtCodigo.Clear();
            txtTitulo.Clear();
            txtSinopsis.Clear();
            cboIdioma.SelectedIndex = -1;
            cboFormato.SelectedIndex = -1;
            cboGenero.SelectedIndex = -1;
            dtpFechaEstreno.Value = DateTime.Today.AddDays(1);

            //validacion para el crystal report
            **/
            banderaFiltro = true;
        }

        private void BtnReporte_Click(object sender, EventArgs e) {




        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e) {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://0112-186-138-214-149.ngrok-free.app/");
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            MenuVentas menuV = new MenuVentas();
            menuV.Show();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            MenuPeliculas menuP = new MenuPeliculas();
            menuP.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            MenuFunciones menuF = new MenuFunciones();
            menuF.Show();
        }
    }
}
