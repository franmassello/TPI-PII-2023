using CineArtBack.Datos.Implementaciones;
using CineArtBack.Datos.Interfaces;
using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineArtBack.Fachada
{
    public class DataLib : IData
    {
        private IPeliculaDAO dao;
        public DataLib()
        {
            dao = new PeliculaDAO();
        }

        public List<Pelicula> getComboPelicula()
        {
            return dao.getComboPelicula();
        }

        public List<GeneroPelicula> getComboGenero()
        {
            return dao.getComboGenero();
        }

        public List<Idioma> getComboIdioma()
        {
            return dao.getComboIdioma();
        }

        public List<FormatoPelicula> getComboFormato()
        {
            return dao.getComboFormato();
        }

        public bool getInsertPelicula(Pelicula pelicula)
        {
            return dao.getInsertPelicula(pelicula);
        }
        public bool getDeletePelicula(int numero)
        {
            return dao.getDeletePelicula(numero);
        }
        public bool getUpdatePelicula(int numero, Pelicula pelicula)
        {
            return dao.getUpdatePelicula(numero, pelicula);
        }

    }
}
