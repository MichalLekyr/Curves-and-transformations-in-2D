namespace ComputerGraphics2D
{
	partial class FormMatrices
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
			this.buttonRun = new System.Windows.Forms.Button();
			this.richTextBoxText = new System.Windows.Forms.RichTextBox();
			this.buttonClear = new System.Windows.Forms.Button();
			this.drawingPanel = new ComputerGraphics2D.DoubleBufferedPanel();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// buttonRun
			// 
			this.buttonRun.Location = new System.Drawing.Point(611, 468);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(75, 23);
			this.buttonRun.TabIndex = 1;
			this.buttonRun.Text = "Run";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
			// 
			// richTextBoxText
			// 
			this.richTextBoxText.Font = new System.Drawing.Font("Consolas", 8F);
			this.richTextBoxText.Location = new System.Drawing.Point(611, 4);
			this.richTextBoxText.Name = "richTextBoxText";
			this.richTextBoxText.Size = new System.Drawing.Size(454, 458);
			this.richTextBoxText.TabIndex = 2;
			this.richTextBoxText.Text = "";
			// 
			// buttonClear
			// 
			this.buttonClear.Location = new System.Drawing.Point(970, 468);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(95, 23);
			this.buttonClear.TabIndex = 3;
			this.buttonClear.Text = "Clear text box";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
			// 
			// drawingPanel
			// 
			this.drawingPanel.BackColor = System.Drawing.Color.White;
			this.drawingPanel.Location = new System.Drawing.Point(5, 5);
			this.drawingPanel.Name = "drawingPanel";
			this.drawingPanel.Size = new System.Drawing.Size(600, 600);
			this.drawingPanel.TabIndex = 4;
			this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
			this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
			this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
			this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
			// 
			// timer
			// 
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// FormMatrices
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(1070, 610);
			this.Controls.Add(this.drawingPanel);
			this.Controls.Add(this.buttonClear);
			this.Controls.Add(this.richTextBoxText);
			this.Controls.Add(this.buttonRun);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FormMatrices";
			this.Text = "Matrices";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.RichTextBox richTextBoxText;
		private System.Windows.Forms.Button buttonClear;
		private DoubleBufferedPanel drawingPanel;
		private System.Windows.Forms.Timer timer;
	}
}

