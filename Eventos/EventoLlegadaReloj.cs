
using Ejercicio27;

public class EventoLlegadaReloj : Evento
{

    public double Rnd { get; set; }





    public EventoLlegadaReloj(string nombre ) : base(nombre)
    {

    }

    public override void GenerarEvento(ref VectorEstado vE)
    {
        Random random = new Random();
        Rnd = Math.Truncate(random.NextDouble()*100)/100;
        TiempoNeto = Math.Truncate(-Simulacion.LLEGADARELOJMEDIA * Math.Log(1 - Rnd)*100)/100;
        TiempoFinal = Math.Truncate(Simulacion.RelojSimulacion + TiempoNeto*100)/100;


        vE.rndLlegadaReloj = Rnd.ToString();
        vE.tiempoLlegadaReloj = TiempoNeto.ToString();
        vE.llegadaReloj = TiempoFinal.ToString();
    }

    public override void ResolverEvento(ref VectorEstado vE)
    {
        // GENERAR LLEGADA PROXIMA
        Evento eventoLlegada = new EventoLlegadaReloj("LlegadaReloj");
        eventoLlegada.GenerarEvento(ref vE);
        Simulacion.ListaEventos.Add(eventoLlegada);

        // RESOLVER LLEGADA ACTUAL
        // Crear Reloj
        if (Simulacion.Empleado1.Estado == "Libre")
        {
            Reloj reloj = new Reloj(Simulacion.ContRelojes + 1, "Siendo_Controlado_Emp1", TiempoFinal);
            Simulacion.Empleado1.PonerseTrabajar();
        }
        else if (Simulacion.Empleado2.Estado == "Libre")
        {
            Reloj reloj = new Reloj(Simulacion.ContRelojes + 1, "Siendo_Controlado_Emp2", TiempoFinal);
            Simulacion.Empleado2.PonerseTrabajar(); 
        }
        else if (Simulacion.Empleado3.Estado == "Libre")
        {
            Reloj reloj = new Reloj(Simulacion.ContRelojes + 1, "Siendo_Controlado_Emp3", TiempoFinal);
            Simulacion.Empleado3.PonerseTrabajar();
        }
        else
        {
            // Agregar a cola
            Reloj reloj = new Reloj(Simulacion.ContRelojes + 1, "En_Cola", TiempoFinal);
            Simulacion.ColaRelojes.Enqueue(reloj);
        }
        // Ver estado de los empleados

    }

}