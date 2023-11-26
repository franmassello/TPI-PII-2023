using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineArtBack.Datos.Interfaces
{
    public interface IButacaDAO
    {
        List<Butaca> getButacasLibres(int idFuncion);
        List<Butaca> getButacasTotales(int idFuncion);
        List<Butaca> getButacasOcupadas(int idFuncion);
    }
}
