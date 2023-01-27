using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.SettingModels;

namespace BulletinBoard.Services.Contracts
{
    public interface IBoardElementService
    {
        #region Public Methods

        Task<IList<IElement>> GetCurrentElements();

        SlideSettings GetSlideSettings();

        Task InitElements();

        #endregion Public Methods
    }
}