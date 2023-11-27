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

namespace CinemaPicon
{

    public partial class MenuFunciones : Form
    {


        FuncionBack f;
        string consulta;
        bool banderaFiltro = false;
        AccesoDatos oDato = new AccesoDatos();
        APIMethods APIMethods = new APIMethods();
        public string pConsulta { get => consulta; set => consulta = value; }

        public MenuFunciones()
        {
            InitializeComponent();
        }


        //DLL PARA PODER MOVER LA VENTANA CON EL MOUSE DOWN
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        // ACA TERMINA EL DLL

        //EVENTOS PARA MOVER LA VENTANA
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Principal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private async void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                CargarColumnasEnDGV();
                refrescarDG();
                deshabilitarEdicionDG(true);
                // CARGAR SALAS Y PELICULAS COMO COMBO

                await CargarComboAsync(cboSalas, "getSalas");
                await CargarComboAsync(cboPeliculas, "getPeliculas");
                dtpFecha.Enabled = false;
                //dtpFecha.Format = DateTimePickerFormat.Custom;
                // dtpFecha.Format = DateTimePickerFormat.Time;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void CargarColumnasEnDGV()
        {
            dataGridView1.ColumnCount = 7;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Visible = false;
            this.dataGridView1.Columns[2].Visible = false;
            this.dataGridView1.Columns[3].Visible = false;
            this.dataGridView1.Columns[4].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;
            this.dataGridView1.Columns[6].Visible = false;
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
        //CARGA COMBOBOX
        private async void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = await APIMethods.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = -1;


        }
        //VALIDACION PARA QUE NO PUEDA ESCRIBIR EN EL DATAGRID
        private void deshabilitarEdicionDG(bool estado)
        {
            dataGridView1.Columns[0].ReadOnly = estado;
            dataGridView1.Columns[1].ReadOnly = estado;
            dataGridView1.Columns[2].ReadOnly = estado;
            dataGridView1.Columns[3].ReadOnly = estado;
            dataGridView1.Columns[4].ReadOnly = estado;
            dataGridView1.Columns[5].ReadOnly = estado;
            dataGridView1.Columns[6].ReadOnly = estado;
        }

        private void BtnNuevoPrincipal_Click(object sender, EventArgs e)
        {
            NuevaFuncion nf = new NuevaFuncion();
            nf.ShowDialog();
            refrescarDG();
        }

