using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.DomainServices.SettingModels;
using Microsoft.Extensions.Options;

namespace hgSoftware.DomainServices.Services
{
    public class ImageService : IImageService
    {
        #region Private Fields

        private readonly int _imageCount;

        private readonly IImageRepository _imageRepository;

        #endregion Private Fields

        #region Public Constructors

        public ImageService(IImageRepository imageRepository, IOptionsMonitor<ElementSettings> namedOptionsAccessor)
        {
            _imageCount = namedOptionsAccessor.Get(ElementSettings.ImageScreenSettings).DisplayCount;
            _imageRepository = imageRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public IList<ImageElement> GetPictures() 
            => _imageRepository.GetImages(_imageCount).Reverse().ToList();

        #endregion Public Methods
    }
}