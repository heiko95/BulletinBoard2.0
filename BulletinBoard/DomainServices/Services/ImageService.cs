using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.SettingModels;
using Microsoft.Extensions.Options;

namespace hgSoftware.DomainServices.Services
{
    public class ImageService : IImageService
    {
        #region Private Fields

        private readonly string _imagePath;

        #endregion Private Fields

        #region Public Constructors

        public ImageService(IOptionsMonitor<ElementSettings> namedOptionsAccessor)
        {
            _imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                                      "BulletinBoard",
                                      namedOptionsAccessor.Get(ElementSettings.ImageScreenSettings).FolderName);
        }

        #endregion Public Constructors

        #region Public Methods

        public IList<ImageElement> GetPictures()
            => (from imagepath in Directory.GetFiles(_imagePath, "*.jpg")
                select new ImageElement(imagepath)).ToList();

        #endregion Public Methods
    }
}