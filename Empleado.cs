using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio27
{
    internal class Empleado
    {
        int id { get; set; }
        string nombre { get; set; }
        public string estado { get; set; }
        public float acum_ocupacion { get; set; }

        public Empleado(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = "Libre";
            this.acum_ocupacion = 0;
        }
    }
}
