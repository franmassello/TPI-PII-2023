using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CinemaPicon.Clases;

namespace CinemaPicon {
    public partial class Login : Form {

        AccesoDatos oDato = new AccesoDatos();
        APIMethods api = new APIMethods();

        public Login() {
            InitializeComponent();
            
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);



        public async void loguear(string usuario, string contraseña) {
            try {
                string response = await api.Login(usuario, contraseña);

                if (response.Equals("Login successful"))
                {
                    this.Hide();
                    Principal principal = new Principal();
                    principal.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                    oDato.pComando.Parameters.Clear();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                oDato.desconectar();
            }

        }

        private void BtnAcceder_Click(object sender, EventArgs e) {
            loguear(txtUsuario.Text,txtContraseña.Text);
        }

        private void Login_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e) {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BtnMinimizarse_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnSalirse_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void TxtContraseña_Enter(object sender, EventArgs e) {
            txtContraseña.UseSystemPasswordChar = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
