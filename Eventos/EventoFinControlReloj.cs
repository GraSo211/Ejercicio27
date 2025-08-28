
using System.Text.RegularExpressions;
using Ejercicio27;

public class EventoFinControlReloj:Evento
{
 
    public float Rnd { get; set; }

    public float FinControl { get; set; }

    public Reloj Reloj { get; set; }

    public EventoFinControlReloj(string nombre, List<Evento> listaEventos, float finControl, Reloj reloj) : base(nombre, listaEventos)
    {
        FinControl = finControl;
        Reloj = reloj;
    
    }

    public void generarResultadoControl()
    {
        // TODO: Implementar la lógica para generar el resultado del control

    }

}