        //BOTON MINIMIZAR
        private void BtnMinimizarse_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //BOTON CERRAR SESION
        private void BtnCerrarPrincipal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();

            }


        }

        //CRUZ SUPERIOR DERECHA
        private void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        //REFRESCAR DATAGRID
        public async void refrescarDG()
        {
            string consultaBase = "select f.id_funcion, s.id_sala, ts.tipo_sala, fp.formato, p.titulo as titulo_pelicula, dia, horario, i.idioma, p.id_pelicula, (SELECT Count(*) FROM detalles d WHERE d.id_funcion = f.id_funcion) as butacas_ocupadas, s.cant_butacas from Funciones f join peliculas p on p.id_pelicula=f.id_pelicula join salas s on s.id_sala=f.id_sala join Idiomas i on i.id_idioma=p.id_idioma join Formatos_peliculas fp on fp.id_formato=p.id_formato join Tipos_salas ts on ts.id_tipo_sala=s.id_tipo_sala";
            this.dataGridView1.DataSource = oDato.consultar(consultaBase);
            this.dataGridView1.Refresh();


        }
        private async void BtnEliminarPrincipal_Click(object sender, EventArgs e)
        {

            if (this.f == null)
            {
                MessageBox.Show("Seleccione una funcion de la lista para eliminar");

            }
            else
            {

                try
                {
                    if (MessageBox.Show("Usted esta por eliminar esta funcion, Esta seguro?", "ELIMINANDO PELICULA",
    MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {


                        // use deleteFuncion from APIMethods.cs\
                        string response = await APIMethods.DeleteFuncion("deleteFuncion", f.id_funcion);


                        MessageBox.Show("Funcion Eliminada");
                        refrescarDG();

                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    MessageBox.Show("Esta funcion no puede ser eliminada para proteger la integridad de la base de datos");
                }
                finally
                {
                    oDato.desconectar();
                }

            }
        }


        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.CurrentRow;

                if (row != null)
                {
                    this.f = new FuncionBack();
                    int baseColValue = 7;
                    this.f.id_funcion = int.Parse(row.Cells[baseColValue].Value.ToString());
                    this.f.id_sala = int.Parse(row.Cells[baseColValue + 1].Value.ToString());
                    this.f.id_pelicula = int.Parse(row.Cells[baseColValue + 8].Value.ToString());
                    this.f.horario = DateTime.Parse(row.Cells[baseColValue + 6].Value.ToString());
                    this.f.dia = row.Cells[baseColValue + 5].Value.ToString();
                    this.f.cant_butacas = int.Parse(row.Cells[baseColValue + 10].Value.ToString());
                    this.f.cant_butacas_ocupadas = int.Parse(row.Cells[baseColValue + 9].Value.ToString());
                }

            }
        }

        private void BtnEditarPrincipal_Click(object sender, EventArgs e)
        {
            if (this.f == null)
            {
                MessageBox.Show("Seleccione una funcion de la lista");

            }
            else
            {
                EditarFuncion editar = new EditarFuncion();
                editar.recibirDatosDePelicula( f.id_funcion, f.id_sala, f.id_pelicula, f.horario, f.dia, f.cant_butacas, f.cant_butacas_ocupadas);
                editar.ShowDialog();
                refrescarDG();

            }
        }


        private void BtnSalirse_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta Seguro que desea cerrar la pestaña Funciones?", "Salir", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Close();
            }
        }


        //FILTROS

        public string filtrar()
        {
            string condicion = "";

            string[] arrayFiltros = new string[7];
            int contI = 0;

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                condicion = "f.id_funcion = " + txtCodigo.Text;
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (dtpFecha.Enabled)
            {

                //string dia = dtpFecha.Value.ToString("yyyy-MM-dd");

                //DateTime dia = dtpFecha.Value;

                // only date 
                //string dia1 = dtpFecha.Value.ToShortDateString();
                // convert dia to int 
                int dia = Convert.ToInt32(dtpFecha.Value.ToString("yyyyMMdd"));

                string final = "'" + dia + "'";
                condicion = " dia = " + final;
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (cboPeliculas.SelectedIndex != -1)
            {
                condicion = "p.id_pelicula = " + cboPeliculas.SelectedValue;
                arrayFiltros[contI] = condicion;
                contI++;
            }

            if (cboSalas.SelectedIndex != -1)
            {
                condicion = "s.id_sala = " + cboSalas.SelectedValue;
                arrayFiltros[contI] = condicion;
                contI++;
            }



            var sb = new System.Text.StringBuilder();

            if (contI == 0)
            {
                return null;
            }
            else if (contI == 1)
            {
                sb.Append(arrayFiltros[0]);
            }
            else
            {
                sb.Append(arrayFiltros[0]);
                for (int i = 1; i < contI; i++)
                {
                    sb.Append(" and");
                    sb.Append(arrayFiltros[i]);

                }
            }

            return sb.ToString();
        }

        private void cbxFecha_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbxFecha.Checked)
            {
                dtpFecha.Enabled = true;
            }
            else
            {
                dtpFecha.Enabled = false;
            }
        }



        private void BtnFiltrar_Click(object sender, EventArgs e)
        {

            this.consulta = filtrar();

            if (this.consulta == null)
            {

                string consultaBase = "select f.id_funcion, s.id_sala, ts.tipo_sala, fp.formato, p.titulo as titulo_pelicula, dia, horario, i.idioma, p.id_pelicula, (SELECT Count(*) FROM detalles d WHERE d.id_funcion = f.id_funcion) as butacas_ocupadas, s.cant_butacas from Funciones f join peliculas p on p.id_pelicula=f.id_pelicula join salas s on s.id_sala=f.id_sala join Idiomas i on i.id_idioma=p.id_idioma join Formatos_peliculas fp on fp.id_formato=p.id_formato join Tipos_salas ts on ts.id_tipo_sala=s.id_tipo_sala";
                this.dataGridView1.DataSource = oDato.consultar(consultaBase);
                this.dataGridView1.Refresh();
                // refrescarDG();
            }
            else
            {
                //this.consulta = "SELECT * FROM Funciones WHERE " + filtrar();

                this.consulta = "select f.id_funcion, s.id_sala, ts.tipo_sala, fp.formato, p.titulo as titulo_pelicula, dia, horario, i.idioma, p.id_pelicula, (SELECT Count(*) FROM detalles d WHERE d.id_funcion = f.id_funcion) as butacas_ocupadas, s.cant_butacas from Funciones f join peliculas p on p.id_pelicula=f.id_pelicula join salas s on s.id_sala=f.id_sala join Idiomas i on i.id_idioma=p.id_idioma join Formatos_peliculas fp on fp.id_formato=p.id_formato join Tipos_salas ts on ts.id_tipo_sala=s.id_tipo_sala WHERE " + filtrar() + ';';

                this.dataGridView1.DataSource = oDato.consultar(consulta);
                this.dataGridView1.Refresh();
            }



            txtCodigo.Clear();
            cboPeliculas.SelectedIndex = -1;
            cboSalas.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Today.AddDays(1);

            //validacion para el crystal report
            banderaFiltro = true;
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {





        }

        private void TxtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Process.Start("https://0112-186-138-214-149.ngrok-free.app/");
        }

        private void lblCodigoPeli_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblFechaEstreno_Click(object sender, EventArgs e)
        {

        }

        private void dtpFecha_onValueChanged(object sender, EventArgs e)
        {

        }
    }
}
