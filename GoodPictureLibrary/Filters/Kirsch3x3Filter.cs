using System.Drawing;

namespace GoodPictureLibrary.Filters
{
    public class Kirsch3x3Filter : MatrixFilter
    {
        MatrixFilter kirsch3x3Horizontal;
        MatrixFilter kirsch3x3Vertical;

        public Kirsch3x3Filter(string key, float[,] expression, int factor = 1, bool grayScale = true) : base(key, expression, factor, grayScale)
        {
            kirsch3x3Horizontal = CreateMatrixFilter("Kirsch3x3HorizontalFilter");
            kirsch3x3Vertical = CreateMatrixFilter("Kirsch3x3VerticalFilter");

        }

        public override Bitmap Process(Bitmap source)
        {
            return ConvolutionFilter(source, kirsch3x3Horizontal.Transform, kirsch3x3Vertical.Transform,
                                                        Factor, 0, GrayScale);


        }
    }
}
