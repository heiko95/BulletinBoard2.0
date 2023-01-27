namespace hgSoftware.DomainServices.Models
{
    public class PlannerEvent
    {
        #region Public Properties

        public string BibleText { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Day { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid Id { get; } = Guid.NewGuid();
        public string Location { get; set; } = string.Empty;

        #endregion Public Properties
    }
}