using System.Globalization;

namespace hgSoftware.Infrastructure.Models
{
    public class Image
    {
        #region Private Fields

        private readonly DateOnly _dateOnly;

        #endregion Private Fields

        #region Public Constructors

        public Image(string imageBase64, DateOnly dateOnly, string imageName)
        {
            ImageBase64 = imageBase64;
            _dateOnly = dateOnly;
            ImageName = imageName;
        }

        #endregion Public Constructors

        #region Public Properties

        public string ImageBase64 { get; }
        public string ImageDate => _dateOnly.ToString("dd. MMMM yyyy", new CultureInfo("de-DE"));
        public string ImageName { get; }

        #endregion Public Properties
    }
}