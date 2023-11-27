using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPicon
{
    public class FacturaBack
    {
        public int Id_factura { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int Id_cliente { get; set; }
        public int Id_forma_pago { get; set; }
        public DetalleFacturaBack DetalleFactura { get; set; }

        public FacturaBack(int id_factura, DateTime fecha, DateTime hora, int id_cliente, int id_forma_pago, DetalleFacturaBack detalleFactura)
        {
            this.Id_factura = id_factura;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Id_cliente = id_cliente;
            this.Id_forma_pago = id_forma_pago;
            this.DetalleFactura = detalleFactura;
        }

        public FacturaBack()
        {
            this.Id_factura = 0;
            this.Fecha = DateTime.Now;
            this.Hora = DateTime.Now;
            this.Id_cliente = 0;
            this.Id_forma_pago = 0;
            this.DetalleFactura = new DetalleFacturaBack();
        }


    }
}
