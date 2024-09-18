using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace proyecto_Jardineria
{
    public class DetallePedido
    {
        private static MySqlDataReader lector;

        public int Codigo_Pedido { get; set; }
        public string Codigo_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_Unidad { get; set; }
        public int Numero_Linea { get; set; }

        public DetallePedido(int codigo_pedido, string codigo_producto, int cantidad, decimal precio_unidad, int numero_linea)
        {
            this.Codigo_Pedido = codigo_pedido;
            this.Codigo_Producto = codigo_producto;
            this.Cantidad = cantidad;
            this.Precio_Unidad = precio_unidad;
            this.Numero_Linea = numero_linea;
        }

        public DetallePedido()
        {
        }

        public static List<DetallePedido> ListaDetalle(int codigo)
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<DetallePedido> lista = new List<DetallePedido>();

            bbdd.Abrir();
            try
            {
                lector = bbdd.EjecutarSelect($"Select * from Detalle_Pedido Where codigo_pedido = {codigo}");

                while (lector.Read())
                {
                    lista.Add(new DetallePedido(lector.GetInt32("Codigo_Pedido"), lector.GetString("Codigo_Producto"), lector.GetInt32("Cantidad"),
                                          lector.GetDecimal("Precio_Unidad"), lector.GetInt32("Numero_Linea")));
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

        public override bool Equals(object obj)
        {
            return obj is DetallePedido pedido &&
                   Codigo_Pedido == pedido.Codigo_Pedido &&
                   Codigo_Producto == pedido.Codigo_Producto;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo_Pedido, Codigo_Producto);
        }

        public override string ToString()
        {
            return $"{Codigo_Pedido}: {Codigo_Producto} {Cantidad}";
        }

        public DetallePedido Clone()
        {
            return MemberwiseClone() as DetallePedido;
        }
    }
}

