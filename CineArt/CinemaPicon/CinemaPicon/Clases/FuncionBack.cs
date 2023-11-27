using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPicon.Clases
{
    public class FuncionBack
    {
        

        public FuncionBack(int id_sala, int id_pelicula, DateTime horario, string dia)
        {
            this.id_sala = id_sala;
            this.id_pelicula = id_pelicula;
            this.horario = horario;
            this.dia = dia;
        }

        public FuncionBack()
        {
            this.id_funcion = 0;
            this.id_sala = 0;
            this.id_pelicula = 0;
            this.horario = new DateTime();
            this.dia = "";
            this.cant_butacas = 0;
            this.cant_butacas_ocupadas = 0;
        }

        public int id_funcion { get; set; }
        public int id_sala { get; set; }
        public int id_pelicula { get; set; }
        public DateTime horario { get; set; }
        public string dia { get; set; }
        public int cant_butacas { get; set; }

        public int cant_butacas_ocupadas { get; set; }
    }
}
