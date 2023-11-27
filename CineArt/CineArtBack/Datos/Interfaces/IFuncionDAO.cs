using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineArtBack.Datos.Interfaces
{
    public interface IFuncionDAO
    {
        public List<Funcion> getFunciones();
        public List<Sala> getSalas();
        public bool insertFuncion(Funcion funcion);
        public bool deleteFuncion(int numero);
        public bool updateFuncion(int numero, Funcion funcion);

    }
}
