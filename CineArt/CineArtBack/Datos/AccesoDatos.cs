using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CineArtBack.Datos
{
    public class AccesoDatos
    {
        protected SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-168KBNT\SQLEXPRESS;Initial Catalog=CINEART5;Integrated Security=True;");
        protected SqlCommand comando = new SqlCommand();
        protected void conectar()
        {
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
        }
        protected void desconectar()
        {
            conexion.Close();
        }
    }
}
