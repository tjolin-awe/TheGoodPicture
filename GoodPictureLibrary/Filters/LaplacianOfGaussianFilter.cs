
using System.Drawing;


namespace GoodPictureLibrary.Filters
{
    public class LaplacianOfGaussianFilter : MatrixFilter
    {

        #region Constructor
        public LaplacianOfGaussianFilter(string key, float[,] expression, int factor = 1) : base(key, expression, factor, false)
        {

        }
        #endregion

        #region Methods

        public override Bitmap Process(Bitmap source)
        {
            return ConvolutionFilter(source, Transform, 1.0, 0, GrayScale);
        }

        #endregion
    }
}
