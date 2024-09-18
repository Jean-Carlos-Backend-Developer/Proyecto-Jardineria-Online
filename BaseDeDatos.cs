using System;
using MySql.Data.MySqlClient;

namespace proyecto_Jardineria
{
    public class BaseDeDatos
    {
        MySqlConnection conexionBD;  //Para conectar con la Base de Datos
        MySqlCommand orden; // Para el comando de conexión
        MySqlDataReader lector; //Almacenará los datos de las consultas
        string strConexion; //Almacenará la cadena de conexión a la BD

        public BaseDeDatos()
        {
            strConexion = @"server=localhost;port=3306;password=root;userid=root;database=jardineriaonline";
            conexionBD = new MySqlConnection(strConexion);
            orden = new MySqlCommand();
        }

        public BaseDeDatos(string strConexion)
        {
            this.strConexion = strConexion;
            conexionBD = new MySqlConnection(strConexion);
            orden = new MySqlCommand();
        }

        public void Abrir()
        {
            conexionBD.Open();

        }

        public void Cerrar()
        {
            if (lector != null)
                lector.Close();

            if (conexionBD != null)
                conexionBD.Close();
        }

        public MySqlDataReader EjecutarSelect(string SQL)
        {
            try
            {
                orden.CommandText = SQL;
                orden.Connection = conexionBD;
                orden.CommandTimeout = 60;
                lector = orden.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al ejecutar la consulta:" + e.Message);
            }
            return lector;
        }

        public int EjecutarIUD(string SQL)
        {
            int filasAfectadas = 0;
            try
            {
                orden.CommandText = SQL;
                orden.Connection = conexionBD;
                orden.CommandTimeout = 60;
                filasAfectadas = orden.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta: " + ex.Message);
            }
            return filasAfectadas;
        }
    }
}

