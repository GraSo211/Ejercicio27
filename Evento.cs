using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio70
{
    internal abstract class Evento
    {
        public string nombre { get; set; }
        protected float rnd { get; set; }
        protected float entreTiempo { get; set; }
        public float reloj { get; set; }
        protected List<Alumno> listaAlumnos { get; set; }
        protected Alumno alumno { get; set; }
        protected Profesor adjunto1 { get; set; }
        protected Profesor adjunto2 { get; set; }
        protected Profesor titularCatedra { get; set; }

        public Evento(string nombre, float reloj, List<Alumno> listaAlumnos, Alumno alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra)
        {
            this.nombre = nombre;
            this.reloj = reloj;
            this.listaAlumnos = listaAlumnos;
            this.alumno = alumno;
            this.adjunto1 = adjunto1;
            this.adjunto2 = adjunto2;
            this.titularCatedra = titularCatedra;
        }

        public virtual void GenerarEvento()
        {

        }


        public virtual void GenerarEvento(ref VectorEstado vectorEstado)
        {

        }

        public virtual void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {

        }



    }


    internal class FinPartePractica : Evento
    {

        public FinPartePractica(string nombre, float reloj, List<Alumno> listaAlumnos, Alumno alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra) : base(nombre, reloj, listaAlumnos, alumno, adjunto1, adjunto2, titularCatedra) { }



        public override void GenerarEvento()
        {
            rnd = (float)(Math.Truncate(new Random().NextDouble() * 100) / 100);
            entreTiempo = -Simulacion.finPartePractica * (float)Math.Log(1 - rnd);
            reloj += entreTiempo;
        }

        public override void GenerarEvento(ref VectorEstado vectorEstado)
        {
            rnd = (float)(Math.Truncate(new Random().NextDouble() * 100) / 100);
            entreTiempo = (float)Math.Round(-Simulacion.finPartePractica * (float)Math.Log(1 - rnd), 2);
            reloj += entreTiempo;
            vectorEstado.rndfinPartePractica = rnd.ToString();
            vectorEstado.tiempofinPartePractica = entreTiempo.ToString();
            vectorEstado.finfinPartePractica = reloj.ToString();

        }

        public override void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {
            // GENERAMOS EL PROXIMO FIN
            int indexProxAlumno = listaAlumnos.IndexOf(alumno) + 1;
            if (indexProxAlumno >= Simulacion.cantidadAlumnos) return;
            Alumno proxAlumno = listaAlumnos[indexProxAlumno];

            Evento eventoFinPartePractica = new FinPartePractica(nombre, reloj, listaAlumnos, proxAlumno, adjunto1, adjunto2, titularCatedra);
            eventoFinPartePractica.GenerarEvento(ref vectorEstado);
            colaEventos.Add(eventoFinPartePractica);



            if (adjunto1.estado.Equals("Libre"))
            {


                adjunto1.estado = "Ocupado";
                alumno.estado = "En_Correccion_Adjunto1";

                vectorEstado.estadoadjunto1 = adjunto1.estado;
                //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                int i = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                vectorEstado.listaAlumnos[i].estado = alumno.estado;

                Evento eventoFinCorreccionAdjunto1 = new FinCorreccionAdjunto1("Fin_Correccion_Adj1", reloj, listaAlumnos, alumno, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionAdjunto1.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionAdjunto1);



            }
            else if (adjunto2.estado.Equals("Libre"))
            {
                adjunto2.estado = "Ocupado";
                alumno.estado = "En_Correccion_Adjunto2";

                vectorEstado.estadoadjunto2 = adjunto2.estado;
                //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                int i = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                vectorEstado.listaAlumnos[i].estado = alumno.estado;

                Evento eventoFinCorreccionAdjunto2 = new FinCorreccionAdjunto2("Fin_Correccion_Adj2", reloj, listaAlumnos, alumno, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionAdjunto2.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionAdjunto2);

            }
            else
            {
                adjunto1.cola.Alumnos.Enqueue(alumno);
                alumno.estado = "En_Cola_Adjuntos";
                //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                int i = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                vectorEstado.listaAlumnos[i].estado = alumno.estado;
                vectorEstado.colaAdjuntos = adjunto1.cola.Alumnos.Count().ToString();
            }

        }

    }

    internal class FinCorreccionAdjunto1 : Evento
    {

        public FinCorreccionAdjunto1(string nombre, float reloj, List<Alumno> listaAlumnos, Alumno alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra) : base(nombre, reloj, listaAlumnos, alumno, adjunto1, adjunto2, titularCatedra)
        {

        }
        public override void GenerarEvento(ref VectorEstado vectorEstado)
        {
            rnd = (float)(Math.Truncate(new Random().NextDouble() * 100) / 100);
            entreTiempo = (float)Math.Round(Simulacion.finCorreccionPartePracticaA + (rnd * (Simulacion.finCorreccionPartePracticaB - Simulacion.finCorreccionPartePracticaA)), 2);
            reloj += entreTiempo;
            vectorEstado.rndfinCorreccionPartePracticaAdjunto1 = rnd.ToString();
            vectorEstado.tiempofinCorreccionPartePracticaAdjunto1 = entreTiempo.ToString();
            vectorEstado.finfinCorreccionPartePracticaAdjunto1 = reloj.ToString();
        }
        private bool generarAprobacion(float rnd)
        {
            if (rnd <= (Simulacion.porcAprobacionPract / 100))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {
            // Resolvemos el alumno
            rnd = (float)(Math.Truncate(new Random().NextDouble() * 100) / 100);
            bool estadoExamenPractico = generarAprobacion(rnd);

            if (estadoExamenPractico == true)
            {
                // NOS FIJAMOS EN LA COLA DEL TITULAR 
                // SI ES MAYOR A 0 LO METEMOS A LA COLA
                // SI NO GENERAMOS EVENTO DE FIN EXAMEN TEORICO
                if(titularCatedra.estado== "Libre")
                {
                    Evento finCorreccionTeorico = new FinCorreccionTeorico("Fin_Correccion_Teorico",reloj,listaAlumnos,alumno,adjunto1,adjunto2,titularCatedra);
                    finCorreccionTeorico.GenerarEvento(ref vectorEstado);
                    colaEventos.Add(finCorreccionTeorico);
                    titularCatedra.estado = "Ocupado";
                    alumno.estado = "En_Correccion_Titular";
                    vectorEstado.titularCatedra = titularCatedra.estado;
                    vectorEstado.estadoadjunto1 = adjunto1.estado;
                    //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                    int j = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                    vectorEstado.listaAlumnos[j].estado = alumno.estado;

                }
                else
                {
                    titularCatedra.cola.Alumnos.Enqueue(alumno);
                    alumno.estado = "En_Cola_Titular";
                    int j = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                    vectorEstado.listaAlumnos[j].estado = alumno.estado;
                    vectorEstado.colaTitular = titularCatedra.cola.Alumnos.Count().ToString();
                }
            }
            else
            {
                alumno.estado = "Desaprobado";
            }

            // Actualizamos el vector con los datos del alumno
            //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
            int i = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
            vectorEstado.listaAlumnos[i].estado = alumno.estado;
            vectorEstado.rndAprobacionPartePractica = rnd.ToString();
            vectorEstado.estadoAprobacionPartePractica = estadoExamenPractico ? "Aprobado" : "Desaprobado";



            // Evaluamos la cola
            // Si no hay alumnos en la cola, el adjunto1 queda libre
            // Si hay alumnos en la cola, generamos evento de fin correccion adjunto1
            if (adjunto1.cola.Alumnos.Count() == 0)
            {
                adjunto1.estado = "Libre";
            }
            else
            {
                // Si hay alumnos en la cola, se atiende al primero
                Alumno alumnoAtendido = adjunto1.cola.Alumnos.Dequeue();
                alumnoAtendido.estado = "En_Correccion_Adjunto1";
                adjunto1.estado = "Ocupado";
                //int j = vectorEstado.listaAlumnos.IndexOf(alumnoAtendido);
                int j = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                vectorEstado.listaAlumnos[j].estado = alumnoAtendido.estado;
                Evento eventoFinCorreccionAdjunto1 = new FinCorreccionAdjunto1("Fin_Correccion_Adj1", reloj, listaAlumnos, alumnoAtendido, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionAdjunto1.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionAdjunto1);
            }

            // Actualizamos el estado del vector con los datos del adjunto1
            vectorEstado.estadoadjunto1 = adjunto1.estado;

        }
    }


    internal class FinCorreccionAdjunto2 : Evento
    {
        public FinCorreccionAdjunto2(string nombre, float reloj, List<Alumno> listaAlumno, Alumno Alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra) : base(nombre, reloj, listaAlumno, Alumno, adjunto1, adjunto2, titularCatedra)
        {

        }


        public override void GenerarEvento(ref VectorEstado vectorEstado)
        {
            rnd = (float)(Math.Truncate(new Random().NextDouble() * 100) / 100);
            entreTiempo = (float)Math.Round(Simulacion.finCorreccionPartePracticaA + (rnd * (Simulacion.finCorreccionPartePracticaB - Simulacion.finCorreccionPartePracticaA)), 2);
            reloj += entreTiempo;
            vectorEstado.rndfinCorreccionPartePracticaAdjunto2 = rnd.ToString();
            vectorEstado.tiempofinCorreccionPartePracticaAdjunto2 = entreTiempo.ToString();
            vectorEstado.finfinCorreccionPartePracticaAdjunto2 = reloj.ToString();
        }

        private bool generarAprobacion(float rnd)
        {
            if (rnd <= (Simulacion.porcAprobacionPract / 100))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {
            // Resolvemos el alumno
            rnd = (float)(Math.Truncate(new Random().NextDouble() * 100) / 100);
            bool estadoExamenPractico = generarAprobacion(rnd);

            if (estadoExamenPractico == true)
            {
                // NOS FIJAMOS EN LA COLA DEL TITULAR 
                // SI ES MAYOR A 0 LO METEMOS A LA COLA
                // SI NO GENERAMOS EVENTO DE FIN EXAMEN TEORICO
                if (titularCatedra.estado == "Libre")
                {
                    Evento finCorreccionTeorico = new FinCorreccionTeorico("Fin_Correccion_Teorico", reloj, listaAlumnos, alumno, adjunto1, adjunto2, titularCatedra);
                    finCorreccionTeorico.GenerarEvento(ref vectorEstado);
                    colaEventos.Add(finCorreccionTeorico);
                    titularCatedra.estado = "Ocupado";
                    alumno.estado = "En_Correccion_Titular";
                    vectorEstado.titularCatedra = titularCatedra.estado;
                    vectorEstado.estadoadjunto1 = adjunto1.estado;
                    //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                    int j = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                    vectorEstado.listaAlumnos[j].estado = alumno.estado;
                }
                else
                {
                    titularCatedra.cola.Alumnos.Enqueue(alumno);
                    alumno.estado = "En_Cola_Titular";
                    int j = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                    vectorEstado.listaAlumnos[j].estado = alumno.estado;
                   
                    vectorEstado.colaTitular = titularCatedra.cola.Alumnos.Count().ToString();
                }
            }
            else
            {
                alumno.estado = "Desaprobado";
            }

            // Actualizamos el vector con los datos del alumno
            //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
            int i = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
            vectorEstado.listaAlumnos[i].estado = alumno.estado;
            vectorEstado.rndAprobacionPartePractica = rnd.ToString();
            vectorEstado.estadoAprobacionPartePractica = estadoExamenPractico ? "Aprobado" : "Desaprobado";



            // Evaluamos la cola
            // Si no hay alumnos en la cola, el adjunto1 queda libre
            // Si hay alumnos en la cola, generamos evento de fin correccion adjunto1
            if (adjunto2.cola.Alumnos.Count() == 0)
            {
                adjunto2.estado = "Libre";
            }
            else
            {
                // Si hay alumnos en la cola, se atiende al primero
                Alumno alumnoAtendido = adjunto2.cola.Alumnos.Dequeue();
                alumnoAtendido.estado = "En_Correccion_Adjunto2";
                adjunto2.estado = "Ocupado";
                //int j = vectorEstado.listaAlumnos.IndexOf(alumnoAtendido);
                int j = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                vectorEstado.listaAlumnos[j].estado = alumnoAtendido.estado;
                Evento eventoFinCorreccionAdjunto2 = new FinCorreccionAdjunto2("Fin_Correccion_Adj2", reloj, listaAlumnos, alumnoAtendido, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionAdjunto2.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionAdjunto2);
            }

            // Actualizamos el estado del vector con los datos del adjunto1
            vectorEstado.estadoadjunto2 = adjunto2.estado;

        }

    }

    internal class FinCorreccionTeorico : Evento
    {
        public FinCorreccionTeorico(string nombre, float reloj, List<Alumno> listaAlumno, Alumno Alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra) : base(nombre, reloj, listaAlumno, Alumno, adjunto1, adjunto2, titularCatedra)
        {

        }
        // Necesitamos una function para generar el aprobado teorico copiar la del practico y editarla 

        public override void GenerarEvento(ref VectorEstado vectorEstado)
        {
            // Comentario para hacerlo mañana
            // NO NOS HACE FALTA RANDOM PORQUE ES CONSTANTE
            // ACA SOLO PONEMOS ENTRE TIEMPO = Simulacion.finCorreccionParteTeorica Y fin haciendo la suma tipica y luego actualizamos el 
            entreTiempo = Simulacion.finCorreccionParteTeorica;
            reloj += entreTiempo;
            vectorEstado.tiempofinCorreccionParteTeorica = entreTiempo.ToString();
            vectorEstado.finfinCorreccionParteTeorica = reloj.ToString();
        }

        private bool generarAprobacion(float rnd)
        {
            if (rnd <= (Simulacion.porcAprobacionTeo / 100))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {
            // Primero resovler el alumno
            // Luego ver el estado de la cola del profesor
            // si hay alumnos lo ponemos a laburar (generamos el evento)
            // si esta vacia lo ponemos libre
            // recordar calcular los tiempo que seria el tiempo actual del alumno - 0 porque es cuando arrancan y a eso lo acumulamos en el acum timepo
            // si aprobo le subimos a 1 el contador aprobdos
            rnd = (float)(Math.Truncate(new Random().NextDouble() * 100) / 100);
            bool estadoAprobacion = generarAprobacion(rnd);
            if (estadoAprobacion) {
                alumno.estado = "Aprobado";
            }
            else
            {
                alumno.estado = "Desaprobado";
            }
            // Actualizamos el vector con los datos del alumno
            //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
            int i = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
            vectorEstado.listaAlumnos[i].estado = alumno.estado;
            vectorEstado.rndAprobacionParteTeorica = rnd.ToString();
            vectorEstado.estadoAprobacionParteTeorica = estadoAprobacion ? "Aprobado" : "Desaprobado";
            if(estadoAprobacion == true)
            {
                Simulacion.acumTiempoTotalExamenAlumnosAprobados += reloj;
                Simulacion.contAlumnosAprobados += 1;
            }
            

            if (titularCatedra.cola.Alumnos.Count() == 0)
            {
                titularCatedra.estado = "Libre";

            }
            else
            {
                
                Alumno a = titularCatedra.cola.Alumnos.Dequeue();
                a.estado = "En_Correccion_Titular";


                Evento eventoFinCorreccionTeorico = new FinCorreccionTeorico("Fin_Correccion_Teorico", reloj, listaAlumnos, a, adjunto1, adjunto2, titularCatedra);
                eventoFinCorreccionTeorico.GenerarEvento(ref vectorEstado);
                colaEventos.Add(eventoFinCorreccionTeorico);
                //int i = vectorEstado.listaAlumnos.IndexOf(alumno);
                int j = vectorEstado.listaAlumnos.FindIndex(a => a.id == alumno.id);
                vectorEstado.listaAlumnos[j].estado = alumno.estado;
                vectorEstado.colaTitular = titularCatedra.cola.Alumnos.Count().ToString();
            }

            vectorEstado.titularCatedra = titularCatedra.estado;
        }

    }
    internal class FinExamen : Evento
    {
        public FinExamen(string nombre, float reloj, List<Alumno> listaAlumno, Alumno Alumno, Profesor adjunto1, Profesor adjunto2, Profesor titularCatedra) : base(nombre, reloj, listaAlumno, Alumno, adjunto1, adjunto2, titularCatedra)
        {

        }

        public override void GenerarEvento(ref VectorEstado vectorEstado)
        {

            reloj = Simulacion.horaFinExamen;
            vectorEstado.horafinExamen = reloj.ToString();

        }

        public override void ResolverEvento(ref VectorEstado vectorEstado, List<Evento> colaEventos)
        {
            foreach(Alumno al in listaAlumnos)
            {
                if (al.estado == "En_Examen") {
                    al.estado = "Desaprobado";
                }
                int index = listaAlumnos.IndexOf(al);
                vectorEstado.listaAlumnos[index].estado = al.estado;
            }
            
            colaEventos.RemoveAll(evento=>evento.nombre == "Fin_Parte_Practica");
        }

    }

}
