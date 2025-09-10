namespace Ejercicio27
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
            llegadaReloj = new Label();
            inputLlegadaReloj = new TextBox();
            AclaracionllegadaReloj = new Label();
            AclaracionAprobReloj = new Label();
            PorcAprobControl = new Label();
            InputPorcAprobReloj = new TextBox();
            AclaracionFinControlRelojMedia = new Label();
            FinControlRelojMedia = new Label();
            InputFinControlRelojMedia = new TextBox();
            AclaracionFinControlRelojDE = new Label();
            FinControlRelojDE = new Label();
            InputFinControlRelojDE = new TextBox();
            btnIniciarSimulacion = new Button();
            AclaracionMomentoMostrarSim = new Label();
            MomentoMostrarSim = new Label();
            InputMomentoMostrarSim = new TextBox();
            AclaracionCantIterMostrar = new Label();
            CantIterMostrar = new Label();
            InputCantIterMostrar = new TextBox();
            AclaracionCantIteracionesRealizar = new Label();
            CantIteracionesRealizar = new Label();
            InputCantIteracionesRealizar = new TextBox();
            SuspendLayout();
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Font = new Font("Montserrat", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titulo.Location = new Point(431, 9);
            titulo.Name = "titulo";
            titulo.Size = new Size(422, 100);
            titulo.TabIndex = 0;
            titulo.Text = "Ejercicio 27";
            titulo.Click += label1_Click;
            // 
            // llegadaReloj
            // 
            llegadaReloj.AutoSize = true;
            llegadaReloj.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            llegadaReloj.Location = new Point(35, 141);
            llegadaReloj.Name = "llegadaReloj";
            llegadaReloj.Size = new Size(130, 25);
            llegadaReloj.TabIndex = 4;
            llegadaReloj.Text = "Llegada Reloj:";
            // 
            // inputLlegadaReloj
            // 
            inputLlegadaReloj.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            inputLlegadaReloj.Location = new Point(171, 138);
            inputLlegadaReloj.Name = "inputLlegadaReloj";
            inputLlegadaReloj.Size = new Size(100, 27);
            inputLlegadaReloj.TabIndex = 3;
            inputLlegadaReloj.Text = "0.6";
            inputLlegadaReloj.TextChanged += textBox2_TextChanged;
            // 
            // AclaracionllegadaReloj
            // 
            AclaracionllegadaReloj.AutoSize = true;
            AclaracionllegadaReloj.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionllegadaReloj.ForeColor = SystemColors.ControlDark;
            AclaracionllegadaReloj.Location = new Point(277, 143);
            AclaracionllegadaReloj.Name = "AclaracionllegadaReloj";
            AclaracionllegadaReloj.Size = new Size(183, 25);
            AclaracionllegadaReloj.TabIndex = 8;
            AclaracionllegadaReloj.Text = "(Exponencial Media)";
            AclaracionllegadaReloj.Click += AclaracionFinPract_Click;
            // 
            // AclaracionAprobReloj
            // 
            AclaracionAprobReloj.AutoSize = true;
            AclaracionAprobReloj.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionAprobReloj.ForeColor = SystemColors.ControlDark;
            AclaracionAprobReloj.Location = new Point(474, 236);
            AclaracionAprobReloj.Name = "AclaracionAprobReloj";
            AclaracionAprobReloj.Size = new Size(115, 25);
            AclaracionAprobReloj.TabIndex = 14;
            AclaracionAprobReloj.Text = "(Porcentaje)";
            AclaracionAprobReloj.Click += label3_Click;
            // 
            // PorcAprobControl
            // 
            PorcAprobControl.AutoSize = true;
            PorcAprobControl.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            PorcAprobControl.Location = new Point(35, 238);
            PorcAprobControl.Name = "PorcAprobControl";
            PorcAprobControl.Size = new Size(327, 25);
            PorcAprobControl.TabIndex = 11;
            PorcAprobControl.Text = "Porcentaje de Aprobacion de Control:";
            // 
            // InputPorcAprobReloj
            // 
            InputPorcAprobReloj.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputPorcAprobReloj.Location = new Point(368, 235);
            InputPorcAprobReloj.Name = "InputPorcAprobReloj";
            InputPorcAprobReloj.Size = new Size(100, 27);
            InputPorcAprobReloj.TabIndex = 10;
            InputPorcAprobReloj.Text = "50";
            InputPorcAprobReloj.TextChanged += textBox2_TextChanged_1;
            // 
            // AclaracionFinControlRelojMedia
            // 
            AclaracionFinControlRelojMedia.AutoSize = true;
            AclaracionFinControlRelojMedia.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionFinControlRelojMedia.ForeColor = SystemColors.ControlDark;
            AclaracionFinControlRelojMedia.Location = new Point(357, 186);
            AclaracionFinControlRelojMedia.Name = "AclaracionFinControlRelojMedia";
            AclaracionFinControlRelojMedia.Size = new Size(142, 25);
            AclaracionFinControlRelojMedia.TabIndex = 18;
            AclaracionFinControlRelojMedia.Text = "(Normal Media)";
            AclaracionFinControlRelojMedia.Click += AclaracionFinCorrecPractA_Click;
            // 
            // FinControlRelojMedia
            // 
            FinControlRelojMedia.AutoSize = true;
            FinControlRelojMedia.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            FinControlRelojMedia.Location = new Point(35, 189);
            FinControlRelojMedia.Name = "FinControlRelojMedia";
            FinControlRelojMedia.Size = new Size(208, 25);
            FinControlRelojMedia.TabIndex = 17;
            FinControlRelojMedia.Text = "Fin de Control de Reloj:";
            // 
            // InputFinControlRelojMedia
            // 
            InputFinControlRelojMedia.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputFinControlRelojMedia.Location = new Point(249, 186);
            InputFinControlRelojMedia.Name = "InputFinControlRelojMedia";
            InputFinControlRelojMedia.Size = new Size(100, 27);
            InputFinControlRelojMedia.TabIndex = 16;
            InputFinControlRelojMedia.Text = "4.8";
            // 
            // AclaracionFinControlRelojDE
            // 
            AclaracionFinControlRelojDE.AutoSize = true;
            AclaracionFinControlRelojDE.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionFinControlRelojDE.ForeColor = SystemColors.ControlDark;
            AclaracionFinControlRelojDE.Location = new Point(929, 186);
            AclaracionFinControlRelojDE.Name = "AclaracionFinControlRelojDE";
            AclaracionFinControlRelojDE.Size = new Size(212, 25);
            AclaracionFinControlRelojDE.TabIndex = 21;
            AclaracionFinControlRelojDE.Text = "(Normal Desv Estandar)";
            // 
            // FinControlRelojDE
            // 
            FinControlRelojDE.AutoSize = true;
            FinControlRelojDE.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            FinControlRelojDE.Location = new Point(609, 189);
            FinControlRelojDE.Name = "FinControlRelojDE";
            FinControlRelojDE.Size = new Size(208, 25);
            FinControlRelojDE.TabIndex = 20;
            FinControlRelojDE.Text = "Fin de Control de Reloj:";
            // 
            // InputFinControlRelojDE
            // 
            InputFinControlRelojDE.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputFinControlRelojDE.Location = new Point(823, 189);
            InputFinControlRelojDE.Name = "InputFinControlRelojDE";
            InputFinControlRelojDE.Size = new Size(100, 27);
            InputFinControlRelojDE.TabIndex = 19;
            InputFinControlRelojDE.Text = "0.6";
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
            // AclaracionMomentoMostrarSim
            // 
            AclaracionMomentoMostrarSim.AutoSize = true;
            AclaracionMomentoMostrarSim.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionMomentoMostrarSim.ForeColor = SystemColors.ControlDark;
            AclaracionMomentoMostrarSim.Location = new Point(629, 320);
            AclaracionMomentoMostrarSim.Name = "AclaracionMomentoMostrarSim";
            AclaracionMomentoMostrarSim.Size = new Size(91, 25);
            AclaracionMomentoMostrarSim.TabIndex = 25;
            AclaracionMomentoMostrarSim.Text = "(Iteracion)";
            // 
            // MomentoMostrarSim
            // 
            MomentoMostrarSim.AutoSize = true;
            MomentoMostrarSim.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            MomentoMostrarSim.Location = new Point(35, 320);
            MomentoMostrarSim.Name = "MomentoMostrarSim";
            MomentoMostrarSim.Size = new Size(486, 25);
            MomentoMostrarSim.TabIndex = 24;
            MomentoMostrarSim.Text = "Momento en el que comienza a mostrarse la Simulacion:";
            MomentoMostrarSim.Click += label2_Click_1;
            // 
            // InputMomentoMostrarSim
            // 
            InputMomentoMostrarSim.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputMomentoMostrarSim.Location = new Point(523, 317);
            InputMomentoMostrarSim.Name = "InputMomentoMostrarSim";
            InputMomentoMostrarSim.Size = new Size(100, 27);
            InputMomentoMostrarSim.TabIndex = 23;
            InputMomentoMostrarSim.Text = "0";
            // 
            // AclaracionCantIteracionesRealizar
            // 
            AclaracionCantIteracionesRealizar.AutoSize = true;
            AclaracionCantIteracionesRealizar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            AclaracionCantIteracionesRealizar.ForeColor = SystemColors.ControlDark;
            AclaracionCantIteracionesRealizar.Location = new Point(469, 277);
            AclaracionCantIteracionesRealizar.Name = "AclaracionCantIteracionesRealizar";
            AclaracionCantIteracionesRealizar.Size = new Size(101, 25);
            AclaracionCantIteracionesRealizar.TabIndex = 31;
            AclaracionCantIteracionesRealizar.Text = "(Cantidad)";
         
            // 
            // CantIteracionesRealizar
            // 
            CantIteracionesRealizar.AutoSize = true;
            CantIteracionesRealizar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            CantIteracionesRealizar.Location = new Point(35, 280);
            CantIteracionesRealizar.Name = "CantIteracionesRealizar";
            CantIteracionesRealizar.Size = new Size(303, 25);
            CantIteracionesRealizar.TabIndex = 30;
            CantIteracionesRealizar.Text = "Cantidad de Iteraciones a Realizar:";
            
            // 
            // InputCantIteracionesRealizar
            // 
            InputCantIteracionesRealizar.Font = new Font("Montserrat", 12F, FontStyle.Bold);
            InputCantIteracionesRealizar.Location = new Point(357, 277);
            InputCantIteracionesRealizar.Name = "InputCantIteracionesRealizar";
            InputCantIteracionesRealizar.Size = new Size(100, 27);
            InputCantIteracionesRealizar.TabIndex = 29;
            InputCantIteracionesRealizar.Text = "100000";
            InputCantIteracionesRealizar.TextChanged += textBox1_TextChanged_1;
            // 
            // SIMULACION
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 738);
            Controls.Add(AclaracionCantIteracionesRealizar);
            Controls.Add(CantIteracionesRealizar);
            Controls.Add(InputCantIteracionesRealizar);
            Controls.Add(AclaracionCantIterMostrar);
            Controls.Add(CantIterMostrar);
            Controls.Add(InputCantIterMostrar);
            Controls.Add(AclaracionMomentoMostrarSim);
            Controls.Add(MomentoMostrarSim);
            Controls.Add(InputMomentoMostrarSim);
            Controls.Add(btnIniciarSimulacion);
            Controls.Add(AclaracionFinControlRelojDE);
            Controls.Add(FinControlRelojDE);
            Controls.Add(InputFinControlRelojDE);
            Controls.Add(AclaracionFinControlRelojMedia);
            Controls.Add(FinControlRelojMedia);
            Controls.Add(InputFinControlRelojMedia);
            Controls.Add(AclaracionAprobReloj);
            Controls.Add(PorcAprobControl);
            Controls.Add(InputPorcAprobReloj);
            Controls.Add(AclaracionllegadaReloj);
            Controls.Add(llegadaReloj);
            Controls.Add(inputLlegadaReloj);
            Controls.Add(titulo);
            Name = "SIMULACION";
            Text = "Simulacion";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titulo;
        private Label llegadaReloj;
        private TextBox inputLlegadaReloj;
        private Label AclaracionllegadaReloj;
        private Label AclaracionAprobReloj;
        private Label PorcAprobControl;
        private TextBox InputPorcAprobReloj;
        private Label AclaracionFinControlRelojMedia;
        private Label FinControlRelojMedia;
        private TextBox InputFinControlRelojMedia;
        private Label AclaracionFinControlRelojDE;
        private Label FinControlRelojDE;
        private TextBox InputFinControlRelojDE;
        private Button btnIniciarSimulacion;
        private Label AclaracionMomentoMostrarSim;
        private Label MomentoMostrarSim;
        private TextBox InputMomentoMostrarSim;
        private Label AclaracionCantIterMostrar;
        private Label CantIterMostrar;
        private TextBox InputCantIterMostrar;
        private Label AclaracionCantIteracionesRealizar;
        private Label CantIteracionesRealizar;
        private TextBox InputCantIteracionesRealizar;
    }
}