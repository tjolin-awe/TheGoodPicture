using GoodPictureLibrary;
using GoodPictureLibrary.Filters;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TheGoodPicture
{
    public partial class frmGoodPicture : Form
    {

        // Oil Paint based in full on work by Dewald Esterhuizen https://softwarebydefault.com 
      
        #region  Ms-PL License

        /*
        This license governs use of the accompanying software. If you use the software, you accept
        this license. If you do not accept the license, do not use the software. 1. Definitions 
        The terms "reproduce," "reproduction," "derivative works," and "distribution" 
        have the same meaning here as under U.S. copyright law. A "contribution" is the original 
        software, or any additions or changes to the software. A "contributor" is any person that
        distributes its contribution under this license. "Licensed patents" are a contributor's 
        patent claims that read directly on its contribution. 2. Grant of Rights (A) Copyright Grant- 
        Subject to the terms of this license, including the license conditions and limitations in 
        section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright 
        license to reproduce its contribution, prepare derivative works of its contribution, 
        and distribute its contribution or any derivative works that you create. (B) Patent Grant- 
        Subject to the terms of this license, including the license conditions and limitations in
        section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license 
        under its licensed patents to make, have made, use, sell, offer for sale, import, and/or 
        otherwise dispose of its contribution in the software or derivative works of the contribution
        in the software. 3. Conditions and Limitations (A) No Trademark License-
        This license does not grant you rights to use any contributors' name, logo, or trademarks. 
        (B) If you bring a patent claim against any contributor over patents that you claim are 
        infringed by the software, your patent license from such contributor to the software ends
        automatically. (C) If you distribute any portion of the software, you must retain all copyright,
        patent, trademark, and attribution notices that are present in the software. (D) If you 
        distribute any portion of the software in source code form, you may do so only under this
        license by including a complete copy of this license with your distribution. If you distribute
        any portion of the software in compiled or object code form, you may only do so under a license 
        that complies with this license. (E) The software is licensed "as-is." You bear the risk of
        using it. The contributors give no express warranties, guarantees or conditions. You may have
        additional consumer rights under your local laws which this license cannot change. To the extent
        permitted under your local laws, the contributors exclude the implied warranties of merchantability,
        fitness for a particular purpose and non-infringement.



        */
        #endregion

        private Bitmap original = null;
        private Bitmap workingcopy = null;
        private Bitmap result = null;
        public frmGoodPicture()
        {
            InitializeComponent();
        }

        public Bitmap OilPaintFilter(Bitmap sourceBitmap, int levels, int filterSize)
        {

            if (levels <= 0)
                levels = 1;

            // Lock bitmap in memory
            BitmapData sourceData =
                       sourceBitmap.LockBits(new Rectangle(0, 0,
                       sourceBitmap.Width, sourceBitmap.Height),
                       ImageLockMode.ReadOnly,
                       PixelFormat.Format32bppArgb);

            // Set buffer width + height
            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];


            //  Set result buffer width + height
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];


            // copy the source file to the pixel buffer
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            // unlock the source bitmap
            sourceBitmap.UnlockBits(sourceData);

            int[] intensityBin = new int[levels];
            int[] blueBin = new int[levels];
            int[] greenBin = new int[levels];
            int[] redBin = new int[levels];

            levels -= 1;

            int filterOffset = (filterSize - 1) / 2;


            int byteOffset = 0;
            int calcOffset = 0;
            int currentIntensity = 0;
            int maxIntensity = 0;
            int maxIndex = 0;

            double blue = 0, green = 0, red = 0;

            for (int offsetY = filterOffset; offsetY < sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = green = red = 0;

                    currentIntensity = maxIntensity = maxIndex = 0;

                    intensityBin = new int[levels + 1];
                    blueBin = new int[levels + 1];
                    greenBin = new int[levels + 1];
                    redBin = new int[levels + 1];

                    byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                            /*  Oil Paint Algorithm
                             (R + G + B) / (3 * intensity) / 255                             
                            */

                            currentIntensity = (int)Math.Round(
                                ((pixelBuffer[calcOffset]       // R
                                + pixelBuffer[calcOffset + 1]   // G
                                + pixelBuffer[calcOffset + 2])  // B
                                    / 3.0 * levels) / 255.0);

                            intensityBin[currentIntensity] += 1;        

                            blueBin[currentIntensity] += pixelBuffer[calcOffset];
                            greenBin[currentIntensity] += pixelBuffer[calcOffset + 1];
                            redBin[currentIntensity] += pixelBuffer[calcOffset + 2];

                            if (intensityBin[currentIntensity] > maxIntensity)
                            {
                                maxIntensity = intensityBin[currentIntensity];
                                maxIndex = currentIntensity;
                            }
                        }
                    }

                    blue = blueBin[maxIndex] / maxIntensity;
                    green = greenBin[maxIndex] / maxIntensity;
                    red = redBin[maxIndex] / maxIntensity;

                    resultBuffer[byteOffset] = ClipByte(blue);    
                    resultBuffer[byteOffset + 1] = ClipByte(green);
                    resultBuffer[byteOffset + 2] = ClipByte(red);
                    resultBuffer[byteOffset + 3] = 255;

                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            // Lock result data into memory
            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                       ImageLockMode.WriteOnly,
                       PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);

            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }


    

        private static byte ClipByte(double color)
        {
            return (byte)(color > 255 ? 255 :
                   (color < 0 ? 0 : color));
        }

        private void Process(bool preview)
        {
            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;


            if (workingcopy == null || cbFilter.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a neighbor pixel range", "Invalid Parameter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!int.TryParse(tbIntensity.Text, out int intensity))
            {
                MessageBox.Show("Invalid intensity set. Please enter a number", "Invalid Parameter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cbFilter.SelectedItem.ToString(), out int filter))
            {
                MessageBox.Show("Invalid neighbor pixel range. Please select a valid range", "Invalid Parameter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (preview == true)
                selectedSource = workingcopy;
            else
                selectedSource = original;


            if (selectedSource != null)
                bitmapResult = OilPaintFilter(selectedSource, intensity, filter);


            if (bitmapResult != null)
            {

                if (preview)
                    pictureDemo.Image = bitmapResult;
                else
                    result = bitmapResult;

            }


        }

        private void pictureDemo_Click(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                ofd.Title = "Select an image file.";
                ofd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                ofd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    using (StreamReader streamReader = new StreamReader(ofd.FileName))
                    {
                        original = (Bitmap)Bitmap.FromStream(streamReader.BaseStream);
                    }


                    workingcopy = SetPreview(original, pictureDemo.Width);
                    pictureDemo.Image = workingcopy;

                    this.AutoSize = true;
                    this.Refresh();

                  //  Process(false);

                    btnReset.Enabled = true;
                    btnSave.Enabled = true;
                }


            }
        }


        public Bitmap SetPreview(Bitmap source, int size)
        {
            float ratio = 1.0f;
            int maxSide = source.Width > source.Height ?
                          source.Width : source.Height;

            ratio = maxSide / (float)size;

            Bitmap bitmapResult = (source.Width > source.Height ?
                                    new Bitmap(size, (int)(source.Height / ratio))
                                    : new Bitmap((int)(source.Width / ratio), size));

            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(source,
                                        new Rectangle(0, 0, bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0, source.Width, source.Height), GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return bitmapResult;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process(true);
        }

        private void btnLowerIntensity_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbIntensity.Text, out int intensity))
            {
                intensity--;
                tbIntensity.Text = (intensity).ToString();
                Process(true);
            }
            else
            {
                tbIntensity.Text = "25";
            }
        }

        private void btnRaiseIntensity_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbIntensity.Text, out int intensity))
            {
                intensity++;
                tbIntensity.Text = (intensity).ToString();
                Process(true);
            }
            else
            {
                tbIntensity.Text = "25";
            }
        }

        private void tbReset_Click(object sender, EventArgs e)
        {
            workingcopy = SetPreview(original, pictureDemo.Width);
            pictureDemo.Image = workingcopy;

            tbIntensity.Text = "25";
            cbFilter.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Process(false);

            if (result != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Specify a file name and file path";
                sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                    ImageFormat imgFormat = ImageFormat.Png;

                    if (fileExtension == "BMP")
                    {
                        imgFormat = ImageFormat.Bmp;
                    }
                    else if (fileExtension == "JPG")
                    {
                        imgFormat = ImageFormat.Jpeg;
                    }

                    using (StreamWriter streamWriter = new StreamWriter(sfd.FileName, false))
                    {
                        result.Save(streamWriter.BaseStream, imgFormat);
                    }

                    result = null;
                }
            }
        }

        private void menuOilPaintTool_CheckedChanged(object sender, EventArgs e)
        {
            tsOilPaint.Visible = !tsOilPaint.Visible;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEdgeDetectionFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox combobox = (ToolStripComboBox)sender;

            if (combobox.SelectedIndex == -1)
                return;

            string edgefilter = combobox.SelectedItem.ToString();


            //Type t = Type.GetType("GoodPictureLibrary.Filters." + edgefilter);

            // Filter filter = MatrixFilter.CreateMatrixFilter<Gaussian3x3Filter>();

            Filter filter =  MatrixFilter.CreateMatrixFilter(edgefilter);

            ProcessUsingFilter(filter, true);
        }


        private void ProcessUsingFilter(Filter filter, bool preview)
        {
            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
                selectedSource = workingcopy;
            else
                selectedSource = original;


            if (selectedSource != null)
                bitmapResult = filter.Process(selectedSource);


            if (bitmapResult != null)
            {

                if (preview)
                    pictureDemo.Image = bitmapResult;
                else
                    result = bitmapResult;

            }
        }

        private void menuEdgeDetectTool_Click(object sender, EventArgs e)
        {
            tsEdgeDetection.Visible = !tsEdgeDetection.Visible;
        }

        private void pictureDemo_Click_1(object sender, EventArgs e)
        {

        }
    }
}