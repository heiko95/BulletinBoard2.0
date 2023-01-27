namespace hgSoftware.DomainServices.Models
{
    public class BibleTextElement : IElement
    {
        #region Public Properties

        public string BiblePassage { get; set; } = string.Empty;
        public string BibleText { get; set; } = string.Empty;
        public Guid Id { get; }

        #endregion Public Properties
    }
}