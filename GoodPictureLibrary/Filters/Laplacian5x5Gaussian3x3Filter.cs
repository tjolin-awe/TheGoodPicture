using System.Drawing;

namespace GoodPictureLibrary.Filters
{
    public class Laplacian5x5Gaussian3x3Filter : MatrixFilter
    {
        private Laplacian3x3Filter _laplacian3x3Filter;
        private Gaussian3x3Filter _gaussian3x3Filter;

       #region Constructor
      
        public Laplacian5x5Gaussian3x3Filter(string key, int blurFactor) : base (key,null, false)
        {
            _laplacian3x3Filter = (Laplacian3x3Filter)CreateMatrixFilter("Laplacian5x5Filter");
            _gaussian3x3Filter = (Gaussian3x3Filter)CreateMatrixFilter("Gaussian3x3Filter");
            _gaussian3x3Filter.Factor = blurFactor;
            _gaussian3x3Filter.GrayScale = true;
        }
        #endregion

        #region Methods

        public override Bitmap Process(Bitmap source)
        {

            // First to Guassian blur
            Bitmap result = _gaussian3x3Filter.Process(source);

            // then apply Laplacian3x3
            return _laplacian3x3Filter.Process(result);

        }

        #endregion
    }
}
