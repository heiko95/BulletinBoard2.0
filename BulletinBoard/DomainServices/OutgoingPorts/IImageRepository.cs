using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IImageRepository
    {
        #region Public Methods

        IList<ImageElement> GetImages();

        ImageElement? GetWelcomeImage();

        #endregion Public Methods
    }
}