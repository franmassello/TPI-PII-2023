using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    internal class Idioma
    { 
    public int Id_idioma { get; set; }
    public string Lenguaje { get; set; }
    public Idioma(int id_idioma, string idioma)
        {
            this.Id_idioma = id_idioma;
            this.Lenguaje = idioma;
        }
    }
}
