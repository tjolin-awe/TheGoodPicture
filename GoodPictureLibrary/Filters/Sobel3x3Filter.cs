using System.Drawing;

namespace GoodPictureLibrary.Filters
{
    public class Sobel3x3Filter : MatrixFilter
    {
        MatrixFilter sobel3x3Horizontal;
        MatrixFilter sobel3x3Vertical;

        public Sobel3x3Filter(string key, float[,] expression, int factor = 1, bool grayScale = true) : base(key, expression, factor, grayScale)
        {
            sobel3x3Horizontal = CreateMatrixFilter("Sobel3x3HorizontalFilter");
            sobel3x3Vertical = CreateMatrixFilter("Sobel3x3VerticalFilter");

        }

        public override Bitmap Process(Bitmap source)
        {
            return ConvolutionFilter(source, sobel3x3Horizontal.Transform, sobel3x3Vertical.Transform,
                                                        Factor, 0, GrayScale);


        }
    }

}
