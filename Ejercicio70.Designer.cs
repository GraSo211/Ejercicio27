namespace Ejercicio70
{
    partial class SIMULACION
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titulo = new Label();
            InputCantAlumnos = new TextBox();
            CantAlumnos = new Label();
            FinPract = new Label();
            InputFinPract = new TextBox();
            FinCorrecTeo = new Label();
            InputFinCorrecTeo = new TextBox();
            AclaracionCantAlumnos = new Label();
            AclaracionFinPract = new Label();
            AclaracionFinCorrecTeo = new Label();
            AclaracionAprobTeo = new Label();
            AclaracionAprobPract = new Label();
            PorcAprobTeo = new Label();
            InputPorcAprobTeo = new TextBox();
            PorcAprobPract = new Label();
            InputPorcAprobPract = new TextBox();
            AclaracionFinCorrecPractA = new Label();
            FinCorrecPractA = new Label();
            InputFinCorrecPractA = new TextBox();
            AclaracionFinCorrecPractB = new Label();
            FinCorrecPractB = new Label();
            InputFinCorrecPractB = new TextBox();
            btnIniciarSimulacion = new Button();
            AclaracionHoraTerminarPract = new Label();
            HoraTerminarPract = new Label();
            InputHoraTerminarPract = new TextBox();
            AclaracionHoraTerminarExamen = new Label();
            HoraTerminarExamen = new Label();
            InputHoraTerminarExamen = new TextBox();
            SuspendLayout();
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Font = new Font("Montserrat", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titulo.Location = new Point(431, 9);
            titulo.Name = "titulo";
            titulo.Size = new Size(426, 100);
            titulo.TabIndex = 0;
            titulo.Text = "Ejercicio 70";
            titulo.Click += label1_Click;
            // 
            // InputCantAlumnos
            // 
            InputCantAlumnos.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputCantAlumnos.Location = new Point(254, 148);
            InputCantAlumnos.Name = "InputCantAlumnos";
            InputCantAlumnos.Size = new Size(100, 27);
            InputCantAlumnos.TabIndex = 1;
            InputCantAlumnos.Text = "10";
            InputCantAlumnos.TextChanged += InputCantAlumnos_TextChanged;
            // 
            // CantAlumnos
            // 
            CantAlumnos.AutoSize = true;
            CantAlumnos.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            CantAlumnos.Location = new Point(44, 148);
            CantAlumnos.Name = "CantAlumnos";
            CantAlumnos.Size = new Size(198, 25);
            CantAlumnos.TabIndex = 2;
            CantAlumnos.Text = "Cantidad de Alumnos:";
            CantAlumnos.Click += CantAlumnos_Click;
            // 
            // FinPract
            // 
            FinPract.AutoSize = true;
            FinPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            FinPract.Location = new Point(44, 201);
            FinPract.Name = "FinPract";
            FinPract.Size = new Size(192, 25);
            FinPract.TabIndex = 4;
            FinPract.Text = "Fin de Parte Practica:";
            // 
            // InputFinPract
            // 
            InputFinPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputFinPract.Location = new Point(251, 201);
            InputFinPract.Name = "InputFinPract";
            InputFinPract.Size = new Size(100, 27);
            InputFinPract.TabIndex = 3;
            InputFinPract.Text = "5";
            InputFinPract.TextChanged += textBox2_TextChanged;
            // 
            // FinCorrecTeo
            // 
            FinCorrecTeo.AutoSize = true;
            FinCorrecTeo.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            FinCorrecTeo.Location = new Point(44, 289);
            FinCorrecTeo.Name = "FinCorrecTeo";
            FinCorrecTeo.Size = new Size(279, 25);
            FinCorrecTeo.TabIndex = 6;
            FinCorrecTeo.Text = "Fin de Correccion Parte Teorica:";
            FinCorrecTeo.Click += label1_Click_1;
            // 
            // InputFinCorrecTeo
            // 
            InputFinCorrecTeo.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputFinCorrecTeo.Location = new Point(329, 291);
            InputFinCorrecTeo.Name = "InputFinCorrecTeo";
            InputFinCorrecTeo.Size = new Size(100, 27);
            InputFinCorrecTeo.TabIndex = 5;
            InputFinCorrecTeo.Text = "5";
            InputFinCorrecTeo.TextChanged += textBox1_TextChanged;
            // 
            // AclaracionCantAlumnos
            // 
            AclaracionCantAlumnos.AutoSize = true;
            AclaracionCantAlumnos.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionCantAlumnos.ForeColor = SystemColors.ControlDark;
            AclaracionCantAlumnos.Location = new Point(366, 145);
            AclaracionCantAlumnos.Name = "AclaracionCantAlumnos";
            AclaracionCantAlumnos.Size = new Size(101, 25);
            AclaracionCantAlumnos.TabIndex = 7;
            AclaracionCantAlumnos.Text = "(Cantidad)";
            AclaracionCantAlumnos.Click += label2_Click;
            // 
            // AclaracionFinPract
            // 
            AclaracionFinPract.AutoSize = true;
            AclaracionFinPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionFinPract.ForeColor = SystemColors.ControlDark;
            AclaracionFinPract.Location = new Point(366, 198);
            AclaracionFinPract.Name = "AclaracionFinPract";
            AclaracionFinPract.Size = new Size(127, 25);
            AclaracionFinPract.TabIndex = 8;
            AclaracionFinPract.Text = "(Exponencial)";
            // 
            // AclaracionFinCorrecTeo
            // 
            AclaracionFinCorrecTeo.AutoSize = true;
            AclaracionFinCorrecTeo.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionFinCorrecTeo.ForeColor = SystemColors.ControlDark;
            AclaracionFinCorrecTeo.Location = new Point(435, 289);
            AclaracionFinCorrecTeo.Name = "AclaracionFinCorrecTeo";
            AclaracionFinCorrecTeo.Size = new Size(110, 25);
            AclaracionFinCorrecTeo.TabIndex = 9;
            AclaracionFinCorrecTeo.Text = "(Constante)";
            // 
            // AclaracionAprobTeo
            // 
            AclaracionAprobTeo.AutoSize = true;
            AclaracionAprobTeo.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionAprobTeo.ForeColor = SystemColors.ControlDark;
            AclaracionAprobTeo.Location = new Point(1069, 324);
            AclaracionAprobTeo.Name = "AclaracionAprobTeo";
            AclaracionAprobTeo.Size = new Size(115, 25);
            AclaracionAprobTeo.TabIndex = 15;
            AclaracionAprobTeo.Text = "(Porcentaje)";
            // 
            // AclaracionAprobPract
            // 
            AclaracionAprobPract.AutoSize = true;
            AclaracionAprobPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionAprobPract.ForeColor = SystemColors.ControlDark;
            AclaracionAprobPract.Location = new Point(463, 328);
            AclaracionAprobPract.Name = "AclaracionAprobPract";
            AclaracionAprobPract.Size = new Size(115, 25);
            AclaracionAprobPract.TabIndex = 14;
            AclaracionAprobPract.Text = "(Porcentaje)";
            AclaracionAprobPract.Click += label3_Click;
            // 
            // PorcAprobTeo
            // 
            PorcAprobTeo.AutoSize = true;
            PorcAprobTeo.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            PorcAprobTeo.Location = new Point(666, 325);
            PorcAprobTeo.Name = "PorcAprobTeo";
            PorcAprobTeo.Size = new Size(299, 25);
            PorcAprobTeo.TabIndex = 13;
            PorcAprobTeo.Text = "Porcentaje de Aprobacion Teorico:";
            // 
            // InputPorcAprobTeo
            // 
            InputPorcAprobTeo.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputPorcAprobTeo.Location = new Point(967, 326);
            InputPorcAprobTeo.Name = "InputPorcAprobTeo";
            InputPorcAprobTeo.Size = new Size(100, 27);
            InputPorcAprobTeo.TabIndex = 12;
            InputPorcAprobTeo.Text = "50";
            // 
            // PorcAprobPract
            // 
            PorcAprobPract.AutoSize = true;
            PorcAprobPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            PorcAprobPract.Location = new Point(44, 328);
            PorcAprobPract.Name = "PorcAprobPract";
            PorcAprobPract.Size = new Size(307, 25);
            PorcAprobPract.TabIndex = 11;
            PorcAprobPract.Text = "Porcentaje de Aprobacion Practico:";
            // 
            // InputPorcAprobPract
            // 
            InputPorcAprobPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputPorcAprobPract.Location = new Point(357, 328);
            InputPorcAprobPract.Name = "InputPorcAprobPract";
            InputPorcAprobPract.Size = new Size(100, 27);
            InputPorcAprobPract.TabIndex = 10;
            InputPorcAprobPract.Text = "80";
            InputPorcAprobPract.TextChanged += textBox2_TextChanged_1;
            // 
            // AclaracionFinCorrecPractA
            // 
            AclaracionFinCorrecPractA.AutoSize = true;
            AclaracionFinCorrecPractA.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionFinCorrecPractA.ForeColor = SystemColors.ControlDark;
            AclaracionFinCorrecPractA.Location = new Point(435, 249);
            AclaracionFinCorrecPractA.Name = "AclaracionFinCorrecPractA";
            AclaracionFinCorrecPractA.Size = new Size(168, 25);
            AclaracionFinCorrecPractA.TabIndex = 18;
            AclaracionFinCorrecPractA.Text = "(Uniforme Valor A)";
            // 
            // FinCorrecPractA
            // 
            FinCorrecPractA.AutoSize = true;
            FinCorrecPractA.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            FinCorrecPractA.Location = new Point(44, 249);
            FinCorrecPractA.Name = "FinCorrecPractA";
            FinCorrecPractA.Size = new Size(287, 25);
            FinCorrecPractA.TabIndex = 17;
            FinCorrecPractA.Text = "Fin de Correccion Parte Practica:";
            // 
            // InputFinCorrecPractA
            // 
            InputFinCorrecPractA.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputFinCorrecPractA.Location = new Point(333, 251);
            InputFinCorrecPractA.Name = "InputFinCorrecPractA";
            InputFinCorrecPractA.Size = new Size(100, 27);
            InputFinCorrecPractA.TabIndex = 16;
            InputFinCorrecPractA.Text = "3";
            // 
            // AclaracionFinCorrecPractB
            // 
            AclaracionFinCorrecPractB.AutoSize = true;
            AclaracionFinCorrecPractB.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionFinCorrecPractB.ForeColor = SystemColors.ControlDark;
            AclaracionFinCorrecPractB.Location = new Point(1057, 251);
            AclaracionFinCorrecPractB.Name = "AclaracionFinCorrecPractB";
            AclaracionFinCorrecPractB.Size = new Size(168, 25);
            AclaracionFinCorrecPractB.TabIndex = 21;
            AclaracionFinCorrecPractB.Text = "(Uniforme Valor B)";
            // 
            // FinCorrecPractB
            // 
            FinCorrecPractB.AutoSize = true;
            FinCorrecPractB.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            FinCorrecPractB.Location = new Point(666, 251);
            FinCorrecPractB.Name = "FinCorrecPractB";
            FinCorrecPractB.Size = new Size(287, 25);
            FinCorrecPractB.TabIndex = 20;
            FinCorrecPractB.Text = "Fin de Correccion Parte Practica:";
            // 
            // InputFinCorrecPractB
            // 
            InputFinCorrecPractB.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputFinCorrecPractB.Location = new Point(955, 253);
            InputFinCorrecPractB.Name = "InputFinCorrecPractB";
            InputFinCorrecPractB.Size = new Size(100, 27);
            InputFinCorrecPractB.TabIndex = 19;
            InputFinCorrecPractB.Text = "7";
            // 
            // btnIniciarSimulacion
            // 
            btnIniciarSimulacion.BackColor = SystemColors.Highlight;
            btnIniciarSimulacion.Cursor = Cursors.Hand;
            btnIniciarSimulacion.Font = new Font("Montserrat", 17.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIniciarSimulacion.ForeColor = SystemColors.ButtonHighlight;
            btnIniciarSimulacion.Location = new Point(448, 551);
            btnIniciarSimulacion.Name = "btnIniciarSimulacion";
            btnIniciarSimulacion.Size = new Size(400, 100);
            btnIniciarSimulacion.TabIndex = 22;
            btnIniciarSimulacion.Text = "INICIAR SIMULACION";
            btnIniciarSimulacion.UseVisualStyleBackColor = false;
            btnIniciarSimulacion.Click += btnIniciarSimulacion_Click;
            // 
            // AclaracionHoraTerminarPract
            // 
            AclaracionHoraTerminarPract.AutoSize = true;
            AclaracionHoraTerminarPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionHoraTerminarPract.ForeColor = SystemColors.ControlDark;
            AclaracionHoraTerminarPract.Location = new Point(609, 375);
            AclaracionHoraTerminarPract.Name = "AclaracionHoraTerminarPract";
            AclaracionHoraTerminarPract.Size = new Size(91, 25);
            AclaracionHoraTerminarPract.TabIndex = 25;
            AclaracionHoraTerminarPract.Text = "(Minutos)";
           
            // 
            // HoraTerminarPract
            // 
            HoraTerminarPract.AutoSize = true;
            HoraTerminarPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            HoraTerminarPract.Location = new Point(44, 377);
            HoraTerminarPract.Name = "HoraTerminarPract";
            HoraTerminarPract.Size = new Size(443, 25);
            HoraTerminarPract.TabIndex = 24;
            HoraTerminarPract.Text = "Hora en la que Comienzan a Terminar los Practicos:";
            HoraTerminarPract.Click += label2_Click_1;
            // 
            // InputHoraTerminarPract
            // 
            InputHoraTerminarPract.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputHoraTerminarPract.Location = new Point(497, 375);
            InputHoraTerminarPract.Name = "InputHoraTerminarPract";
            InputHoraTerminarPract.Size = new Size(100, 27);
            InputHoraTerminarPract.TabIndex = 23;
            InputHoraTerminarPract.Text = "90";
      
            // 
            // AclaracionHoraTerminarExamen
            // 
            AclaracionHoraTerminarExamen.AutoSize = true;
            AclaracionHoraTerminarExamen.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionHoraTerminarExamen.ForeColor = SystemColors.ControlDark;
            AclaracionHoraTerminarExamen.Location = new Point(478, 420);
            AclaracionHoraTerminarExamen.Name = "AclaracionHoraTerminarExamen";
            AclaracionHoraTerminarExamen.Size = new Size(91, 25);
            AclaracionHoraTerminarExamen.TabIndex = 28;
            AclaracionHoraTerminarExamen.Text = "(Minutos)";
            // 
            // HoraTerminarExamen
            // 
            HoraTerminarExamen.AutoSize = true;
            HoraTerminarExamen.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            HoraTerminarExamen.Location = new Point(44, 423);
            HoraTerminarExamen.Name = "HoraTerminarExamen";
            HoraTerminarExamen.Size = new Size(302, 25);
            HoraTerminarExamen.TabIndex = 27;
            HoraTerminarExamen.Text = "Hora en la que Termina el Examen";
            HoraTerminarExamen.Click += label4_Click;
            // 
            // InputHoraTerminarExamen
            // 
            InputHoraTerminarExamen.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputHoraTerminarExamen.Location = new Point(366, 420);
            InputHoraTerminarExamen.Name = "InputHoraTerminarExamen";
            InputHoraTerminarExamen.Size = new Size(100, 27);
            InputHoraTerminarExamen.TabIndex = 26;
            InputHoraTerminarExamen.Text = "120";
            // 
            // SIMULACION
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 738);
            Controls.Add(AclaracionHoraTerminarExamen);
            Controls.Add(HoraTerminarExamen);
            Controls.Add(InputHoraTerminarExamen);
            Controls.Add(AclaracionHoraTerminarPract);
            Controls.Add(HoraTerminarPract);
            Controls.Add(InputHoraTerminarPract);
            Controls.Add(btnIniciarSimulacion);
            Controls.Add(AclaracionFinCorrecPractB);
            Controls.Add(FinCorrecPractB);
            Controls.Add(InputFinCorrecPractB);
            Controls.Add(AclaracionFinCorrecPractA);
            Controls.Add(FinCorrecPractA);
            Controls.Add(InputFinCorrecPractA);
            Controls.Add(AclaracionAprobTeo);
            Controls.Add(AclaracionAprobPract);
            Controls.Add(PorcAprobTeo);
            Controls.Add(InputPorcAprobTeo);
            Controls.Add(PorcAprobPract);
            Controls.Add(InputPorcAprobPract);
            Controls.Add(AclaracionFinCorrecTeo);
            Controls.Add(AclaracionFinPract);
            Controls.Add(AclaracionCantAlumnos);
            Controls.Add(FinCorrecTeo);
            Controls.Add(InputFinCorrecTeo);
            Controls.Add(FinPract);
            Controls.Add(InputFinPract);
            Controls.Add(CantAlumnos);
            Controls.Add(InputCantAlumnos);
            Controls.Add(titulo);
            Name = "SIMULACION";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titulo;
        private TextBox InputCantAlumnos;
        private Label CantAlumnos;
        private Label FinPract;
        private TextBox InputFinPract;
        private Label FinCorrecTeo;
        private TextBox InputFinCorrecTeo;
        private Label AclaracionCantAlumnos;
        private Label AclaracionFinPract;
        private Label AclaracionFinCorrecTeo;
        private Label AclaracionAprobTeo;
        private Label AclaracionAprobPract;
        private Label PorcAprobTeo;
        private TextBox InputPorcAprobTeo;
        private Label PorcAprobPract;
        private TextBox InputPorcAprobPract;
        private Label AclaracionFinCorrecPractA;
        private Label FinCorrecPractA;
        private TextBox InputFinCorrecPractA;
        private Label AclaracionFinCorrecPractB;
        private Label FinCorrecPractB;
        private TextBox InputFinCorrecPractB;
        private Button btnIniciarSimulacion;
        private Label AclaracionHoraTerminarPract;
        private Label HoraTerminarPract;
        private TextBox InputHoraTerminarPract;
        private Label AclaracionHoraTerminarExamen;
        private Label HoraTerminarExamen;
        private TextBox InputHoraTerminarExamen;
    }
}
