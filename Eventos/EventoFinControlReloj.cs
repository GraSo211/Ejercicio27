
using System.Text.RegularExpressions;
using Ejercicio27;

public class EventoFinControlReloj:Evento
{
 
    protected float Rnd { get; set; }

    public float FinControl { get; set; }


    protected Reloj reloj { get; set; }
    protected Empleado empleado { get; set; }



    public void generarResultadoControl()
    {
        // TODO: Implementar la lógica para generar el resultado del control
    }

}

