using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IEventRepository
    {
        #region Public Methods

        BibleInfo GetBibleInfoByDate(DateOnly date, TimeOnly time);

        IList<PlannerEvent> GetEventsByDate(DateOnly date);

        #endregion Public Methods
    }
}