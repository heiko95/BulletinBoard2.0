using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IEventRepository
    {
        #region Public Methods

        BibleInfo GetBibleInfoByDate(int day, int month, int year);

        IList<PlannerEvent> GetEventsByDate(int month, int year, int year1);

        #endregion Public Methods
    }
}