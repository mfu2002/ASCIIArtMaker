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
        /// <summary>
        /// Saves the original images to continue performming transformations on it. 
        /// </summary>
        Image SourceImage = null;

        const string blackCharacter = "00";


        /// <summary>
        /// Regular Constructor that initiates the default form components. 
        /// </summary>
        public frmASCII()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Uses a file dialog to select a picture and runs the b&W conversion function. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SourceImage = Image.FromFile(openFileDialog.FileName);
                RefreshImage();
            }


        }

        /// <summary>
        /// Recreates the black and white image and sets it to the preview. 
        /// </summary>
        private void RefreshImage() => picPicture.Image = GetBWImage((Image)SourceImage.Clone(), //copy used to ensure the original image is not altered. 
                                                                     (float)sldTolerance.Value / 1000);
        
        /// <summary>
        /// Converts the image into black and white. 
        /// </summary>
        /// <param name="imageCopy">reference of the image to convert.</param>
        /// <param name="blackAndWhiteThreshold">threshold for the black and white matrix.</param>
        /// <returns>returns imageCopy reference again. </returns>
        private Image GetBWImage(Image imageCopy, float blackAndWhiteThreshold)
        {
            using (Graphics gr = Graphics.FromImage(imageCopy)) // SourceImage is a Bitmap object
            {
                //matrix to convert image to black and white. 
                var gray_matrix = new float[][] {
                        new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                        new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                        new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                        new float[] { 0,      0,      0,      1, 0 },
                        new float[] { 0,      0,      0,      0, 1 }
                    };
                //converts the image to b&w.
                var imageAttribute = new System.Drawing.Imaging.ImageAttributes();
                imageAttribute.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                imageAttribute.SetThreshold(blackAndWhiteThreshold);
                var imageRect = new Rectangle(0, 0, imageCopy.Width, imageCopy.Height);
                gr.DrawImage(imageCopy, imageRect, 0, 0, imageCopy.Width, imageCopy.Height, GraphicsUnit.Pixel, imageAttribute);
                return imageCopy;
            }
        }

        /// <summary>
        /// sets the richTextBox to string representaion of the black and white image. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnASCII_Click(object sender, EventArgs e)=> rtbASCII.Text = GetASCII(picPicture.Image);
        

        /// <summary>
        /// converts image into text.
        /// </summary>
        /// <param name="artImage">Image to convert from. Presumes the image is in B&W.</param>
        /// <returns>string representation of the image.</returns>
        private string GetASCII(Image artImage)
        {
            Bitmap BWBitmap = new Bitmap(artImage);
            StringBuilder ASCIIString = new StringBuilder();

            //loops through each pixel and inserts blackCharacter for black and empty space for white. 
            for (int y = 0; y < BWBitmap.Height; y++)
            {
                for (int x = 0; x < BWBitmap.Width; x++)
                {
                    if (BWBitmap.GetPixel(x, y).ToArgb() == Color.White.ToArgb())
                    {
                        ASCIIString.Append("  ");
                    }
                    else
                    {
                        ASCIIString.Append(blackCharacter);
                    }
                }
                ASCIIString.Append("\n");
            }
            return ASCIIString.ToString();
        }

        /// <summary>
        /// Refreshes the preview image with the new threshold. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sldTolerance_Changed(object sender, EventArgs e) => RefreshImage();
    }
}