using System.Drawing;

namespace GoodPictureLibrary.Filters
{
    public class Laplacian3x3Gaussian3x3Filter : MatrixFilter
    {
        private Laplacian3x3Filter _laplacian3x3Filter;
        private Gaussian3x3Filter _gaussian3x3Filter;

        #region Constructor
        public Laplacian3x3Gaussian3x3Filter(string key, int factor) : base(key, null)
        {
            _gaussian3x3Filter = (Gaussian3x3Filter)MatrixFilter.CreateMatrixFilter("Gaussian3x3Filter");
            _gaussian3x3Filter.GrayScale = true;
            _gaussian3x3Filter.Factor = factor;

            _laplacian3x3Filter = (Laplacian3x3Filter)MatrixFilter.CreateMatrixFilter("Laplacian3x3Filter");


        }
        #endregion

        #region Methods

        public override Bitmap Process(Bitmap source)
        {

            // Blur edges
            Bitmap result = _gaussian3x3Filter.Process(source);

            // execute laplacian filter
            return _laplacian3x3Filter.Process(result);

        }

        #endregion
    }
}
