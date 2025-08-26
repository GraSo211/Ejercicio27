using CsvHelper;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
namespace Ejercicio70
{
    internal class Simulacion
    {
        public static int cantidadAlumnos { get; set; }
        public static float finPartePractica { get; set; }
        public static float finCorreccionPartePracticaA { get; set; }
        public static float finCorreccionPartePracticaB { get; set; }
        public static float finCorreccionParteTeorica { get; set; }
        public static float porcAprobacionPract { get; set; }
        public static float porcAprobacionTeo { get; set; }
        public static int horaFinPract { get; set; }
        public static int horaFinExamen { get; set; }

        public static int indexAlumnosProcesar { get; set; }
        private List<VectorEstado> listaVectoresEstado { get; set; }


        private float reloj { get; set; }
        private Profesor adjunto1 { get; set; }
        private Profesor adjunto2 { get; set; }
        private Profesor titularCatedra { get; set; }
        private Cola colaAdjuntos { get; set; }
        private Cola colaTitular { get; set; }
        public static float acumTiempoTotalExamenAlumnosAprobados { get; set; }
        public static int contAlumnosAprobados { get; set; }
        private List<Alumno> listaAlumnos { get; set; }
        private List<Evento> colaEventos { get; set; }

        private Evento eventoActual { get; set; }


        public Simulacion(int cantidadAlumnosP, float finPartePracticaP, float finCorreccionPartePracticaAP, float finCorreccionPartePracticaBP, float finCorreccionParteTeoricaP, float porcAprobacionPractP, float porcAprobacionTeoP, int horaFinPractP, int horaFinExamenP)
        {
            cantidadAlumnos = cantidadAlumnosP;
            finPartePractica = finPartePracticaP;
            finCorreccionPartePracticaA = finCorreccionPartePracticaAP;
            finCorreccionPartePracticaB = finCorreccionPartePracticaBP;
            finCorreccionParteTeorica = finCorreccionParteTeoricaP;
            porcAprobacionPract = porcAprobacionPractP;
            porcAprobacionTeo = porcAprobacionTeoP;
            horaFinPract = horaFinPractP;
            horaFinExamen = horaFinExamenP;

            indexAlumnosProcesar = 0;
            this.listaVectoresEstado = new List<VectorEstado>();



            this.reloj = horaFinPract;
            this.colaAdjuntos = new Cola(1, "Cola_Profesores_Adjuntos");
            this.colaTitular = new Cola(2, "Cola_Titular_Catedra");
            this.adjunto1 = new Profesor(1, "Adjunto_1", colaAdjuntos);
            this.adjunto2 = new Profesor(2, "Adjunto_2", colaAdjuntos);
            this.titularCatedra = new Profesor(3, "Titular_Catedra", colaTitular);
            acumTiempoTotalExamenAlumnosAprobados = 0;
            contAlumnosAprobados = 0;
            this.listaAlumnos = new List<Alumno>();
            this.colaEventos = new List<Evento>();
        }


