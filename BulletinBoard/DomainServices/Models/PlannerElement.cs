namespace hgSoftware.DomainServices.Models
{
    public class PlannerElement : IElement
    {
        #region Public Properties

        public Guid Id { get; } = Guid.NewGuid();
        public List<PlannerSection> PlannerSections { get; } = new List<PlannerSection>();

        #endregion Public Properties

        #region Public Methods

        public void AddPlannerSection(PlannerSection plannerSection)
        {
            PlannerSections.Add(plannerSection);
        }

        #endregion Public Methods
    }
}