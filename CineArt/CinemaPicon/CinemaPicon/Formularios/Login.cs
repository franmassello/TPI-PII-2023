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

namespace CinemaPicon {
    public partial class Login : Form {

        AccesoDatos oDato = new AccesoDatos();
        
        public Login() {
            InitializeComponent();
            
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);



        public void loguear(string usuario, string contraseña) {

            try {


                DataTable dt = new DataTable();
                DataTable dtUsuarios = new DataTable();
                dtUsuarios = oDato.consultarTabla("usuarios");

                oDato.conectar();
                oDato.pComando.CommandText = "SELECT nombre,tipo_usuario FROM usuarios WHERE usuario = @usuario AND contraseña = @contraseña";
                oDato.pComando.Parameters.AddWithValue("usuario", usuario);
                oDato.pComando.Parameters.AddWithValue("contraseña", contraseña);
                dt.Load(oDato.pComando.ExecuteReader());

                string usuarioBD = dtUsuarios.Rows[0][3].ToString();
                string contraseñaBD = dtUsuarios.Rows[0][2].ToString() ;


                if (dt.Rows.Count != 0 && contraseñaBD.Equals(contraseña) && usuarioBD.ToLower().Equals(usuario.ToLower())) {

                   
                        this.Hide();
                        Principal principal = new Principal();
                        principal.ShowDialog();
                        this.Close();
                    

                } else {
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
