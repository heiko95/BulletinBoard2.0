namespace hgSoftware.DomainServices.Models
{
    public class PlannerSection
    {
        #region Public Constructors

        public PlannerSection()
        {
        }

        public PlannerSection(IList<PlannerEvent> events, string month)
        {
            Events = events;
            Month = month;
        }

        #endregion Public Constructors

        #region Public Properties

        public IList<PlannerEvent> Events { get; set; } = new List<PlannerEvent>();
        public string Month { get; set; } = string.Empty;

        #endregion Public Properties
    }
}