public abstract class Evento
{
    public string Nombre { get; set; }

    public float TiempoNeto { get; set; }

    public float TiempoFinal { get; set; }

    public List<Evento> ListaEventos { get; set; }

    public Evento(string nombre, List<Evento> listaEventos)
    {
        Nombre = nombre;
        ListaEventos = listaEventos;
    }

    public virtual void ResolverEvento() { }

    public virtual void GenerarEvento() { }
}
