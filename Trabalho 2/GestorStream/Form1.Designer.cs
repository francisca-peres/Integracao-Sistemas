namespace GestorStream
{
    partial class Form1
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
            lblTotalPecas = new Label();
            lblTotalOk = new Label();
            lblTotalFalhas = new Label();
            lblMediaTempo = new Label();
            txtTotalPecas = new TextBox();
            txtTempoMedio = new TextBox();
            txtTotalFalhas = new TextBox();
            txtTotalOK = new TextBox();
            btnIniciar = new Button();
            SuspendLayout();
            // 
            // lblTotalPecas
            // 
            lblTotalPecas.AutoSize = true;
            lblTotalPecas.Location = new Point(117, 71);
            lblTotalPecas.Name = "lblTotalPecas";
            lblTotalPecas.Size = new Size(82, 20);
            lblTotalPecas.TabIndex = 0;
            lblTotalPecas.Text = "Total Peças";
            // 
            // lblTotalOk
            // 
            lblTotalOk.AutoSize = true;
            lblTotalOk.Location = new Point(117, 123);
            lblTotalOk.Name = "lblTotalOk";
            lblTotalOk.Size = new Size(69, 20);
            lblTotalOk.TabIndex = 1;
            lblTotalOk.Text = "Peças OK";
            // 
            // lblTotalFalhas
            // 
            lblTotalFalhas.AutoSize = true;
            lblTotalFalhas.Location = new Point(117, 188);
            lblTotalFalhas.Name = "lblTotalFalhas";
            lblTotalFalhas.Size = new Size(49, 20);
            lblTotalFalhas.TabIndex = 2;
            lblTotalFalhas.Text = "Falhas";
            // 
            // lblMediaTempo
            // 
            lblMediaTempo.AutoSize = true;
            lblMediaTempo.Location = new Point(117, 238);
            lblMediaTempo.Name = "lblMediaTempo";
            lblMediaTempo.Size = new Size(102, 20);
            lblMediaTempo.TabIndex = 3;
            lblMediaTempo.Text = "Tempo Médio";
            // 
            // txtTotalPecas
            // 
            txtTotalPecas.Location = new Point(221, 64);
            txtTotalPecas.Name = "txtTotalPecas";
            txtTotalPecas.ReadOnly = true;
            txtTotalPecas.Size = new Size(125, 27);
            txtTotalPecas.TabIndex = 4;
            // 
            // txtTempoMedio
            // 
            txtTempoMedio.Location = new Point(225, 235);
            txtTempoMedio.Name = "txtTempoMedio";
            txtTempoMedio.ReadOnly = true;
            txtTempoMedio.Size = new Size(125, 27);
            txtTempoMedio.TabIndex = 5;
            // 
            // txtTotalFalhas
            // 
            txtTotalFalhas.Location = new Point(221, 185);
            txtTotalFalhas.Name = "txtTotalFalhas";
            txtTotalFalhas.ReadOnly = true;
            txtTotalFalhas.Size = new Size(125, 27);
            txtTotalFalhas.TabIndex = 6;
            // 
            // txtTotalOK
            // 
            txtTotalOK.Location = new Point(221, 120);
            txtTotalOK.Name = "txtTotalOK";
            txtTotalOK.ReadOnly = true;
            txtTotalOK.Size = new Size(125, 27);
            txtTotalOK.TabIndex = 7;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(328, 331);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(94, 29);
            btnIniciar.TabIndex = 8;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnIniciar);
            Controls.Add(txtTotalOK);
            Controls.Add(txtTotalFalhas);
            Controls.Add(txtTempoMedio);
            Controls.Add(txtTotalPecas);
            Controls.Add(lblMediaTempo);
            Controls.Add(lblTotalFalhas);
            Controls.Add(lblTotalOk);
            Controls.Add(lblTotalPecas);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTotalPecas;
        private Label lblTotalOk;
        private Label lblTotalFalhas;
        private Label lblMediaTempo;
        private TextBox txtTotalPecas;
        private TextBox txtTempoMedio;
        private TextBox txtTotalFalhas;
        private TextBox txtTotalOK;
        private Button btnIniciar;
    }
}
