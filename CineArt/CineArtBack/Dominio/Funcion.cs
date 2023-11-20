using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    internal class Funcion
    {
        public Funcion(int id_funcion, int id_sala, int id_pelicula, DateTime horario, string dia)
        {
            this.Id_funcion = id_funcion;
            this.Id_sala = id_sala;
            this.Id_pelicula = id_pelicula;
            this.Horario = horario;
            this.Dia = dia;
        }

        public int Id_funcion { get; set; }
        public int Id_sala { get; set; }
        public int Id_pelicula { get; set; }
        public DateTime Horario { get; set; }
        public string Dia { get; set; }
    }
}
