using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IEventRepository
    {
        #region Public Methods

        IList<PlannerEvent> GetEventsByDate(int month, int year, int year1);

        #endregion Public Methods
    }
}