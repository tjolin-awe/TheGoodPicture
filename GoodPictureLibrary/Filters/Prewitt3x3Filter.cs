using System.Drawing;

namespace GoodPictureLibrary.Filters
{
    public class Prewitt3x3Filter : MatrixFilter
    {
        MatrixFilter prewitt3x3Horizontal;
        MatrixFilter prewitt3x3Vertical;

        public Prewitt3x3Filter(string key, float[,] expression, int factor = 1, bool grayScale = true) : base(key, expression, factor, grayScale)
        {
            prewitt3x3Horizontal = CreateMatrixFilter("Prewitt3x3HorizontalFilter");
            prewitt3x3Vertical = CreateMatrixFilter("Prewitt3x3VerticalFilter");

        }

        public override Bitmap Process(Bitmap source)
        {
            return ConvolutionFilter(source, prewitt3x3Horizontal.Transform, prewitt3x3Vertical.Transform,
                                                        Factor, 0, GrayScale);


        }
    }
}
