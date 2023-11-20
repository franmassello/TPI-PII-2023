using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineArtBack.Dominio
{
    public class Pelicula
    {
        int id;
        string titulo;
        string descripcion;
        int genero;
        DateTime fechaEstreno;
        int idioma;
        int formato;

        public int pId { get => id; set => id = value; }
        public string pTitulo { get => titulo; set => titulo = value; }
        public string pDescripcion { get => descripcion; set => descripcion = value; }
        public int pGenero { get => genero; set => genero = value; }
        public DateTime pFechaEstreno { get => fechaEstreno; set => fechaEstreno = value; }
        public int pIdioma { get => idioma; set => idioma = value; }
        public int pFormato { get => formato; set => formato = value; }

        public Pelicula(int id, string titulo, string descripcion, int genero, DateTime fechaEstreno, int idioma, int formato)
        {
            this.id = id;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.genero = genero;
            this.fechaEstreno = fechaEstreno;
            this.idioma = idioma;
            this.formato = formato;
        }
        public Pelicula()
        {
            this.id = 0;
            this.titulo = "";
            this.descripcion = "";
            this.genero = 0;
            this.fechaEstreno = DateTime.Today;
            this.idioma = 0;
            this.formato = 0;
        }

        public override string ToString()
        {
            return id + " " + titulo + " " + genero + " " + fechaEstreno.ToString() + " " + idioma + " " + formato;
        }

    }
}
