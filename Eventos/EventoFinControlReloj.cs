
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

    public void generarResultadoControl()
    {
        // TODO: Implementar la lógica para generar el resultado del control

    }

    public override void GenerarEvento(ref VectorEstado vE)
    {
        // Generar los numeros pero verificar que si en la variablde de simualcion no es null entonces hay que usar el numero anterior por lo que no recalculamos lso rnd ni nada y devolveriamos solo ese 
        Random random = new Random();
        Rnd1 = Math.Truncate(random.NextDouble() * 100) / 100;
        Rnd2 = Math.Truncate(random.NextDouble() * 100) / 100;
        TiempoNeto1 = Math.Truncate((Math.Sqrt(-2 * Math.Log(1 - Rnd1)) * Math.Cos(2 * Math.PI * Rnd2) * Simulacion.FINCONTROLRELOJDE + Simulacion.FINCONTROLRELOJMEDIA) * 100) / 100;
        TiempoNeto2 = Math.Truncate((Math.Sqrt(-2 * Math.Log(1 - Rnd1)) * Math.Sin(2 * Math.PI * Rnd2) * Simulacion.FINCONTROLRELOJDE + Simulacion.FINCONTROLRELOJMEDIA) * 100) / 100;
        TiempoFinal = Math.Truncate(Simulacion.RelojSimulacion + TiempoNeto1 * 100) / 100;

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
        
    }

}

