using System;
using System.Collections.Generic;
using System.IO;
namespace proyecto_Jardineria
{
    public class Incidencia
    {
        private DateTime hora { get; set; }
        private string operacion { get; set; }

        private static List<Incidencia> incidencias = new List<Incidencia>();

        public Incidencia()
        {
        }

        public Incidencia(DateTime hora, string operacion)
        {
            this.hora = hora;
            this.operacion = operacion;
        }

        public override string ToString()
        {
            return $"{hora} - {operacion}";
        }

        public static void AddIncidencia(DateTime fecha, string operacion)
        {
            incidencias.Add(new Incidencia(fecha, operacion));
        }

        public static void ListarIncidencias()
        {
            incidencias.ForEach(i => Console.WriteLine(i));
        }

        public static void GuardarIncidencias()
        {
            string nombre = "" + DateTime.Now.Year + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + ".log";

            try
            {
                using (StreamWriter fichero = new StreamWriter(nombre, true))
                {
                    incidencias.ForEach(i => fichero.WriteLine(i));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error guardando incidencias ", ex.Message);
            }
        }
    }
}

