namespace GeoQuiz
{
    partial class HighscoreForm
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
            lblTitle = new Label();
            grpFilter = new GroupBox();
            rdoCurrent = new RadioButton();
            rdoAll = new RadioButton();
            gridHighscores = new DataGridView();
            Platzierung = new DataGridViewTextBoxColumn();
            Spieler = new DataGridViewTextBoxColumn();
            Punkte = new DataGridViewTextBoxColumn();
            Datum = new DataGridViewTextBoxColumn();
            btnRefresh = new Button();
            btnClose = new Button();
            grpFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridHighscores).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(229, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(147, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Highscore";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // grpFilter
            // 
            grpFilter.Controls.Add(rdoCurrent);
            grpFilter.Controls.Add(rdoAll);
            grpFilter.Location = new Point(8, 47);
            grpFilter.Name = "grpFilter";
            grpFilter.Size = new Size(586, 39);
            grpFilter.TabIndex = 1;
            grpFilter.TabStop = false;
            grpFilter.Text = "Anzeige";
            // 
            // rdoCurrent
            // 
            rdoCurrent.AutoSize = true;
            rdoCurrent.Location = new Point(221, 14);
            rdoCurrent.Name = "rdoCurrent";
            rdoCurrent.Size = new Size(131, 19);
            rdoCurrent.TabIndex = 1;
            rdoCurrent.TabStop = true;
            rdoCurrent.Text = "Nur aktueller Spieler";
            rdoCurrent.UseVisualStyleBackColor = true;
            rdoCurrent.CheckedChanged += HighscoreForm_Load;
            // 
            // rdoAll
            // 
            rdoAll.AutoSize = true;
            rdoAll.Location = new Point(66, 14);
            rdoAll.Name = "rdoAll";
            rdoAll.Size = new Size(83, 19);
            rdoAll.TabIndex = 0;
            rdoAll.TabStop = true;
            rdoAll.Text = "Alle Spieler";
            rdoAll.UseVisualStyleBackColor = true;
            rdoAll.CheckedChanged += HighscoreForm_Load;
            // 
            // gridHighscores
            // 
            gridHighscores.AllowUserToAddRows = false;
            gridHighscores.AllowUserToDeleteRows = false;
            gridHighscores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridHighscores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridHighscores.Columns.AddRange(new DataGridViewColumn[] { Platzierung, Spieler, Punkte, Datum });
            gridHighscores.Location = new Point(8, 92);
            gridHighscores.MultiSelect = false;
            gridHighscores.Name = "gridHighscores";
            gridHighscores.ReadOnly = true;
            gridHighscores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridHighscores.Size = new Size(587, 236);
            gridHighscores.TabIndex = 2;
            gridHighscores.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Platzierung
            // 
            Platzierung.HeaderText = "Platzierung";
            Platzierung.Name = "Platzierung";
            Platzierung.ReadOnly = true;
            // 
            // Spieler
            // 
            Spieler.HeaderText = "Spieler";
            Spieler.Name = "Spieler";
            Spieler.ReadOnly = true;
            // 
            // Punkte
            // 
            Punkte.HeaderText = "Punkte";
            Punkte.Name = "Punkte";
            Punkte.ReadOnly = true;
            // 
            // Datum
            // 
            Datum.HeaderText = "Datum";
            Datum.Name = "Datum";
            Datum.ReadOnly = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(8, 338);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(117, 31);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Aktualisieren";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(131, 338);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(117, 31);
            btnClose.TabIndex = 4;
            btnClose.Text = "Schließen";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // HighscoreForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 381);
            Controls.Add(btnClose);
            Controls.Add(btnRefresh);
            Controls.Add(gridHighscores);
            Controls.Add(grpFilter);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "HighscoreForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GeoQuiz – Highscores";
            Load += HighscoreForm_Load;
            grpFilter.ResumeLayout(false);
            grpFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridHighscores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private GroupBox grpFilter;
        private RadioButton rdoAll;
        private RadioButton rdoCurrent;
        private DataGridView gridHighscores;
        private DataGridViewTextBoxColumn Platzierung;
        private DataGridViewTextBoxColumn Spieler;
        private DataGridViewTextBoxColumn Punkte;
        private DataGridViewTextBoxColumn Datum;
        private Button btnRefresh;
        private Button btnClose;
    }
}