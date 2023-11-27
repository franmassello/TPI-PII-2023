using CinemaPicon.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaPicon.Formularios {
    public partial class EditarPelicula : Form {

        int id;
        string titulo;
        string descripcion;
        string genero;
        DateTime fechaEstreno;
        string idioma;
        string formato;

        AccesoDatos oDato = new AccesoDatos();
        APIMethods APIMethods = new APIMethods();   
        public EditarPelicula() {
            InitializeComponent();
        }

        //DLL PARA PODER MOVER LA VENTANA CON EL MOUSE DOWN
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        // ACA TERMINA EL DLL


        private async void Editar_Load(object sender, EventArgs e) {
            try {
                await CargarComboAsync(cboFormato, "getFormatos");
                await CargarComboAsync(cboGenero, "getGeneros");
                await CargarComboAsync(cboIdioma, "getIdiomas");
                cargarCampos();
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }

        }

        private void cargarCampos() {
            txtDescripcion.Text = this.descripcion;
            txtTitulo.Text = this.titulo;
            cboGenero.SelectedIndex = cboGenero.FindStringExact(this.genero);
            dtpFechaEstreno.Value = this.fechaEstreno;
            cboIdioma.SelectedIndex = cboIdioma.FindStringExact(this.idioma);
            cboFormato.SelectedIndex = cboFormato.FindStringExact(this.formato);
        }

        private void limpiarCampos() {
            txtDescripcion.Clear();
            txtTitulo.Clear();
            cboGenero.SelectedIndex = -1;
            dtpFechaEstreno.Value = DateTime.Today;
            cboIdioma.SelectedIndex = -1;
            cboFormato.SelectedValue = -1;
        }
    


        public void recibirDatosDePelicula(int id, string titulo, string descripcion, string genero, DateTime fechaEstreno, string idioma, string formato) {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.genero = genero;
            this.fechaEstreno = fechaEstreno;
            this.idioma = idioma;
            this.formato = formato;
        }
        private async Task CargarComboAsync(ComboBox combo, string nombreTabla) {
            DataTable tabla = new DataTable();
            tabla = await APIMethods.consultarTabla(nombreTabla);
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

        private async void BtnActualizar_Click(object sender, EventArgs e) {


            if (validar()) {
                if (MessageBox.Show("Esta seguro que desea modificar esta pelicula?", "ADVERTENCIA", MessageBoxButtons.YesNo,
    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {

                   
                    //oDato.actualizarBD(consulta);

                    // instead of using actualizarBD, we use the API method putPelicula
                    string json = "{";
                    json += "\"titulo\": \"" + txtTitulo.Text + "\",";
                    json += "\"descripcion\": \"" + txtDescripcion.Text + "\",";
                    json += "\"genero\": \"" + cboGenero.Text + "\",";
                    json += "\"fechaEstreno\": \"" + dtpFechaEstreno.Value.ToString("yyyy-MM-dd") + "\",";
                    json += "\"idioma\": \"" + cboIdioma.Text + "\",";
                    json += "\"formato\": \"" + cboFormato.Text + "\"";
                    json += "}";


                    
                    var response = await APIMethods.PutPelicula("updatePelicula" , id.ToString(), json);

                    if (response != "Update successful")
                    {
                        MessageBox.Show(response);
                        this.Close();
                        return;
                    } else
                    {
                        MessageBox.Show("Pelicula modificada con exito");
                        this.Close();
                    }

                   

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

        private void cboIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
