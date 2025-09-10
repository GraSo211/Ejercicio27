using Ejercicio27;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
namespace Ejercicio27
{
    internal class Simulacion
    {
        public static float LLEGADARELOJMEDIA { get; set; }
        public static float FINCONTROLRELOJMEDIA { get; set; }
        public static float FINCONTROLRELOJDE { get; set; }
        public static float PORCAPROBCONTROL { get; set; }
        public static int CANTITERACIONESREALIZAR { get; set; }
        public static int MOMENTOMOSTRARSIM { get; set; }
        public static int CANTITERACIONESMOSTRAR { get; set; }

        private List<VectorEstado> ListaVectoresEstado { get; set; }


        public static double RelojSimulacion { get; set; }
        public static Empleado Empleado1 { get; set; }
        public static Empleado Empleado2 { get; set; }
        public static Empleado Empleado3 { get; set; }
        public static Queue<Reloj> ColaRelojes { get; set; }

        public static double AcumTiempoEsperaReloj { get; set; }
        public static int ContRelojes { get; set; }
        public static int ContRelojesTerminados { get; set; }
        public static double AcumTiempoRelojSistema { get; set; }
        public static List<Reloj> ListaRelojes { get; set; }
        //! public static List<Evento> ListaEventos { get; set; }
        public static PriorityQueue<Evento, double> ListaEventos { get; set; }
        public static double? TiempoValorSobranteNormal { get; set; }
        private Evento EventoActual { get; set; }


        public Simulacion(
            float llegadaRelojMedia,
            float finControlRelojMedia,
            float finControlRelojDE,
            float porcaProbControl,
            int cantIteracionesRealizar,
            int momentoMostrarSim
        )
        {

            LLEGADARELOJMEDIA = llegadaRelojMedia;
            FINCONTROLRELOJMEDIA = finControlRelojMedia;
            FINCONTROLRELOJDE = finControlRelojDE;
            PORCAPROBCONTROL = porcaProbControl;
            CANTITERACIONESREALIZAR = cantIteracionesRealizar;
            MOMENTOMOSTRARSIM = momentoMostrarSim;
            CANTITERACIONESMOSTRAR = 100;


            RelojSimulacion = 0;
            ListaVectoresEstado = new List<VectorEstado>();
            ListaRelojes = new List<Reloj>();
            //! ListaEventos = new List<Evento>();
            ListaEventos = new PriorityQueue<Evento, double>();

            Empleado1 = new Empleado(1, "Empleado_1");
            Empleado2 = new Empleado(2, "Empleado_2");
            Empleado3 = new Empleado(3, "Empleado_3");

            ColaRelojes = new Queue<Reloj>();

            AcumTiempoEsperaReloj = 0;
            ContRelojes = 0;
            ContRelojesTerminados = 0;
            AcumTiempoRelojSistema = 0;

            TiempoValorSobranteNormal = null;
        }


