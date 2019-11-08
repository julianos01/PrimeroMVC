using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modelo
{
    public class Alumno
    {
        public int id { get; set; }
        public string nombre { get; set; }



        public static List<Alumno> listar()
        {
            var Alumnos = new List<Alumno>();
            for (var i = 1; i <= 10; i++)
            {
                Alumnos.Add(new Alumno()
                {
                    id = i,
                    nombre = "Alumno" + i
                });
            }
            return Alumnos;
        }



        public static Alumno obtener()
        {
            return new Alumno
            {
                id = 1,
                nombre = "Alumno 1"

            };
        }

    }
}