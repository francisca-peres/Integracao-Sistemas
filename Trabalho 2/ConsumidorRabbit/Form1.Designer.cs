namespace ConsumidorRabbit
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            btnIniciar = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(50, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(520, 384);
            listBox1.TabIndex = 0;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(659, 364);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(94, 29);
            btnIniciar.TabIndex = 1;
            btnIniciar.Text = "button1";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += new EventHandler(btnIniciar_Click);

            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnIniciar);
            Controls.Add(listBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button btnIniciar;
    }
}