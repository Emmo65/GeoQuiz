namespace GeoQuiz
{
    partial class QuizForm
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
            lblProgress = new Label();
            groupBox1 = new GroupBox();
            picFlag = new PictureBox();
            lblPrompt = new Label();
            lblFeedback = new Label();
            btnNext = new Button();
            btnA = new Button();
            btnB = new Button();
            btnC = new Button();
            btnD = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picFlag).BeginInit();
            SuspendLayout();
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProgress.Location = new Point(10, 16);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(86, 21);
            lblProgress.TabIndex = 0;
            lblProgress.Text = "Frage 1/10";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(picFlag);
            groupBox1.Controls.Add(lblPrompt);
            groupBox1.Location = new Point(10, 40);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(560, 135);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // picFlag
            // 
            picFlag.Location = new Point(156, 45);
            picFlag.Margin = new Padding(3, 2, 3, 2);
            picFlag.Name = "picFlag";
            picFlag.Size = new Size(254, 78);
            picFlag.SizeMode = PictureBoxSizeMode.Zoom;
            picFlag.TabIndex = 2;
            picFlag.TabStop = false;
            // 
            // lblPrompt
            // 
            lblPrompt.Dock = DockStyle.Fill;
            lblPrompt.Location = new Point(3, 18);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(554, 115);
            lblPrompt.TabIndex = 0;
            lblPrompt.Text = "Fragetext hier";
            lblPrompt.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblFeedback
            // 
            lblFeedback.AutoSize = true;
            lblFeedback.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFeedback.Location = new Point(13, 301);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(0, 25);
            lblFeedback.TabIndex = 6;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(360, 304);
            btnNext.Margin = new Padding(3, 2, 3, 2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(170, 26);
            btnNext.TabIndex = 7;
            btnNext.Text = "Weiter";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnA
            // 
            btnA.Location = new Point(144, 180);
            btnA.Name = "btnA";
            btnA.Size = new Size(146, 45);
            btnA.TabIndex = 8;
            btnA.Text = "Antwort A";
            btnA.TextImageRelation = TextImageRelation.ImageAboveText;
            btnA.UseVisualStyleBackColor = true;
            btnA.Click += AnswerButton_Click;
            // 
            // btnB
            // 
            btnB.Location = new Point(296, 180);
            btnB.Name = "btnB";
            btnB.Size = new Size(146, 45);
            btnB.TabIndex = 9;
            btnB.Text = "Antwort B";
            btnB.UseVisualStyleBackColor = true;
            btnB.Click += AnswerButton_Click;
            // 
            // btnC
            // 
            btnC.Location = new Point(144, 231);
            btnC.Name = "btnC";
            btnC.Size = new Size(146, 45);
            btnC.TabIndex = 10;
            btnC.Text = "Antwort C";
            btnC.UseVisualStyleBackColor = true;
            btnC.Click += AnswerButton_Click;
            // 
            // btnD
            // 
            btnD.Location = new Point(296, 231);
            btnD.Name = "btnD";
            btnD.Size = new Size(146, 45);
            btnD.TabIndex = 11;
            btnD.Text = "Antwort D";
            btnD.UseVisualStyleBackColor = true;
            btnD.Click += AnswerButton_Click;
            // 
            // QuizForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 340);
            Controls.Add(btnD);
            Controls.Add(btnC);
            Controls.Add(btnB);
            Controls.Add(btnA);
            Controls.Add(btnNext);
            Controls.Add(lblFeedback);
            Controls.Add(groupBox1);
            Controls.Add(lblProgress);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "QuizForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GeoQuiz – Quiz";
            Load += QuizForm_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picFlag).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProgress;
        private GroupBox groupBox1;
        private Label lblPrompt;
        private PictureBox picFlag;
        private Label lblFeedback;
        private Button btnNext;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button btnA;
        private Button btnB;
        private Button btnC;
        private Button btnD;
    }
}