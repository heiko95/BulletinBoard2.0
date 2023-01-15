namespace hgSoftware.DomainServices.Models
{
    public class ImageElement : IElement
    {
        #region Public Constructors

        public ImageElement(string imagePath)
        {
            Id = Guid.NewGuid();

            var imageArray = File.ReadAllBytes(imagePath);
            var image = Convert.ToBase64String(imageArray);
            Base64Image = string.Format("data:image/jpg;base64,{0}", image);
        }

        #endregion Public Constructors

        #region Public Properties

        public string Base64Image { get; set; }
        public Guid Id { get; }

        #endregion Public Properties
    }
}