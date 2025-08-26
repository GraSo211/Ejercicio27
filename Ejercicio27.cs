namespace Ejercicio27
{
    public partial class SIMULACION : Form
    {
        public SIMULACION()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void InputCantAlumnos_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CantAlumnos_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnIniciarSimulacion_Click(object sender, EventArgs e)
        {
            float LlegadaRelojMedia = float.Parse(this.inputLlegadaReloj.Text);
            float FinControlRelojMedia = float.Parse(this.InputFinControlRelojMedia.Text);
            float FinControlRelojDE = float.Parse(this.InputFinControlRelojDE.Text);
            float PorcAprobControl = float.Parse(this.InputPorcAprobReloj.Text);
            float MomentoMostrarSim = float.Parse(this.InputMomentoMostrarSim.Text);
            int CantIteracionMostrar = int.Parse(this.InputCantIterMostrar.Text);

            //Simulacion simulacion = new Simulacion(cantidadAlumnos, InputFinPract, InputFinCorrecPractA, InputFinCorrecPractB, InputFinCorrecTeo, InputPorcAprobPract, InputPorcAprobTeo, horaFinPract, horaFinExamen );
            //simulacion.Simular();

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AclaracionFinCorrecPractA_Click(object sender, EventArgs e)
        {

        }

        private void AclaracionFinPract_Click(object sender, EventArgs e)
        {

        }
    }




}
