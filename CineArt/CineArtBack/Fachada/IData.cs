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

        public List<Funcion> getFunciones();
        public List<Sala> getSalas();
        public bool insertFuncion(Funcion funcion);
        public bool deleteFuncion(int numero);
        public bool updateFuncion(int numero, Funcion funcion);

        public List<Factura> getFacturas();
        public bool insertFactura(Factura factura);
        public bool deleteFactura(int numero);
        public bool updateFactura(int numero, Factura factura);

        public List<Butaca> getButacasLibres(int idFuncion);
        public List<Butaca> getButacasTotales(int idFuncion);
        public List<Butaca> getButacasOcupadas(int idFuncion);


    }
}
