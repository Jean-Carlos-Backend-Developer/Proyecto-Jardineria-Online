using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace proyecto_Jardineria
{
    public class Cliente
    {
        private static MySqlDataReader lector;

        public int Codigo_cliente { get; set; }
        public string Nombre_cliente { get; set; }
        public string Nombre_contacto { get; set; }
        public string Apellido_contacto { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Linea_direccion1 { get; set; }
        public string Linea_direccion2 { get; set; }
        public string Ciudad { get; set; }
        public string Region { get; set; }
        public string Pais { get; set; }
        public string Codigo_postal { get; set; }
        public int Codigo_empleado_rep_ventas { get; set; }
        public double Limite_credito { get; set; }
        public string Pass { get; set; }

        public Cliente(int codigo_cliente, string nombre_cliente, string nombre_contacto, string apellido_contacto,
            string telefono, string fax, string linea_direccion1, string linea_direccion2, string ciudad, string region,
            string pais, string codigo_postal, int codigo_empleado_rep_ventas, double limite_credito, string pass)
        {
            Codigo_cliente = codigo_cliente;
            Nombre_cliente = nombre_cliente;
            Nombre_contacto = nombre_contacto;
            Apellido_contacto = apellido_contacto;
            Telefono = telefono;
            Fax = fax;
            Linea_direccion1 = linea_direccion1;
            Linea_direccion2 = linea_direccion2;
            Ciudad = ciudad;
            Region = region;
            Pais = pais;
            Codigo_postal = codigo_postal;
            Codigo_empleado_rep_ventas = codigo_empleado_rep_ventas;
            Limite_credito = limite_credito;
            Pass = pass;
        }

        public Cliente(int codigo_cliente, string nombre_cliente, string nombre_contacto, string apellido_contacto,
            string telefono, string fax, string linea_direccion1, string ciudad, string pais, string pass)
        {
            Codigo_cliente = codigo_cliente;
            Nombre_cliente = nombre_cliente;
            Nombre_contacto = nombre_contacto;
            Apellido_contacto = apellido_contacto;
            Telefono = telefono;
            Fax = fax;
            Linea_direccion1 = linea_direccion1;
            Ciudad = ciudad;
            Pais = pais;
            Pass = pass;
        }

        public Cliente(int codigo_empleado_rep_ventas)
        {
            Codigo_empleado_rep_ventas = codigo_empleado_rep_ventas;
        }

        public Cliente()
        {

        }


        public static List<Cliente> ListaClientesDistintos()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Cliente> resultado = new List<Cliente>();

            bbdd.Abrir();

            try
            {
                lector = bbdd.EjecutarSelect($"SELECT DISTINCT codigo_empleado_rep_ventas FROM Cliente");

                while (lector.Read())
                {
                    resultado.Add(new Cliente(lector.GetInt32("codigo_empleado_rep_ventas")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar clientes:" + ex.Message);
            }
            finally
            {
                lector.Close();
                bbdd.Cerrar();
            }

            return resultado;
        }


        public static List<Cliente> ListaClientes()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Cliente> resultado = new List<Cliente>();

            bbdd.Abrir();

            try
            {
                lector = bbdd.EjecutarSelect($"SELECT * FROM Cliente");

                while (lector.Read())
                {
                    resultado.Add(new Cliente(lector.GetInt32("codigo_cliente"),
                        lector.GetString("nombre_cliente"),
                        lector.GetString("nombre_contacto"),
                        lector.GetString("apellido_contacto"),
                        lector.GetString("telefono"),
                        lector.GetString("fax"),
                        lector.GetString("linea_direccion1"),
                        lector.GetString("ciudad"),
                        lector.GetString("pais"),
                        //lector.IsDBNull(2) ? default : lector.GetString("nombre_contacto"),
                        lector.GetString("pass")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar clientes:" + ex.Message);
            }
            finally
            {
                lector.Close();
                bbdd.Cerrar();
            }

            return resultado;
        }

        public static List<Cliente> ListaCliente(int codigo)
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Cliente> resultado = new List<Cliente>();

            bbdd.Abrir();

            try
            {
                lector = bbdd.EjecutarSelect($"SELECT * FROM Cliente WHERE codigo_cliente = {codigo}");

                while (lector.Read())
                {
                    resultado.Add(new Cliente(lector.GetInt32("codigo_cliente"),
                        lector.GetString("nombre_cliente"),
                        lector.IsDBNull(2) ? default : lector.GetString("nombre_contacto"),
                        lector.IsDBNull(3) ? default : lector.GetString("apellido_contacto"),
                        lector.GetString("telefono"),
                        lector.GetString("fax"),
                        lector.GetString("linea_direccion1"),
                        lector.IsDBNull(7) ? default : lector.GetString("linea_direccion2"),
                        lector.GetString("ciudad"),
                        lector.IsDBNull(9) ? default : lector.GetString("region"),
                        lector.IsDBNull(10) ? default : lector.GetString("pais"),
                        lector.IsDBNull(11) ? default : lector.GetString("codigo_postal"),
                        lector.IsDBNull(12) ? default : lector.GetInt32("codigo_empleado_rep_ventas"),
                        lector.IsDBNull(13) ? default : lector.GetDouble("limite_credito"),
                        lector.GetString("pass")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar cliente:" + ex.Message);
            }
            finally
            {
                lector.Close();
                bbdd.Cerrar();
            }
            return resultado;
        }


        //listado de España
        public static List<Cliente> ListaEspaña()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Cliente> resultado = new List<Cliente>();

            bbdd.Abrir();

            try
            {
                lector = bbdd.EjecutarSelect($"SELECT * FROM Cliente WHERE pais = 'Spain' or pais = 'España'");

                while (lector.Read())
                {
                    resultado.Add(new Cliente(lector.GetInt32("codigo_cliente"),
                        lector.GetString("nombre_cliente"),
                        lector.IsDBNull(2) ? default : lector.GetString("nombre_contacto"),
                        lector.IsDBNull(3) ? default : lector.GetString("apellido_contacto"),
                        lector.GetString("telefono"),
                        lector.GetString("fax"),
                        lector.GetString("linea_direccion1"),
                        lector.IsDBNull(7) ? default : lector.GetString("linea_direccion2"),
                        lector.GetString("ciudad"),
                        lector.IsDBNull(9) ? default : lector.GetString("region"),
                        lector.IsDBNull(10) ? default : lector.GetString("pais"),
                        lector.IsDBNull(11) ? default : lector.GetString("codigo_postal"),
                        lector.IsDBNull(12) ? default : lector.GetInt32("codigo_empleado_rep_ventas"),
                        lector.IsDBNull(13) ? default : lector.GetDouble("limite_credito"),
                        lector.GetString("pass")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar cliente:" + ex.Message);
            }
            finally
            {
                lector.Close();
                bbdd.Cerrar();
            }
            return resultado;
        }

        //listado de Estados Unidos
        public static List<Cliente> ListaUSA()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Cliente> resultado = new List<Cliente>();

            bbdd.Abrir();

            try
            {
                lector = bbdd.EjecutarSelect($"SELECT * FROM Cliente WHERE pais = 'USA' or pais = 'Estados Unidos'");

                while (lector.Read())
                {
                    resultado.Add(new Cliente(lector.GetInt32("codigo_cliente"),
                        lector.GetString("nombre_cliente"),
                        lector.IsDBNull(2) ? default : lector.GetString("nombre_contacto"),
                        lector.IsDBNull(3) ? default : lector.GetString("apellido_contacto"),
                        lector.GetString("telefono"),
                        lector.GetString("fax"),
                        lector.GetString("linea_direccion1"),
                        lector.IsDBNull(7) ? default : lector.GetString("linea_direccion2"),
                        lector.GetString("ciudad"),
                        lector.IsDBNull(9) ? default : lector.GetString("region"),
                        lector.IsDBNull(10) ? default : lector.GetString("pais"),
                        lector.IsDBNull(11) ? default : lector.GetString("codigo_postal"),
                        lector.IsDBNull(12) ? default : lector.GetInt32("codigo_empleado_rep_ventas"),
                        lector.IsDBNull(13) ? default : lector.GetDouble("limite_credito"),
                        lector.GetString("pass")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar cliente:" + ex.Message);
            }
            finally
            {
                lector.Close();
                bbdd.Cerrar();
            }
            return resultado;
        }

        //listado de Otros Paises
        public static List<Cliente> ListaOtros()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Cliente> resultado = new List<Cliente>();

            bbdd.Abrir();

            try
            {
                lector = bbdd.EjecutarSelect($"select * from cliente where (pais != 'España' and pais != 'Spain') AND (pais != 'USA' and pais != 'Estados Unidos')");

                while (lector.Read())
                {
                    resultado.Add(new Cliente(lector.GetInt32("codigo_cliente"),
                        lector.GetString("nombre_cliente"),
                        lector.IsDBNull(2) ? default : lector.GetString("nombre_contacto"),
                        lector.IsDBNull(3) ? default : lector.GetString("apellido_contacto"),
                        lector.GetString("telefono"),
                        lector.GetString("fax"),
                        lector.GetString("linea_direccion1"),
                        lector.IsDBNull(7) ? default : lector.GetString("linea_direccion2"),
                        lector.GetString("ciudad"),
                        lector.IsDBNull(9) ? default : lector.GetString("region"),
                        lector.IsDBNull(10) ? default : lector.GetString("pais"),
                        lector.IsDBNull(11) ? default : lector.GetString("codigo_postal"),
                        lector.IsDBNull(12) ? default : lector.GetInt32("codigo_empleado_rep_ventas"),
                        lector.IsDBNull(13) ? default : lector.GetDouble("limite_credito"),
                        lector.GetString("pass")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar cliente:" + ex.Message);
            }
            finally
            {
                lector.Close();
                bbdd.Cerrar();
            }
            return resultado;
        }


        public int Insertar()
        {

            int filasAfectadas = 0;
            BaseDeDatos bbdd = new BaseDeDatos();

            bbdd.Abrir();
            try
            {
                filasAfectadas = bbdd.EjecutarIUD(String.Format($"INSERT INTO Cliente(nombre_cliente,nombre_contacto,apellido_contacto," +
                    "telefono,fax,linea_direccion1,linea_direccion2,ciudad,region,pais,codigo_postal,codigo_empleado_rep_ventas," +
                    "limite_credito,pass) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',{11},{12},'{13}')",
                    Nombre_cliente, Nombre_contacto, Apellido_contacto, Telefono, Fax, Linea_direccion1, Linea_direccion2, Ciudad, Region, Pais, Codigo_postal,
                    Codigo_empleado_rep_ventas, Limite_credito, Pass));
            }
            catch (Exception ex)
            {
                filasAfectadas = 0;
                Console.WriteLine("Error al insertar cliente {0}", ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return filasAfectadas;
        }

        public int Actualizar()
        {
            int filasAfectadas = 0;
            BaseDeDatos bbdd = new BaseDeDatos();

            bbdd.Abrir();
            try
            {
                filasAfectadas = bbdd.EjecutarIUD(String.Format("UPDATE Cliente SET " +
                                                                    "nombre_cliente='{0}'," +
                                                                    "nombre_contacto='{1}'," +
                                                                    "apellido_contacto='{2}'," +
                                                                    "telefono='{3}'," +
                                                                    "fax='{4}'," +
                                                                    "linea_direccion1='{5}'," +
                                                                    "linea_direccion2='{6}'," +
                                                                    "ciudad='{7}'," +
                                                                    "region='{8}'," +
                                                                    "pais='{9}'," +
                                                                    "codigo_postal='{10}'," +
                                                                    "codigo_empleado_rep_ventas={11}," +
                                                                    "limite_credito={12}," +
                                                                    "pass='{13}'" +
                                                                    "WHERE codigo_cliente={14}",

                Nombre_cliente, Nombre_contacto, Apellido_contacto, Telefono, Fax, Linea_direccion1, Linea_direccion2, Ciudad, Region, Pais, Codigo_postal,
                Codigo_empleado_rep_ventas, Limite_credito, Pass, Codigo_cliente));
            }
            catch (Exception ex)
            {
                filasAfectadas = 0;
                Console.WriteLine("Error al actualizar cliente {0}", ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return filasAfectadas;
        }

        public static int Borrar(int codigo)
        {
            BaseDeDatos bbdd = new BaseDeDatos();

            int filas = 0;
            bbdd.Abrir();
            try
            {
                filas = bbdd.EjecutarIUD($"Delete from cliente where codigo_cliente={codigo}");
            }
            catch (Exception ex)
            {
                filas = 0;
                Console.WriteLine("Error al borrar Cliente:" + ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return filas;
        }

        public override bool Equals(object obj)
        {
            return obj is Cliente cliente &&
                   Codigo_cliente == cliente.Codigo_cliente;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo_cliente);
        }

        public override string ToString()
        {
            return $"{Codigo_cliente,-7} {Nombre_cliente,-50} {Nombre_contacto,-30} {Apellido_contacto,-30} {Ciudad,-50}";
        }

        public Cliente Clone()
        {
            return MemberwiseClone() as Cliente;
        }

    }
}

