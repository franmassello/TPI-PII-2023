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
                comando.Parameters.AddWithValue("@titulo", pelicula.Titulo);
                comando.Parameters.AddWithValue("@descripcion", pelicula.Descripcion);
                comando.Parameters.AddWithValue("@genero_var", pelicula.Genero);
                comando.Parameters.AddWithValue("@fecha_estreno", pelicula.FechaEstreno);
                comando.Parameters.AddWithValue("@idioma_var", pelicula.Idioma);
                comando.Parameters.AddWithValue("@formato_var", pelicula.Formato);
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
                comando.Parameters.AddWithValue("@titulo", pelicula.Titulo);
                comando.Parameters.AddWithValue("@descripcion", pelicula.Descripcion);
                comando.Parameters.AddWithValue("@genero_var", pelicula.Genero);
                comando.Parameters.AddWithValue("@fecha_estreno", pelicula.FechaEstreno);
                comando.Parameters.AddWithValue("@idioma_var", pelicula.Idioma);
                comando.Parameters.AddWithValue("@formato_var", pelicula.Formato);
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

        public DataTable getFacturas()
        {
            try
            {
                comando.Parameters.Clear();
                conectar();
                comando = new SqlCommand("EXEC SP_GET_FACTURAS", conexion);
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
                comando.CommandText = "SP_INSERT_FACTURA";

                comando.Parameters.AddWithValue("@fecha", factura.Fecha);
                comando.Parameters.AddWithValue("@hora", factura.Hora);
                comando.Parameters.AddWithValue("@id_cliente", factura.Id_cliente);
                comando.Parameters.AddWithValue("@id_forma_pago", factura.Id_forma_pago);
                comando.Parameters.AddWithValue("@precio", factura.DetalleFactura.Precio);
                comando.Parameters.AddWithValue("@id_funcion", factura.DetalleFactura.Id_Funcion);
                comando.Parameters.AddWithValue("@descuento", factura.DetalleFactura.Descuento);
                comando.Parameters.AddWithValue("@id_butaca", factura.DetalleFactura.Id_Butaca);
                comando.Parameters.AddWithValue("@cantidad", factura.DetalleFactura.Cantidad);

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

        public bool updateFactura(int numero, Factura factura)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_UPDATE_FACTURA";

                comando.Parameters.AddWithValue("@id_factura", numero);
                comando.Parameters.AddWithValue("@fecha", factura.Fecha);
                comando.Parameters.AddWithValue("@hora", factura.Hora);
                comando.Parameters.AddWithValue("@id_cliente", factura.Id_cliente);
                comando.Parameters.AddWithValue("@id_forma_pago", factura.Id_forma_pago);
                
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

        public bool deleteFactura(int numero)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_DELETE_FACTURA";
                comando.Parameters.AddWithValue("@id_factura", numero);
                comando.ExecuteNonQuery();
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine(ex.Message);
                ok = false;
            }
            finally
            {
                desconectar();
            }
            return ok;
        }

        public DataTable getFunciones()
        {
            try
            {
                comando.Parameters.Clear();
                conectar();
                comando = new SqlCommand("EXEC SP_GET_FUNCIONES", conexion);
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

        public bool insertFuncion(Funcion funcion)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_INSERT_FUNCION";

                comando.Parameters.AddWithValue("@id_sala", funcion.Id_sala);
                comando.Parameters.AddWithValue("@id_pelicula", funcion.Id_pelicula);
                comando.Parameters.AddWithValue("@horario", funcion.Horario);
                comando.Parameters.AddWithValue("@dia", funcion.Dia);


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

        // i need to update funcion and delete funcion

        public bool updateFuncion(int numero, Funcion funcion)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_UPDATE_FUNCION";

                comando.Parameters.AddWithValue("@id_funcion", numero);
                comando.Parameters.AddWithValue("@id_sala", funcion.Id_sala);
                comando.Parameters.AddWithValue("@id_pelicula", funcion.Id_pelicula);
                comando.Parameters.AddWithValue("@horario", funcion.Horario);
                comando.Parameters.AddWithValue("@dia", funcion.Dia);

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

        public bool deleteFuncion(int numero)
        {
            bool ok = true;
            SqlTransaction t = null;
            try
            {
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_DELETE_FUNCION";
                comando.Parameters.AddWithValue("@id_funcion", numero);
                comando.ExecuteNonQuery();
                t.Commit();
                desconectar();
            }
            catch (Exception ex)
            {
                t.Rollback();
                Console.WriteLine(ex.Message);
                ok = false;
            }
            finally
            {
                desconectar();
            }
            return ok;
        }

        // need one to do getSalas

        public DataTable getSalas()
        {
            try
            {
                comando.Parameters.Clear();
                conectar();
                comando = new SqlCommand("EXEC SP_GET_SALAS", conexion);
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

        // i need to do getButacas 

        public DataTable getButacasLibres(int idFuncion)
        {
            SqlTransaction t = null;
            try
            {
                DataTable tablaLibres = new DataTable();
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_BUTACAS_LIBRES";
                comando.Parameters.AddWithValue("@id_funcion", idFuncion);
                comando.ExecuteNonQuery();
                tablaLibres.Load(comando.ExecuteReader());
                t.Commit();
                desconectar();


                return tablaLibres;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataTable getButacasTotales(int idFuncion)
        {
            SqlTransaction t = null;
            try
            {
                DataTable tablaTotales = new DataTable();
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_GET_BUTACAS_TOTALES";
                comando.Parameters.AddWithValue("@id_funcion", idFuncion);
                comando.ExecuteNonQuery();
                tablaTotales.Load(comando.ExecuteReader());
                t.Commit();
                desconectar();

                return tablaTotales;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public DataTable getButacasOcupadas(int idFuncion)
        {
            SqlTransaction t = null;
            try
            {
                DataTable tablaTotales = new DataTable();
                conectar();
                comando.Parameters.Clear();
                t = conexion.BeginTransaction();
                comando.Transaction = t;
                comando.CommandText = "SP_GET_BUTACAS_OCUPADAS";
                comando.Parameters.AddWithValue("@id_funcion", idFuncion);
                comando.ExecuteNonQuery();
                tablaTotales.Load(comando.ExecuteReader());
                t.Commit();
                desconectar();

                return tablaTotales;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


    }
}
