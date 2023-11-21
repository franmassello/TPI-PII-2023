using CineArtBack.Datos.Interfaces;
using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineArtBack.Datos.Implementaciones
{
    public class PeliculaDAO : IPeliculaDAO
    {
        public List<Pelicula> getComboPelicula()
        {
            List<Pelicula> list = new List<Pelicula>();
            DataTable tabla = DBHelper.obtenerInstancia().comboPeliculas();
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_producto"].ToString());
                string titulo = dr["titulo"].ToString();
                string descripcion = dr["descripcion"].ToString();
                string genero = dr["genero"].ToString();
                string fechaEstrenoString = dr["fechaEstreno"].ToString();
                DateTime fechaEstreno = DateTime.Parse(fechaEstrenoString);
                string idioma = dr["idioma"].ToString();
                string formato = dr["formato"].ToString();

                Pelicula aux = new Pelicula(id, titulo, descripcion, genero, fechaEstreno, idioma, formato);
                list.Add(aux);
            }
            return list;
        }

        public List<GeneroPelicula> getComboGenero() 
        {
            List<GeneroPelicula> list = new List<GeneroPelicula>();
            DataTable tabla = DBHelper.obtenerInstancia().comboGenero();
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_genero"].ToString());
                string nombre = dr["genero"].ToString();
                GeneroPelicula aux = new GeneroPelicula(id, nombre);
                list.Add(aux);
            }
            return list;

        }
        public List<Idioma> getComboIdioma() 
        {
            List<Idioma> list = new List<Idioma>();
            DataTable tabla = DBHelper.obtenerInstancia().comboGenero();
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_idioma"].ToString());
                string nombre = dr["idioma"].ToString();
                Idioma aux = new Idioma(id, nombre);
                list.Add(aux);
            }
            return list;
        }
        public List<FormatoPelicula> getComboFormato()
        {
            List<FormatoPelicula> list = new List<FormatoPelicula>();
            DataTable tabla = DBHelper.obtenerInstancia().comboFormato();
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_formato"].ToString());
                string nombre = dr["formato"].ToString();
                FormatoPelicula aux = new FormatoPelicula(id, nombre);
                list.Add(aux);
            }
            return list;
        }
        public bool getInsertPelicula(Pelicula pelicula)
        {
            return DBHelper.obtenerInstancia().insertPelicula(pelicula);

        }
        public bool getDeletePelicula(int numero)
        {
            return DBHelper.obtenerInstancia().deletePelicula(numero);

        }
        public bool getUpdatePelicula(int numero, Pelicula pelicula)
        {
            return DBHelper.obtenerInstancia().updatePelicula(numero, pelicula);

        }
    }
}
