using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing2
{
	public partial class Form1 : Form
	{
		private Bitmap image;
		private Bitmap originalImage;
		private Bitmap customImage;
		private Point firstScalePoint;
		private Point secondScalePoint;

		public Form1()
		{
			InitializeComponent();
			this.textBoxScalability.Text = "5";
		}

		private void buttonLoadImage_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Title = "Choose an image";
				dlg.Filter = "Image files | *.bmp;*.jpg;*.png";

				if (dlg.ShowDialog() == DialogResult.OK)
				{
					this.image = new Bitmap(dlg.FileName);
					this.originalImagePictureBox.Size = new Size(this.image.Width, this.image.Height);
					this.originalImagePictureBox.Image = this.image;

					int x = this.originalImagePictureBox.Location.X;
					int y = this.originalImagePictureBox.Location.Y;
					int margin = 10;

					this.originalImage = new Bitmap(this.image);
					this.customImage = new Bitmap(this.image);
					this.customImagePictureBox.Location = new Point(x + this.image.Width + margin, y);
					this.customImagePictureBox.Size = new Size(customImage.Width, customImage.Height);
					this.customImagePictureBox.Image = this.customImage;
				}
			}
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			this.image = new Bitmap(this.originalImage);
			this.originalImagePictureBox.Image = this.image;
			this.customImage = new Bitmap(this.originalImage);
			this.customImagePictureBox.Image = this.customImage;
			this.customImagePictureBox.Size = new Size(customImage.Width, customImage.Height);
		}

		private Color getColorAfterMatrix(Bitmap image, int x, int y, double[,] matrix)
		{
			double r = 0, g = 0, b = 0;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					Color pixel = image.GetPixel(x - 1 + i, y - 1 + j);
					r += pixel.R * matrix[i, j];
					g += pixel.G * matrix[i, j];
					b += pixel.B * matrix[i, j];
				}
			}
			int newR = Math.Max(0, Math.Min((int)r, 255));
			int newG = Math.Max(0, Math.Min((int)g, 255));
			int newB = Math.Max(0, Math.Min((int)b, 255));
			return Color.FromArgb(newR, newG, newB);
		}

		private byte sobelOperator(byte x, byte y)
		{
			return (byte)Math.Sqrt(x * x + y * y);
		}
		private Color getSobelColor(Color x, Color y)
		{
			//int greyPixel = (int)(0.3 * this.sobelOperator(x.R, y.R) + 0.59 * this.sobelOperator(x.G, y.G) + 0.11 * this.sobelOperator(x.B, y.B));
			//int realPixel = Math.Min((int)greyPixel, 255);
			//return Color.FromArgb(realPixel, realPixel, realPixel);
			return Color.FromArgb(
				this.sobelOperator(x.R, y.R),
				this.sobelOperator(x.G, y.G),
				this.sobelOperator(x.B, y.B)
				);
		}
		private void buttonSobelOperator_Click(object sender, EventArgs e)
		{
			double[,] matrixGX = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
			double[,] matrixGY = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };

			Bitmap currImage = new Bitmap(this.customImage);
			for (int i = 1; i < customImage.Width - 1; i++)
			{
				for (int j = 1; j < customImage.Height - 1; j++)
				{
					Color gX = this.getColorAfterMatrix(currImage, i, j, matrixGX);
					Color gY = this.getColorAfterMatrix(currImage, i, j, matrixGY);
					this.customImage.SetPixel(i, j, this.getSobelColor(gX, gY));
				}
			}
			this.customImagePictureBox.Image = this.customImage;
		}

		private void buttonLaplasOperator_Click(object sender, EventArgs e)
		{
			double[,] matrix = { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
			//double[,] matrix = { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } };
			Bitmap currImage = new Bitmap(this.customImage);
			for (int i = 1; i < customImage.Width - 1; i++)
			{
				for (int j = 1; j < customImage.Height - 1; j++)
				{
					this.customImage.SetPixel(i, j, this.getColorAfterMatrix(currImage, i, j, matrix));
				}
			}
			this.customImagePictureBox.Image = this.customImage;
		}

		private void drawScaleSquare()
		{
			this.image = new Bitmap(this.originalImage);
			this.originalImagePictureBox.Image = this.image;
			var graphics = Graphics.FromImage(this.originalImagePictureBox.Image);
			graphics.DrawRectangle(
				new Pen(Color.Red, 2.0F),
				this.firstScalePoint.X,
				this.firstScalePoint.Y,
				this.secondScalePoint.X - this.firstScalePoint.X,
				this.secondScalePoint.Y - this.firstScalePoint.Y
				);
			this.originalImagePictureBox.Refresh();
		}

		private void originalImagePictureBox_Click(object sender, EventArgs e)
		{
			MouseEventArgs clickEvent = (MouseEventArgs)e;
			this.firstScalePoint = this.secondScalePoint;
			this.secondScalePoint = new Point(clickEvent.X, clickEvent.Y);
			if (this.firstScalePoint.IsEmpty || this.secondScalePoint.IsEmpty)
				return;
			if (this.firstScalePoint.X >= this.secondScalePoint.X || this.firstScalePoint.Y >= this.secondScalePoint.Y)
				return;
			this.drawScaleSquare();
		}

		private Point[,] buildMatrix(double xOrig, double yOrig, int width, int height)
		{
			Point[,] matrix = new Point[4,4];

			int x1 = (int)xOrig;
			int y1 = (int)yOrig;

			int x0 = Math.Max(0, x1 - 1);
			int y0 = Math.Max(0, y1 - 1);

			int x2 = Math.Min(x1 + 1, width - 1);
			int y2 = Math.Min(y1 + 1, height - 1);

			int x3 = Math.Min(x2 + 1, width - 1);
			int y3 = Math.Min(y2 + 1, height - 1);

			int[] xCoeffs = { x0, x1, x2, x3 };
			int[] yCoeffs = { y0, y1, y2, y3 };

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					matrix[i, j] = new Point(xCoeffs[i], yCoeffs[j]);
				}
			}
			return matrix;
		}

		private double calculateEquation(int[] xPoints, int[] yPoints, double origCoord)
		{
			double[] coeffs = new double[4];
			for (int i = 0; i < 4; i++)
			{
				double res = 1;

				for (int j = 0; j < 4; j++)
				{
					if (i == j) continue;

					res *= (origCoord - (double)xPoints[j]) / ((double)xPoints[i] - (double)xPoints[j]);
				}
				coeffs[i] = res;
			}

			double equationRes = 0;

			for (int i = 0; i < 4; i++)
			{
				equationRes += coeffs[i] * yPoints[i];
			}

			return equationRes;
		}
	
		private Color calculateScaleColor(Color[] equationColors, int[] equationPoints, double origCoord)
		{
			int[] R = new int[4];
			int[] G = new int[4];
			int[] B = new int[4];
			for (int i = 0; i < 4; i++)
			{
				R[i] = equationColors[i].R;
				G[i] = equationColors[i].G;
				B[i] = equationColors[i].B;
			}
			int RPart = (int)this.calculateEquation(equationPoints, R, origCoord);
			int GPart = (int)this.calculateEquation(equationPoints, G, origCoord);
			int BPart = (int)this.calculateEquation(equationPoints, B, origCoord);
			return Color.FromArgb(
				Math.Max(0, Math.Min((int)RPart, 255)),
				Math.Max(0, Math.Min((int)GPart, 255)),
				Math.Max(0, Math.Min((int)BPart, 255))
				);
		}

		private Color getScaledColor(double xOrig, double yOrig, int width, int height, int xOffset, int yOffset)
		{
			Point[,] matrix = buildMatrix(xOrig, yOrig, width, height);
			Color[] equationColors = new Color[4];
			for (int row = 0; row < 4; row++)
			{
				Color[] tempColors = new Color[4];
				int[] tempPoints = new int[4];
				for (int col = 0; col < 4; col++)
				{
					tempColors[col] = this.originalImage.GetPixel((int)(matrix[col, row].X + xOffset), (int)(matrix[col, row].Y + yOffset));
					tempPoints[col] = matrix[col, row].X;
				}
				equationColors[row] = this.calculateScaleColor(tempColors, tempPoints, xOrig);
			}
			int[] lastTempPoints = new int[4];
			for (int row = 0; row < 4; row++)
			{
				lastTempPoints[row] = matrix[0, row].Y;
			}
			return this.calculateScaleColor(equationColors, lastTempPoints, yOrig);
		}

		private void scaleImage()
		{
			int scalability = Int32.Parse(this.textBoxScalability.Text);
			if (scalability < 1)
			{
				return;
			}
			int x1 = this.firstScalePoint.X;
			int y1 = this.firstScalePoint.Y;
			int x2 = this.secondScalePoint.X;
			int y2 = this.secondScalePoint.Y;

			int scaledImageWidth = (int)((x2 - x1) * scalability);
			int scaledImageHeight = (int)((y2 - y1) * scalability);
			this.customImage = new Bitmap(scaledImageWidth, scaledImageHeight);
			for (int i = 0; i < scaledImageWidth; i++)
			{
				for (int j = 0;  j < scaledImageHeight; j++)
				{
					double xOrig = (double)i / scalability;
					double yOrig = (double)j / scalability;
					Color newColor = this.getScaledColor(xOrig, yOrig, scaledImageWidth, scaledImageHeight, x1, y1);
					this.customImage.SetPixel(i, j, newColor);
				}
			}
			this.customImagePictureBox.Size = new Size(scaledImageWidth, scaledImageHeight);
			this.customImagePictureBox.Image = this.customImage;
		}

		private void buttonScaleImage_Click(object sender, EventArgs e)
		{
			if (this.firstScalePoint.IsEmpty || this.secondScalePoint.IsEmpty)
				return;
			if (this.firstScalePoint.X >= this.secondScalePoint.X || this.firstScalePoint.Y >= this.secondScalePoint.Y)
				return;
			this.scaleImage();
		}
	}
}
