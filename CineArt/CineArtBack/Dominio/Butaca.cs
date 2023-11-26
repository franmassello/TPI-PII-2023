using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    public class Butaca
    {
        public int IdFuncion { get; set; }
        public int IdSala { get; set; }
        public int NroButaca { get; set; }
        public string Fila { get; set; } 


        public Butaca()
        {
            IdFuncion = 0;
            IdSala = 0;
            NroButaca = 0;
            Fila = "";
        }

        public Butaca(int idSala, int idButaca, int numero, string fila)
        {
            IdFuncion = idButaca;
            IdSala = idSala;
            NroButaca = numero;
            Fila = fila;
        }
    }
}
