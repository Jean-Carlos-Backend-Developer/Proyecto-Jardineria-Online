using System;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.IO;
using Google.Protobuf.WellKnownTypes;

namespace proyecto_Jardineria
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        //==================================== Función de Menú principal ===================================================
        public static void Menu()
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("Introduce una opción: ");
                Console.WriteLine("1) Clientes");
                Console.WriteLine("2) Pedidos");
                Console.WriteLine("3) Consultas");
                Console.WriteLine("4) Escribir ficheros de Clientes");
                Console.WriteLine("5) Escribir ficheros de Pedidos");
                Console.WriteLine("6) Limpiar pantalla.");
                Console.WriteLine("0) Salir");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            MenuClientes();
                            break;
                        case 2:
                            MenuPedidos();
                            break;
                        case 3:
                            Consultas();
                            break;
                        case 4:
                            MenuEscrituraClientes();
                            break;
                        case 5:
                            MenuEscrituraPedidos();
                            break;
                        case 6:
                            Console.Clear();
                            break;
                        case 0:
                            Incidencia.GuardarIncidencias();
                            Incidencia.ListarIncidencias();
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número.");
                    opcion = -1;
                }
            }
        }

        //==================================== Función de Menú Clientes ===================================================
        public static void MenuClientes()
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("********************** 1. CLIENTES **********************");
                Console.WriteLine("1) Pulse 1 para INSERTAR un CLIENTE");
                Console.WriteLine("2) Pulse 2 para MODIFICAR un CLIENTE");
                Console.WriteLine("3) Pulse 3 para BORRAR un CLIENTE");
                Console.WriteLine("4) Pulse 4 para MOSTRAR todos los CLIENTES");
                Console.WriteLine("0) Pulse 0 para volver al menú principal");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            InsertarClientes();
                            break;
                        case 2:
                            ModificarClientes();
                            break;
                        case 3:
                            BorrarClientes();
                            break;
                        case 4:
                            MostrarClientes();
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número.");
                    opcion = -1;
                }
            }
        }

        //==================================== Función de Menú Pedidos ===================================================
        public static void MenuPedidos()
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("********************** 2. PEDIDOS **********************");
                Console.WriteLine("1) Pulse 1 para INSERTAR un PEDIDO");
                Console.WriteLine("2) Pulse 2 para MODIFICAR un PEDIDO");
                Console.WriteLine("3) Pulse 3 para BORRAR un PEDIDO");
                Console.WriteLine("4) Pulse 4 para MOSTRAR un PEDIDO");
                Console.WriteLine("0) Pulse 0 para volver al menú principal");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            InsertarPedidos();
                            break;
                        case 2:
                            ModificarPedidos();
                            break;
                        case 3:
                            BorrarPedidos();
                            break;
                        case 4:
                            MostrarPedidos();
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número.");
                    opcion = -1;
                }
                if (opcion != 0)
                {
                    Console.WriteLine("Pulsa una tecla para continuar...");
                    Console.ReadLine();
                }
            }
        }

        //==================================== Función de Menú Consultas + Consultas ===================================================
        public static void Consultas()
        {
            int opcion = -1;
            BaseDeDatos bbdd = new BaseDeDatos();
            bbdd.Abrir();
            MySqlDataReader lector;

            while (opcion != 0)
            {
                Console.WriteLine("Selecciona una consulta: ");
                Console.WriteLine("1) Clientes de España.");
                Console.WriteLine("2) Clientes de España con región de Madrid.");
                Console.WriteLine("3) Clientes que empicen por A con límite de crédito superior a 1000");
                Console.WriteLine("4) Productos con stock inferior a 50 unidades.");
                Console.WriteLine("5) Productos con el valor total.");
                Console.WriteLine("6) Pedidos del año 2008.");
                Console.WriteLine("7) Pedidos cuya fecha entrega sea menor de la esperada.");
                Console.WriteLine("8) Datos representantes de ventas de MAD - ES");
                Console.WriteLine("0) Volver al menú anterior.");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        //Clientes de España
                        case 1:
                            try
                            {
                                lector = bbdd.EjecutarSelect("SELECT nombre_cliente, pais, ciudad FROM Cliente WHERE pais = 'SPAIN' or pais = 'España'");
                                Console.WriteLine($"{"CLIENTE",-40}{"PAIS",-15}{"CIUDAD",-15}");
                                Console.WriteLine("--------------------------------------------------------------------------------");
                                while (lector.Read())
                                {
                                    Console.WriteLine($"{lector.GetString(0),-40}{lector.GetString(1),-15}{lector.GetString(2),-15}");
                                }
                                lector.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            break;
                        //Clientes de España con región de Madrid
                        case 2:
                            try
                            {
                                lector = bbdd.EjecutarSelect("SELECT nombre_cliente, pais, region FROM Cliente WHERE (pais = 'SPAIN' or pais = 'España') && region = 'Madrid'");
                                Console.WriteLine($"{"CLIENTE",-40}{"PAÍS",-15}{"REGIÓN",-15}");
                                Console.WriteLine("--------------------------------------------------------------------------------");

                                while (lector.Read())
                                {
                                    Console.WriteLine($"{lector.GetString(0),-40}{lector.GetString(1),-15}{lector.GetString(2),-15}");
                                }
                                lector.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            break;
                        //Clientes que empicen por A con límite de crédito superior a 1000
                        case 3:
                            try
                            {
                                lector = bbdd.EjecutarSelect("SELECT nombre_cliente, limite_credito, ciudad FROM Cliente WHERE nombre_cliente LIKE 'A%' && limite_credito > 1000");
                                Console.WriteLine($"{"CLIENTE",-40}{"CRÉDITO",15}{"CIUDAD",20}");
                                Console.WriteLine("--------------------------------------------------------------------------------");

                                while (lector.Read())
                                {
                                    Console.WriteLine($"{lector.GetString(0),-40}{lector.GetString(1),15}{lector.GetString(2),20}");
                                }
                                lector.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            break;
                        //Productos con stock inferior a 50 unidades.
                        case 4:
                            try
                            {
                                lector = bbdd.EjecutarSelect("SELECT codigo_producto, nombre, cantidad_en_stock FROM Producto WHERE cantidad_en_stock < 50");
                                Console.WriteLine($"{"CÓDIGO",-15}{"PRODUCTO",-50}{"CANTIDAD",15}");
                                Console.WriteLine("--------------------------------------------------------------------------------");
                                while (lector.Read())
                                {
                                    Console.WriteLine($"{lector.GetString(0),-15}{lector.GetString(1),-50}{lector.GetString(2),15}");
                                }
                                lector.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            break;
                        //Productos con el valor total.
                        case 5:
                            try
                            {
                                lector = bbdd.EjecutarSelect("Select codigo_producto, nombre, cantidad_en_stock, precio_venta, cantidad_en_stock * precio_venta as TOTAL from producto order by TOTAL desc");
                                Console.WriteLine($"{"CÓDIGO",-15}{"PRODUCTO",-70}{"STOCK",15}{"PRECIO VENTA",15}{"TOTAL",15}");
                                Console.WriteLine("-----------------------------------------------------------------------------------");

                                while (lector.Read())
                                {
                                    Console.WriteLine($"{lector.GetString(0),-15}{lector.GetString(1),-70}{lector.GetString(2),15}{lector.GetString(3),15}{lector.GetString(4),15}");
                                }
                                lector.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            break;
                        //Pedidos del año 2008.
                        case 6:
                            try
                            {
                                //lector = bbdd.EjecutarSelect("SELECT codigo_pedido, estado, fecha_pedido FROM Pedido WHERE fecha_pedido between '2008-01-01' and '2008-12-01'");
                                lector = bbdd.EjecutarSelect("Select codigo_pedido, estado, fecha_pedido from pedido where year(fecha_pedido) = 2008");
                                Console.WriteLine($"{"PEDIDO",-10}{"ESTADO",-15}{"FECHA",-15}");
                                Console.WriteLine("--------------------------------------------------------------------------------");

                                while (lector.Read())
                                {
                                    Console.WriteLine($"{lector.GetString(0),-10} {lector.GetString(1),-15} {lector.GetString(2),-15}");
                                }
                                lector.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            break;
                        //Pedidos cuya fecha entrega sea menor de la esperada.
                        case 7:
                            try
                            {
                                lector = bbdd.EjecutarSelect("SELECT codigo_pedido, fecha_entrega, fecha_esperada,estado FROM Pedido WHERE fecha_entrega < fecha_esperada");
                                Console.WriteLine($"{"PEDIDO",-10}{"FECHA ENTREGA",-30}{"FECHA ESPERADA",-30}{"ESTADO",-15}");
                                Console.WriteLine("--------------------------------------------------------------------------------");

                                while (lector.Read())
                                {
                                    Console.WriteLine($"{lector.GetString(0),-10}{lector.GetString(1),-30:D2}{lector.GetString(2),-30:D2}{lector.GetString(3),-15}");
                                }
                                lector.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            break;
                        //Datos representantes de ventas de MAD - ES.
                        case 8:
                            try
                            {
                                lector = bbdd.EjecutarSelect("SELECT nombre, apellido1, apellido2 ,email FROM Empleado WHERE codigo_oficina = 'MAD-ES' && puesto = 'Representante Ventas'");
                                Console.WriteLine($"{"NOMBRE",-20}{"APELLIDOS",-30}{"CORREO",-20}");
                                Console.WriteLine("--------------------------------------------------------------------------------");
                                while (lector.Read())
                                {
                                    Console.WriteLine($"{lector.GetString(0),-20}{lector.GetString(1) + " " + lector.GetString(2),-30}{lector.GetString(3),-20}");
                                }
                                lector.Close();
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número.");
                    opcion = -1;
                }
                if (opcion != 0)
                {
                    Incidencia.AddIncidencia(DateTime.Now, "Consultas");
                }
                if (opcion != 0)
                {
                    Console.WriteLine("Pulsa una tecla para continuar...");
                    Console.ReadLine();
                }

            }
            bbdd.Cerrar();
        }

        //==================================== Función de Menú Escritura Clientes ===================================================
        public static void MenuEscrituraClientes()
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("********************** 4. ESCRIBIR FICHEROS DE CLIENTES **********************");
                Console.WriteLine("1) Pulse 1 para Mostrar por pantalla y Escribir fichero Clientes de España");
                Console.WriteLine("2) Pulse 2 para Mostrar por pantalla y Escribir fichero Clientes de ESTADOS UNIDOS");
                Console.WriteLine("3) Pulse 3 para Mostrar por pantalla y Escribir fichero Clientes de otros paises");
                Console.WriteLine("4) Pulse 4 para Limpiar pantalla");
                Console.WriteLine("0) Pulse 0 para volver al menú principal");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Lineas();
                            try
                            {
                                Console.WriteLine($"{"CÓDIGO",-7}{"NOMBRE CLIENTE",-50}{"PAÍS",-30}{"CIUDAD",-50}{"CÓDIGO_ÚNICO",-50}");
                                Lineas();
                                Cliente.ListaEspaña().ForEach(c => Console.WriteLine($"{c.Codigo_cliente,-7}{c.Nombre_cliente,-50}{c.Pais,-30}{c.Ciudad,-50}"));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            Lineas();

                            EscribirFicheroSpain();
                            break;
                        case 2:
                            Lineas();
                            try
                            {
                                Console.WriteLine($"{"CÓDIGO",-7}{"NOMBRE CLIENTE",-50}{"PAÍS",-30}{"CIUDAD",-50}");
                                Lineas();
                                Cliente.ListaUSA().ForEach(c => Console.WriteLine($"{c.Codigo_cliente,-7}{c.Nombre_cliente,-50}{c.Pais,-30}{c.Ciudad,-50}"));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            Lineas();

                            EscribirFicheroUSA();
                            break;
                        case 3:
                            Lineas();
                            try
                            {
                                Console.WriteLine($"{"CÓDIGO",-7}{"NOMBRE CLIENTE",-50}{"PAÍS",-30}{"CIUDAD",-50}");
                                Lineas();
                                Cliente.ListaOtros().ForEach(c => Console.WriteLine($"{c.Codigo_cliente,-7}{c.Nombre_cliente,-50}{c.Pais,-30}{c.Ciudad,-50}"));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            Lineas();

                            EscribirFicheroOtros(); ;
                            break;
                        case 4:
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta.");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número.");
                    opcion = -1;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("Pulsa una tecla para continuar...");
                    Console.ReadLine();
                }
            }
        }

        //==================================== Función de Menú Escritura Pedidos ===================================================
        public static void MenuEscrituraPedidos()
        {
            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine("********************** 5. ESCRIBIR FICHEROS DE PEDIDOS **********************");
                Console.WriteLine("1) Pulse 1 para Mostrar por pantalla y Escribir fichero Pedidos con estado 'Entregado'");
                Console.WriteLine("2) Pulse 2 para Mostrar por pantalla y Escribir fichero Pedidos con estado 'Pendiente'");
                Console.WriteLine("3) Pulse 3 para Mostrar por pantalla y Escribir fichero Pedidos con estado 'Rechazado'");
                Console.WriteLine("4) Pulse 4 para Limpiar pantalla");
                Console.WriteLine("0) Pulse 0 para volver al menú principal");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Lineas();
                            try
                            {
                                Console.WriteLine($"{"Codigo_Pedido",-15}{"Fecha_Pedido",-50}{"Estado",-30}{"Comentarios",-120}{"Codigo_Cliente",-7}");
                                Lineas();
                                Pedido.ListarPedidosEntregados().ForEach(p => Console.WriteLine($"{p.Codigo_Pedido,-15}{p.Fecha_Pedido,-50}{p.Estado,-30}{p.Comentarios,-120}{p.Codigo_Cliente,-7}"));

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            EscribirFicheroEntregados();
                            break;
                        case 2:
                            try
                            {
                                Console.WriteLine($"{"Codigo_Pedido",-15}{"Fecha_Pedido",-50}{"Estado",-30}{"Comentarios",-120}{"Codigo_Cliente",-7}");
                                Lineas();
                                Pedido.ListarPedidosPendientes().ForEach(p => Console.WriteLine($"{p.Codigo_Pedido,-15}{p.Fecha_Pedido,-50}{p.Estado,-30}{p.Comentarios,-120}{p.Codigo_Cliente,-7}"));

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            EscribirFicheroPendientes();
                            break;
                        case 3:
                            try
                            {
                                Console.WriteLine($"{"Codigo_Pedido",-15}{"Fecha_Pedido",-50}{"Estado",-30}{"Comentarios",-120}{"Codigo_Cliente",-7}");
                                Lineas();
                                Pedido.ListarPedidosRechazados().ForEach(p => Console.WriteLine($"{p.Codigo_Pedido,-15}{p.Fecha_Pedido,-50}{p.Estado,-30}{p.Comentarios,-120}{p.Codigo_Cliente,-7}"));

                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Error al ejecutar la consulta");
                            }
                            EscribirFicheroRechazados();
                            break;
                        case 4:
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta.");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, introduce un número.");
                    opcion = -1;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("Pulsa una tecla para continuar...");
                    Console.ReadLine();
                }

            }
        }
        //==================================== Función de Insertar Clientes ===================================================
        public static void InsertarClientes()
        {
            int codigo_empleado;
            bool encontrado = false;
            bool correcto = false;
            Cliente c = new Cliente();
            //para validar números de teléfono
            Regex regex = new Regex("\\(?\\d{3}\\)?-? *\\d{3}-? *-?\\d{3}");

            Lineas();
            Cliente.ListaClientesDistintos().ForEach(c => Console.Write(c.Codigo_empleado_rep_ventas + ", "));
            Console.WriteLine();
            Lineas();
            Console.Write("Elija uno de los código de empleado que se muestran arriba: ");

            do
            {
                while (!int.TryParse(Console.ReadLine(), out codigo_empleado))
                {
                    Console.WriteLine("Solo se permiten números.\nVuelve a introducir el código de empleado: ");
                }
                Cliente.ListaClientesDistintos().ForEach(c =>
                {
                    if (c.Codigo_empleado_rep_ventas == codigo_empleado) encontrado = true;
                });
                if (!encontrado)
                {
                    Console.WriteLine("Código de empleado no existe.\nVuelve a introducir el código de empleado: ");
                }
            } while (!encontrado);
            c.Codigo_empleado_rep_ventas = codigo_empleado;
            Console.Write("Nombre del Cliente: ");
            c.Nombre_cliente = Console.ReadLine();
            //Expresion regular para reemplazar dígitos por cadena en blanco
            c.Nombre_cliente = Regex.Replace(c.Nombre_cliente, "\\d+", "");
            Console.Write("Nombre del Contacto: ");
            c.Nombre_contacto = Console.ReadLine();
            c.Nombre_contacto = Regex.Replace(c.Nombre_contacto, "\\d+", "");
            Console.Write("Apellido del Contacto: ");
            c.Apellido_contacto = Console.ReadLine();
            c.Apellido_contacto = Regex.Replace(c.Apellido_contacto, "\\d+", "");
            Console.Write("Teléfono: ");
            c.Telefono = Console.ReadLine();
            correcto = regex.IsMatch(c.Telefono);

            while (!correcto)
            {
                Console.Write(" vuelve a insertar Teléfono: ");
                c.Telefono = Console.ReadLine();
                correcto = regex.IsMatch(c.Telefono);
            }

            Console.Write("Dirección: ");
            c.Linea_direccion1 = Console.ReadLine();
            Console.Write("Ciudad: ");
            c.Ciudad = Console.ReadLine();
            c.Ciudad = Regex.Replace(c.Ciudad, "\\d+", "");
            Console.Write("País: ");
            c.Pais = Console.ReadLine();
            c.Pais = Regex.Replace(c.Pais, "\\d+", "");
            Console.Write("Contraseña: ");
            c.Pass = Console.ReadLine();

            if (c.Insertar() == 1)
            {
                Console.WriteLine("Cliente insertado correctamente");
            }

            Incidencia.AddIncidencia(DateTime.Now, "Insertar Cliente");
        }

        //==================================== Función de Modificar Clientes ===================================================
        public static void ModificarClientes()
        {
            Cliente c = new Cliente();
            int codigo_cliente;
            int codigo_empleado;
            bool encontradoCliente = false;
            bool encontradoEmpleado = false;

            Lineas();
            Cliente.ListaClientes().ForEach(c => Console.Write(c.Codigo_cliente + ", "));
            Console.WriteLine();
            Lineas();

            Console.Write("Elija uno de los código de cliente a modificar de los que se muestran arriba: ");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out codigo_cliente))
                {
                    Console.WriteLine("Solo se permiten números.\nVuelve a introducir el código de cliente: ");
                }
                Cliente.ListaClientes().ForEach(c =>
                {
                    if (c.Codigo_cliente == codigo_cliente) encontradoCliente = true;
                });
                if (!encontradoCliente)
                {
                    Console.WriteLine("Código de cliente no existe.\nVuelve a introducir el código de cliente: ");
                }
            } while (!encontradoCliente);
            c.Codigo_cliente = codigo_cliente;
            Console.Write("Nombre del Cliente: ");
            c.Nombre_cliente = Console.ReadLine();
            c.Nombre_cliente = Regex.Replace(c.Nombre_cliente, "\\d+", "");
            Console.Write("Nombre del Contacto: ");
            c.Nombre_contacto = Console.ReadLine();
            c.Nombre_contacto = Regex.Replace(c.Nombre_contacto, "\\d+", "");
            Console.Write("Apellido del Contacto: ");
            c.Apellido_contacto = Console.ReadLine();
            c.Apellido_contacto = Regex.Replace(c.Apellido_contacto, "\\d+", "");
            Console.Write("Teléfono: ");
            c.Telefono = Console.ReadLine();
            Console.Write("Dirección: ");
            c.Linea_direccion1 = Console.ReadLine();
            Console.Write("Ciudad: ");
            c.Ciudad = Console.ReadLine();
            c.Ciudad = Regex.Replace(c.Ciudad, "\\d+", "");

            Lineas();
            Cliente.ListaClientesDistintos().ForEach(c => Console.WriteLine(c.Codigo_empleado_rep_ventas + ", "));
            Lineas();
            Console.Write("Elija uno de los código de empleado que se muestran arriba: ");

            do
            {
                while (!int.TryParse(Console.ReadLine(), out codigo_empleado))
                {
                    Console.WriteLine("Solo se permiten números.\nVuelve a introducir el código de empleado: ");
                }
                Cliente.ListaClientesDistintos().ForEach(c =>
                {
                    if (c.Codigo_empleado_rep_ventas == codigo_empleado) encontradoEmpleado = true;
                });
                if (!encontradoEmpleado)
                {
                    Console.WriteLine("Código de empleado no existe.\nVuelve a introducir el código de empleado: ");
                }
            } while (!encontradoEmpleado);
            c.Codigo_empleado_rep_ventas = codigo_empleado;
            Console.Write("Contraseña: ");
            c.Pass = Console.ReadLine();

            if (c.Actualizar() == 1)
            {
                Console.WriteLine("Cliente modificado correctamente");
            }

            Incidencia.AddIncidencia(DateTime.Now, "Actualizar Cliente");
        }

        //==================================== Función de Borrar Clientes ===================================================
        public static void BorrarClientes()
        {
            int codigo_cliente;
            bool encontrado = false;

            Lineas();
            Cliente.ListaClientes().ForEach(c => Console.Write(c.Codigo_cliente + ", "));
            Console.WriteLine();
            Lineas();

            Console.Write("Elija uno de los códigos de cliente a borrar de los que se muestran arriba: ");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out codigo_cliente))
                {
                    Console.WriteLine("Solo se permiten números.\nVuelve a introducir el código de cliente: ");
                }
                Cliente.ListaClientes().ForEach(c =>
                {
                    if (c.Codigo_cliente == codigo_cliente) encontrado = true;
                });
                if (!encontrado)
                {
                    Console.WriteLine("Código de cliente no existe.\nVuelve a introducir el código de cliente: ");
                }
                else
                {
                    if (Cliente.Borrar(codigo_cliente) == 1)
                    {
                        Console.WriteLine($"Cliente {codigo_cliente} borrado correctamente");
                    }
                }
            } while (!encontrado);
            Incidencia.AddIncidencia(DateTime.Now, "Borrar Cliente");
        }

        //==================================== Función de Mostrar Clientes ===================================================
        public static void MostrarClientes()
        {
            Console.WriteLine($"{"CÓDIGO",-7} {"NOMBRE CLIENTE",-50} {"NOMBRE CONTACTO",-30} {"APELLIDOS CONTACTO",-30} {"CIUDAD",-50}");
            Lineas();
            Cliente.ListaClientes().ForEach(c => Console.WriteLine(c));
            Lineas();
            Incidencia.AddIncidencia(DateTime.Now, "Listar Cliente");
        }

        //==================================== Función de Insertar Pedidos ===================================================
        public static void InsertarPedidos()
        {
            Pedido p = new Pedido();
            DateTime fecha_pedido;
            DateTime fecha_entrega;
            DateTime fecha_esperada;
            int codigo_cliente;
            bool encontrado = false;

            Lineas();
            Cliente.ListaClientes().ForEach(c => Console.Write(c.Codigo_cliente + ", "));
            Console.WriteLine();
            Lineas();

            Console.Write("Elija un codigo de cliente de los de arriba para poder insertar el nuevo pedido: ");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out codigo_cliente))
                {
                    Console.WriteLine("Solo se permiten números.\nVuelve a introducir el código de cliente: ");
                }
                Cliente.ListaClientes().ForEach(c =>
                {
                    if (c.Codigo_cliente == codigo_cliente) encontrado = true;
                });
                if (!encontrado)
                {
                    Console.WriteLine("Código de cliente no existe.\nVuelve a introducir el código de cliente: ");
                }
            } while (!encontrado);
            p.Codigo_Cliente = codigo_cliente;

            Console.Write("Fecha del pedido: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_pedido))
            {
                Console.WriteLine("Fecha incorrecta.\nVuelva a intentarlo: ");
            }
            p.Fecha_Pedido = fecha_pedido;

            Console.Write("Fecha esperada: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_esperada))
            {
                Console.WriteLine("Fecha incorrecta.\nVuelva a intentarlo: ");
            }
            p.Fecha_Esperada = fecha_esperada;

            Console.Write("Fecha entrega: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_entrega))
            {
                Console.WriteLine("Fecha incorrecta.\nVuelva a intentarlo: ");
            }
            p.Fecha_Entrega = fecha_entrega;

            Console.Write("Estado: ");
            p.Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
            while (p.Estado != "Entregado" && p.Estado != "Rechazado" && p.Estado != "Pendiente")
            {
                Console.WriteLine("El estado solo puede ser (Entregado,Rechazado,Pendiente)");
                Console.Write("Estado: ");
                p.Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
            }

            Console.Write("Comentarios: ");
            p.Comentarios = Console.ReadLine();

            if (p.Insertar() == 1)
            {
                Console.WriteLine("Pedido insertado correctamente");
            }
            Incidencia.AddIncidencia(DateTime.Now, "Insertar Pedido");
        }

        //==================================== Función de Modificar Pedidos ===================================================
        public static void ModificarPedidos()
        {
            Pedido p = new Pedido();
            int codigo_pedido;
            bool encontrado = false;
            DateTime fecha_pedido;
            DateTime fecha_entrega;
            DateTime fecha_esperada;

            Lineas();
            Pedido.ListarPedidos().ForEach(p => Console.Write(p.Codigo_Pedido + ", "));
            Console.WriteLine();
            Lineas();

            Console.Write("Elija un codigo de pedido de los de arriba para poder modificar el pedido: ");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out codigo_pedido))
                {
                    Console.WriteLine("Solo se permiten números.\nVuelve a introducir el código de pedido: ");
                }
                Pedido.ListarPedidos().ForEach(c =>
                {
                    if (c.Codigo_Pedido == codigo_pedido) encontrado = true;
                });
                if (!encontrado)
                {
                    Console.WriteLine("Código de cliente no existe.\nVuelve a introducir el código de cliente: ");
                }
            } while (!encontrado);
            p.Codigo_Pedido = codigo_pedido;

            Console.Write("Fecha del pedido: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_pedido))
            {
                Console.WriteLine("Fecha incorrecta.\nVuelva a intentarlo: ");
            }
            p.Fecha_Pedido = fecha_pedido;

            Console.Write("Fecha esperada: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_esperada))
            {
                Console.WriteLine("Fecha incorrecta.\nVuelva a intentarlo: ");
            }
            p.Fecha_Esperada = fecha_esperada;

            Console.Write("Fecha entrega: ");
            while (!DateTime.TryParse(Console.ReadLine(), out fecha_entrega))
            {
                Console.WriteLine("Fecha incorrecta.\nVuelva a intentarlo: ");
            }
            p.Fecha_Entrega = fecha_entrega;

            Console.Write("Estado: ");
            p.Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
            while (p.Estado != "Entregado" && p.Estado != "Rechazado" && p.Estado != "Pendiente")
            {
                Console.WriteLine("El estado solo puede ser (Entregado,Rechazado,Pendiente)");
                Console.Write("Estado: ");
                p.Estado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine());
            }

            Console.Write("Comentarios: ");
            p.Comentarios = Console.ReadLine();

            if (p.Actualizar() == 1)
            {
                Console.WriteLine("Pedido modificado correctamente");
            }
            else
            {
                Console.WriteLine("Código pedido no existe.");
            }
            Incidencia.AddIncidencia(DateTime.Now, "Actualizar Pedido");
        }


        //==================================== Función de Borrar Pedidos ===================================================
        public static void BorrarPedidos()
        {
            int codigo_pedido;
            bool encontrado = false;

            Lineas();
            Pedido.ListarPedidos().ForEach(p => Console.Write(p.Codigo_Pedido + ", "));
            Console.WriteLine();
            Lineas();

            Console.Write("Elija un codigo de pedido a borrar de los que se muestran arriba: ");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out codigo_pedido))
                {
                    Console.WriteLine("Solo se permiten números.\nVuelve a introducir el código de pedido: ");
                }
                Pedido.ListarPedidos().ForEach(p =>
                {
                    if (p.Codigo_Pedido == codigo_pedido) encontrado = true;
                });
                if (!encontrado)
                {
                    Console.WriteLine("Código de cliente no existe.\nVuelve a introducir el código de pedido: ");
                }
                else
                {
                    if (Pedido.Borrar(codigo_pedido) == 1)
                    {
                        Console.WriteLine($"Pedido {codigo_pedido} borrado correctamente.");
                    }
                }
            } while (!encontrado);

            Incidencia.AddIncidencia(DateTime.Now, "Borrar Pedido");
        }

        //==================================== Función de Mostrar Pedidos ===================================================
        public static void MostrarPedidos()
        {
            Cliente c = new Cliente();

            Lineas();
            Pedido.ListarPedidos().ForEach(p => Console.Write(p.Codigo_Pedido + ", "));
            Console.WriteLine();
            Lineas();

            Console.Write("Introduzca el código del pedido de la lista que se muestra arriba: ");
            int codigo = Convert.ToInt32(Console.ReadLine());

            Pedido pedido = Pedido.ListaPedido(codigo)[0];
            Cliente cliente = Cliente.ListaCliente(pedido.Codigo_Cliente)[0];

            Console.WriteLine($"PEDIDO CÓDIGO: {pedido.Codigo_Pedido}");
            Console.WriteLine($"-----------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"NOMBRE: {cliente.Nombre_cliente,-50} APELLIDOS: {cliente.Apellido_contacto,-50}");
            Console.WriteLine($"FECHA PEDIDO: {pedido.Fecha_Pedido,-30} FECHA ENTREGA: {pedido.Fecha_Entrega,-30}");
            Console.WriteLine($"-----------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{"LÍNEA",-10}{"PRODUCTO",-50}{"CANTIDAD",-10}{"PRECIO",-10}{"TOTAL",-10}");

            decimal total = 0;
            DetallePedido.ListaDetalle(codigo).ForEach(linea =>
            {
                Producto producto = Producto.ListaProducto(linea.Codigo_Producto)[0];
                decimal totalLinea = linea.Precio_Unidad * linea.Cantidad;
                Console.WriteLine($"{linea.Numero_Linea,-10}{producto.Nombre,-50}{linea.Cantidad,-10}" +
                    $"{linea.Precio_Unidad,-10}{totalLinea,-10}");
                total += totalLinea;
            });

            Console.WriteLine($"-----------------------------------------------------------------------------------------------------------------------------------------------");
            //decimal iva = total
            Console.WriteLine($"Total sin IVA: {total:F2}€" + " " + $"IVA(21%): {(total * 21 / 100):F4}€" + " " + $"Total: {total + (total * 21 / 100):F4}€");
            Incidencia.AddIncidencia(DateTime.Now, "Listar Pedidos");
        }

        //==================================== Función de escribir fichero de España ===================================================
        public static void EscribirFicheroSpain()
        {
            try
            {
                using (StreamWriter fichero = new StreamWriter("Spain.txt"))
                {
                    fichero.WriteLine($"{"CÓDIGO",-7}{"NOMBRE CLIENTE",-50}{"PAÍS",-30}{"CIUDAD",-50}");
                    fichero.WriteLine($"-----------------------------------------------------------------------------------------------------------------------------------------------");
                    Cliente.ListaEspaña().ForEach(c => fichero.WriteLine($"{c.Codigo_cliente,-7}{c.Nombre_cliente,-50}{c.Pais,-30}{c.Ciudad,-50}"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error escribiendo el fichero de España ", ex.Message);
            }
            Incidencia.AddIncidencia(DateTime.Now, "Escribir fichero de España");
        }

        //==================================== Función de escribir fichero de USA ===================================================
        public static void EscribirFicheroUSA()
        {
            try
            {
                using (StreamWriter fichero = new StreamWriter("USA.txt"))
                {
                    fichero.WriteLine($"{"CÓDIGO",-7}{"NOMBRE CLIENTE",-50}{"PAÍS",-30}{"CIUDAD",-50}");
                    fichero.WriteLine($"-----------------------------------------------------------------------------------------------------------------------------------------------");
                    Cliente.ListaUSA().ForEach(c => fichero.WriteLine($"{c.Codigo_cliente,-7}{c.Nombre_cliente,-50}{c.Pais,-30}{c.Ciudad,-50}"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error escribiendo el fichero de Estados Unidos ", ex.Message);
            }
            Incidencia.AddIncidencia(DateTime.Now, "Escribir fichero de Estados Unidos");
        }

        //==================================== Función de escribir fichero de Otros Paises ===================================================
        public static void EscribirFicheroOtros()
        {
            try
            {
                using (StreamWriter fichero = new StreamWriter("Otros.txt"))
                {
                    fichero.WriteLine($"{"CÓDIGO",-7}{"NOMBRE CLIENTE",-50}{"PAÍS",-30}{"CIUDAD",-50}");
                    fichero.WriteLine($"-----------------------------------------------------------------------------------------------------------------------------------------------");
                    Cliente.ListaOtros().ForEach(c => fichero.WriteLine($"{c.Codigo_cliente,-7}{c.Nombre_cliente,-50}{c.Pais,-30}{c.Ciudad,-50}"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error escribiendo el fichero de Otros Paises ", ex.Message);
            }
            Incidencia.AddIncidencia(DateTime.Now, "Escribir fichero de Otros paises");
        }

        //==================================== Función de escribir fichero de Pedidos Entregados ===================================================
        public static void EscribirFicheroEntregados()
        {
            try
            {
                using (StreamWriter fichero = new StreamWriter("Entregados.txt"))
                {
                    fichero.WriteLine($"{"Codigo_Pedido",-15}{"Fecha_Pedido",-50}{"Estado",-30}{"Comentarios",-120}{"Codigo_Cliente",-7}");
                    Lineas();
                    Pedido.ListarPedidosEntregados().ForEach(p => fichero.WriteLine($"{p.Codigo_Pedido,-15}{p.Fecha_Pedido,-50}{p.Estado,-30}{p.Comentarios,-120}{p.Codigo_Cliente,-7}"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error escribiendo el fichero de Pedidos Entregados ", ex.Message);
            }
            Incidencia.AddIncidencia(DateTime.Now, "Escribir fichero de Pedidos Entregados");
        }

        //==================================== Función de escribir fichero de Pedidos Pendientes ===================================================
        public static void EscribirFicheroPendientes()
        {
            try
            {
                using (StreamWriter fichero = new StreamWriter("Pendientes.txt"))
                {
                    fichero.WriteLine($"{"Codigo_Pedido",-15}{"Fecha_Pedido",-50}{"Estado",-30}{"Comentarios",-120}{"Codigo_Cliente",-7}");
                    Lineas();
                    Pedido.ListarPedidosPendientes().ForEach(p => fichero.WriteLine($"{p.Codigo_Pedido,-15}{p.Fecha_Pedido,-50}{p.Estado,-30}{p.Comentarios,-120}{p.Codigo_Cliente,-7}"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error escribiendo el fichero de Pedidos Pendientes ", ex.Message);
            }
            Incidencia.AddIncidencia(DateTime.Now, "Escribir fichero de Pedidos Pendientes");
        }

        //==================================== Función de escribir fichero de Pedidos Rechazados ===================================================
        public static void EscribirFicheroRechazados()
        {
            try
            {
                using (StreamWriter fichero = new StreamWriter("Rechazados.txt"))
                {
                    fichero.WriteLine($"{"Codigo_Pedido",-15}{"Fecha_Pedido",-50}{"Estado",-30}{"Comentarios",-120}{"Codigo_Cliente",-7}");
                    Lineas();
                    Pedido.ListarPedidosRechazados().ForEach(p => fichero.WriteLine($"{p.Codigo_Pedido,-15}{p.Fecha_Pedido,-50}{p.Estado,-30}{p.Comentarios,-120}{p.Codigo_Cliente,-7}"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error escribiendo el fichero de Pedidos Rechazados ", ex.Message);
            }
            Incidencia.AddIncidencia(DateTime.Now, "Escribir fichero de Pedidos Rechazados");
        }

        //============================= FUNCIÓN PARA IMPRIMIR LINEAS ===========================================
        public static void Lineas()
        {
            for (int i = 0; i < 214; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}

