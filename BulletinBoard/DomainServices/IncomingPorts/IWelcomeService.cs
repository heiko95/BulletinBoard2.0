using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.IncomingPorts
{
    public interface IWelcomeService
    {
        #region Public Methods

        ImageElement? GetWelcomePicture();

        #endregion Public Methods
    }
}