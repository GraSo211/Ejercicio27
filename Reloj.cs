using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal class Reloj
    {
        public int id { get; set; }
        public string estado { get; set; }

        public float tiempo_llegada { get; set; }


        public Alumno(int id)
        {
            this.id = id;
            this.estado = "En_Examen";
        }

        // Constructor copia para clonado
        public Alumno(Alumno otro)
        {
            this.id = otro.id;
            this.estado = otro.estado;
        }

        // Metodo cloanr
        public Alumno Clone()
        {
            return new Alumno(this);
        }


    }
}
