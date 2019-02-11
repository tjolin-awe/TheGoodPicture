using System.Drawing;


namespace GoodPictureLibrary.Filters
{
    public class Laplacian5x5Gaussian5x5Filter : MatrixFilter
    {
        private Laplacian5x5Filter _laplacian5x5Filter;
        private Gaussian5x5Filter _gaussian5x5Filter;
        #region Constructor
    

        public Laplacian5x5Gaussian5x5Filter(string key, int blurFactor) : base(key, null, false)
        {
            _laplacian5x5Filter = (Laplacian5x5Filter)CreateMatrixFilter("Laplacian5x5Filter");

            _gaussian5x5Filter = (Gaussian5x5Filter)CreateMatrixFilter("Gaussian5x5Filter");
            _gaussian5x5Filter.GrayScale = true;
            _gaussian5x5Filter.Factor = blurFactor;

        }
        #endregion

        #region Methods

        public override Bitmap Process(Bitmap source)
        {

            var result = _gaussian5x5Filter.Process(source);

            // then apply Laplacian3x3
            return _laplacian5x5Filter.Process(result);

        }

        #endregion
    }

}
