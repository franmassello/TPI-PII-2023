using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    internal class Butaca
    {
        public int IdButaca { get; set; }
        public int IdSala { get; set; }
        public int NroButaca { get; set; }
        public int Fila { get; set; } 


        public Butaca()
        {
            IdButaca = 0;
            IdSala = 0;
            NroButaca = 0;
            Fila = 0;
        }

        public Butaca(int idSala, int idButaca, int numero, int fila)
        {
            IdButaca = idButaca;
            IdSala = idSala;
            NroButaca = numero;
            Fila = fila;
        }
    }
}
