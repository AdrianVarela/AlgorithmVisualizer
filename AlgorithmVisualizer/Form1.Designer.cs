namespace AlgorithmVisualizer
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.chartMain = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.quickSort = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Button();
            this.Stats = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(197, 415);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Bubble Sort";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // chartMain
            // 
            this.chartMain.Location = new System.Drawing.Point(12, 12);
            this.chartMain.Name = "chartMain";
            this.chartMain.Size = new System.Drawing.Size(776, 397);
            this.chartMain.TabIndex = 1;
            this.chartMain.Text = "chart1";
            this.chartMain.Click += new System.EventHandler(this.chartMain_Click);
            // 
            // quickSort
            // 
            this.quickSort.Location = new System.Drawing.Point(322, 415);
            this.quickSort.Name = "quickSort";
            this.quickSort.Size = new System.Drawing.Size(75, 23);
            this.quickSort.TabIndex = 2;
            this.quickSort.Text = "Quick Sort";
            this.quickSort.UseVisualStyleBackColor = true;
            this.quickSort.Click += new System.EventHandler(this.quickSort_Click);
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(65, 415);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(75, 23);
            this.Refresh.TabIndex = 3;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Stats
            // 
            this.Stats.AutoSize = true;
            this.Stats.Location = new System.Drawing.Point(461, 420);
            this.Stats.Name = "Stats";
            this.Stats.Size = new System.Drawing.Size(35, 13);
            this.Stats.TabIndex = 4;
            this.Stats.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Stats);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.quickSort);
            this.Controls.Add(this.chartMain);
            this.Controls.Add(this.buttonOK);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chartMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMain;
        private System.Windows.Forms.Button quickSort;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Label Stats;
    }
}

