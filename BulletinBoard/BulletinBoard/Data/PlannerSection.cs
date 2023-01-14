namespace BulletinBoard.Data
{
    public class PlannerSection
    {
        #region Public Properties

        public IList<PlannerEvent> Events { get; set; } = new List<PlannerEvent>();
        public string Month { get; set; }

        #endregion Public Properties
    }
}