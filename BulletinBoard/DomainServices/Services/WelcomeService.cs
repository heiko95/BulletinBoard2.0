using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.OutgoingPorts;

namespace hgSoftware.DomainServices.Services
{
    public class WelcomeService : IWelcomeService
    {
        #region Private Fields

        private readonly IImageRepository _imageRepository;

        #endregion Private Fields

        #region Public Constructors

        public WelcomeService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public WelcomeElement? GetWelcomePicture()
            => _imageRepository.GetWelcomeImage();

        #endregion Public Methods
    }
}