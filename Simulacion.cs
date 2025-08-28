
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


        public static float RelojSimulacion { get; set; }
        public static Empleado Empleado1 { get; set; }
        public static Empleado Empleado2 { get; set; }
        public static Empleado Empleado3 { get; set; }
        private Queue<Reloj> ColaRelojes { get; set; }

        public static float AcumTiempoEsperaReloj { get; set; }
        public static int ContRelojes { get; set; }
        public static float AcumTiempoRelojSistema { get; set; }
        private List<Reloj> ListaRelojes { get; set; }
        private List<Evento> ListaEventos { get; set; }

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


            int idVectorEstado = 1;

            // Creamos el evento inicial
            EventoInit eventoInit = new EventoInit("init", ListaEventos);
            ListaEventos.Add(eventoInit);

            while (idVectorEstado <= CANTITERACIONESREALIZAR + 1)
            {

                // Comienza el sistema
                // Comenzamos revisando cual es el evento que hay que resolver, para ello buscamos el que suceda mas proximo al reloj actual
                EventoActual = ListaEventos.OrderBy(e => e.TiempoFinal).First();
                ListaEventos.Remove(EventoActual);
                EventoActual.ResolverEvento();







                //? LOGICA DE AGREGAR EL VECTOR ESTADO A LA LISTA PARA LUEGO MOSTRARLO

                int iterRestantes = CANTITERACIONESMOSTRAR;
                if (RelojSimulacion >= MOMENTOMOSTRARSIM)
                {

                    //TODO: AÑADIR VECTOR ESTADO A MOSTRAR
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
            string header = ",,,LLEGADA_RELOJ,,,FIN_CONTROL_RELOJ,,,,,RESULTADO_DE_CONTROL,,EMPLEADO_1,,EMPLEADO_2,,EMPLEADO_3";
            string subHeader = "NRO,EVENTO,RELOJ,RND,TIEMPO,LLEGADA_RELOJ,RND1,RND2,TIEMPO1,TIEMPO2,FIN_CONTROL,RND,RESULTADO,ESTADO,ACUM_OCUPACION,ESTADO,ACUM_OCUPACION,ESTADO,ACUM_OCUPACION,COLA_RELOJES,ACUM_TIEMPO_ESPERA_RELOJ,CONT_RELOJES,ACUM_TIEMPO_RELOJ_SISTEMA";
            /* for (int i = 1; i <= cantidadAlumnos; i++)
            {
                header += ", ALUMNO_" + i;
                subHeader += ",ESTADO";
            } */
            csv.Add(header);
            csv.Add(subHeader);

            /* foreach (VectorEstado vE in listaVectoresEstado)
            {
                string linea = $"{vE.id},{vE.eventoActual},{vE.reloj},{vE.rndfinPartePractica},{vE.tiempofinPartePractica},{vE.finfinPartePractica},{vE.rndfinCorreccionPartePracticaAdjunto1},{vE.tiempofinCorreccionPartePracticaAdjunto1},{vE.finfinCorreccionPartePracticaAdjunto1},{vE.rndfinCorreccionPartePracticaAdjunto2},{vE.tiempofinCorreccionPartePracticaAdjunto2},{vE.finfinCorreccionPartePracticaAdjunto2},{vE.rndAprobacionPartePractica},{vE.estadoAprobacionPartePractica},{vE.tiempofinCorreccionParteTeorica},{vE.finfinCorreccionParteTeorica},{vE.rndAprobacionParteTeorica},{vE.estadoAprobacionParteTeorica},{vE.horafinExamen},{vE.estadoadjunto1},{vE.estadoadjunto2},{vE.colaAdjuntos},{vE.titularCatedra},{vE.colaTitular},{vE.acumTiempoTotalExamenAlumnosAprobados},{vE.contAlumnosAprobados},";
                foreach (Alumno a in vE.listaAlumnos)
                {
                    linea += $"{a.estado},";
                }
                csv.Add(linea);
            } */


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


    internal struct VectorEstado
    {
        public int id { get; set; }
        public string eventoActual { get; set; }
        public string reloj { get; set; }
        public string rndLlegadaReloj { get; set; }
        public string tiempoLlegadaReloj { get; set; }
        public string llegadaReloj { get; set; }
        public string rndfinControlReloj { get; set; }
        public string tiempofinControlReloj { get; set; }
        public string finControlReloj { get; set; }
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
        string rndfinControlReloj,
        string tiempofinControlReloj,
        string finControlReloj,
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
            this.rndfinControlReloj = rndfinControlReloj;
            this.tiempofinControlReloj = tiempofinControlReloj;
            this.finControlReloj = finControlReloj;
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
