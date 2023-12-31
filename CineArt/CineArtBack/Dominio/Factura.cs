﻿using System;
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
        public DateTime Hora { get; set; }
        public int Id_cliente { get; set; }
        public int Id_forma_pago { get; set; }
        public DetalleFactura DetalleFactura { get; set; }

        public Factura(int id_factura, DateTime fecha, DateTime hora, int id_cliente, int id_forma_pago, DetalleFactura detalleFactura)
        {
            this.Id_factura = id_factura;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Id_cliente = id_cliente;
            this.Id_forma_pago = id_forma_pago;
            this.DetalleFactura = detalleFactura;
        }

    }
}
