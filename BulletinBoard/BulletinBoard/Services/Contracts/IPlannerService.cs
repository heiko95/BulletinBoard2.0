using BulletinBoard.Data;

namespace BulletinBoard.Services.Contracts
{
    public interface IPlannerService
    {
        #region Public Methods

        PlannerElement GetPlanner();

        #endregion Public Methods
    }
}