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

        public double TiempoLlegada { get; set; }


        public Reloj(int id, string estado, double tiempoLlegada)
        {
            this.Id = id;
            this.Estado = estado;
            this.TiempoLlegada= tiempoLlegada;
        }
    }
}
