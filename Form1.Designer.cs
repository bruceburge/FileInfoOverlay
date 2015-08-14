namespace FileInfoOverlay
{
	partial class FileInfoOverlay
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
			this.components = new System.ComponentModel.Container();
			this.tmrPaintCheck = new System.Windows.Forms.Timer(this.components);
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btnMinimize = new System.Windows.Forms.Button();
			this.btnKill = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tmrPaintCheck
			// 
			this.tmrPaintCheck.Enabled = true;
			this.tmrPaintCheck.Interval = 250;
			this.tmrPaintCheck.Tick += new System.EventHandler(this.tmrPaintCheck_Tick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btnMinimize);
			this.splitContainer1.Panel1.Controls.Add(this.btnKill);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Size = new System.Drawing.Size(998, 29);
			this.splitContainer1.SplitterDistance = 160;
			this.splitContainer1.TabIndex = 1;
			// 
			// btnMinimize
			// 
			this.btnMinimize.BackColor = System.Drawing.Color.White;
			this.btnMinimize.Location = new System.Drawing.Point(82, 3);
			this.btnMinimize.Name = "btnMinimize";
			this.btnMinimize.Size = new System.Drawing.Size(75, 23);
			this.btnMinimize.TabIndex = 1;
			this.btnMinimize.Text = "Minimize";
			this.btnMinimize.UseVisualStyleBackColor = false;
			this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
			// 
			// btnKill
			// 
			this.btnKill.BackColor = System.Drawing.Color.White;
			this.btnKill.Location = new System.Drawing.Point(3, 3);
			this.btnKill.Name = "btnKill";
			this.btnKill.Size = new System.Drawing.Size(75, 23);
			this.btnKill.TabIndex = 0;
			this.btnKill.Text = "Kill";
			this.btnKill.UseVisualStyleBackColor = false;
			this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(-1, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Loading...";
			// 
			// FileInfoOverlay
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(998, 29);
			this.Controls.Add(this.splitContainer1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "FileInfoOverlay";
			this.ShowIcon = false;
			this.Text = "File Info Overlay";
			this.TopMost = true;
			this.TransparencyKey = System.Drawing.SystemColors.Control;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer tmrPaintCheck;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMinimize;
    }
}

