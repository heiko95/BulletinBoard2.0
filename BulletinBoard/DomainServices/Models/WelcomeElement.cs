namespace hgSoftware.DomainServices.Models
{
    public class WelcomeElement : IElement
    {
        #region Public Properties

        public string Base64Image { get; set; } = string.Empty;
        public Guid Id { get; } = Guid.NewGuid();
        public string ImageName { get; set; } = string.Empty;

        #endregion Public Properties
    }
}