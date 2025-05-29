namespace WinFormsProdutorRabbit
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
            Label label1;
            txtCodigoPeca = new TextBox();
            txtTempo = new TextBox();
            txtResultado = new TextBox();
            label2 = new Label();
            label3 = new Label();
            btnEnviar = new Button();
            txtData = new TextBox();
            txtHora = new TextBox();
            label4 = new Label();
            label5 = new Label();
            btnPreencher = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 170);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 4;
            label1.Text = "Código da Peça";
            // 
            // txtCodigoPeca
            // 
            txtCodigoPeca.Location = new Point(223, 163);
            txtCodigoPeca.Name = "txtCodigoPeca";
            txtCodigoPeca.ReadOnly = true;
            txtCodigoPeca.Size = new Size(125, 27);
            txtCodigoPeca.TabIndex = 0;
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(223, 211);
            txtTempo.Name = "txtTempo";
            txtTempo.ReadOnly = true;
            txtTempo.Size = new Size(125, 27);
            txtTempo.TabIndex = 1;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(223, 256);
            txtResultado.Name = "txtResultado";
            txtResultado.ReadOnly = true;
            txtResultado.Size = new Size(125, 27);
            txtResultado.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 218);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 5;
            label2.Text = "Tempo de Produção";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 259);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 6;
            label3.Text = "Código Resultado";
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(517, 308);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(94, 29);
            btnEnviar.TabIndex = 8;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtData
            // 
            txtData.Location = new Point(223, 70);
            txtData.Name = "txtData";
            txtData.ReadOnly = true;
            txtData.Size = new Size(125, 27);
            txtData.TabIndex = 9;
            // 
            // txtHora
            // 
            txtHora.Location = new Point(223, 119);
            txtHora.Name = "txtHora";
            txtHora.ReadOnly = true;
            txtHora.Size = new Size(125, 27);
            txtHora.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(162, 70);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 11;
            label4.Text = "Data";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(153, 126);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 12;
            label5.Text = "Hora";
            // 
            // btnPreencher
            // 
            btnPreencher.Location = new Point(517, 256);
            btnPreencher.Name = "btnPreencher";
            btnPreencher.Size = new Size(94, 29);
            btnPreencher.TabIndex = 13;
            btnPreencher.Text = "Preencher";
            btnPreencher.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPreencher);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtHora);
            Controls.Add(txtData);
            Controls.Add(btnEnviar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtResultado);
            Controls.Add(txtTempo);
            Controls.Add(txtCodigoPeca);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCodigoPeca;
        private TextBox txtTempo;
        private TextBox txtResultado;
        private Label label2;
        private Label label3;
        private Button btnEnviar;
        private TextBox txtData;
        private TextBox txtHora;
        private Label label4;
        private Label label5;
        private Button btnPreencher;
    }
}
