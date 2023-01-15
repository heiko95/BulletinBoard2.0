using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.SettingModels;
using Microsoft.Extensions.Options;

namespace hgSoftware.DomainServices.Services
{
    public class InitService : IInitService
    {
        #region Private Fields

        private readonly IOptionsMonitor<ElementSettings> _namedOptionsAccessor;

        #endregion Private Fields

        #region Public Constructors

        public InitService(IOptionsMonitor<ElementSettings> namedOptionsAccessor)
        {
            _namedOptionsAccessor = namedOptionsAccessor;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task InitializeBulletinBoard()
        {
            if (_namedOptionsAccessor == null) throw new ArgumentNullException(nameof(_namedOptionsAccessor));

            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var appDataFolder = Path.Combine(userFolder, "BulletinBoard");
            CreateDirectory(appDataFolder);
            CreateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.EventScreenSettings).FolderName));
            CreateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.ImageScreenSettings).FolderName));
            CreateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FolderName));

            await UpdateDirectory(appDataFolder);
        }

        #endregion Public Methods

        #region Private Methods

        private void CreateDirectory(string folderName)
        {
            if (string.IsNullOrEmpty(folderName) || Directory.Exists(folderName)) return;
            Directory.CreateDirectory(folderName);
        }

        private async Task UpdateDirectory(string folderName)
        {
            await Task.Delay(1000);
            // TODO Do Rsync Stuff here
        }

        #endregion Private Methods
    }
}