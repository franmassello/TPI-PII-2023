using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    public class Sala
    {
        public int IdSala { get; set; }
        public int TipoSalaId { get; set; }
        public int CantButacas { get; set; }

        public string TipoSala { get; set; }

        public Sala(int idSala, int cantButacas, int tipoSalaId, string tipoSala)
        {
            IdSala = idSala;
            TipoSalaId = tipoSalaId;
            CantButacas = cantButacas;
            TipoSala = tipoSala;
        }
    }
}
