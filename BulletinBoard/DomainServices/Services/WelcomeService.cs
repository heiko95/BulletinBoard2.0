using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.SettingModels;
using Microsoft.Extensions.Options;

namespace hgSoftware.DomainServices.Services
{
    public class WelcomeService : IWelcomeService
    {
        #region Private Fields

        private readonly string _imagePath;

        #endregion Private Fields

        #region Public Constructors

        public WelcomeService(IOptionsMonitor<ElementSettings> namedOptionsAccessor)
        {
            _imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                                      "BulletinBoard",
                                      namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FolderName,
                                      namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FileName);
        }

        #endregion Public Constructors

        #region Public Methods

        public ImageElement? GetWelcomePicture()
            => File.Exists(_imagePath) ? new ImageElement(_imagePath) : null;

        #endregion Public Methods
    }
}