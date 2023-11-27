using CineArtBack.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineArtBack.Datos.Interfaces
{
    public interface IFacturaDAO
    {
        public List<Factura> getFacturas();
        public bool insertFactura(Factura factura);
        public bool deleteFactura(int numero);
        public bool updateFactura(int numero, Factura factura);
        
    }
}
