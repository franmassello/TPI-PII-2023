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

namespace CinemaPicon.Formularios {
    public partial class Editar : Form {

        int id;
        string titulo;
        string descripcion;
        int genero;
        DateTime fechaEstreno;
        int idioma;
        int formato;

        AccesoDatos oDato = new AccesoDatos();

        public Editar() {
            InitializeComponent();
        }

        //DLL PARA PODER MOVER LA VENTANA CON EL MOUSE DOWN
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        // ACA TERMINA EL DLL


        private void Editar_Load(object sender, EventArgs e) {
            try {
                cargarCombo(cboFormato, "formatos_peliculas");
                cargarCombo(cboGenero, "Generos");
                cargarCombo(cboIdioma, "Idiomas");
                cargarCampos();
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }

        private void cargarCampos() {
            txtDescripcion.Text = this.descripcion;
            txtTitulo.Text = this.titulo;
            cboGenero.SelectedValue = this.genero;
            dtpFechaEstreno.Value = this.fechaEstreno;
            cboIdioma.SelectedValue = this.idioma;
            cboFormato.SelectedValue = this.formato;
        }

        private void limpiarCampos() {
            txtDescripcion.Clear();
            txtTitulo.Clear();
            cboGenero.SelectedIndex = -1;
            dtpFechaEstreno.Value = DateTime.Today;
            cboIdioma.SelectedIndex = -1;
            cboFormato.SelectedValue = -1;
        }
    


        public void recibirDatosDePelicula(int id, string titulo, string descripcion, int genero, DateTime fechaEstreno, int idioma, int formato) {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.genero = genero;
            this.fechaEstreno = fechaEstreno;
            this.idioma = idioma;
            this.formato = formato;
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


        private void BtnMinimizarse_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnSalirse_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e) {


            if (validar()) {
                if (MessageBox.Show("Esta seguro que desea modificar esta pelicula?", "ADVERTENCIA", MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {

                    string consulta;
                    consulta = "UPDATE PELICULAS SET TITULO = '" + txtTitulo.Text + "'" + ","
                        + "DESCRIPCION = '" + txtDescripcion.Text + "'" + ","
                        + "ID_GENERO = " + Convert.ToInt32(cboGenero.SelectedValue) + ","
                        + "FECHA_ESTRENO = '" + dtpFechaEstreno.Value.ToString("yyyy - MM - dd") + "'" + ","
                        + "ID_IDIOMA = " + Convert.ToInt32(cboIdioma.SelectedValue) + ","
                        + "ID_FORMATO = " + Convert.ToInt32(cboFormato.SelectedValue)
                        + "WHERE ID_PELICULA = " + this.id;
                    oDato.actualizarBD(consulta);
                    MessageBox.Show("Su pelicula fue actualizada");
                    this.Close();
                    Principal p = new Principal();
                    //p.refrescarDG();
                }
            }


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

        private void Button1_Click(object sender, EventArgs e) {
            limpiarCampos();
        }

        private void BtnCancelar_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void Editar_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
