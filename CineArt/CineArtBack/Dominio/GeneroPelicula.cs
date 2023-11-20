using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    internal class GeneroPelicula
    {
        public int Id_genero { get; set; }
        public string Genero { get; set; }
        public GeneroPelicula(int id_genero, string genero)
        {
            this.Id_genero = id_genero;
            this.Genero = genero;
        }

       
    }
}
