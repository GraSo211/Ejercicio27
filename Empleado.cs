using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio27
{
    public class Empleado
    {
        int Id { get; set; }
        string Nombre { get; set; }
        public string Estado { get; set; }
        public float AcumOcupacion { get; set; }

        public Empleado(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Estado = "Libre";
            this.AcumOcupacion = 0;
        }

        public void PonerseTrabajar()
        {
            this.Estado = "Ocupado";

        }

        public void PonerseLibre(float acumOcupacion)
        {
            this.Estado = "Libre";
            this.AcumOcupacion += acumOcupacion;
        }
    }
}
