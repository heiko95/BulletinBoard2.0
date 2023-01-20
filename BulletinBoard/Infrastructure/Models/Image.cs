namespace Infrastructure.Models
{
    public class Image
    {
        #region Public Constructors

        public Image(string imageBase64, string imagePath)
        {
            ImageBase64 = imageBase64;
            ImagePath = imagePath;
        }

        #endregion Public Constructors

        #region Public Properties

        public string ImageBase64 { get; }
        public string ImagePath { get; }

        #endregion Public Properties

    }
}