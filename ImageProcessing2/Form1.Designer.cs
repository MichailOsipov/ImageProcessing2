namespace ImageProcessing2
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
			this.buttonLoadImage = new System.Windows.Forms.Button();
			this.customImagePictureBox = new System.Windows.Forms.PictureBox();
			this.originalImagePictureBox = new System.Windows.Forms.PictureBox();
			this.buttonSobelOperator = new System.Windows.Forms.Button();
			this.buttonLaplasOperator = new System.Windows.Forms.Button();
			this.buttonReset = new System.Windows.Forms.Button();
			this.buttonScaleImage = new System.Windows.Forms.Button();
			this.textBoxScalability = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.customImagePictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.originalImagePictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonLoadImage
			// 
			this.buttonLoadImage.Location = new System.Drawing.Point(12, 12);
			this.buttonLoadImage.Name = "buttonLoadImage";
			this.buttonLoadImage.Size = new System.Drawing.Size(120, 23);
			this.buttonLoadImage.TabIndex = 1;
			this.buttonLoadImage.Text = "Load Image";
			this.buttonLoadImage.UseVisualStyleBackColor = true;
			this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
			// 
			// customImagePictureBox
			// 
			this.customImagePictureBox.Location = new System.Drawing.Point(272, 12);
			this.customImagePictureBox.Name = "customImagePictureBox";
			this.customImagePictureBox.Size = new System.Drawing.Size(100, 100);
			this.customImagePictureBox.TabIndex = 5;
			this.customImagePictureBox.TabStop = false;
			// 
			// originalImagePictureBox
			// 
			this.originalImagePictureBox.Location = new System.Drawing.Point(166, 12);
			this.originalImagePictureBox.Name = "originalImagePictureBox";
			this.originalImagePictureBox.Size = new System.Drawing.Size(100, 100);
			this.originalImagePictureBox.TabIndex = 4;
			this.originalImagePictureBox.TabStop = false;
			this.originalImagePictureBox.Click += new System.EventHandler(this.originalImagePictureBox_Click);
			// 
			// buttonSobelOperator
			// 
			this.buttonSobelOperator.Location = new System.Drawing.Point(12, 135);
			this.buttonSobelOperator.Name = "buttonSobelOperator";
			this.buttonSobelOperator.Size = new System.Drawing.Size(120, 23);
			this.buttonSobelOperator.TabIndex = 6;
			this.buttonSobelOperator.Text = "Sobel operator";
			this.buttonSobelOperator.UseVisualStyleBackColor = true;
			this.buttonSobelOperator.Click += new System.EventHandler(this.buttonSobelOperator_Click);
			// 
			// buttonLaplasOperator
			// 
			this.buttonLaplasOperator.Location = new System.Drawing.Point(12, 174);
			this.buttonLaplasOperator.Name = "buttonLaplasOperator";
			this.buttonLaplasOperator.Size = new System.Drawing.Size(120, 23);
			this.buttonLaplasOperator.TabIndex = 7;
			this.buttonLaplasOperator.Text = "Laplas operator";
			this.buttonLaplasOperator.UseVisualStyleBackColor = true;
			this.buttonLaplasOperator.Click += new System.EventHandler(this.buttonLaplasOperator_Click);
			// 
			// buttonReset
			// 
			this.buttonReset.Location = new System.Drawing.Point(12, 50);
			this.buttonReset.Name = "buttonReset";
			this.buttonReset.Size = new System.Drawing.Size(120, 23);
			this.buttonReset.TabIndex = 8;
			this.buttonReset.Text = "Reset";
			this.buttonReset.UseVisualStyleBackColor = true;
			this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
			// 
			// buttonScaleImage
			// 
			this.buttonScaleImage.Location = new System.Drawing.Point(12, 212);
			this.buttonScaleImage.Name = "buttonScaleImage";
			this.buttonScaleImage.Size = new System.Drawing.Size(120, 23);
			this.buttonScaleImage.TabIndex = 9;
			this.buttonScaleImage.Text = "Scale Image";
			this.buttonScaleImage.UseVisualStyleBackColor = true;
			this.buttonScaleImage.Click += new System.EventHandler(this.buttonScaleImage_Click);
			// 
			// textBoxScalability
			// 
			this.textBoxScalability.Location = new System.Drawing.Point(12, 252);
			this.textBoxScalability.Name = "textBoxScalability";
			this.textBoxScalability.Size = new System.Drawing.Size(120, 20);
			this.textBoxScalability.TabIndex = 10;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1159, 542);
			this.Controls.Add(this.textBoxScalability);
			this.Controls.Add(this.buttonScaleImage);
			this.Controls.Add(this.buttonReset);
			this.Controls.Add(this.buttonLaplasOperator);
			this.Controls.Add(this.buttonSobelOperator);
			this.Controls.Add(this.customImagePictureBox);
			this.Controls.Add(this.originalImagePictureBox);
			this.Controls.Add(this.buttonLoadImage);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.customImagePictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.originalImagePictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonLoadImage;
		private System.Windows.Forms.PictureBox customImagePictureBox;
		private System.Windows.Forms.PictureBox originalImagePictureBox;
		private System.Windows.Forms.Button buttonSobelOperator;
		private System.Windows.Forms.Button buttonLaplasOperator;
		private System.Windows.Forms.Button buttonReset;
		private System.Windows.Forms.Button buttonScaleImage;
		private System.Windows.Forms.TextBox textBoxScalability;
	}
}

