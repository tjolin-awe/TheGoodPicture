using GoodPictureLibrary.Filters;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace GoodPictureLibrary
{
    public class MatrixFilter : Filter
    {

        #region Fields
        private float[,] _transform;
        private bool _grayScale;
        private int _factor;
        #endregion


        #region Constructor

        public MatrixFilter(string key, float[,] expression) : base(key)
        {
            _transform = expression;
            _grayScale = false;
            _factor = 1;
        }
        public MatrixFilter(string key, float[,] expression, bool grayScale = false) : base(key)
        {
            _grayScale = grayScale;
            _transform = expression;
            _factor = 1;
        }

        public MatrixFilter(string key, float[,] expression, int factor = 1, bool grayScale = false) : base(key)
        {
            _grayScale = grayScale;
            _transform = expression;
            _factor = factor;
        }

        #endregion

        #region Properties

        public float[,] Transform
        {
            get { return _transform; }
        }

        public bool GrayScale
        {
            get { return _grayScale; }
            set { _grayScale = value; }
        }

        public int Factor
        {
            get { return _factor; }
            set { _factor = value; }
        }


        public override Bitmap Process(Bitmap source)
        {
            return source;
        }

        protected Bitmap ConvolutionFilter(Bitmap sourceBitmap, float[,] filterMatrix, double factor = 1, int bias = 0, bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }


        protected Bitmap ConvolutionFilter(Bitmap sourceBitmap, float[,] xFilterMatrix, float[,] yFilterMatrix,
                                              double factor = 1,
                                                   int bias = 0,
                                         bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                  PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            double blueTotal = 0.0;
            double greenTotal = 0.0;
            double redTotal = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;

                    blueTotal = greenTotal = redTotal = 0.0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blueX += (double)(pixelBuffer[calcOffset]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenX += (double)(pixelBuffer[calcOffset + 1]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redX += (double)(pixelBuffer[calcOffset + 2]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            blueY += (double)(pixelBuffer[calcOffset]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenY += (double)(pixelBuffer[calcOffset + 1]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redY += (double)(pixelBuffer[calcOffset + 2]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];
                        }
                    }

                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                    { blueTotal = 255; }
                    else if (blueTotal < 0)
                    { blueTotal = 0; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }
                    else if (greenTotal < 0)
                    { greenTotal = 0; }

                    if (redTotal > 255)
                    { redTotal = 255; }
                    else if (redTotal < 0)
                    { redTotal = 0; }

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }
        #endregion



        public static T CreateMatrixFilter<T>(int factor, bool grayScale) where T : MatrixFilter
        {
           var filter = (T)Activator.CreateInstance(typeof(T));

           filter.GrayScale = grayScale;
           filter.Factor = factor;

            return filter;
           
        }

        public static T CreateMatrixFilter<T>() where T : MatrixFilter 
        {
            return (T)CreateMatrixFilter(typeof(T).Name);
        }
        public static MatrixFilter CreateMatrixFilter(string filterName)
        {
            switch (filterName)
            {
                case "Laplacian3x3Filter":
                    return new Laplacian3x3Filter(filterName,
                        new float[,] { { -1, -1, -1,  },
                                       { -1,  8, -1,  },
                                       { -1, -1, -1,  }, });

                case "Laplacian3x3GrayScaleFilter":
                    return new Laplacian3x3Filter(filterName,
                          new float[,] { { -1, -1, -1,  },
                                       { -1,  8, -1,  },
                                       { -1, -1, -1,  }, }, 1, true);


                case "Laplacian5x5Filter":
                    return new Laplacian5x5Filter(filterName,
                        new float[,] { { -1, -1, -1, -1, -1, },
                                       { -1, -1, -1, -1, -1, },
                                       { -1, -1, 24, -1, -1, },
                                       { -1, -1, -1, -1, -1, },
                                       { -1, -1, -1, -1, -1  }, });

                case "Laplacian5x5GrayScaleFilter":
                    return new Laplacian5x5Filter(filterName,
                        new float[,] { { -1, -1, -1, -1, -1, },
                                       { -1, -1, -1, -1, -1, },
                                       { -1, -1, 24, -1, -1, },
                                       { -1, -1, -1, -1, -1, },
                                       { -1, -1, -1, -1, -1  }, }, 1, true);

                case "LaplacianOfGaussianFilter":
                    return new LaplacianOfGaussianFilter(filterName,
                        new float[,] { {  0,   0, -1,  0,  0 },
                                       {  0,  -1, -2, -1,  0 },
                                       { -1,  -2, 16, -2, -1 },
                                       {  0,  -1, -2, -1,  0 },
                                       {  0,   0, -1,  0,  0 }, });
                case "Laplacian3x3Gaussian3x3Filter":
                    return new Laplacian3x3Gaussian3x3Filter(filterName, 16);

                case "Gaussian3x3Filter":
                    return new Gaussian3x3Filter(filterName,
                        new float[,] { { 1, 2, 1, },
                                       { 2, 4, 2, },
                                       { 1, 2, 1, }, });

                case "Gaussian5x5Filter":
                    return new Gaussian5x5Filter(filterName,
                        new float[,] { { -1, -1, -1, -1, -1, },
                                       { -1, -1, -1, -1, -1, },
                                       { -1, -1, 24, -1, -1, },
                                       { -1, -1, -1, -1, -1, },
                                       { -1, -1, -1, -1, -1  }, });

                case "Laplacian3x3OfGaussian5x5Filter_159":
                    return new Laplacian3x3Gaussian5x5Filter(filterName, 159);

                case "Laplacian3x3OfGaussian5x5Filter_256":
                    return new Laplacian3x3Gaussian5x5Filter(filterName, 256);

                case "Laplacian5x5Gaussian5x5Filter_159":
                    return new Laplacian5x5Gaussian5x5Filter(filterName, 159);

                case "Laplacian5x5Gaussian5x5Ftiler_256":
                    return new Laplacian5x5Gaussian5x5Filter(filterName, 256);


                case "Sobel3x3Filter":
                    return new Sobel3x3Filter(filterName,
                            new float[,] { { 0, 0 }, { 0, 0 } });

                case "Sobel3x3HorizontalFilter":
                    return new MatrixFilter(filterName,
                         new float[,] { { -1,  0,  1, },
                                        { -2,  0,  2, },
                                        { -1,  0,  1, }, });

                case "Sobel3x3VerticalFilter":
                    return new MatrixFilter(filterName,
                         new float[,] { {  1,  2,  1, },
                                        {  0,  0,  0, },
                                        { -1, -2, -1, }, });

                case "Prewitt3x3Filter":
                    return new Prewitt3x3Filter(filterName,
                        new float[,] { { 0, 0 }, { 0, 0 } });

                case "Prewitt3x3HorizontalFilter":
                    return new MatrixFilter(filterName,
                        new float[,] { { -1,  0,  1, },
                                       { -1,  0,  1, },
                                       { -1,  0,  1, }, });

                case "Prewitt3x3VerticalFilter":
                    return new MatrixFilter(filterName,
                        new float[,] { {  1,  1,  1, },
                                       {  0,  0,  0, },
                                       { -1, -1, -1, }, });

                case "Kirsch3x3Filter":
                    return new Kirsch3x3Filter(filterName,
                        new float[,] { { 0, 0 }, { 0, 0 } });

                case "Kirsch3x3HorizontalFilter":
                    return new MatrixFilter(filterName,
                        new float[,] { {  5,  5,  5, },
                                       { -3,  0, -3, },
                                       { -3, -3, -3, }, });

                case "Kirsch3x3VerticalFilter":
                    return new MatrixFilter(filterName,
                       new float[,] { {  5, -3, -3, },
                                      {  5,  0, -3, },
                                      {  5, -3, -3, }, });

            }

            throw new Exception(filterName + "is not a recognized Filter!");
        }


    }


}
