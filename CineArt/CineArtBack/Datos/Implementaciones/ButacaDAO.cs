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
    public class ButacaDAO : IButacaDAO
    {
        public List<Butaca> getButacasLibres(int idFuncion)
        {
            List<Butaca> list = new List<Butaca>();
            DataTable tabla = DBHelper.obtenerInstancia().getButacasLibres(idFuncion);
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_funcion"].ToString());
                int idSala = int.Parse(dr["id_sala"].ToString());
                int nroButaca = int.Parse(dr["nro_butaca"].ToString());
                string fila = dr["fila"].ToString();

                Butaca aux = new Butaca(id, idSala, nroButaca, fila);
                list.Add(aux);
            }
            return list;
        }

        public List<Butaca> getButacasTotales(int idFuncion)
        {
            List<Butaca> list = new List<Butaca>();
            DataTable tabla = DBHelper.obtenerInstancia().getButacasTotales(idFuncion);
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_funcion"].ToString());
                int idSala = int.Parse(dr["id_sala"].ToString());
                int nroButaca = int.Parse(dr["nro_butaca"].ToString());
                string fila = dr["fila"].ToString();

                Butaca aux = new Butaca(id, idSala, nroButaca, fila);
                list.Add(aux);
            }
            return list;
        }

        public List<Butaca> getButacasOcupadas(int idFuncion)
        {
            List<Butaca> list = new List<Butaca>();
            DataTable tabla = DBHelper.obtenerInstancia().getButacasOcupadas(idFuncion);
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_funcion"].ToString());
                int idSala = int.Parse(dr["id_sala"].ToString());
                int nroButaca = int.Parse(dr["nro_butaca"].ToString());
                string fila = dr["fila"].ToString();

                Butaca aux = new Butaca(id, idSala, nroButaca, fila);
                list.Add(aux);
            }
            return list;
        }
    }
}
