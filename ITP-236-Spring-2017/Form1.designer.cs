namespace InventoryOopGrader
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
            this.ResultsView = new System.Windows.Forms.DataGridView();
            this.ProjectName = new System.Windows.Forms.Label();
            this.StudentName = new System.Windows.Forms.Label();
            this.GradeSummary = new System.Windows.Forms.Label();
            this.Percentage = new System.Windows.Forms.Label();
            this.TestView = new System.Windows.Forms.DataGridView();
            this.ProgressIndicator = new System.Windows.Forms.ProgressBar();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestView)).BeginInit();
            this.HeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ResultsView
            // 
            this.ResultsView.AllowUserToAddRows = false;
            this.ResultsView.AllowUserToDeleteRows = false;
            this.ResultsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ResultsView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ResultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsView.Location = new System.Drawing.Point(16, 158);
            this.ResultsView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ResultsView.Name = "ResultsView";
            this.ResultsView.ReadOnly = true;
            this.ResultsView.Size = new System.Drawing.Size(1293, 213);
            this.ResultsView.TabIndex = 0;
            this.ResultsView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultsView_CellClick);
            this.ResultsView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.ResultsView_ColumnAdded);
            // 
            // ProjectName
            // 
            this.ProjectName.AutoSize = true;
            this.ProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectName.Location = new System.Drawing.Point(23, 14);
            this.ProjectName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.Size = new System.Drawing.Size(85, 29);
            this.ProjectName.TabIndex = 1;
            this.ProjectName.Text = "label1";
            this.ProjectName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StudentName
            // 
            this.StudentName.AutoSize = true;
            this.StudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentName.Location = new System.Drawing.Point(23, 43);
            this.StudentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StudentName.Name = "StudentName";
            this.StudentName.Size = new System.Drawing.Size(85, 29);
            this.StudentName.TabIndex = 2;
            this.StudentName.Text = "label1";
            this.StudentName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GradeSummary
            // 
            this.GradeSummary.AutoSize = true;
            this.GradeSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradeSummary.Location = new System.Drawing.Point(23, 73);
            this.GradeSummary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GradeSummary.Name = "GradeSummary";
            this.GradeSummary.Size = new System.Drawing.Size(85, 29);
            this.GradeSummary.TabIndex = 3;
            this.GradeSummary.Text = "label1";
            this.GradeSummary.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Percentage
            // 
            this.Percentage.AutoSize = true;
            this.Percentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Percentage.ForeColor = System.Drawing.Color.Blue;
            this.Percentage.Location = new System.Drawing.Point(23, 102);
            this.Percentage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Percentage.Name = "Percentage";
            this.Percentage.Size = new System.Drawing.Size(85, 29);
            this.Percentage.TabIndex = 4;
            this.Percentage.Text = "label1";
            this.Percentage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TestView
            // 
            this.TestView.AllowUserToAddRows = false;
            this.TestView.AllowUserToDeleteRows = false;
            this.TestView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.TestView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TestView.Location = new System.Drawing.Point(17, 379);
            this.TestView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TestView.Name = "TestView";
            this.TestView.ReadOnly = true;
            this.TestView.Size = new System.Drawing.Size(1292, 399);
            this.TestView.TabIndex = 5;
            this.TestView.Visible = false;
            this.TestView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.TestView_ColumnAdded);
            this.TestView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.TestView_DataBindingComplete);
            // 
            // ProgressIndicator
            // 
            this.ProgressIndicator.Location = new System.Drawing.Point(159, 102);
            this.ProgressIndicator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProgressIndicator.Name = "ProgressIndicator";
            this.ProgressIndicator.Size = new System.Drawing.Size(315, 28);
            this.ProgressIndicator.Step = 5;
            this.ProgressIndicator.TabIndex = 6;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.Controls.Add(this.ProjectName);
            this.HeaderPanel.Controls.Add(this.StudentName);
            this.HeaderPanel.Controls.Add(this.ProgressIndicator);
            this.HeaderPanel.Controls.Add(this.GradeSummary);
            this.HeaderPanel.Controls.Add(this.Percentage);
            this.HeaderPanel.Location = new System.Drawing.Point(200, 15);
            this.HeaderPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(673, 135);
            this.HeaderPanel.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 799);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.TestView);
            this.Controls.Add(this.ResultsView);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "ITP-236 OOP Project Grader";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TestView)).EndInit();
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ResultsView;
        private System.Windows.Forms.Label ProjectName;
        private System.Windows.Forms.Label StudentName;
        private System.Windows.Forms.Label GradeSummary;
        private System.Windows.Forms.Label Percentage;
        private System.Windows.Forms.DataGridView TestView;
        private System.Windows.Forms.ProgressBar ProgressIndicator;
        private System.Windows.Forms.Panel HeaderPanel;
    }
}

