namespace hgSoftware.DomainServices.Models
{
    public class ImageElement : IElement
    {
        #region Public Properties

        public string Base64Image { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        #endregion Public Properties
    }
}