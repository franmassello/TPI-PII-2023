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
        private IPeliculaDAO daoP;
        private IFuncionDAO daoFu;
        private IFacturaDAO daoFa;
        private IButacaDAO daoB;
        public DataLib()
        {
            daoP = new PeliculaDAO();
            daoFu = new FuncionDAO();
            daoFa = new FacturaDAO();
            daoB = new ButacaDAO();
        }

        public List<Pelicula> getComboPelicula()
        {
            return daoP.getComboPelicula();
        }

        public List<GeneroPelicula> getComboGenero()
        {
            return daoP.getComboGenero();
        }

        public List<Idioma> getComboIdioma()
        {
            return daoP.getComboIdioma();
        }

        public List<FormatoPelicula> getComboFormato()
        {
            return daoP.getComboFormato();
        }

        public bool getInsertPelicula(Pelicula pelicula)
        {
            return daoP.getInsertPelicula(pelicula);
        }
        public bool getDeletePelicula(int numero)
        {
            return daoP.getDeletePelicula(numero);
        }
        public bool getUpdatePelicula(int numero, Pelicula pelicula)
        {
            return daoP.getUpdatePelicula(numero, pelicula);
        }

        public bool postLogin(string user, string password)
        {
            return daoP.postLogin(user, password);
        }

        public List<Funcion> getFunciones()
        {
            return daoFu.getFunciones();
        }
        public List<Sala> getSalas()
        {
            return daoFu.getSalas();
        }
        public bool insertFuncion(Funcion funcion)
        {
            return daoFu.insertFuncion(funcion);
        }
        public bool deleteFuncion(int numero)
        {
            return daoFu.deleteFuncion(numero);
        }
        public bool updateFuncion(int numero, Funcion funcion)
        {
            return daoFu.updateFuncion(numero, funcion);
        }

        public List<Factura> getFacturas()
        {
            return daoFa.getFacturas();
        }
        public bool insertFactura(Factura factura)
        {
            return daoFa.insertFactura(factura);
        }
        public bool deleteFactura(int numero)
        {
            return daoFa.deleteFactura(numero);
        }
        public bool updateFactura(int numero, Factura factura)
        {
            return daoFa.updateFactura(numero, factura);
        }

        public List<Butaca> getButacasLibres(int idFuncion)
        {
            return daoB.getButacasLibres(idFuncion);
        }

        public List<Butaca> getButacasTotales(int idFuncion)
        {
            return daoB.getButacasTotales(idFuncion);
        }

        public List<Butaca> getButacasOcupadas(int idFuncion)
        {
            return daoB.getButacasOcupadas(idFuncion);
        }


    }
}
