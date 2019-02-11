using System.Drawing;

namespace GoodPictureLibrary.Filters
{
    public class Laplacian3x3Filter : MatrixFilter
    {

        #region Constructor
        public Laplacian3x3Filter(string key, float[,] expression, int factor = 1, bool grayScale = false) : base(key, expression, factor, grayScale)
        {
            
        }
        #endregion

        #region Methods

        public override Bitmap Process(Bitmap source)
        {
            return ConvolutionFilter(source, Transform, Factor, 0, GrayScale);
        }

        #endregion
    }
}
