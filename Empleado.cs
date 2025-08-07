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

        public void PonerseTrabajar(ref VectorEstado vE, int nroEmpleado)
        {
            this.Estado = "Ocupado";
            switch (nroEmpleado)
            {
                case 1:
                    vE.estadoEmpleado1 = this.Estado;
                    break;
                case 2:
                    vE.estadoEmpleado2 = this.Estado;
                    break;
                case 3:
                    vE.estadoEmpleado3 = this.Estado;
                    break;
            }

        }

        public void PonerseLibre(float acumOcupacion, ref VectorEstado vE)
        {
            this.Estado = "Libre";
            this.AcumOcupacion += acumOcupacion;
        }
    }
}
