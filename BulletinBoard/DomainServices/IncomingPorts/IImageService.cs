using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.IncomingPorts
{
    public interface IImageService
    {
        #region Public Methods

        IList<ImageElement> GetPictures();

        #endregion Public Methods
    }
}