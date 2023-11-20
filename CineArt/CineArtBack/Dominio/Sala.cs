using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    internal class Sala
    {
        public int IdSala { get; set; }
        public int Capacidad { get; set; }
        public int NumeroPeliculas { get; set; }
        public int TipoSalaId { get; set; }

        public Sala(int idSala, int capacidad, int numeroPeliculas, int tipoSalaId)
        {
            IdSala = idSala;
            Capacidad = capacidad;
            NumeroPeliculas = numeroPeliculas;
            TipoSalaId = tipoSalaId;
        }
    }
}
