using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio27
{
    public class Reloj
    {
        public int Id { get; set; }
        public string Estado { get; set; }

        public float TiempoLlegada { get; set; }


        public Reloj(int id, string estado, float tiempoLlegada)
        {
            this.Id = id;
            this.Estado = estado;
            this.TiempoLlegada= tiempoLlegada;
        }

        


    }
}
