using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    public class DetalleFactura
    {
        public int Id_Detalle { get; set; }
        public int Id_Factura { get; set; }
        public double Precio { get; set; }
        public int Id_Funcion { get; set; }
        public double Descuento { get; set; }
        public int Id_Butaca { get; set; }
        public int Cantidad { get; set; }

        public DetalleFactura(double costo, int butacaId, int funcion, double descuento)
        {
            Precio = costo;
            Id_Funcion = funcion;
            Id_Butaca = butacaId;
            Descuento = descuento;
            Cantidad = 1;
        }

        public DetalleFactura()
        {
            Precio = 0;
            Id_Funcion = 0;
            Id_Butaca = 0;
            Descuento = 0;
            Cantidad = 0;
        }
    }
}
