
using System.Text.RegularExpressions;
using Ejercicio27;

public class EventoFinControlReloj : Evento
{

    public double Rnd1 { get; set; }

    public double Rnd2 { get; set; }

    public double TiempoNeto1 { get; set; }

    public double TiempoNeto2 { get; set; }


    public Reloj Reloj { get; set; }

    public EventoFinControlReloj(string nombre, Reloj reloj) : base(nombre)
    {
        Reloj = reloj;
    }

    

    public override void GenerarEvento(ref VectorEstado vE)
    {
        // Generar los numeros pero verificar que si en la variablde de simualcion no es null entonces hay que usar el numero anterior por lo que no recalculamos lso rnd ni nada y devolveriamos solo ese 
        // SITUACION NO TENEMOS NUMEROS
        if (Simulacion.TiempoValorSobranteNormal == null)
        {

            Random random = new Random();
            Rnd1 = Math.Truncate(random.NextDouble() * 100) / 100;
            Rnd2 = Math.Truncate(random.NextDouble() * 100) / 100;
            TiempoNeto1 = Math.Truncate((Math.Sqrt(-2 * Math.Log(1 - Rnd1)) * Math.Cos(2 * Math.PI * Rnd2) * Simulacion.FINCONTROLRELOJDE + Simulacion.FINCONTROLRELOJMEDIA) * 100) / 100;
            TiempoNeto2 = Math.Truncate((Math.Sqrt(-2 * Math.Log(1 - Rnd1)) * Math.Sin(2 * Math.PI * Rnd2) * Simulacion.FINCONTROLRELOJDE + Simulacion.FINCONTROLRELOJMEDIA) * 100) / 100;
            TiempoFinal = Math.Truncate((Simulacion.RelojSimulacion + TiempoNeto1) * 100) / 100;

            vE.rnd1FinControlReloj = Rnd1.ToString();
            vE.rnd2FinControlReloj = Rnd2.ToString();
            vE.tiempo1FinControlReloj = TiempoNeto1.ToString();
            vE.tiempo2FinControlReloj = TiempoNeto2.ToString();
            if (Simulacion.Empleado1.Estado == "Libre")
            {
                vE.finControlRelojEmp1 = TiempoFinal.ToString();
            }
            else if (Simulacion.Empleado2.Estado == "Libre")
            {
                vE.finControlRelojEmp2 = TiempoFinal.ToString();
            }
            else if (Simulacion.Empleado3.Estado == "Libre")
            {
                vE.finControlRelojEmp3 = TiempoFinal.ToString();
            }
            Simulacion.TiempoValorSobranteNormal = TiempoNeto2;
        }


        else
        {
            // SITUACION YA GENERAMOS NUMEROS Y NOS QUEDA EL 2DO
            TiempoFinal = Math.Truncate((Simulacion.RelojSimulacion + Simulacion.TiempoValorSobranteNormal.Value) * 100) / 100;
            Simulacion.TiempoValorSobranteNormal = null;
            if (Simulacion.Empleado1.Estado == "Libre")
            {
                vE.finControlRelojEmp1 = TiempoFinal.ToString();
            }
            else if (Simulacion.Empleado2.Estado == "Libre")
            {
                vE.finControlRelojEmp2 = TiempoFinal.ToString();
            }
            else if (Simulacion.Empleado3.Estado == "Libre")
            {
                vE.finControlRelojEmp3 = TiempoFinal.ToString();
            }
        }
    }

    public string GenerarResultadoControl(ref VectorEstado vE)
    {
        // TODO: Implementar la lógica para generar el resultado del control
        Random random = new Random();
        double rnd = Math.Truncate(random.NextDouble() * 100) / 100;
        vE.rndResultadoControl = rnd.ToString();
        if (Simulacion.PORCAPROBCONTROL / 100 > rnd)
        {
            vE.resultadoControl = "OK";
            return "OK";
            
        }
        else
        {
            vE.resultadoControl = "Fallado";
            return "Fallado";
            
        }
        

    }

    public override void ResolverEvento(ref VectorEstado vE)
    {


        // HAY QUE GENERAR EL RESULTADO DEL RELOJ
        // Y ACTUALIZAR LAS VARIABLES ESTADISTICAS
        // VER ESTADO DE LA COLA 
        // SI ESTA VACIA SE PONE LIBRE AL EMPLEADO 
        // SI HAY ALGO SE LO ATIENDE


        // Liberar empleado
        if (Reloj.Estado == "Siendo_Controlado_Emp1")
        {

            if (Simulacion.ColaRelojes.Count == 0)
                Simulacion.Empleado1.PonerseLibre(ref vE);
            else
            {
                Reloj reloj = Simulacion.ColaRelojes.Dequeue();
                reloj.Estado = "Siendo_Controlado_Emp1";
                EventoFinControlReloj eventoFinControlReloj = new EventoFinControlReloj("FinControlReloj", reloj);
                eventoFinControlReloj.GenerarEvento(ref vE);
                Simulacion.ListaEventos.Add(eventoFinControlReloj);
                Simulacion.Empleado1.PonerseTrabajar(ref vE, 1);
            }
            string resultado = GenerarResultadoControl(ref vE);
            Reloj.Estado = resultado;
                
        }
        else if (Reloj.Estado == "Siendo_Controlado_Emp2")
        {
            if (Simulacion.ColaRelojes.Count == 0)
                Simulacion.Empleado2.PonerseLibre(ref vE);
            else
            {
                Reloj reloj = Simulacion.ColaRelojes.Dequeue();
                reloj.Estado = "Siendo_Controlado_Emp2";
                EventoFinControlReloj eventoFinControlReloj = new EventoFinControlReloj("FinControlReloj", reloj);
                eventoFinControlReloj.GenerarEvento(ref vE);
                Simulacion.ListaEventos.Add(eventoFinControlReloj);
                Simulacion.Empleado2.PonerseTrabajar(ref vE, 2);
            }
            string resultado = GenerarResultadoControl(ref vE);
            Reloj.Estado = resultado;
            
        }
        else if (Reloj.Estado == "Siendo_Controlado_Emp3")
        {
            if (Simulacion.ColaRelojes.Count == 0)
                Simulacion.Empleado3.PonerseLibre(ref vE );
            else
            {
                Reloj reloj = Simulacion.ColaRelojes.Dequeue();
                reloj.Estado = "Siendo_Controlado_Emp3";
                EventoFinControlReloj eventoFinControlReloj = new EventoFinControlReloj("FinControlReloj", reloj);
                eventoFinControlReloj.GenerarEvento(ref vE);
                Simulacion.ListaEventos.Add(eventoFinControlReloj);
                Simulacion.Empleado3.PonerseTrabajar(ref vE, 3);
            }
            string resultado = GenerarResultadoControl(ref vE);
            Reloj.Estado = resultado;
        
        }

        
    }
}
