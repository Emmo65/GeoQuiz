namespace GeoQuiz
{
    partial class SetupForm
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
            grpMode = new GroupBox();
            cmbMode = new ComboBox();
            grpRegion = new GroupBox();
            cmbContinent = new ComboBox();
            rdoContinent = new RadioButton();
            rdoWorldwide = new RadioButton();
            btnStart = new Button();
            btnHighscore = new Button();
            btnLogout = new Button();
            grpMode.SuspendLayout();
            grpRegion.SuspendLayout();
            SuspendLayout();
            // 
            // grpMode
            // 
            grpMode.Controls.Add(cmbMode);
            grpMode.Location = new Point(18, 24);
            grpMode.Margin = new Padding(3, 2, 3, 2);
            grpMode.Name = "grpMode";
            grpMode.Padding = new Padding(3, 2, 3, 2);
            grpMode.Size = new Size(480, 74);
            grpMode.TabIndex = 0;
            grpMode.TabStop = false;
            grpMode.Text = "Quiz Modus";
            // 
            // cmbMode
            // 
            cmbMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMode.FormattingEnabled = true;
            cmbMode.Items.AddRange(new object[] { "Flagge → Land", "", "", "Flagge → Hauptstadt", "", "", "Land → Hauptstadt", "", "", "Land → Flagge", "", "", "Hauptstadt → Land", "", "", "Hauptstadt → Flagge" });
            cmbMode.Location = new Point(5, 32);
            cmbMode.Margin = new Padding(3, 2, 3, 2);
            cmbMode.Name = "cmbMode";
            cmbMode.Size = new Size(223, 23);
            cmbMode.TabIndex = 0;
            // 
            // grpRegion
            // 
            grpRegion.Controls.Add(cmbContinent);
            grpRegion.Controls.Add(rdoContinent);
            grpRegion.Controls.Add(rdoWorldwide);
            grpRegion.Location = new Point(18, 110);
            grpRegion.Margin = new Padding(3, 2, 3, 2);
            grpRegion.Name = "grpRegion";
            grpRegion.Padding = new Padding(3, 2, 3, 2);
            grpRegion.Size = new Size(480, 74);
            grpRegion.TabIndex = 1;
            grpRegion.TabStop = false;
            grpRegion.Text = "Quiz Modus";
            // 
            // cmbContinent
            // 
            cmbContinent.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbContinent.Enabled = false;
            cmbContinent.FormattingEnabled = true;
            cmbContinent.Items.AddRange(new object[] { "Europa", "Asien", "Afrika", "Nordamerika", "Südamerika", "Ozeanien" });
            cmbContinent.Location = new Point(146, 39);
            cmbContinent.Margin = new Padding(3, 2, 3, 2);
            cmbContinent.Name = "cmbContinent";
            cmbContinent.Size = new Size(212, 23);
            cmbContinent.TabIndex = 2;
            // 
            // rdoContinent
            // 
            rdoContinent.AutoSize = true;
            rdoContinent.Location = new Point(5, 42);
            rdoContinent.Margin = new Padding(3, 2, 3, 2);
            rdoContinent.Name = "rdoContinent";
            rdoContinent.Size = new Size(77, 19);
            rdoContinent.TabIndex = 1;
            rdoContinent.TabStop = true;
            rdoContinent.Text = "Kontinent";
            rdoContinent.UseVisualStyleBackColor = true;
            rdoContinent.CheckedChanged += rdoContinent_CheckedChanged;
            // 
            // rdoWorldwide
            // 
            rdoWorldwide.AutoSize = true;
            rdoWorldwide.Location = new Point(5, 20);
            rdoWorldwide.Margin = new Padding(3, 2, 3, 2);
            rdoWorldwide.Name = "rdoWorldwide";
            rdoWorldwide.Size = new Size(71, 19);
            rdoWorldwide.TabIndex = 0;
            rdoWorldwide.TabStop = true;
            rdoWorldwide.Text = "Weltweit";
            rdoWorldwide.UseVisualStyleBackColor = true;
            rdoWorldwide.CheckedChanged += rdoWorldwide_CheckedChanged;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(28, 222);
            btnStart.Margin = new Padding(3, 2, 3, 2);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(118, 25);
            btnStart.TabIndex = 2;
            btnStart.Text = "Quiz Starten";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnHighscore
            // 
            btnHighscore.Location = new Point(181, 222);
            btnHighscore.Margin = new Padding(3, 2, 3, 2);
            btnHighscore.Name = "btnHighscore";
            btnHighscore.Size = new Size(118, 25);
            btnHighscore.TabIndex = 3;
            btnHighscore.Text = "Highscore";
            btnHighscore.UseVisualStyleBackColor = true;
            btnHighscore.Click += btnHighscore_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(332, 222);
            btnLogout.Margin = new Padding(3, 2, 3, 2);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(118, 25);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Abmelden";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // SetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 280);
            Controls.Add(btnLogout);
            Controls.Add(btnHighscore);
            Controls.Add(btnStart);
            Controls.Add(grpRegion);
            Controls.Add(grpMode);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "SetupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GeoQuiz – Quiz konfigurieren";
            FormClosed += SetupForm_FormClosed;
            grpMode.ResumeLayout(false);
            grpRegion.ResumeLayout(false);
            grpRegion.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpMode;
        private ComboBox cmbMode;
        private GroupBox grpRegion;
        private RadioButton rdoWorldwide;
        private ComboBox cmbContinent;
        private RadioButton rdoContinent;
        private Button btnStart;
        private Button btnHighscore;
        private Button btnLogout;
    }
}