        public void Simular()
        {

            int idVectorEstado = 1;

            VectorEstado vE = new VectorEstado
            {
                id = idVectorEstado,
                eventoActual = "",
                reloj = RelojSimulacion.ToString(),
                rndLlegadaReloj = "",
                tiempoLlegadaReloj = "",
                llegadaReloj = "",
                rnd1FinControlReloj = "",
                rnd2FinControlReloj = "",
                tiempo1FinControlReloj = "",
                tiempo2FinControlReloj = "",
                finControlRelojEmp1 = "",
                finControlRelojEmp2 = "",
                finControlRelojEmp3 = "",
                rndResultadoControl = "",
                resultadoControl = "",
                estadoEmpleado1 = Empleado1.Estado.ToString(),
                acumOcupacionEmpleado1 = Empleado1.AcumOcupacion.ToString(),
                estadoEmpleado2 = Empleado2.Estado.ToString(),
                acumOcupacionEmpleado2 = Empleado2.AcumOcupacion.ToString(),
                estadoEmpleado3 = Empleado3.Estado.ToString(),
                acumOcupacionEmpleado3 = Empleado3.AcumOcupacion.ToString(),
                colaRelojes = "",
                acumTiempoEsperaReloj = AcumTiempoEsperaReloj.ToString(),
                contRelojes = ContRelojes.ToString(),
                contRelojesTerminados = ContRelojesTerminados.ToString(),
                acumTiempoRelojSistema = AcumTiempoRelojSistema.ToString(),
                listaRelojes = ListaRelojes.ToArray().ToList()
            };



            // Creamos el evento inicial
            EventoInit eventoInit = new EventoInit("init");
            ListaEventos.Enqueue(eventoInit, eventoInit.TiempoFinal);
            //!ListaEventos.Add(eventoInit);
            while (idVectorEstado <= CANTITERACIONESREALIZAR + 1)
            {

                // Comienza el sistema
                // Comenzamos revisando cual es el evento que hay que resolver, para ello buscamos el que suceda mas proximo al reloj actual

                // EventoActual = ListaEventos.OrderBy(e => e.TiempoFinal).First();
                EventoActual = ListaEventos.Dequeue();
                // actualizar reloj
                RelojSimulacion = EventoActual.TiempoFinal;


                if (Empleado1.Estado == "Ocupado")
                {
                    Empleado1.AcumOcupacion += Math.Truncate((RelojSimulacion - (vE.reloj == "" ? 0 : float.Parse(vE.reloj, CultureInfo.InvariantCulture))) * 100) / 100;

                }

                if (Empleado2.Estado == "Ocupado")
                {
                    Empleado2.AcumOcupacion += Math.Truncate((RelojSimulacion - (vE.reloj == "" ? 0 : float.Parse(vE.reloj, CultureInfo.InvariantCulture))) * 100) / 100;

                }

                if (Empleado3.Estado == "Ocupado")
                {
                    Empleado3.AcumOcupacion += Math.Truncate((RelojSimulacion - (vE.reloj == "" ? 0 : float.Parse(vE.reloj, CultureInfo.InvariantCulture))) * 100) / 100;

                }

                //? ACUMULAR TIEMPO ESPERA RELOJES


                AcumTiempoEsperaReloj += (RelojSimulacion - (vE.reloj == "" ? 0 : float.Parse(vE.reloj, CultureInfo.InvariantCulture))) * ColaRelojes.Count;



                // resolvemos evento
                //ListaEventos.Remove(EventoActual);
                EventoActual.ResolverEvento(ref vE);

                if (!EventoActual.Nombre.Contains("FinControlReloj"))
                {
                    vE.resultadoControl = "";
                    vE.rndResultadoControl = "";


                }
                if (EventoActual.Nombre != "LlegadaReloj" && EventoActual.Nombre != "init")
                {
                    vE.rndLlegadaReloj = "";
                    vE.tiempoLlegadaReloj = "";
                }
                else
                {

                }






                //? LOGICA DE AGREGAR EL VECTOR ESTADO A LA LISTA PARA LUEGO MOSTRARLO


                if (idVectorEstado >= MOMENTOMOSTRARSIM && CANTITERACIONESMOSTRAR > 0)
                {

                    //TODO: AÑADIR VECTOR ESTADO A MOSTRAR
                    vE.id = idVectorEstado;
                    vE.eventoActual = EventoActual.Nombre;
                    vE.reloj = RelojSimulacion.ToString();

                    vE.estadoEmpleado1 = Empleado1.Estado.ToString();
                    vE.acumOcupacionEmpleado1 = (Math.Truncate(Empleado1.AcumOcupacion * 100) / 100).ToString();
                    vE.estadoEmpleado2 = Empleado2.Estado.ToString();
                    vE.acumOcupacionEmpleado2 = (Math.Truncate(Empleado2.AcumOcupacion * 100) / 100).ToString();
                    vE.estadoEmpleado3 = Empleado3.Estado.ToString();
                    vE.acumOcupacionEmpleado3 = (Math.Truncate(Empleado3.AcumOcupacion * 100) / 100).ToString();
                    vE.colaRelojes = ColaRelojes.Count.ToString();
                    vE.acumTiempoEsperaReloj = AcumTiempoEsperaReloj.ToString();
                    vE.contRelojes = ContRelojes.ToString();
                    vE.contRelojesTerminados = ContRelojesTerminados.ToString();
                    vE.acumTiempoRelojSistema = AcumTiempoRelojSistema.ToString();
                    vE.listaRelojes = ListaRelojes.Select(r => new Reloj(r.Id, r.Estado, r.TiempoLlegada)).ToList();
                    ListaVectoresEstado.Add(vE);

                    CANTITERACIONESMOSTRAR--;
                }




                //? INCREMENTAMOS EN UNO EL ID DEL VECTOR DE ESTADO
                idVectorEstado++;

            }





            // Habiendo salido del while, ya no tenemos eventos por resolver, por lo que calculamos las estadisticas
            // y actualizamos el vector estado
            // las estaddisticas toca agregarlas mas abajo del vector

            // TODO: CALCUALR ESTADISCTICAS

            //? El tiempo medio que debe esperar un reloj antes de ser controlado
            int cantTotalRelojes = ListaRelojes.Count;
            double tiempoPromedioEsperaReloj = cantTotalRelojes > 0
                ? Math.Truncate((AcumTiempoEsperaReloj / cantTotalRelojes) * 100) / 100
                : 0;

            //? El tiempo total promedio de un reloj en el sistema, desde que entra para ser controlado hasta que sale Ok o fallado
            double tiempoPromedioRelojSistema = ContRelojesTerminados > 0
                ? Math.Truncate((AcumTiempoRelojSistema / ContRelojesTerminados) * 100) / 100
                : 0;

            //? El porcentaje de utilización de cada uno de los operarios que controlan a los relojes.
            double porcentajeOcupacionEmp1 = (RelojSimulacion > 0)
                ? Math.Truncate(((Empleado1.AcumOcupacion / RelojSimulacion) * 100) * 100) / 100
                : 0;

            double porcentajeOcupacionEmp2 = (RelojSimulacion > 0)
                ? Math.Truncate(((Empleado2.AcumOcupacion / RelojSimulacion) * 100) * 100) / 100
                : 0;

            double porcentajeOcupacionEmp3 = (RelojSimulacion > 0)
                ? Math.Truncate(((Empleado3.AcumOcupacion / RelojSimulacion) * 100) * 100) / 100
                : 0;


            string ruta = "E:\\Proyectos\\sim_final_tp_2\\ResultadosSimulacion.csv";

            string header = ",,,LLEGADA_RELOJ,,,FIN_CONTROL_RELOJ,,,,,,,RESULTADO_DE_CONTROL,,EMPLEADO_1,,EMPLEADO_2,,EMPLEADO_3,,,,,,";
            string subHeader = "NRO,EVENTO,RELOJ,RND,TIEMPO,LLEGADA_RELOJ,RND1,RND2,TIEMPO1,TIEMPO2,FIN_CONTROL_EMP1,FIN_CONTROL_EMP2,FIN_CONTROL_EMP3,RND,RESULTADO,ESTADO,ACUM_OCUPACION,ESTADO,ACUM_OCUPACION,ESTADO,ACUM_OCUPACION,COLA_RELOJES,ACUM_TIEMPO_ESPERA_RELOJ,CONT_RELOJES,CONT_RELOJES_TERMINADOS,ACUM_TIEMPO_RELOJ_SISTEMA";
            int maxRelojes = ListaVectoresEstado.Max(ve => ve.listaRelojes?.Count ?? 0);


            var sb = new StringBuilder(1000000);
            for (int i = 0; i < maxRelojes; i++)
            {
                header += $",Reloj_{i},";
                subHeader += ",ESTADO, TIEMPO_LLEGADA";
            }

            sb.AppendLine(header);
            sb.AppendLine(subHeader);

            foreach (var vecE in ListaVectoresEstado)
            {
                var linea = new StringBuilder(1000);
                linea.Append($"{vecE.id},{vecE.eventoActual},{vecE.reloj},{vecE.rndLlegadaReloj},{vecE.tiempoLlegadaReloj},{vecE.llegadaReloj},{vecE.rnd1FinControlReloj},{vecE.rnd2FinControlReloj},{vecE.tiempo1FinControlReloj},{vecE.tiempo2FinControlReloj},{vecE.finControlRelojEmp1},{vecE.finControlRelojEmp2},{vecE.finControlRelojEmp3},{vecE.rndResultadoControl},{vecE.resultadoControl},{vecE.estadoEmpleado1},{vecE.acumOcupacionEmpleado1},{vecE.estadoEmpleado2},{vecE.acumOcupacionEmpleado2},{vecE.estadoEmpleado3},{vecE.acumOcupacionEmpleado3},{vecE.colaRelojes},{vecE.acumTiempoEsperaReloj},{vecE.contRelojes},{vecE.contRelojesTerminados},{vecE.acumTiempoRelojSistema}");

                if (vecE.listaRelojes != null)
                {
                    for (int i = 0; i < maxRelojes; i++)
                    {

                        if (i < vecE.listaRelojes.Count)
                        {
                            var r = vecE.listaRelojes[i];
                            linea.Append($",{r.Estado},{r.TiempoLlegada}");
                        }
                        else
                        {
                            linea.Append(",,");
                        }
                    }
                }

                sb.AppendLine(linea.ToString());
            }



            sb.AppendLine("");
            sb.AppendLine("");

            sb.AppendLine(",Resultados");
            sb.AppendLine($",Tiempo Medio Espera Reloj, {tiempoPromedioEsperaReloj} ");
            sb.AppendLine($",Tiempo Medio Reloj Sistema, {tiempoPromedioRelojSistema} ");
            sb.AppendLine($",Porcentaje Ocupacion Empleado 1, {porcentajeOcupacionEmp1} ");
            sb.AppendLine($",Porcentaje Ocupacion Empleado 2, {porcentajeOcupacionEmp2} ");
            sb.AppendLine($",Porcentaje Ocupacion Empleado 3, {porcentajeOcupacionEmp3} ");


            using (var writer = new StreamWriter(ruta, false, Encoding.UTF8, 65536))
            {
                writer.Write(sb.ToString());
            }
            Process.Start("explorer.exe", @"E:\Proyectos\sim_final_tp_2\ResultadosSimulacion.csv");









        }
    }

