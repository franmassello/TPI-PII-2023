using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineArtBack.Fachada
{
    public interface IData
    {
        List<Pelicula> getComboPelicula();
        List<GeneroPelicula> getComboGenero();
        List<Idioma> getComboIdioma();
        List<FormatoPelicula> getComboFormato();
        bool getInsertPelicula(Pelicula pelicula);
        bool getDeletePelicula(int numero);
        bool getUpdatePelicula(int numero, Pelicula pelicula);
        bool postLogin(string user, string password);
    }
}
