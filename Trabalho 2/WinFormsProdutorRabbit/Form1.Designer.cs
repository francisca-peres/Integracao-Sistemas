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
            txtTipo = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnEnviar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 66);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 4;
            label1.Text = "Código da Peça";
            // 
            // txtCodigoPeca
            // 
            txtCodigoPeca.Location = new Point(223, 62);
            txtCodigoPeca.Name = "txtCodigoPeca";
            txtCodigoPeca.Size = new Size(125, 27);
            txtCodigoPeca.TabIndex = 0;
            // 
            // txtTempo
            // 
            txtTempo.Location = new Point(223, 118);
            txtTempo.Name = "txtTempo";
            txtTempo.Size = new Size(125, 27);
            txtTempo.TabIndex = 1;
            // 
            // txtResultado
            // 
            txtResultado.Location = new Point(223, 177);
            txtResultado.Name = "txtResultado";
            txtResultado.Size = new Size(125, 27);
            txtResultado.TabIndex = 2;
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(223, 242);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(125, 27);
            txtTipo.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 125);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 5;
            label2.Text = "Tempo de Produção";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(75, 184);
            label3.Name = "label3";
            label3.Size = new Size(128, 20);
            label3.TabIndex = 6;
            label3.Text = "Código Resultado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(125, 242);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 7;
            label4.Text = "Tipo";
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(517, 308);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(94, 29);
            btnEnviar.TabIndex = 8;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += new EventHandler(btnEnviar_Click);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEnviar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTipo);
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
        private TextBox txtTipo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnEnviar;
    }
}
