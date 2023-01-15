using BulletinBoard.Data;

namespace BulletinBoard.Services.Contracts
{
    public interface IWelcomeService
    {
        #region Public Methods

        ImageElement GetWelcomePicture();

        #endregion Public Methods
    }
}