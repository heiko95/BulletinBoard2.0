using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.OutgoingPorts;

namespace hgSoftware.DomainServices.Services
{
    public class ImageService : IImageService
    {
        #region Private Fields

        private readonly IImageRepository _imageRepository;

        #endregion Private Fields

        #region Public Constructors

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public IList<ImageElement> GetPictures()
            => _imageRepository.GetImages();

        #endregion Public Methods
    }
}