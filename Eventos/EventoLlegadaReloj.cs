
using Ejercicio27;

public class EventoLlegadaReloj : Evento
{

    public float Rnd { get; set; }

    public float LlegadaReloj { get; set; }



    public EventoLlegadaReloj(string nombre, List<Evento> listaEventos) : base(nombre, listaEventos)
    {
        
    }

    public override void GenerarEvento()
    {
        Random random = new Random();
        Rnd = (float)random.NextDouble();
        LlegadaReloj = (float)(-Simulacion.LLEGADARELOJMEDIA * Math.Log(1 - Rnd));
        TiempoNeto = LlegadaReloj;
        TiempoFinal = Simulacion.RelojSimulacion + TiempoNeto;

    }

}