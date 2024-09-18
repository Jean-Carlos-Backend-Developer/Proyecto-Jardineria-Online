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

<img width="574" alt="Captura de Pantalla 2024-09-11 a las 13 51 00" src="https://github.com/user-attachments/assets/7408c333-8ad0-442a-b6f0-de5355061fc8">

Menú Principal

<img width="957" alt="Captura de Pantalla 2024-09-11 a las 13 56 54" src="https://github.com/user-attachments/assets/c5e4b05d-965a-4c35-9868-b708f31e4ac2">

Opción de ver todos los clientes dentro del menú de Clientes

<img width="687" alt="Captura de Pantalla 2024-09-11 a las 14 00 49" src="https://github.com/user-attachments/assets/0ce65439-b590-4441-9ede-64522e2bd92d">

Opción de ver todos los clientes de España dentro del menú de consultas

<img width="758" alt="Captura de Pantalla 2024-09-11 a las 14 04 12" src="https://github.com/user-attachments/assets/25e68a9b-d2d9-4bd4-af73-f7db0253bbe2">

Opción de escribir y mostrar por pantalla el fichero de Clientes de España

__Prueba el Proyecto__

Si quieres ver el resto de opciones y funcionalidades, te invito a descargar mi proyecto y la base de datos para probar todas las opciones disponibles. Sigue estos pasos para empezar:

1. Clona el repositorio:

2. Usando XAMPP o MYSQL Workbench importa el archivo jardineriaOnline_v2.sql para crear la base de datos.

3. Modifica la función BaseDeDatos en el archivo BaseDeDatos.cs con los datos de tu usuario, contraseña, puerto y nombre de la base de datos:

`    strConexion = @"server=localhost;port=tu-puerto;password=tu-contraseña;userid=tu-usuario;database=tu-base-datos";
`

4. Abre el proyecto en Visual Studio y ejecuta la aplicación.

¡Espero que disfrutes explorando mi proyecto! Si tienes alguna pregunta o sugerencia, no dudes en contactarme.



