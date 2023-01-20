namespace hgSoftware.DomainServices.Models
{
    public class BibleInfo
    {
        #region Public Properties

        public string Book { get; set; } = string.Empty;
        public int Chapter { get; set; }
        public int Verse { get; set; }

        #endregion Public Properties
    }
}