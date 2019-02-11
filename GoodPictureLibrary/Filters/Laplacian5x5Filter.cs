using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GoodPictureLibrary.Filters
{
    public class Laplacian5x5Filter : MatrixFilter
    {

        #region Constructor
        public Laplacian5x5Filter(string key, float[,] expression, int factor = 1, bool grayScale = false) : base(key, expression, factor, grayScale)
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
