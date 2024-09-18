# Proyecto Jardineria Online

__Sobre el Proyecto__

Mi aplicación de consola permite gestionar una base de datos llamada JardineriaOnline, en la cual se pueden:

- Insertar, modificar, mostrar y borrar clientes y pedidos.
- Realizar consultas sobre la base de datos.
- Escribir ficheros.

__Principales Tecnologías__

- Lenguaje de Programación: C#
- Base de Datos: MySQL
- Entorno de Desarrollo: Visual Studio

__Características__

- Gestión de Clientes y Pedidos: Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Borrar) sobre clientes y pedidos.
- Consultas Personalizadas: Realiza consultas específicas sobre la base de datos para obtener información relevante.
- Exportación de Datos: Escribe datos en ficheros para su posterior análisis o respaldo.

__Uso__

- Inicia la aplicación desde la consola.
- Sigue las instrucciones en pantalla para gestionar clientes y pedidos.
- Utiliza las opciones de menú para realizar consultas y exportar datos.

__Capturas de Pantalla__

<img width="574" alt="Captura de Pantalla 2024-09-11 a las 13 51 00" src="https://github.com/user-attachments/assets/8d603a4f-5b9a-4fe4-9738-7075a2c19541">

Menú Principal

<img width="957" alt="Captura de Pantalla 2024-09-11 a las 13 56 54" src="https://github.com/user-attachments/assets/4e0cb467-8aff-4136-a8ee-274753620ea4">

Menú de clientes y opción de ver todos los clientes dentro del menú de consultas

<img width="649" alt="Captura de Pantalla 2024-09-18 a las 13 31 15" src="https://github.com/user-attachments/assets/55fd7ff0-2d0c-40c7-84b1-aad8fa8d2ed2">

Menú de pedidos y opción de ver un pedido

<img width="687" alt="Captura de Pantalla 2024-09-11 a las 14 00 49" src="https://github.com/user-attachments/assets/24bc8bdf-053a-4d7a-88e5-7d61482a17b5">

Menú de consultas y opción de mostrar por pantalla el fichero de Clientes de España

<img width="690" alt="Captura de Pantalla 2024-09-18 a las 13 44 08" src="https://github.com/user-attachments/assets/5a2221c5-162b-4977-a067-9b1d492ebcde">

Menú de escribir clientes y opción de escribir y mostrar clientes de Estados Unidos

<img width="1631" alt="Captura de Pantalla 2024-09-18 a las 13 47 28" src="https://github.com/user-attachments/assets/8c98f0ed-0b62-4884-ab30-8988d7dd6fa4">

Menú de escribir pedidos y opción de ver pedidos con estado rechazado

__Prueba el Proyecto__

Si quieres ver el resto de opciones y funcionalidades, te invito a descargar mi proyecto y la base de datos para probar todas las opciones disponibles. Sigue estos pasos para empezar:

1. Clona el repositorio:

2. Usando XAMPP o MYSQL Workbench importa el archivo jardineriaOnline_v2.sql para crear la base de datos.

3. Modifica la función BaseDeDatos en el archivo BaseDeDatos.cs con los datos de tu usuario, contraseña, puerto y nombre de la base de datos:

`    strConexion = @"server=localhost;port=tu-puerto;password=tu-contraseña;userid=tu-usuario;database=tu-base-datos";
`

4. Abre el proyecto en Visual Studio y ejecuta la aplicación.

¡Espero que disfrutes explorando mi proyecto! Si tienes alguna pregunta o sugerencia, no dudes en contactarme.



