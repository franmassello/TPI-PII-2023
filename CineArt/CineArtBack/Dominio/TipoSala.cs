using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    public class TipoSala
    {
        public int IdTipoSala { get; set; }
        public string Descripcion { get; set; }

        public TipoSala(int idTipoSala, string descripcion)
        {
            IdTipoSala = idTipoSala;
            Descripcion = descripcion;
        }
    }
}
