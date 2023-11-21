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
        #region combos

        public DataTable comboIdioma()
        {
            comando.Parameters.Clear();
            conectar();
            comando.CommandText = "cargarIdiomas";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
        public DataTable comboFormato()
        {
            comando.Parameters.Clear();
            conectar();
            comando.CommandText = "cargarFormatos";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }

        public DataTable comboGenero()
        {
            comando.Parameters.Clear();
            conectar();
            comando.CommandText = "cargarGeneros";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
        public DataTable comboPeliculas()
        {
            comando.Parameters.Clear();
            conectar();
            comando.CommandText = "cargarPeliculas";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            desconectar();
            return tabla;
        }
        public bool Login(string user, string password)
        {
            comando.Parameters.Clear();
            conectar();
            comando = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password", conexion);
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
        #endregion

        public bool insertFactura(Factura factura)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "insert_Factura";
                comando.Parameters.AddWithValue("@fecha", factura.Fecha);
                comando.Parameters.AddWithValue("@hora", factura.Hora);
                comando.Parameters.AddWithValue("@id_cliente", factura.Id_cliente);
                comando.Parameters.AddWithValue("@id_forma_pago", factura.Id_forma_pago);
                SqlParameter parametro = new SqlParameter("@id", SqlDbType.Int);
                parametro.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametro);
                comando.ExecuteNonQuery();
                int idFactura = (int)parametro.Value;
                foreach (DetalleFactura detalle in factura.DetalleFactura)
                {
                    comando.Parameters.Clear();
                    comando.CommandText = "insert_Detalle";
                    comando.Parameters.AddWithValue("@id_factura", idFactura);
                    comando.Parameters.AddWithValue("@precio", detalle.Precio);
                    comando.Parameters.AddWithValue("@id_funcion", detalle.Id_Funcion);
                    comando.Parameters.AddWithValue("@descuento", detalle.Descuento);
                    comando.Parameters.AddWithValue("@id_butaca", detalle.Id_Butaca);
                    comando.Parameters.AddWithValue("@cantidad", detalle.Cantidad);

                    comando.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
                ok = false;

            }
            finally
            {
                desconectar();
            }
            return ok;
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
                comando.CommandText = "insertPelicula";
                comando.Parameters.AddWithValue("@titulo", pelicula.pTitulo);
                comando.Parameters.AddWithValue("@descripcion", pelicula.pDescripcion);
                comando.Parameters.AddWithValue("@id_genero", pelicula.pGenero);
                comando.Parameters.AddWithValue("@fecha_estreno", pelicula.pFechaEstreno);
                comando.Parameters.AddWithValue("@id_idioma", pelicula.pIdioma);
                comando.Parameters.AddWithValue("@id_formato", pelicula.pFormato);
                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception)
            {
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
                comando.CommandText = "eliminarPelicula";
                comando.Parameters.AddWithValue("@id_pelicula", numero);
                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception)
            {
                t.Rollback();
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
                comando.CommandText = "editarProducto";
                comando.Parameters.AddWithValue("@id_pelicula", numero);
                comando.Parameters.AddWithValue("@titulo", pelicula.pTitulo);
                comando.Parameters.AddWithValue("@descripcion", pelicula.pDescripcion);
                comando.Parameters.AddWithValue("@id_genero", pelicula.pGenero);
                comando.Parameters.AddWithValue("@fecha_estreno", pelicula.pFechaEstreno);
                comando.Parameters.AddWithValue("@id_idioma", pelicula.pIdioma);
                comando.Parameters.AddWithValue("@id_formato", pelicula.pFormato);
                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception)
            {
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
