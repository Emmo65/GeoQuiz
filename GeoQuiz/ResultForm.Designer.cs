namespace GeoQuiz
{
    partial class ResultForm
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
            lblPoints = new Label();
            btnNewQuiz = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // lblPoints
            // 
            lblPoints.AutoSize = true;
            lblPoints.Location = new Point(117, 53);
            lblPoints.Name = "lblPoints";
            lblPoints.Size = new Size(54, 15);
            lblPoints.TabIndex = 0;
            lblPoints.Text = "Punkze 0";
            // 
            // btnNewQuiz
            // 
            btnNewQuiz.Location = new Point(86, 213);
            btnNewQuiz.Name = "btnNewQuiz";
            btnNewQuiz.Size = new Size(138, 37);
            btnNewQuiz.TabIndex = 1;
            btnNewQuiz.Text = "Neues Quiz";
            btnNewQuiz.UseVisualStyleBackColor = true;
            btnNewQuiz.Click += btnNewQuiz_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(333, 213);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(138, 37);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnLogout);
            Controls.Add(btnNewQuiz);
            Controls.Add(lblPoints);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "ResultForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GeoQuiz – Ergebnis";
            Load += ResultForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPoints;
        private Button btnNewQuiz;
        private Button btnLogout;
    }
}