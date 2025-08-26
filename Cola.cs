using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal class Cola
    {
        int id { get; set; }
        string nombre { get; set; }
        public Queue<Alumno> Alumnos { get; set; }

        public Cola(int id, string nombre) {
            this.id = id;
            this.nombre = nombre;
            this.Alumnos = new Queue<Alumno>();
        }

    }

}
