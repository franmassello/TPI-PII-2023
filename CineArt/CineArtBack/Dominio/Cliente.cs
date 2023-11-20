using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    public class Cliente
    {

        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Dni { get; set; }
        public string Email { get; set; }
   

        public Cliente(int id_cliente, string nombre, string apellido, long dni, string email)
        {
            Id_Cliente = id_cliente;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
        }

        public Cliente()
        {
            Id_Cliente = 0;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Dni = 0;
            Email = string.Empty;
        }
    }
}
