using CineArtBack.Datos.Interfaces;
using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineArtBack.Datos.Implementaciones
{
    public class FacturaDAO : IFacturaDAO
    {
        public List<Factura> getFacturas()
        {
            List<Factura> list = new List<Factura>();
            DataTable tabla = DBHelper.obtenerInstancia().getFacturas();
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_factura"].ToString());
                DateTime fecha = DateTime.Parse(dr["fecha"].ToString());
                DateTime hora = DateTime.Parse(dr["hora"].ToString());
                int idCliente = int.Parse(dr["id_cliente"].ToString());
                int idFormaPago = int.Parse(dr["id_forma_pago"].ToString());

                DetalleFactura detalleFactura = new DetalleFactura();

                detalleFactura.Id_Detalle= int.Parse(dr["id_detalle"].ToString());
                detalleFactura.Id_Factura = int.Parse(dr["id_factura"].ToString());
                detalleFactura.Precio = double.Parse(dr["precio_entrada"].ToString());
                detalleFactura.PrecioFinal = double.Parse(dr["precioFinal"].ToString());
                detalleFactura.Id_Funcion = int.Parse(dr["id_funcion"].ToString());
                detalleFactura.Descuento = double.Parse(dr["descuento"].ToString());
                detalleFactura.Id_Butaca = int.Parse(dr["id_butaca"].ToString());
                detalleFactura.Cantidad = int.Parse(dr["cantidad"].ToString());

                Factura aux = new Factura(id, fecha, hora, idCliente, idFormaPago, detalleFactura);
                list.Add(aux);
            }
            return list;
        }
        public bool insertFactura(Factura factura)
        {
            return DBHelper.obtenerInstancia().insertFactura(factura);

        }
        public bool deleteFactura(int numero)
        {
            return DBHelper.obtenerInstancia().deleteFactura(numero);

        }
        public bool updateFactura(int numero, Factura factura)
        {
            return DBHelper.obtenerInstancia().updateFactura(numero, factura);

        }

    }
}
