using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal class Profesor
    {
        int id { get; set; }
        string nombre { get; set; }
        public string estado { get; set; }
        public Cola cola { get; set; }

        public Profesor(int id, string nombre,  Cola cola)
        {
            this.id = id;
            this.nombre = nombre;
            this.estado = "Libre";
            this.cola = cola;
        }
    }
}