    public struct VectorEstado
    {
        public int id { get; set; }
        public string eventoActual { get; set; }
        public string reloj { get; set; }
        public string rndLlegadaReloj { get; set; }
        public string tiempoLlegadaReloj { get; set; }
        public string llegadaReloj { get; set; }
        public string rnd1FinControlReloj { get; set; }
        public string rnd2FinControlReloj { get; set; }
        public string tiempo1FinControlReloj { get; set; }
        public string tiempo2FinControlReloj { get; set; }
        public string finControlRelojEmp1 { get; set; }
        public string finControlRelojEmp2 { get; set; }
        public string finControlRelojEmp3 { get; set; }
        public string rndResultadoControl { get; set; }
        public string resultadoControl { get; set; }
        public string estadoEmpleado1 { get; set; }
        public string acumOcupacionEmpleado1 { get; set; }
        public string estadoEmpleado2 { get; set; }
        public string acumOcupacionEmpleado2 { get; set; }
        public string estadoEmpleado3 { get; set; }
        public string acumOcupacionEmpleado3 { get; set; }
        public string colaRelojes { get; set; }
        public string acumTiempoEsperaReloj { get; set; }
        public string contRelojes { get; set; }
        public string contRelojesTerminados { get; set; }
        public string acumTiempoRelojSistema { get; set; }
        public List<Reloj> listaRelojes { get; set; }

