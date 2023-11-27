using CinemaPicon.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CinemaPicon {
    public partial class NuevaFuncion : Form {
        AccesoDatos oDato = new AccesoDatos();
        APIMethods APIMethods = new APIMethods();
        List<Pelicula> listaPeliculas = new List<Pelicula>(); 
        public NuevaFuncion() {
            InitializeComponent();
        }

        //DLL PARA MOVER VENTANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //MOVER VENTANA CON CLICK
        private void NuevaPelicula_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //MOVER VENTANA CON CLICK
        private void Panel1_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private async void NuevaPelicula_Load(object sender, EventArgs e) {
            try {
                await CargarComboAsync(cboFormato, "getFormatos");
                await CargarComboAsync(cboGenero, "getGeneros");
                await CargarComboAsync(cboIdioma, "getIdiomas");
                cargarPeliculasEnLista("Peliculas");
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void cargarPeliculasEnLista(string nombreTabla) {
            oDato.leerTabla(nombreTabla);
            while (oDato.pLector.Read()) {

                Pelicula p = new Pelicula();

                if (!oDato.pLector.IsDBNull(0)) {
                    p.pId = oDato.pLector.GetInt32(0);
                }
                if (!oDato.pLector.IsDBNull(1)) {
                    p.pTitulo = oDato.pLector.GetString(1);
                }
                if (!oDato.pLector.IsDBNull(2)) {
                    p.pDescripcion = oDato.pLector.GetString(2);
                }
                if (!oDato.pLector.IsDBNull(3)) {
                    p.pGenero = oDato.pLector.GetInt32(3);
                }
                if (!oDato.pLector.IsDBNull(4)) {
                    p.pFechaEstreno = oDato.pLector.GetDateTime(4);
                }
                if (!oDato.pLector.IsDBNull(5)) {
                    p.pIdioma = oDato.pLector.GetInt32(5);
                }
                if (!oDato.pLector.IsDBNull(6)) {
                    p.pFormato = oDato.pLector.GetInt32(6);
                }

                listaPeliculas.Add(p);

            }
            oDato.pLector.Close();
            oDato.desconectar();
        }

        private async Task CargarComboAsync(ComboBox combo, string methodName)
        {
            // Load data into combo box
            DataTable tabla = new DataTable();
            tabla = await APIMethods.consultarTabla(methodName);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;

        }


        private async void BtnAgregar_Click(object sender, EventArgs e) {


            if (validar()) {

                string consultaSQL = "";
                PeliculaBack p = new PeliculaBack();
                p.Titulo = txtTitulo.Text;
                p.Descripcion = txtDescripcion.Text;
                p.Genero = cboGenero.Text;
                p.FechaEstreno = dtpFechaEstreno.Value;
                p.Idioma = cboIdioma.Text;
                p.Formato = cboFormato.Text;

                try {
                    if (!existe(p.Titulo)) {

                        string json = JsonConvert.SerializeObject(p);

                        string response = await APIMethods.PostPelicula("insertPelicula", json);

                        MessageBox.Show("Pelicula agregada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                        this.Close();

                    } else {
                        MessageBox.Show("Este titulo ya fue ingresado");
                    }


                }
                catch (Exception ex) {

                    MessageBox.Show(ex.Message);

                }

            }



        }

        private bool existe(string titulo) {

            foreach (Pelicula p in listaPeliculas) {
                if (p.pTitulo.ToUpper().Equals(titulo.ToUpper())) { 
                    return true;
                }
            }
            return false;

        }

        private bool validar() {
            if (string.IsNullOrEmpty(txtTitulo.Text)) {
                MessageBox.Show("Complete el campo titulo");
                txtTitulo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text)) {
                MessageBox.Show("Complete el campo Descripcion");
                txtDescripcion.Focus();
                return false;
            }
            if (cboGenero.SelectedIndex == -1) {
                MessageBox.Show("Seleccione un genero");
                cboGenero.Focus();
                return false;
            }

            if (cboIdioma.SelectedIndex == -1) {
                MessageBox.Show("Seleccione un idioma");
                cboIdioma.Focus();
                return false;
            }
            if (cboFormato.SelectedIndex == -1) {
                MessageBox.Show("Seleccione un formato");
                cboFormato.Focus();
                return false;
            }
            return true;

        }

        private void limpiarCampos() {
            txtDescripcion.Clear();
            txtTitulo.Clear();
            cboGenero.SelectedIndex = -1;
            dtpFechaEstreno.Value = DateTime.Today;
            cboIdioma.SelectedIndex = -1;
            cboFormato.SelectedValue = -1;
        }


        private void BtnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnMinimizarse_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnSalirse_Click(object sender, EventArgs e) {
            if (MessageBox.Show("¿Desea Salir sin guardar?","SALIENDO",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                this.Close();
            }
            
        }
    }
}
