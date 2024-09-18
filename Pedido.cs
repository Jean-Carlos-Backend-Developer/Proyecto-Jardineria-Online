using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace proyecto_Jardineria
{
    public class Pedido
    {
        private static MySqlDataReader lector;

        public int Codigo_Pedido { get; set; }
        public DateTime Fecha_Pedido { get; set; }
        public DateTime Fecha_Esperada { get; set; }
        public DateTime Fecha_Entrega { get; set; }
        public string Estado { get; set; }
        public string Comentarios { get; set; }
        public int Codigo_Cliente { get; set; }

        public Pedido(int codigo_Pedido, DateTime fecha_Pedido, DateTime fecha_Esperada, DateTime fecha_Entrega, string estado, string comentarios, int codigo_Cliente)
        {
            Codigo_Pedido = codigo_Pedido;
            Fecha_Pedido = fecha_Pedido;
            Fecha_Esperada = fecha_Esperada;
            Fecha_Entrega = fecha_Entrega;
            Estado = estado;
            Comentarios = comentarios;
            Codigo_Cliente = codigo_Cliente;
        }

        public Pedido()
        {
        }

        public Pedido(int codigo_Pedido)
        {
            Codigo_Pedido = codigo_Pedido;
        }

        public Pedido(DateTime fecha_Pedido, DateTime fecha_Esperada, DateTime fecha_Entrega, string estado, string comentarios, int codigo_Cliente)
        {
            Fecha_Pedido = fecha_Pedido;
            Fecha_Esperada = fecha_Esperada;
            Fecha_Entrega = fecha_Entrega;
            Estado = estado;
            Comentarios = comentarios;
            Codigo_Cliente = codigo_Cliente;
        }

        public override bool Equals(object obj)
        {
            return obj is Pedido pedido &&
                   Codigo_Pedido == pedido.Codigo_Pedido;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo_Pedido);
        }

        public int Insertar()
        {
            int filasAfectadas = 0;
            BaseDeDatos bbdd = new BaseDeDatos();

            bbdd.Abrir();
            try
            {
                filasAfectadas = bbdd.EjecutarIUD(String.Format($"INSERT INTO Pedido(fecha_pedido,fecha_esperada," +
                    "fecha_entrega,estado,comentarios,codigo_cliente) VALUES " +
                    "('{0}','{1}','{2}','{3}','{4}',{5})",
                    Fecha_Pedido.ToString("yyyy-MM-dd"), Fecha_Esperada.ToString("yyyy-MM-dd"), Fecha_Entrega.ToString("yyyy-MM-dd"), Estado, Comentarios, Codigo_Cliente));
            }
            catch (Exception ex)
            {
                filasAfectadas = 0;
                Console.WriteLine("Error al insertar pedido {0}", ex.Message);
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
                filasAfectadas = bbdd.EjecutarIUD(String.Format("UPDATE Pedido SET " +
                                                                    "fecha_pedido='{0}'," +
                                                                    "fecha_esperada='{1}'," +
                                                                    "fecha_entrega='{2}'," +
                                                                    "estado='{3}'," +
                                                                    "comentarios='{4}'" +
                                                                    "WHERE codigo_pedido={5}",



                                            Fecha_Pedido.ToString("yyyy-MM-dd"), Fecha_Esperada.ToString("yyyy-MM-dd"),
                                            Fecha_Entrega.ToString("yyyy-MM-dd"), Estado, Comentarios, Codigo_Pedido));
            }
            catch (Exception ex)
            {
                filasAfectadas = 0;
                Console.WriteLine("Error al actualizar el pedido {0}", ex.Message);
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
                filas = bbdd.EjecutarIUD($"Delete from pedido where codigo_pedido={codigo}");
            }
            catch (Exception ex)
            {
                filas = 0;
                Console.WriteLine("Error al borrar Pedido:" + ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return filas;
        }

        public override string ToString()
        {
            return $"{Codigo_Pedido}{Fecha_Pedido.ToShortDateString()}{Estado}{Comentarios}{Codigo_Cliente}";
        }

        public Pedido Clone()
        {
            return MemberwiseClone() as Pedido;
        }

        public static List<Pedido> ListaPedido(int codigo)
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Pedido> lista = new List<Pedido>();

            bbdd.Abrir();
            try
            {
                lector = bbdd.EjecutarSelect($"Select * from Pedido Where codigo_pedido = {codigo}");

                while (lector.Read())
                {
                    lista.Add(new Pedido(lector.GetInt32("Codigo_Pedido"),
                                         lector.GetDateTime("Fecha_Pedido"),
                                         lector.GetDateTime("Fecha_Esperada"),
                                         lector.IsDBNull(3) ? default : lector.GetDateTime("Fecha_Entrega"),
                                         lector.GetString("Estado"),
                                         lector.IsDBNull(5) ? default : lector.GetString("Comentarios"),
                                         lector.GetInt32("Codigo_Cliente")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los Pedidos:" + ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return lista;

        }

        //Listado codigos pedido
        public static List<Pedido> ListarPedidos()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Pedido> lista = new List<Pedido>();

            bbdd.Abrir();
            try
            {
                lector = bbdd.EjecutarSelect($"Select * from Pedido");

                while (lector.Read())
                {
                    lista.Add(new Pedido(lector.GetInt32("Codigo_Pedido"),
                                         lector.GetDateTime("Fecha_Pedido"),
                                         lector.GetDateTime("Fecha_Esperada"),
                                         lector.IsDBNull(3) ? default : lector.GetDateTime("Fecha_Entrega"),
                                         lector.GetString("Estado"),
                                         lector.IsDBNull(5) ? default : lector.GetString("Comentarios"),
                                         lector.GetInt32("Codigo_Cliente")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los Pedidos:" + ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return lista;
        }

        //Listado pedidos Entregados
        public static List<Pedido> ListarPedidosEntregados()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Pedido> lista = new List<Pedido>();

            bbdd.Abrir();
            try
            {
                lector = bbdd.EjecutarSelect($"select * from pedido where estado = 'Entregado' ORDER BY codigo_pedido asc");

                while (lector.Read())
                {
                    lista.Add(new Pedido(lector.GetInt32("Codigo_Pedido"),
                                         lector.GetDateTime("Fecha_Pedido"),
                                         lector.GetDateTime("Fecha_Esperada"),
                                         lector.IsDBNull(3) ? default : lector.GetDateTime("Fecha_Entrega"),
                                         lector.GetString("Estado"),
                                         lector.IsDBNull(5) ? default : lector.GetString("Comentarios"),
                                         lector.GetInt32("Codigo_Cliente")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los Pedidos Entregados:" + ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return lista;
        }

        //Listado pedidos Pendientes
        public static List<Pedido> ListarPedidosPendientes()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Pedido> lista = new List<Pedido>();

            bbdd.Abrir();
            try
            {
                lector = bbdd.EjecutarSelect($"select * from pedido where estado = 'Pendiente' ORDER BY codigo_pedido asc");

                while (lector.Read())
                {
                    lista.Add(new Pedido(lector.GetInt32("Codigo_Pedido"),
                                         lector.GetDateTime("Fecha_Pedido"),
                                         lector.GetDateTime("Fecha_Esperada"),
                                         lector.IsDBNull(3) ? default : lector.GetDateTime("Fecha_Entrega"),
                                         lector.GetString("Estado"),
                                         lector.IsDBNull(5) ? default : lector.GetString("Comentarios"),
                                         lector.GetInt32("Codigo_Cliente")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los Pedidos Pendientes:" + ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return lista;
        }

        //Listado pedidos Rechazados
        public static List<Pedido> ListarPedidosRechazados()
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Pedido> lista = new List<Pedido>();

            bbdd.Abrir();
            try
            {
                lector = bbdd.EjecutarSelect($"select * from pedido where estado = 'Rechazado' ORDER BY codigo_pedido asc");

                while (lector.Read())
                {
                    lista.Add(new Pedido(lector.GetInt32("Codigo_Pedido"),
                                         lector.GetDateTime("Fecha_Pedido"),
                                         lector.GetDateTime("Fecha_Esperada"),
                                         lector.IsDBNull(3) ? default : lector.GetDateTime("Fecha_Entrega"),
                                         lector.GetString("Estado"),
                                         lector.IsDBNull(5) ? default : lector.GetString("Comentarios"),
                                         lector.GetInt32("Codigo_Cliente")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los Pedidos Rechazados:" + ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
            }
            return lista;
        }

    }
}