        public VectorEstado(
        int id,
        string eventoActual,
        string reloj,
        string rndLlegadaReloj,
        string tiempoLlegadaReloj,
        string llegadaReloj,
        string rnd1FinControlReloj,
        string rnd2FinControlReloj,
        string tiempo1FinControlReloj,
        string tiempo2FinControlReloj,
        string finControlRelojEmp1,
        string finControlRelojEmp2,
        string finControlRelojEmp3,
        string rndResultadoControl,
        string resultadoControl,
        string estadoEmpleado1,
        string acumOcupacionEmpleado1,
        string estadoEmpleado2,
        string acumOcupacionEmpleado2,
        string estadoEmpleado3,
        string acumOcupacionEmpleado3,
        string colaRelojes,
        string acumTiempoEsperaReloj,
        string contRelojes,
        string contRelojesTerminados,
        string acumTiempoRelojSistema,
        List<Reloj> listaRelojes
    )
        {
            this.id = id;
            this.eventoActual = eventoActual;
            this.reloj = reloj;
            this.rndLlegadaReloj = rndLlegadaReloj;
            this.tiempoLlegadaReloj = tiempoLlegadaReloj;
            this.llegadaReloj = llegadaReloj;
            this.rnd1FinControlReloj = rnd1FinControlReloj;
            this.rnd2FinControlReloj = rnd2FinControlReloj;
            this.tiempo1FinControlReloj = tiempo1FinControlReloj;
            this.tiempo2FinControlReloj = tiempo2FinControlReloj;
            this.finControlRelojEmp1 = finControlRelojEmp1;
            this.finControlRelojEmp2 = finControlRelojEmp2;
            this.finControlRelojEmp3 = finControlRelojEmp3;
            this.rndResultadoControl = rndResultadoControl;
            this.resultadoControl = resultadoControl;
            this.estadoEmpleado1 = estadoEmpleado1;
            this.acumOcupacionEmpleado1 = acumOcupacionEmpleado1;
            this.estadoEmpleado2 = estadoEmpleado2;
            this.acumOcupacionEmpleado2 = acumOcupacionEmpleado2;
            this.estadoEmpleado3 = estadoEmpleado3;
            this.acumOcupacionEmpleado3 = acumOcupacionEmpleado3;
            this.colaRelojes = colaRelojes;
            this.acumTiempoEsperaReloj = acumTiempoEsperaReloj;
            this.contRelojes = contRelojes;
            this.contRelojesTerminados = contRelojesTerminados;
            this.acumTiempoRelojSistema = acumTiempoRelojSistema;
            this.listaRelojes = listaRelojes;
        }

    }
}
