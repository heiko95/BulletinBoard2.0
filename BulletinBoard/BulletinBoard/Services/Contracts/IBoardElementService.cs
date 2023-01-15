using BulletinBoard.Data;

namespace BulletinBoard.Services.Contracts
{
    public interface IBoardElementService
    {
        #region Public Methods

        IList<IElement> GetCurrentElements();

        #endregion Public Methods
    }
}