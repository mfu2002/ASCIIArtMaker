using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCIIArtMaker
{
    public partial class frmASCII : Form
    {
        public frmASCII()
        {
            InitializeComponent();
        }

        Image SourceImage = null;

        private void btnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SourceImage = Image.FromFile(openFileDialog.FileName);
                getBWImage();
            }


        }


        private void getBWImage()
        {
            Image tempImage = (Image)SourceImage.Clone();
            using (Graphics gr = Graphics.FromImage(tempImage)) // SourceImage is a Bitmap object
            {
                var gray_matrix = new float[][] {
                        new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                        new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                        new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                        new float[] { 0,      0,      0,      1, 0 },
                        new float[] { 0,      0,      0,      0, 1 }
                    };

                var ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                ia.SetThreshold((float)sldTolerance.Value/1000); // Change this threshold as needed
                var rc = new Rectangle(0, 0, tempImage.Width, tempImage.Height);
                gr.DrawImage(tempImage, rc, 0, 0, tempImage.Width, tempImage.Height, GraphicsUnit.Pixel, ia);
                picPicture.Image = tempImage;
            }
        }

        private void btnASCII_Click(object sender, EventArgs e)
        {
            Bitmap BWBitmap = new Bitmap(picPicture.Image);
            StringBuilder ASCIIString = new StringBuilder();

            for (int y = 0; y < BWBitmap.Height; y++)
            {
                for (int x = 0; x < BWBitmap.Width; x++)
                {
                    Color test = BWBitmap.GetPixel(x, y);
                    if (BWBitmap.GetPixel(x, y).ToArgb() == Color.White.ToArgb())
                    {
                        ASCIIString.Append("  ");
                    }
                    else
                    {
                        ASCIIString.Append("00");
                    }
                }
                ASCIIString.Append("\n");
            }

            rtbASCII.Text = ASCIIString.ToString();
        }

        private void sldTolerance_Scroll(object sender, EventArgs e)
        {
            getBWImage();
            // getBWImage();
        }

        private void sldTolerance_ValueChanged(object sender, EventArgs e)
        {
            getBWImage();
        }
    }
}