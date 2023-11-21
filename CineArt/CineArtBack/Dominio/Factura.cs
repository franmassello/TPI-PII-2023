using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    public class Factura
    {
        public int Id_factura { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int Id_cliente { get; set; }
        public int Id_forma_pago { get; set; }
        public List<DetalleFactura> DetalleFactura { get; set; }

        public Factura(int id_factura, DateTime fecha, TimeSpan hora, int id_cliente, int id_forma_pago)
        {
            this.Id_factura = id_factura;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Id_cliente = id_cliente;
            this.Id_forma_pago = id_forma_pago;
        }

        public void agregarDetalle(DetalleFactura detalle)
        {
            DetalleFactura.Add(detalle);
        }
        public void quitarDetalle(int index)
        {
            DetalleFactura.RemoveAt(index);
        }
    }
}
