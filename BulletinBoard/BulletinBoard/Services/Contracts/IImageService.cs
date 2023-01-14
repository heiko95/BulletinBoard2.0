using BulletinBoard.Data;

namespace BulletinBoard.Services.Contracts
{
    public interface IImageService
    {
        #region Public Methods

        IList<ImageElement> GetPictures();

        #endregion Public Methods
    }
}