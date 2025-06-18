namespace AppIntro
{
    partial class frmIntro
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
            btnAcao = new Button();
            label1 = new Label();
            txtPalavra = new TextBox();
            lblPalavra = new Label();
            btnFechar = new Button();
            SuspendLayout();
            // 
            // btnAcao
            // 
            btnAcao.BackColor = Color.ForestGreen;
            btnAcao.Cursor = Cursors.Hand;
            btnAcao.FlatStyle = FlatStyle.Flat;
            btnAcao.Font = new Font("Lexend", 12F, FontStyle.Bold);
            btnAcao.ForeColor = SystemColors.ControlLight;
            btnAcao.Location = new Point(265, 44);
            btnAcao.Name = "btnAcao";
            btnAcao.Size = new Size(88, 37);
            btnAcao.TabIndex = 0;
            btnAcao.Text = "AÇÃO";
            btnAcao.UseVisualStyleBackColor = false;
            btnAcao.Click += btnAcao_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lexend Medium", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(127, 19);
            label1.TabIndex = 1;
            label1.Text = "Digite uma palavra";
            // 
            // txtPalavra
            // 
            txtPalavra.Font = new Font("Lexend", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPalavra.Location = new Point(12, 54);
            txtPalavra.Name = "txtPalavra";
            txtPalavra.PlaceholderText = "Ex: Camundongo";
            txtPalavra.Size = new Size(235, 22);
            txtPalavra.TabIndex = 2;
            // 
            // lblPalavra
            // 
            lblPalavra.AutoSize = true;
            lblPalavra.Font = new Font("Lexend", 14F, FontStyle.Bold);
            lblPalavra.Location = new Point(66, 111);
            lblPalavra.Name = "lblPalavra";
            lblPalavra.Size = new Size(0, 30);
            lblPalavra.TabIndex = 4;
            // 
            // btnFechar
            // 
            btnFechar.BackColor = Color.Firebrick;
            btnFechar.Cursor = Cursors.Hand;
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.Font = new Font("Lexend", 12F, FontStyle.Bold);
            btnFechar.ForeColor = SystemColors.ControlLight;
            btnFechar.Location = new Point(265, 110);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(88, 35);
            btnFechar.TabIndex = 3;
            btnFechar.Text = "FECHAR";
            btnFechar.UseVisualStyleBackColor = false;
            btnFechar.Click += btnFechar_Click;
            // 
            // frmIntro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(420, 236);
            Controls.Add(lblPalavra);
            Controls.Add(btnFechar);
            Controls.Add(txtPalavra);
            Controls.Add(label1);
            Controls.Add(btnAcao);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmIntro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Introdução a Forms";
            Load += frmIntro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAcao;
        private Label label1;
        private TextBox txtPalavra;
        private Label lblPalavra;
        private Button btnFechar;
    }
}
