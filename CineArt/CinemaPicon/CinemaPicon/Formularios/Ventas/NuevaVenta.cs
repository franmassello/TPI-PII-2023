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


namespace CinemaPicon
{
    public partial class NuevaVenta: Form
    {
        AccesoDatos oDato = new AccesoDatos();
        APIMethods APIMethods = new APIMethods();
        public NuevaVenta()
        {
            InitializeComponent();
        }

        //DLL PARA MOVER VENTANA
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        //MOVER VENTANA CON CLICK
        private void NuevaPelicula_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //MOVER VENTANA CON CLICK
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private async void NuevaPelicula_Load(object sender, EventArgs e)
        {
            try
            {
                await CargarComboAsync(cboSalas, "getSalas");
                await CargarComboAsync(cboPeliculas, "getPeliculas");
                //cargarPeliculasEnLista("Peliculas");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void cargarPeliculasEnLista(string nombreTabla)
        {
            oDato.leerTabla(nombreTabla);
            while (oDato.pLector.Read())
            {

                Pelicula p = new Pelicula();

                if (!oDato.pLector.IsDBNull(0))
                {
                    p.pId = oDato.pLector.GetInt32(0);
                }
                if (!oDato.pLector.IsDBNull(1))
                {
                    p.pTitulo = oDato.pLector.GetString(1);
                }
                if (!oDato.pLector.IsDBNull(2))
                {
                    p.pDescripcion = oDato.pLector.GetString(2);
                }
                if (!oDato.pLector.IsDBNull(3))
                {
                    p.pGenero = oDato.pLector.GetInt32(3);
                }
                if (!oDato.pLector.IsDBNull(4))
                {
                    p.pFechaEstreno = oDato.pLector.GetDateTime(4);
                }
                if (!oDato.pLector.IsDBNull(5))
                {
                    p.pIdioma = oDato.pLector.GetInt32(5);
                }
                if (!oDato.pLector.IsDBNull(6))
                {
                    p.pFormato = oDato.pLector.GetInt32(6);
                }



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


        private async void BtnAgregar_Click(object sender, EventArgs e)
        {


            if (validar())
            {


                int idPelicula = int.Parse(cboPeliculas.SelectedValue.ToString());
                
                fecha = fecha.Date;
                string fechaString = fecha.ToString("yyyy-MM-dd");
               
                string horarioStr = horario.ToString("yyyy-MM-ddTHH:mm:ssZ");
                string dia = fecha.ToString("yy-MM-dd");



                FuncionBack funcion = new FuncionBack(idSala, idPelicula, horario, fechaString);


                try
                {
                    //string json = JsonConvert.SerializeObject(funcion);
                    // instead of serializing funcion, let me enter the properties manually
                    string json = "{\"id_sala\":" + idSala + ",\"id_pelicula\":" + idPelicula + ",\"horario\":\"" + horarioStr + "\",\"dia\":\"" + dia + "\"}";


                    string response = await APIMethods.PostFuncion("postFuncion", json);

                    if (response == "Post successful")
                    {
                        MessageBox.Show("Funcion agregada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                        this.Close();
                    } else
                    {
                        MessageBox.Show("Error al agregar funcion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }

            }



        }

        private bool validar()
        {
            if (cboPeliculas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un genero");
                cboPeliculas.Focus();
                return false;
            }

            if (cboSalas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un idioma");
                cboSalas.Focus();
                return false;
            }

            return true;

        }

        private void limpiarCampos()
        {
            //txtDescripcion.Clear();
            //txtTitulo.Clear();
            cboPeliculas.SelectedIndex = -1;
            dtpFechaEstreno.Value = DateTime.Today;
            cboSalas.SelectedIndex = -1;
        }


        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnMinimizarse_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnSalirse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir sin guardar?", "SALIENDO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cboFormato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaEstreno_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
