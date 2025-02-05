using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Data
{
    public class connection
    {
        public NpgsqlConnection conexion;
        public NpgsqlConnection ConexionBD()
        {
            string servidor = "localhost";
            int puerto = 5432;
            string usuario = "postgres";
            int clave = 123;
            string baseDatos = "adopta";

            string cadenaConexion = "Server=" + servidor + ";" + "Port=" + puerto + ";" + "User Id=" + usuario + ";" + "Password=" + clave + ";" + "Database=" + baseDatos;
            conexion = new NpgsqlConnection(cadenaConexion);
            conexion.Open();

            return conexion;
        }
    }
}

