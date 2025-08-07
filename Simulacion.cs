
using Ejercicio27;

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
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
        public static float MOMENTOMOSTRARSIM { get; set; }
        public static int CANTITERACIONESMOSTRAR { get; set; }

        private List<VectorEstado> ListaVectoresEstado { get; set; }


        public static double RelojSimulacion { get; set; }
        public static Empleado Empleado1 { get; set; }
        public static Empleado Empleado2 { get; set; }
        public static Empleado Empleado3 { get; set; }
        public static Queue<Reloj> ColaRelojes { get; set; }

        public static float AcumTiempoEsperaReloj { get; set; }
        public static int ContRelojes { get; set; }
        public static float AcumTiempoRelojSistema { get; set; }
        public static List<Reloj> ListaRelojes { get; set; }
        public static List<Evento> ListaEventos { get; set; }
        public static double? TiempoValorSobranteNormal { get; set;}
        private dynamic EventoActual { get; set; }


        public Simulacion(
            float llegadaRelojMedia,
            float finControlRelojMedia,
            float finControlRelojDE,
            float porcaProbControl,
            int cantIteracionesRealizar,
            float momentoMostrarSim,
            int cantIteracionesMostrar
        )
        {

            LLEGADARELOJMEDIA = llegadaRelojMedia;
            FINCONTROLRELOJMEDIA = finControlRelojMedia;
            FINCONTROLRELOJDE = finControlRelojDE;
            PORCAPROBCONTROL = porcaProbControl;
            CANTITERACIONESREALIZAR = cantIteracionesRealizar;
            MOMENTOMOSTRARSIM = momentoMostrarSim;
            CANTITERACIONESMOSTRAR = cantIteracionesMostrar;


            RelojSimulacion = 0;
            ListaVectoresEstado = new List<VectorEstado>();
            ListaRelojes = new List<Reloj>();
            ListaEventos = new List<Evento>();

            Empleado1 = new Empleado(1, "Empleado_1");
            Empleado2 = new Empleado(2, "Empleado_2");
            Empleado3 = new Empleado(3, "Empleado_3");

            ColaRelojes = new Queue<Reloj>();

            AcumTiempoEsperaReloj = 0;
            ContRelojes = 0;
            AcumTiempoRelojSistema = 0;


        }


        public void Simular()
        {
            ListaRelojes.Add(new Reloj(1,"",0));

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
                acumTiempoRelojSistema = AcumTiempoRelojSistema.ToString(),
                listaRelojes = ListaRelojes
            };



            // Creamos el evento inicial
            EventoInit eventoInit = new EventoInit("init");
            ListaEventos.Add(eventoInit);
            Console.WriteLine(ListaEventos.Count);
            while (idVectorEstado <=  CANTITERACIONESREALIZAR  +1 )
            {

                // Comienza el sistema
                // Comenzamos revisando cual es el evento que hay que resolver, para ello buscamos el que suceda mas proximo al reloj actual
                
                EventoActual = ListaEventos.OrderBy(e => e.TiempoFinal).First();
                // actualizar reloj
                RelojSimulacion = RelojSimulacion + EventoActual.TiempoFinal;
                // resolvemos evento
                ListaEventos.Remove(EventoActual);
                EventoActual.ResolverEvento(ref vE);

                

                







                //? LOGICA DE AGREGAR EL VECTOR ESTADO A LA LISTA PARA LUEGO MOSTRARLO

                int iterRestantes = CANTITERACIONESMOSTRAR;
                if (RelojSimulacion >= MOMENTOMOSTRARSIM)
                {

                    //TODO: AÑADIR VECTOR ESTADO A MOSTRAR
                    vE.id = idVectorEstado;
                    vE.eventoActual = EventoActual.Nombre;
                    vE.reloj = RelojSimulacion.ToString();

                    vE.estadoEmpleado1 = Empleado1.Estado.ToString();
                    vE.acumOcupacionEmpleado1 = Empleado1.AcumOcupacion.ToString();
                    vE.estadoEmpleado2 = Empleado2.Estado.ToString();
                    vE.acumOcupacionEmpleado2 = Empleado2.AcumOcupacion.ToString();
                    vE.estadoEmpleado3 = Empleado3.Estado.ToString();
                    vE.acumOcupacionEmpleado3 = Empleado3.AcumOcupacion.ToString();
                    vE.colaRelojes = ColaRelojes.Count.ToString();
                    vE.acumTiempoEsperaReloj = AcumTiempoEsperaReloj.ToString();
                    vE.contRelojes = ContRelojes.ToString();
                    
                    vE.acumTiempoRelojSistema = AcumTiempoRelojSistema.ToString();
                    ListaVectoresEstado.Add(vE);

                    iterRestantes--;
                }

                if (iterRestantes == 0) 
                {
                    break;
                }


                //? INCREMENTAMOS EN UNO EL ID DEL VECTOR DE ESTADO
                idVectorEstado++;

            }





            // Habiendo salido del while, ya no tenemos eventos por resolver, por lo que calculamos las estadisticas
            // y actualizamos el vector estado
            // las estaddisticas toca agregarlas mas abajo del vector


            string ruta = "E:\\Proyectos\\sim_final_tp_2\\ResultadosSimulacion.csv";

            List<string> csv = new List<string>();
            string header = ",,,LLEGADA_RELOJ,,,FIN_CONTROL_RELOJ,,,,,,,RESULTADO_DE_CONTROL,,EMPLEADO_1,,EMPLEADO_2,,EMPLEADO_3";
            string subHeader = "NRO,EVENTO,RELOJ,RND,TIEMPO,LLEGADA_RELOJ,RND1,RND2,TIEMPO1,TIEMPO2,FIN_CONTROL_EMP1,FIN_CONTROL_EMP2,FIN_CONTROL_EMP3,RND,RESULTADO,ESTADO,ACUM_OCUPACION,ESTADO,ACUM_OCUPACION,ESTADO,ACUM_OCUPACION,COLA_RELOJES,ACUM_TIEMPO_ESPERA_RELOJ,CONT_RELOJES,ACUM_TIEMPO_RELOJ_SISTEMA";
            /* for (int i = 1; i <= cantidadAlumnos; i++)
            {
                header += ", ALUMNO_" + i;
                subHeader += ",ESTADO";
            } */
            csv.Add(header);
            csv.Add(subHeader);

            foreach (VectorEstado vecE in ListaVectoresEstado)
            {
                string linea = $"{vecE.id},{vecE.eventoActual},{vecE.reloj}, {vecE.rndLlegadaReloj}, {vecE.tiempoLlegadaReloj}, {vecE.llegadaReloj}, {vecE.rnd1FinControlReloj}, {vecE.rnd2FinControlReloj}, {vecE.tiempo1FinControlReloj}, {vecE.tiempo2FinControlReloj}, {vecE.finControlRelojEmp1}, {vecE.finControlRelojEmp2}, {vecE.finControlRelojEmp3}, {vecE.rndResultadoControl}, {vecE.resultadoControl}, {vecE.estadoEmpleado1}, {vecE.acumOcupacionEmpleado1}, {vecE.estadoEmpleado2}, {vecE.acumOcupacionEmpleado2}, {vecE.estadoEmpleado3}, {vecE.acumOcupacionEmpleado3}, {vecE.colaRelojes}, {vecE.acumTiempoEsperaReloj}, {vecE.contRelojes}, {vecE.acumTiempoRelojSistema}";

                csv.Add(linea);
            }


            // TODO: CALCUALR ESTADISCTICAS
            /*  csv.Add("");
             csv.Add("");
             csv.Add(",Resultados");
             float resultado = 0;
             if (contAlumnosAprobados != 0) resultado = acumTiempoTotalExamenAlumnosAprobados / contAlumnosAprobados;
             csv.Add($",Tiempo promedio de examen de los alumnos, {resultado} ");
             csv.Add(",desde que inician el práctico ");
             csv.Add(",hasta que terminan el teórico"); */


            try
            {
                File.WriteAllLines(ruta, csv, Encoding.UTF8);
                Process.Start("explorer.exe", @"E:\Proyectos\sim_final_tp_2\ResultadosSimulacion.csv");
            }
            catch (Exception IOException)
            {
                // NO HACEMOS NADA XD
            }









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
            this.acumTiempoRelojSistema = acumTiempoRelojSistema;
            this.listaRelojes = listaRelojes;
        }

    }
}
