namespace ClienteSoap
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
            dtInicio = new DateTimePicker();
            dtFim = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            btnLucro = new Button();
            btnPrejuizo = new Button();
            btnMaior = new Button();
            txtResultado = new TextBox();
            txtCodigoPeca = new TextBox();
            btnDetalhes = new Button();
            SuspendLayout();
            // 
            // dtInicio
            // 
            dtInicio.Location = new Point(282, 51);
            dtInicio.Name = "dtInicio";
            dtInicio.Size = new Size(250, 27);
            dtInicio.TabIndex = 1;
            // 
            // dtFim
            // 
            dtFim.Location = new Point(282, 105);
            dtFim.Name = "dtFim";
            dtFim.Size = new Size(250, 27);
            dtFim.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 60);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 3;
            label1.Text = "Data de Início";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 110);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 4;
            label2.Text = "Data de Fim";
            // 
            // btnLucro
            // 
            btnLucro.Location = new Point(56, 210);
            btnLucro.Name = "btnLucro";
            btnLucro.Size = new Size(119, 50);
            btnLucro.TabIndex = 5;
            btnLucro.Text = "Lucro Total ";
            btnLucro.UseVisualStyleBackColor = true;
            // 
            // btnPrejuizo
            // 
            btnPrejuizo.Location = new Point(56, 278);
            btnPrejuizo.Name = "btnPrejuizo";
            btnPrejuizo.Size = new Size(119, 54);
            btnPrejuizo.TabIndex = 6;
            btnPrejuizo.Text = "Prejuizo Total por Peça";
            btnPrejuizo.UseVisualStyleBackColor = true;
            // 
            // btnMaior
            // 
            btnMaior.Location = new Point(56, 356);
            btnMaior.Name = "btnMaior";
            btnMaior.Size = new Size(119, 57);
            btnMaior.TabIndex = 7;
            btnMaior.Text = "Peça com maior Prejuízo";
            btnMaior.UseVisualStyleBackColor = true;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(245, 267);
            txtResultado.Multiline = true;
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.Size = new Size(151, 78);
            txtResultado.TabIndex = 8;
            //txtResultado.TextChanged += txtResultado_TextChanged;
            // 
            // txtCodigoPeca
            // 
            txtCodigoPeca.Location = new Point(570, 210);
            txtCodigoPeca.Name = "txtCodigoPeca";
            txtCodigoPeca.Size = new Size(159, 27);
            txtCodigoPeca.TabIndex = 9;
            // 
            // btnDetalhes
            // 
            btnDetalhes.Location = new Point(570, 267);
            btnDetalhes.Name = "btnDetalhes";
            btnDetalhes.Size = new Size(159, 65);
            btnDetalhes.TabIndex = 10;
            btnDetalhes.Text = "Detalhes da Peça ";
            btnDetalhes.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDetalhes);
            Controls.Add(txtCodigoPeca);
            Controls.Add(txtResultado);
            Controls.Add(btnMaior);
            Controls.Add(btnPrejuizo);
            Controls.Add(btnLucro);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtFim);
            Controls.Add(dtInicio);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dtInicio;
        private DateTimePicker dtFim;
        private Label label1;
        private Label label2;
        private Button btnLucro;
        private Button btnPrejuizo;
        private Button btnMaior;
        private TextBox txtResultado;
        private TextBox txtCodigoPeca;
        private Button btnDetalhes;
    }
}
