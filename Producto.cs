using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace proyecto_Jardineria
{
    public class Producto
    {
        private static MySqlDataReader lector;

        public string Codigo_producto { get; set; }
        public string Nombre { get; set; }
        public string Gama { get; set; }
        public string Dimensiones { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_En_Stock { get; set; }
        public decimal Precio_Venta { get; set; }
        public decimal Precio_Proveedor { get; set; }

        public Producto()
        {

        }

        public Producto(string codigo_producto, string nombre, string gama,
            string dimensiones, string proveedor, string descripcion,
            int cantidad_En_Stock, decimal precio_Venta, decimal precio_Proveedor)
        {
            Codigo_producto = codigo_producto;
            Nombre = nombre;
            Gama = gama;
            Dimensiones = dimensiones;
            Proveedor = proveedor;
            Descripcion = descripcion;
            Cantidad_En_Stock = cantidad_En_Stock;
            Precio_Venta = precio_Venta;
            Precio_Proveedor = precio_Proveedor;
        }

        public override bool Equals(object obj)
        {
            return obj is Producto producto &&
                   Codigo_producto == producto.Codigo_producto;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo_producto);
        }

        public override string ToString()
        {
            return $"Codigo: {Codigo_producto} - Nombre: {Nombre} - Precio: {Precio_Venta.ToString("C")}";
        }

        public Producto Clone()
        {
            return MemberwiseClone() as Producto;
        }

        public static List<Producto> ListaProducto(string codigo)
        {
            BaseDeDatos bbdd = new BaseDeDatos();
            List<Producto> lista = new List<Producto>();

            bbdd.Abrir();
            try
            {
                lector = bbdd.EjecutarSelect($"Select * from Producto Where codigo_producto = '{codigo}'");

                while (lector.Read())
                {
                    lista.Add(new Producto(lector.GetString("Codigo_Producto"),
                        lector.GetString("Nombre"),
                        lector.GetString("Gama"),
                        lector.IsDBNull(3) ? default : lector.GetString("Dimensiones"),
                        lector.IsDBNull(4) ? default : lector.GetString("Proveedor"),
                        lector.IsDBNull(5) ? default : lector.GetString("Descripcion"),
                        lector.GetInt32("Cantidad_En_Stock"),
                        lector.GetDecimal("Precio_Venta"),
                        lector.IsDBNull(8) ? default : lector.GetDecimal("Precio_Proveedor")));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar los Productos:" + ex.Message);
            }
            finally
            {
                bbdd.Cerrar();
                lector.Close();
            }
            return lista;

        }
    }
}

