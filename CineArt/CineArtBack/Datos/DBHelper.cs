using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CineArtBack.Datos
{
    public class DBHelper : AccesoDatos
    {
        private static DBHelper instancia;
        public static DBHelper obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new DBHelper();
            }
            return instancia;
        }

        public DataTable comboIdioma()
        {
            try
            {
                comando.Parameters.Clear();
                conectar();
                comando = new SqlCommand("EXEC SP_GET_IDIOMAS", conexion);
                DataTable tabla = new DataTable();
                tabla.Load(comando.ExecuteReader());
                desconectar();
                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable comboFormato()
        {
            try
            {
                comando.Parameters.Clear();
                conectar();
                comando = new SqlCommand("EXEC SP_GET_FORMATOS", conexion);
                DataTable tabla = new DataTable();
                tabla.Load(comando.ExecuteReader());
                desconectar();
                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable comboGenero()
        {
            try
            {
                comando.Parameters.Clear();
                conectar();
                comando = new SqlCommand("EXEC SP_GET_GENEROS", conexion);
                DataTable tabla = new DataTable();
                tabla.Load(comando.ExecuteReader());
                desconectar();
                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable comboPeliculas()
        {
            try
            {
                comando.Parameters.Clear();
                conectar();
                comando = new SqlCommand("EXEC SP_GET_PELICULAS", conexion);
                DataTable tabla = new DataTable();
                tabla.Load(comando.ExecuteReader());
                desconectar();
                return tabla;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Login(string user, string password)
        {
            try
            {
                comando.Parameters.Clear();
                conectar();
                comando = new SqlCommand("SELECT COUNT(*) FROM usuarios WHERE usuario = @username AND contraseña = @password", conexion);
                comando.Parameters.AddWithValue("@username", user);
                comando.Parameters.AddWithValue("@password", password);
                int count = (int)comando.ExecuteScalar();
                desconectar();

                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to log in: " + ex.Message);
                return false;
            }
        }
        public DataTable ConsultaSQL(string spNombre, List<Parametro> values)
        {
            DataTable tabla = new DataTable();

            conectar();
            SqlCommand cmd = new SqlCommand(spNombre, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
            {
                foreach (Parametro oParametro in values)
                {
                    cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor);
                }
            }
            tabla.Load(cmd.ExecuteReader());
            desconectar();

            return tabla;
        }
       
        public bool insertPelicula(Pelicula pelicula)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_INSERT_PELICULA";
                comando.Parameters.AddWithValue("@titulo", pelicula.pTitulo);
                comando.Parameters.AddWithValue("@descripcion", pelicula.pDescripcion);
                comando.Parameters.AddWithValue("@genero_var", pelicula.pGenero);
                comando.Parameters.AddWithValue("@fecha_estreno", pelicula.pFechaEstreno);
                comando.Parameters.AddWithValue("@idioma_var", pelicula.pIdioma);
                comando.Parameters.AddWithValue("@formato_var", pelicula.pFormato);
                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                t.Rollback();
                ok = false;
            }
            finally
            {
                desconectar();
            }
            return ok;
        }
        public bool deletePelicula(int numero)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_DELETE_PELICULA";
                comando.Parameters.AddWithValue("@id_pelicula", numero);
                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine(
                        ex.Message
                    );
                ok = false;
            }
            finally
            {
                desconectar();
            }
            return ok;
        }
        public bool updatePelicula(int numero, Pelicula pelicula)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_UPDATE_PELICULA";
                comando.Parameters.AddWithValue("@id_pelicula", numero);
                comando.Parameters.AddWithValue("@titulo", pelicula.pTitulo);
                comando.Parameters.AddWithValue("@descripcion", pelicula.pDescripcion);
                comando.Parameters.AddWithValue("@genero_var", pelicula.pGenero);
                comando.Parameters.AddWithValue("@fecha_estreno", pelicula.pFechaEstreno);
                comando.Parameters.AddWithValue("@idioma_var", pelicula.pIdioma);
                comando.Parameters.AddWithValue("@formato_var", pelicula.pFormato);
                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                t.Rollback();
                ok = false;
            }
            finally
            {
                desconectar();
            }
            return ok;
        }
        public int ConsultaEscalarSQL(string spNombre, string pOutNombre)
        {
            conectar();
            SqlCommand cmd = new SqlCommand(spNombre, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = pOutNombre;
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();
            desconectar();

            return (int)pOut.Value;
        }
    }
}
