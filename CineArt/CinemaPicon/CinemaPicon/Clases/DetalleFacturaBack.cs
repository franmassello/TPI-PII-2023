using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPicon
{
    public class DetalleFacturaBack
    {
        public int Id_Detalle { get; set; }
        public int Id_Factura { get; set; }
        public double Precio { get; set; }
        public double PrecioFinal { get; set; }
        public int Id_Funcion { get; set; }
        public double Descuento { get; set; }
        public int Id_Butaca { get; set; }
        public int Cantidad { get; set; }

        public DetalleFacturaBack(double costo, int butacaId, int funcion, double descuento, double precioFinal)
        {
            Precio = costo;
            Id_Funcion = funcion;
            Id_Butaca = butacaId;
            Descuento = descuento;
            Cantidad = 1;
            PrecioFinal = precioFinal;
        }

        public DetalleFacturaBack()
        {
            Precio = 0;
            Id_Funcion = 0;
            Id_Butaca = 0;
            Descuento = 0;
            Cantidad = 0;
            PrecioFinal = 0;
        }
    }
}
