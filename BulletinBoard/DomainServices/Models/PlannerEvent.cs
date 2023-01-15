namespace hgSoftware.DomainServices.Models
{
    public enum Day
    {
        Mo,
        Di,
        Mi,
        Do,
        Fr,
        Sa,
        So,
    }

    public class PlannerEvent
    {
        #region Public Properties

        public string BibleText { get; set; }
        public string Date { get; set; }
        public Day Day { get; set; }
        public string Description { get; set; }
        public Guid Id { get; }
        public string Location { get; set; }
        public string Time { get; set; }

        #endregion Public Properties
    }
}