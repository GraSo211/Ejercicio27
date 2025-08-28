

using Ejercicio27;

public class EventoInit : Evento
{

    public EventoInit(string nombre, List<Evento> listaEventos) : base(nombre, listaEventos)
    {
        TiempoNeto = 0;
    }

    public override void ResolverEvento()
    {
        EventoLlegadaReloj llegadaReloj = new EventoLlegadaReloj("LlegadaReloj", ListaEventos);
        llegadaReloj.GenerarEvento();
        ListaEventos.Add(llegadaReloj);
    }

}
