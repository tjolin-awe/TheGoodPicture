using System.Drawing;

namespace GoodPictureLibrary.Filters
{
    public class Gaussian3x3Filter : MatrixFilter
    {
       

        #region Constructor
        public Gaussian3x3Filter(string key, float[,] expression, int factor = 16, bool grayScale = false) : base(key, expression, factor, grayScale)
        {

        }
        #endregion


        #region Methods

        public override Bitmap Process(Bitmap source)
        {
            return ConvolutionFilter(source,
                          Transform, 1.0 / Factor, 0, GrayScale);
        }

        #endregion
    }

}
