namespace TravelVisualMan {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.StartBtn = new System.Windows.Forms.Button();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.Algorithm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Initial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InitialTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Improved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImprovedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(12, 12);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Algorithm,
            this.Initial,
            this.InitialTime,
            this.Improved,
            this.ImprovedTime});
            this.DataGridView.Location = new System.Drawing.Point(13, 53);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(544, 221);
            this.DataGridView.TabIndex = 1;
            this.DataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick);
            // 
            // Algorithm
            // 
            this.Algorithm.HeaderText = "Initial Algorithm";
            this.Algorithm.Name = "Algorithm";
            // 
            // Initial
            // 
            this.Initial.HeaderText = "Initial Solution";
            this.Initial.Name = "Initial";
            this.Initial.ReadOnly = true;
            // 
            // InitialTime
            // 
            this.InitialTime.HeaderText = "Initial Time";
            this.InitialTime.Name = "InitialTime";
            this.InitialTime.ReadOnly = true;
            // 
            // Improved
            // 
            this.Improved.HeaderText = "Improved Solution";
            this.Improved.Name = "Improved";
            this.Improved.ReadOnly = true;
            // 
            // ImprovedTime
            // 
            this.ImprovedTime.HeaderText = "Improved Time";
            this.ImprovedTime.Name = "ImprovedTime";
            this.ImprovedTime.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 286);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.StartBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Algorithm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Initial;
        private System.Windows.Forms.DataGridViewTextBoxColumn InitialTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Improved;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImprovedTime;
    }
}

