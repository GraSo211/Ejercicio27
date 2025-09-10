

using Ejercicio27;

public class EventoInit : Evento
{
    public double TiempoNeto { get; set; }



    public EventoInit(string nombre) : base(nombre)
    {
        TiempoNeto = 0;
        TiempoFinal = 0;
    }

    public override void ResolverEvento(ref VectorEstado vE)
    {
        EventoLlegadaReloj llegadaReloj = new EventoLlegadaReloj("LlegadaReloj");
        llegadaReloj.GenerarEvento(ref vE);
        //Simulacion.ListaEventos.Add(llegadaReloj);
        Simulacion.ListaEventos.Enqueue(llegadaReloj, llegadaReloj.TiempoFinal);
    }

}
