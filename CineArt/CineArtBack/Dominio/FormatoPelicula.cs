using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    internal class FormatoPelicula
    {
        
        public int Id_formato { get; set; }
        public string Formato { get; set; }

        public FormatoPelicula(int id_formato, string formato)
        {
            this.Id_formato = id_formato;
            this.Formato = formato;
        }

    }
}
