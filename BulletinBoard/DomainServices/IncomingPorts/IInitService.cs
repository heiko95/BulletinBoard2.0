using hgSoftware.DomainServices.SettingModels;

namespace hgSoftware.DomainServices.IncomingPorts
{
    public interface IInitService
    {
        #region Public Methods

        SlideSettings GetSlideSettings();

        Task InitializeBulletinBoard();

        #endregion Public Methods
    }
}