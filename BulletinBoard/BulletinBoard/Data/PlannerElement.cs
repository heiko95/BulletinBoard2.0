namespace BulletinBoard.Data
{
    public class PlannerElement : IElement
    {
        #region Public Properties

        public PlannerSection CurrentMonth { get; set; }
        public PlannerSection FollowingMonth { get; set; }
        public Guid Id { get; }

        #endregion Public Properties
    }
}