using Ejercicio27;

public abstract class Evento
{
    public string Nombre { get; set; }

    public double TiempoNeto { get; set; }

    public double TiempoFinal { get; set; }



    public Evento(string nombre )
    {
        Nombre = nombre;
    }

    public virtual void ResolverEvento(ref VectorEstado vE) { }

    public virtual void GenerarEvento(ref VectorEstado vE) { }
}
