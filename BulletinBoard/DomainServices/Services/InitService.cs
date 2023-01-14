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

            var eventTask = Task.Run(()
                => CheckAndUpdateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.EventScreenSettings).FolderName)));
            var imageTask = Task.Run(()
                => CheckAndUpdateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.ImageScreenSettings).FolderName)));
            var welcomeTask = Task.Run(()
                => CheckAndUpdateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FolderName)));
            await Task.WhenAll(eventTask, imageTask, welcomeTask);
        }

        #endregion Public Methods

        #region Private Methods

        private void CheckAndUpdateDirectory(string folderName)
        {
            CreateDirectory(folderName);
            // DO Rsync Stuff here
        }

        private void CreateDirectory(string folderName)
        {
            if (!string.IsNullOrEmpty(folderName) && !Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
        }

        #endregion Private Methods
    }
}