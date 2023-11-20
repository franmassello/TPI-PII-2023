using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    internal class TipoPago
    {
        public int IdTipoPago { get; set; }
        public string Descripcion { get; set; }

        public TipoPago(int idTipoPago, string descripcion)
        {
            IdTipoPago = idTipoPago;
            Descripcion = descripcion;
        }
    }
}