        public void Simular()
        {
            for (int i = 1; i <= cantidadAlumnos; i++)
            {
                Alumno alumno = new Alumno(i);
                listaAlumnos.Add(alumno);

            }

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
            if (contAlumnosAprobados != 0)resultado = acumTiempoTotalExamenAlumnosAprobados / contAlumnosAprobados;
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
        public string rndfinPartePractica { get; set; }
        public string tiempofinPartePractica { get; set; }
        public string finfinPartePractica { get; set; }
        public string rndfinCorreccionPartePracticaAdjunto1 { get; set; }
        public string tiempofinCorreccionPartePracticaAdjunto1 { get; set; }
        public string finfinCorreccionPartePracticaAdjunto1 { get; set; }
        public string rndfinCorreccionPartePracticaAdjunto2 { get; set; }
        public string tiempofinCorreccionPartePracticaAdjunto2 { get; set; }
        public string finfinCorreccionPartePracticaAdjunto2 { get; set; }
        public string rndAprobacionPartePractica { get; set; }
        public string estadoAprobacionPartePractica { get; set; }
        public string tiempofinCorreccionParteTeorica { get; set; }
        public string finfinCorreccionParteTeorica { get; set; }
        public string rndAprobacionParteTeorica { get; set; }
        public string estadoAprobacionParteTeorica { get; set; }
        public string horafinExamen { get; set; }
        public string estadoadjunto1 { get; set; }
        public string estadoadjunto2 { get; set; }
        public string colaAdjuntos { get; set; }
        public string titularCatedra { get; set; }
        public string colaTitular { get; set; }
        public string acumTiempoTotalExamenAlumnosAprobados { get; set; }
        public string contAlumnosAprobados { get; set; }
        public List<Alumno> listaAlumnos { get; set; }

        public VectorEstado(
    int id,
    string eventoActual,
    string reloj,
    string rndfinPartePractica,
    string tiempofinPartePractica,
    string finfinPartePractica,
    string rndfinCorreccionPartePracticaAdjunto1,
    string tiempofinCorreccionPartePracticaAdjunto1,
    string finfinCorreccionPartePracticaAdjunto1,
    string rndfinCorreccionPartePracticaAdjunto2,
    string tiempofinCorreccionPartePracticaAdjunto2,
    string finfinCorreccionPartePracticaAdjunto2,
    string rndAprobacionPartePractica,
    string estadoAprobacionPartePractica,
    string tiempofinCorreccionParteTeorica,
    string finfinCorreccionParteTeorica,
    string rndAprobacionParteTeorica,
    string estadoAprobacionParteTeorica,
    string horafinExamen,
    string estadoadjunto1,
    string estadoadjunto2,
    string colaAdjuntos,
    string titularCatedra,
    string colaTitular,
    string acumTiempoTotalExamenAlumnosAprobados,
    string contAlumnosAprobados,
    List<Alumno> listaAlumnos)
        {
            this.id = id;
            this.eventoActual = eventoActual;
            this.reloj = reloj;
            this.rndfinPartePractica = rndfinPartePractica;
            this.tiempofinPartePractica = tiempofinPartePractica;
            this.finfinPartePractica = finfinPartePractica;
            this.rndfinCorreccionPartePracticaAdjunto1 = rndfinCorreccionPartePracticaAdjunto1;
            this.tiempofinCorreccionPartePracticaAdjunto1 = tiempofinCorreccionPartePracticaAdjunto1;
            this.finfinCorreccionPartePracticaAdjunto1 = finfinCorreccionPartePracticaAdjunto1;
            this.rndfinCorreccionPartePracticaAdjunto2 = rndfinCorreccionPartePracticaAdjunto2;
            this.tiempofinCorreccionPartePracticaAdjunto2 = tiempofinCorreccionPartePracticaAdjunto2;
            this.finfinCorreccionPartePracticaAdjunto2 = finfinCorreccionPartePracticaAdjunto2;
            this.rndAprobacionPartePractica = rndAprobacionPartePractica;
            this.estadoAprobacionPartePractica = estadoAprobacionPartePractica;
            this.tiempofinCorreccionParteTeorica = tiempofinCorreccionParteTeorica;
            this.finfinCorreccionParteTeorica = finfinCorreccionParteTeorica;
            this.rndAprobacionParteTeorica = rndAprobacionParteTeorica;
            this.estadoAprobacionParteTeorica = estadoAprobacionParteTeorica;
            this.horafinExamen = horafinExamen;
            this.estadoadjunto1 = estadoadjunto1;
            this.estadoadjunto2 = estadoadjunto2;
            this.colaAdjuntos = colaAdjuntos;
            this.titularCatedra = titularCatedra;
            this.colaTitular = colaTitular;
            this.acumTiempoTotalExamenAlumnosAprobados = acumTiempoTotalExamenAlumnosAprobados;
            this.contAlumnosAprobados = contAlumnosAprobados;
            this.listaAlumnos = listaAlumnos;
        }

    }
}
