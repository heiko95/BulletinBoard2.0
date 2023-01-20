using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.DomainServices.SettingModels;
using Microsoft.Extensions.Options;

namespace hgSoftware.DomainServices.Services
{
    public class InitService : IInitService
    {
        #region Private Fields

        private readonly IEventFileReader _eventFileReader;
        private readonly IImageFilesReader _imageFilesReader;
        private readonly IOptionsMonitor<ElementSettings> _namedOptionsAccessor;
        private readonly IWelcomeImageReader _welcomeImageReader;

        #endregion Private Fields

        #region Public Constructors

        public InitService(IOptionsMonitor<ElementSettings> namedOptionsAccessor,
                           IImageFilesReader imageFilesReader,
                           IWelcomeImageReader welcomeImageReader,
                           IEventFileReader eventFileReader)
        {
            _namedOptionsAccessor = namedOptionsAccessor;
            _imageFilesReader = imageFilesReader;
            _welcomeImageReader = welcomeImageReader;
            _eventFileReader = eventFileReader;
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

            var welcomeTask = Task.Run(() => TryToReadFile(_eventFileReader.ReadEvents, Path.Combine(appDataFolder,
                                                     _namedOptionsAccessor.Get(ElementSettings.EventScreenSettings).FolderName,
                                                     _namedOptionsAccessor.Get(ElementSettings.EventScreenSettings).FileName)));

            var plannerTask = Task.Run(() => TryToReadFile(_welcomeImageReader.ReadImage, Path.Combine(appDataFolder,
                                                    _namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FolderName,
                                                    _namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FileName)));

            var imageTask = Task.Run(() => TryToReadFile(_imageFilesReader.ReadImages, Path.Combine(appDataFolder,
                                                    _namedOptionsAccessor.Get(ElementSettings.ImageScreenSettings).FolderName)));

            await Task.WhenAll(welcomeTask, plannerTask, imageTask);
        }

        #endregion Public Methods

        #region Private Methods

        private void CreateDirectory(string folderName)
        {
            if (string.IsNullOrEmpty(folderName) || Directory.Exists(folderName)) return;
            Directory.CreateDirectory(folderName);
        }

        private void TryToReadFile(Action<string> readAction, string path)
        {
            try
            {
                readAction(path);
            }
            catch (FileNotFoundException fex)
            {
                // TODO add info to Log File
            }
            catch (DirectoryNotFoundException dex)
            {
                // TODO add info to Log File
            }
        }

        private async Task UpdateDirectory(string folderName)
        {
            await Task.Delay(1000);
            // TODO Do Rsync Stuff here
        }

        #endregion Private Methods
    }
}