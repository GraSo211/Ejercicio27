
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
        public static float MOMENTOMOSTRARSIM { get; set; }
        public static int CANTITERACIONESMOSTRAR { get; set; }

        private List<VectorEstado> ListaVectoresEstado { get; set; }


        private float RelojSimulacion { get; set; }
        private Empleado Empleado1 { get; set; }
        private Empleado Empleado2 { get; set; }
        private Empleado Empleado3 { get; set; }
        private Queue<Reloj> ColaRelojes { get; set; }

        public static float AcumTiempoEsperaReloj { get; set; }
        public static int ContRelojes { get; set; }
        public static float AcumTiempoRelojSistema { get; set; }
        private List<Reloj> ListaRelojes { get; set; }
        private Queue<dynamic> ColaEventos { get; set; }

        private dynamic EventoActual { get; set; }


        public Simulacion(
          float llegadaRelojMedia,
          float finControlRelojMedia,
          float finControlRelojDE,
          float porcaProbControl,
          float momentoMostrarSim,
          int cantIteracionesMostrar
      )
        {

            LLEGADARELOJMEDIA = llegadaRelojMedia;
            FINCONTROLRELOJMEDIA = finControlRelojMedia;
            FINCONTROLRELOJDE = finControlRelojDE;
            PORCAPROBCONTROL = porcaProbControl;
            MOMENTOMOSTRARSIM = momentoMostrarSim;
            CANTITERACIONESMOSTRAR = cantIteracionesMostrar;


            RelojSimulacion = 0;
            ListaVectoresEstado = new List<VectorEstado>();
            ListaRelojes = new List<Reloj>();
            ColaEventos = new Queue<dynamic>();

            Empleado1 = new Empleado(1, "Empleado_1");
            Empleado2 = new Empleado(2, "Empleado_2");
            Empleado3 = new Empleado(3, "Empleado_3");

            ColaRelojes = new Queue<Reloj>();

            AcumTiempoEsperaReloj = 0;
            ContRelojes = 0;
            AcumTiempoRelojSistema = 0;

            EventoActual = new { };
        }


        public void Simular()
        {


            int idVectorEstado = 1;
            VectorEstado vectorEstado = new VectorEstado(idVectorEstado++, "init", reloj.ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", adjunto1.estado, adjunto2.estado, colaAdjuntos.Alumnos.Count.ToString(), titularCatedra.estado, colaTitular.Alumnos.Count.ToString(), acumTiempoTotalExamenAlumnosAprobados.ToString(), contAlumnosAprobados.ToString(), listaAlumnos);

            Evento eventoFinExamen = new FinExamen("Fin_Examen", horaFinExamen, listaAlumnos, listaAlumnos[0], adjunto1, adjunto2, titularCatedra);
            eventoFinExamen.GenerarEvento();
            colaEventos.Add(eventoFinExamen);
            vectorEstado.horafinExamen = horaFinExamen.ToString();

            Evento eventoFinPartePractica = new FinPartePractica("Fin_Parte_Practica", reloj, listaAlumnos, listaAlumnos[0], adjunto1, adjunto2, titularCatedra);
            eventoFinPartePractica.GenerarEvento(ref vectorEstado);

            eventoActual = eventoFinPartePractica;
            colaEventos.Add(eventoFinPartePractica);
            List<Alumno> copiaListaAlumnos = listaAlumnos.Select(a => a.Clone()).ToList();
            vectorEstado.listaAlumnos = copiaListaAlumnos;
            listaVectoresEstado.Add(vectorEstado);
            float eventoMenorTiempo = reloj;



            while (idVectorEstado <= 100000 + 1)
            {
                // Comienza el sistema
                // Comenzamos revisando cual es el evento que hay que resolver, para ello buscamos el que suceda mas proximo al reloj actual
                if (colaEventos.Count() == 0) break;
                eventoActual = colaEventos.OrderBy(e => e.reloj).First();
                eventoMenorTiempo = eventoActual.reloj;

                // Resolvemos el evento actual
                vectorEstado.eventoActual = eventoActual.nombre;
                vectorEstado.reloj = eventoActual.reloj.ToString();
                eventoActual.ResolverEvento(ref vectorEstado, colaEventos);
                colaEventos.Remove(eventoActual);

                copiaListaAlumnos = listaAlumnos.Select(a => a.Clone()).ToList();
                vectorEstado.listaAlumnos = copiaListaAlumnos;

                vectorEstado.horafinExamen = horaFinExamen.ToString();
                vectorEstado.colaTitular = titularCatedra.cola.Alumnos.Count().ToString();
                vectorEstado.acumTiempoTotalExamenAlumnosAprobados = acumTiempoTotalExamenAlumnosAprobados.ToString();
                vectorEstado.contAlumnosAprobados = contAlumnosAprobados.ToString();
                listaVectoresEstado.Add(vectorEstado);
                vectorEstado.id = idVectorEstado;
                idVectorEstado++;


            }
            // Habiendo salido del while, ya no tenemos eventos por resolver, por lo que calculamos las estadisticas
            // y actualizamos el vector estado
            // las estaddisticas toca agregarlas mas abajo del vector


            string ruta = "E:\\Proyectos\\sim_final_tp\\ResultadosSimulacion.csv";

            List<string> csv = new List<string>();
            string header = ",,,FIN_DE_PARTE_PRACTICA,,,FIN_CORRECCION_ADJUNTO_1,,,FIN_CORRECCION_ADJUNTO_2,,,APROBACION_PARTE_PRACTICA,,FIN_CORRECCION_PARTE_TEORICA,,APROBACION_PARTE_TEORICA,,FIN_DE_EXAMEN,ADJUNTO_1,ADJUNTO_2,,TITULAR_CATEDRA,,ACUM_TIEMPO_EXAMEN_ALUMNOS_APROBADOS,CONT_APROBADOS";
            string subHeader = "NRO,EVENTO,RELOJ,RND,TIEMPO,FIN_PARTE_PRACTICA,RND,TIEMPO,FIN_CORRECCION,RND,TIEMPO,FIN_CORRECCION,RND,ESTADO,TIEMPO,FIN_PARTE_TEORICA,RND,ESTADO,HORA,ESTADO,ESTADO,COLA_PROFESORES,ESTADO,COLA_TITULAR,, ";
            for (int i = 1; i <= cantidadAlumnos; i++)
            {
                header += ", ALUMNO_" + i;
                subHeader += ",ESTADO";
            }
            csv.Add(header);
            csv.Add(subHeader);

            foreach (VectorEstado vE in listaVectoresEstado)
            {
                string linea = $"{vE.id},{vE.eventoActual},{vE.reloj},{vE.rndfinPartePractica},{vE.tiempofinPartePractica},{vE.finfinPartePractica},{vE.rndfinCorreccionPartePracticaAdjunto1},{vE.tiempofinCorreccionPartePracticaAdjunto1},{vE.finfinCorreccionPartePracticaAdjunto1},{vE.rndfinCorreccionPartePracticaAdjunto2},{vE.tiempofinCorreccionPartePracticaAdjunto2},{vE.finfinCorreccionPartePracticaAdjunto2},{vE.rndAprobacionPartePractica},{vE.estadoAprobacionPartePractica},{vE.tiempofinCorreccionParteTeorica},{vE.finfinCorreccionParteTeorica},{vE.rndAprobacionParteTeorica},{vE.estadoAprobacionParteTeorica},{vE.horafinExamen},{vE.estadoadjunto1},{vE.estadoadjunto2},{vE.colaAdjuntos},{vE.titularCatedra},{vE.colaTitular},{vE.acumTiempoTotalExamenAlumnosAprobados},{vE.contAlumnosAprobados},";
                foreach (Alumno a in vE.listaAlumnos)
                {
                    linea += $"{a.estado},";
                }
                csv.Add(linea);
            }

            csv.Add("");
            csv.Add("");
            csv.Add(",Resultados");
            float resultado = 0;
            if (contAlumnosAprobados != 0) resultado = acumTiempoTotalExamenAlumnosAprobados / contAlumnosAprobados;
            csv.Add($",Tiempo promedio de examen de los alumnos, {resultado} ");
            csv.Add(",desde que inician el práctico ");
            csv.Add(",hasta que terminan el teórico");
            try
            {
                File.WriteAllLines(ruta, csv, Encoding.UTF8);
                Process.Start("explorer.exe", @"E:\Proyectos\sim_final_tp\ResultadosSimulacion.csv");
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
