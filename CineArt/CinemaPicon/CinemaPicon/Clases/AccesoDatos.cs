﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPicon {
    class AccesoDatos {

        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        string cadenaConexion = @"Data Source=DESKTOP-168KBNT\SQLEXPRESS;Initial Catalog=CINEART5;Integrated Security=True;";
        public string pCadenaConexion {
            set { cadenaConexion = value; }
            get { return cadenaConexion; }
        }

        public SqlDataReader pLector {
            set { lector = value; }
            get { return lector; }
        }

        public SqlConnection pConexion { get => conexion; set => conexion = value; }
        public SqlCommand pComando { get => comando; set => comando = value; }
        

        public AccesoDatos() {
            conexion = new SqlConnection();
            comando = new SqlCommand();
            lector = null;
          
        }

        public void conectar() {
            conexion.ConnectionString = cadenaConexion;
            conexion.Open();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;//nos deja escrbir consultas de tipo texto

        }
        public void desconectar() {
            conexion.Close();//cierra la conexion
            conexion.Dispose();//elimina la conexion
        }
        public DataTable consultarTabla(string nombreTabla) {
            DataTable tabla = new DataTable();
            this.conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla; //hay que dejar el espacio en blanco despues del from
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;

        }

        public DataTable consultar(string consulta) {
            DataTable tabla = new DataTable();
            this.conectar();
            comando.CommandText = consulta;
            tabla.Load(comando.ExecuteReader());
            this.desconectar();
            return tabla;
        }

        public void leerTabla(string nombreTabla) {
            this.conectar();
            comando.CommandText = "SELECT * FROM " + nombreTabla;
            lector = comando.ExecuteReader();

        }
        public void actualizarBD(string consultaSQL) {
            this.conectar();
            comando.CommandText = consultaSQL;
            comando.ExecuteNonQuery();//ES NONQUERY PORQUE NO ES UNA CONSULTA SOLO EJECUTA 
            this.desconectar();
        }

        public DataTable ConsultarTablaConSP(string nombreSP)
        {
            DataTable tabla = new DataTable();
            conectar();
            comando.Parameters.Clear();
            comando.CommandText = nombreSP;
            comando.CommandType = CommandType.StoredProcedure;

            tabla.Load(comando.ExecuteReader());

            desconectar();
            return tabla;
        }

        public DataTable ConsultarTablaConSPParam(string nombreSP, int param)
        {
            DataTable tabla = new DataTable();
            conectar();
            comando.Parameters.Clear();
            comando.CommandText = nombreSP;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_funcion", param);

            tabla.Load(comando.ExecuteReader());

            desconectar();
            return tabla;
        }

        // i need to use a SP that deletes a row from a table
        public void BorrarConSP(string nombreSP, int param)
        {
            conectar();
            comando.Parameters.Clear();
            comando.CommandText = nombreSP;
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id_factura", param);

            comando.ExecuteNonQuery();

            desconectar();
        }

    }
}
