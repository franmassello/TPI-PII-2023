﻿using System;
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
        string genero;
        DateTime fechaEstreno;
        string idioma;
        string formato;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Genero { get => genero; set => genero = value; }
        public DateTime FechaEstreno { get => fechaEstreno; set => fechaEstreno = value; }
        public string Idioma { get => idioma; set => idioma = value; }
        public string Formato { get => formato; set => formato = value; }

        public Pelicula(int id, string titulo, string descripcion, string genero, DateTime fechaEstreno, string idioma, string formato)
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
            this.genero = "";
            this.fechaEstreno = DateTime.Today;
            this.idioma = "";
            this.formato = "";
        }

        public override string ToString()
        {
            return titulo + " " + genero + " " + fechaEstreno.ToString() + " " + idioma + " " + formato;
        }

    }
}
