using System.Drawing;

namespace GoodPictureLibrary.Filters
{
    public class Gaussian5x5Filter : MatrixFilter
    {
       

        #region Constructor
        public Gaussian5x5Filter(string key, float[,] expression, int factor = 256, bool grayScale = false) : base(key, expression, factor, grayScale)
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
