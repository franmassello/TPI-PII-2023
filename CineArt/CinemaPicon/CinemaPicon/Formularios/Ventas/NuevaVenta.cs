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
    public partial class NuevaVenta : Form
    {

        string pelicula;
        string horario;
        string formato;
        int idSelected;
        double precio;

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
                //await CargarComboAsync(cboSalas, "getSalas");
                //await CargarComboAsync(cboPeliculas, "getPeliculas");
                //cargarPeliculasEnLista("Peliculas");
                CargarComboSP(cboPeliculas, "SP_GET_FUNCIONES");
                //CargarComboSPParam(cboButacas, "SP_BUTACAS_LIBRES", idSelected);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private async Task CargarComboSP(ComboBox combo, string methodName)
        {
            // Load data into combo box
            DataTable tabla = new DataTable();
            tabla = oDato.ConsultarTablaConSP(methodName);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[10].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;


        }

        private async Task CargarComboSPParam(ComboBox combo, string methodName, int idFuncion)
        {
            // Load data into combo box
            DataTable tabla = new DataTable();
            tabla = oDato.ConsultarTablaConSPParam(methodName, idFuncion);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[7].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;
        }

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {


            if (validar())
            {
                FacturaBack f = new FacturaBack();

                f.Fecha = DateTime.Now;
                f.Hora = DateTime.Now;
                f.Id_cliente = 1;
                f.Id_forma_pago = 1;
                f.DetalleFactura = new DetalleFacturaBack();
                f.DetalleFactura.Id_Funcion = idSelected;
                f.DetalleFactura.Id_Butaca = Convert.ToInt32(cboButacas.SelectedValue);
                f.DetalleFactura.Precio = Convert.ToDouble(numericUpDown1.Value);
                f.DetalleFactura.PrecioFinal = Convert.ToDouble(numericUpDown1.Value);
                f.DetalleFactura.Descuento = 0;
                f.DetalleFactura.Cantidad = 1;

                try
                {

                    string json = JsonConvert.SerializeObject(f);

                    string response = await APIMethods.PostPelicula("insertFactura", json);

                    if(response == "Post successful")
                    {
                        MessageBox.Show("Venta agregada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //MessageBox.Show("Venta agregada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

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
                MessageBox.Show("Seleccione una funcion");
                cboPeliculas.Focus();
                return false;
            }

            /**
            if (cboSalas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un idioma");
                cboSalas.Focus();
                return false;
            }
            **/
            return true;

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

        private async void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPeliculas.SelectedIndex != -1)
            {
                DataRowView selectedRow = (DataRowView)cboPeliculas.SelectedItem;
                this.idSelected = Convert.ToInt32(selectedRow["id_funcion"]);
                //this.precio = Convert.ToDouble(selectedRow["precio"]);
                await CargarComboSPParam(cboButacas, "SP_BUTACAS_LIBRES", idSelected);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //pelicula = textBox1.Text;
        }

    }
}
