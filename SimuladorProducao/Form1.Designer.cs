namespace SimuladorProducao
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtData = new TextBox();
            txtHora = new TextBox();
            txtCodigo = new TextBox();
            txtTempo = new TextBox();
            txtResultado = new TextBox();
            btnGerar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(132, 45);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "Data";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(131, 95);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Hora";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 146);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 2;
            label3.Text = "Código da Peça";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 198);
            label4.Name = "label4";
            label4.Size = new Size(143, 20);
            label4.TabIndex = 3;
            label4.Text = "Tempo de Produção";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(98, 246);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 4;
            label5.Text = "Resultado";
            // 
            // txtData
            // 
            txtData.Location = new Point(206, 45);
            txtData.Name = "txtData";
            txtData.ReadOnly = true;
            txtData.Size = new Size(125, 27);
            txtData.TabIndex = 5;
            txtData.TextChanged += txtData_TextChanged;
            // 
            // txtHora
            // 
            txtHora.Location = new Point(206, 92);
            txtHora.Name = "txtHora";
            txtHora.ReadOnly = true;
            txtHora.Size = new Size(125, 27);
            txtHora.TabIndex = 6;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(206, 146);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.ReadOnly = true;
            txtCodigo.Size = new Size(125, 27);
            txtCodigo.TabIndex = 7;
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(206, 195);
            txtTempo.Name = "txtTempo";
            txtTempo.ReadOnly = true;
            txtTempo.Size = new Size(125, 27);
            txtTempo.TabIndex = 8;
            txtTempo.TextChanged += textBox4_TextChanged;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(206, 239);
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.Size = new Size(125, 27);
            txtResultado.TabIndex = 9;
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(338, 286);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(127, 43);
            btnGerar.TabIndex = 10;
            btnGerar.Text = "Gerar Dados";
            btnGerar.UseVisualStyleBackColor = true;
            btnGerar.Click += btnGerar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGerar);
            Controls.Add(txtResultado);
            Controls.Add(txtTempo);
            Controls.Add(txtCodigo);
            Controls.Add(txtHora);
            Controls.Add(txtData);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtData;
        private TextBox txtHora;
        private TextBox txtCodigo;
        private TextBox txtTempo;
        private TextBox txtResultado;
        private Button btnGerar;
    }
}
