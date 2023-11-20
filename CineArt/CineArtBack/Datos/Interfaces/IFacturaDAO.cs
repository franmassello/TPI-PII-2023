using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineArtBack.Datos.Interfaces
{
    public interface IFacturaDAO
    {
        List<Cliente> getComboCliente();
        List<FormaEntrega> getComboFormaEntrega();
        List<MedioPedido> getComboMedioPedido();
        List<FormaPago> getComboFormaPago();
        List<Producto> getComboProducto();
        bool getInsertFactura(Factura factura);
        Factura getFactura(int nro);
        List<Factura> getFacturas();
        bool getInsertCliente(Cliente cliente);
        bool getDeleteCliente(int numero);
        bool getUpdateCliente(int numero, Cliente cliente);
        bool getInsertProducto(Producto producto);
        bool getDeleteProducto(int numero);
        bool getUpdateProducto(int numero, Producto producto);
        bool getUpdateFactura(int numero, Factura factura);
        bool getDeleteFactura(int numero);
        int getProximaFactura();
        List<Usuario> getUsuario();
    }
}
