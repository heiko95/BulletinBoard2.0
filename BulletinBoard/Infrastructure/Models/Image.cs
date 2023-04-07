using System.Globalization;

namespace hgSoftware.Infrastructure.Models
{
    public class Image
    {
             

        #region Public Constructors

        public Image(string imageBase64, DateOnly dateOnly, string imageName)
        {
            ImageBase64 = imageBase64;
            ImageDate = dateOnly.ToString("dd. MMMM yyyy", new CultureInfo("de-DE"));
            ImageName = imageName;
        }

        public Image(string imageBase64)
        {
            ImageBase64 = imageBase64;
            ImageDate = string.Empty;
            ImageName = string.Empty;
        }

        #endregion Public Constructors

        #region Public Properties

        public string ImageBase64 { get; }
        public string ImageDate { get; }
        public string ImageName { get; }
               

        #endregion Public Properties
    }
}