namespace Ejercicio70
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
            int cantidadAlumnos = int.Parse(this.InputCantAlumnos.Text);
            float InputFinPract = float.Parse(this.InputFinPract.Text);
            float InputFinCorrecPractA = float.Parse(this.InputFinCorrecPractA.Text);
            float InputFinCorrecPractB = float.Parse(this.InputFinCorrecPractB.Text);
            float InputFinCorrecTeo = float.Parse(this.InputFinCorrecTeo.Text);
            float InputPorcAprobPract = float.Parse(this.InputPorcAprobPract.Text);
            float InputPorcAprobTeo = float.Parse(this.InputPorcAprobTeo.Text);
            int horaFinPract = int.Parse(this.InputHoraTerminarPract.Text);
            int horaFinExamen = int.Parse(this.InputHoraTerminarExamen.Text);

            Simulacion simulacion = new Simulacion(cantidadAlumnos, InputFinPract, InputFinCorrecPractA, InputFinCorrecPractB, InputFinCorrecTeo, InputPorcAprobPract, InputPorcAprobTeo, horaFinPract, horaFinExamen );
            simulacion.Simular();

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }




}
