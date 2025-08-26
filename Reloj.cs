using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio27
{
    internal class Reloj
    {
        public int id { get; set; }
        public string estado { get; set; }

        public float tiempo_llegada { get; set; }


        public Reloj(int id, string estado, float tiempo_llegada)
        {
            this.id = id;
            this.estado = estado;
            this.tiempo_llegada = tiempo_llegada;
        }

        


    }
}
