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
    public class FuncionDAO : IFuncionDAO
    {
        public List<Funcion> getFunciones()
        {
            List<Funcion> list = new List<Funcion>();
            DataTable tabla = DBHelper.obtenerInstancia().getFunciones();
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_funcion"].ToString());
                int idSala = int.Parse(dr["id_sala"].ToString());
                int idPelicula = int.Parse(dr["id_pelicula"].ToString());
                DateTime horario = DateTime.Parse(dr["horario"].ToString());
                string dia = dr["dia"].ToString();
                int cantButacas = int.Parse(dr["cant_butacas"].ToString());
                int cantButacasOcupadas = int.Parse(dr["butacas_ocupadas"].ToString());

                Funcion aux = new Funcion(id, idSala, idPelicula, horario, dia, cantButacas, cantButacasOcupadas);
                list.Add(aux);
            }
            return list;
        }

        public List<Sala> getSalas() 
        {
            List<Sala> list = new List<Sala>();
            DataTable tabla = DBHelper.obtenerInstancia().getSalas();
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_sala"].ToString());
                string tipoSala = dr["tipo_sala"].ToString();
                int cantButacas = int.Parse(dr["cant_butacas"].ToString());
                int tipoSalaId = int.Parse(dr["id_tipo_sala"].ToString());
                Sala aux = new Sala(id, cantButacas, tipoSalaId, tipoSala);
                list.Add(aux);
            }
            return list;

        }
      
        public bool insertFuncion(Funcion funcion)
        {
            return DBHelper.obtenerInstancia().insertFuncion(funcion);

        }
        public bool deleteFuncion(int numero)
        {
            if(numero == null)
            {
                return false;
            } else
            {
                return DBHelper.obtenerInstancia().deleteFuncion(numero);
            }
        }
        public bool updateFuncion(int numero, Funcion funcion)
        {
            if(numero == null)
            {
                return false;
            } else
            {
                return DBHelper.obtenerInstancia().updateFuncion(numero, funcion);
            }

        }

    }
}
