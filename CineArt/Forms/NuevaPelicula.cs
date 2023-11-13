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
    public partial class NuevaPelicula : Form {
        AccesoDatos oDato = new AccesoDatos();
        List<Pelicula> listaPeliculas = new List<Pelicula>(); 
        public NuevaPelicula() {
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


        private void NuevaPelicula_Load(object sender, EventArgs e) {
            try {
                cargarCombo(cboFormato, "formatos_peliculas");
                cargarCombo(cboGenero, "Generos");
                cargarCombo(cboIdioma, "Idiomas");
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

        private void cargarCombo(ComboBox combo, string nombreTabla) {
            DataTable tabla = new DataTable();
            tabla = oDato.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;


        }


        private void BtnAgregar_Click(object sender, EventArgs e) {


            if (validar()) {


                string consultaSQL = "";
                Pelicula p = new Pelicula();
                p.pTitulo = txtTitulo.Text;
                p.pDescripcion = txtDescripcion.Text;
                p.pGenero = Convert.ToInt32(cboGenero.SelectedValue);
                p.pFechaEstreno = dtpFechaEstreno.Value;
                p.pIdioma = Convert.ToInt32(cboIdioma.SelectedValue);
                p.pFormato = Convert.ToInt32(cboFormato.SelectedValue);
                try {
                    if (!existe(p.pTitulo)) {
                        consultaSQL = "INSERT INTO PELICULAS(TITULO,DESCRIPCION,ID_GENERO,FECHA_ESTRENO,ID_IDIOMA,ID_FORMATO) VALUES("
                        + "'" + p.pTitulo + "'" + "," + "'" + p.pDescripcion + "'" + "," +
                        p.pGenero + "," + "'" + p.pFechaEstreno.ToString("yyyy-MM-dd") + "'" + "," + p.pIdioma + "," + p.pFormato + ")";

                        
                        oDato.actualizarBD(consultaSQL);
                        MessageBox.Show("Pelicula agregada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();

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
