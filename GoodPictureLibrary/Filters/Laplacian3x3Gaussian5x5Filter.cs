using System.Drawing;


namespace GoodPictureLibrary.Filters
{
    public class Laplacian3x3Gaussian5x5Filter : MatrixFilter
    {
        private Laplacian3x3Filter _laplacian3x3Filter;
        private Gaussian5x5Filter _gaussian5x5Filter;
        #region Constructor
 

        public Laplacian3x3Gaussian5x5Filter(string key, int factor) : base(key, null, false)
        {
            _laplacian3x3Filter = (Laplacian3x3Filter)CreateMatrixFilter("Laplacian3x3Filter");

            _gaussian5x5Filter = (Gaussian5x5Filter)CreateMatrixFilter("Gaussian5x5Filter");
            _gaussian5x5Filter.GrayScale = true;
            _gaussian5x5Filter.Factor = factor;

        }
        #endregion

        #region Methods

        public override Bitmap Process(Bitmap source)
        {

            var result = _gaussian5x5Filter.Process(source);

            // then apply Laplacian3x3
            return _laplacian3x3Filter.Process(result);

        }

        #endregion
    }

}
