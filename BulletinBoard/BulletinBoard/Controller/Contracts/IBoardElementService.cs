using hgSoftware.DomainServices.Models;

namespace BulletinBoard.Services.Contracts
{
    public interface IBoardElementService
    {
        #region Public Methods

        IList<IElement> GetCurrentElements();

        Task InitElements();

        #endregion Public Methods
    }
}