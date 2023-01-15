using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.IncomingPorts
{
    public interface IPlannerService
    {
        #region Public Methods

        PlannerElement GetPlanner();

        #endregion Public Methods
    }
}