using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.IncomingPorts
{
    public interface IWelcomeService
    {
        #region Public Methods

        WelcomeElement? GetWelcomePicture();

        #endregion Public Methods
    }
}