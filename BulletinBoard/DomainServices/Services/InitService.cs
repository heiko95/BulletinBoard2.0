using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.DomainServices.SettingModels;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace hgSoftware.DomainServices.Services
{
    public class InitService : IInitService
    {
        #region Private Fields

        private readonly IBibleFileReader _bibleFileReader;
        private readonly IEventFileReader _eventFileReader;
        private readonly IFileUpdater _fileUpdater;
        private readonly IImageFilesReader _imageFilesReader;
        private readonly ILogger<IInitService> _logger;
        private readonly IOptionsMonitor<ElementSettings> _namedOptionsAccessor;
        private readonly SlideSettings _slideOptions;
        private readonly SyncSettings _syncOptions;
        private readonly IWelcomeImageReader _welcomeImageReader;

        #endregion Private Fields

        #region Public Constructors

        public InitService(IOptionsMonitor<ElementSettings> namedOptionsAccessor,
                           IOptions<SlideSettings> slideOptions,
                           IOptions<SyncSettings> syncOptions,
                           IImageFilesReader imageFilesReader,
                           IWelcomeImageReader welcomeImageReader,
                           IEventFileReader eventFileReader,
                           IBibleFileReader bibleFileReader,
                           IFileUpdater fileUpdater,
                           ILogger<IInitService> logger)
        {
            _namedOptionsAccessor = namedOptionsAccessor;
            _slideOptions = slideOptions.Value;
            _syncOptions = syncOptions.Value;
            _imageFilesReader = imageFilesReader;
            _welcomeImageReader = welcomeImageReader;
            _eventFileReader = eventFileReader;
            _bibleFileReader = bibleFileReader;
            _fileUpdater = fileUpdater;
            _logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        public SlideSettings GetSlideSettings()
        {
            return _slideOptions;
        }

        public async Task InitializeBulletinBoard()
        {
            if (_namedOptionsAccessor == null) throw new ArgumentNullException(nameof(_namedOptionsAccessor));

            var userFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var appDataFolder = Path.Combine(userFolder, "BulletinBoard");
            CreateDirectory(appDataFolder);
            CreateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.EventScreenSettings).FolderName));
            CreateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.ImageScreenSettings).FolderName));
            CreateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FolderName));
            CreateDirectory(Path.Combine(appDataFolder, _namedOptionsAccessor.Get(ElementSettings.BibleSettings).FolderName));

            await UpdateDirectory();

            var welcomeTask = Task.Run(() => TryToReadFile(_eventFileReader.ReadEvents, Path.Combine(appDataFolder,
                                                     _namedOptionsAccessor.Get(ElementSettings.EventScreenSettings).FolderName,
                                                     _namedOptionsAccessor.Get(ElementSettings.EventScreenSettings).FileName)));

            var plannerTask = Task.Run(() => TryToReadFile(_welcomeImageReader.ReadImage, Path.Combine(appDataFolder,
                                                    _namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FolderName,
                                                    _namedOptionsAccessor.Get(ElementSettings.WelcomeScreenSettings).FileName)));

            var imageTask = Task.Run(() => TryToReadFile(_imageFilesReader.ReadImages, Path.Combine(appDataFolder,
                                                    _namedOptionsAccessor.Get(ElementSettings.ImageScreenSettings).FolderName)));

            var bibleTask = Task.Run(() => TryToReadFile(_bibleFileReader.ReadBible, Path.Combine(appDataFolder,
                                                   _namedOptionsAccessor.Get(ElementSettings.BibleSettings).FolderName,
                                                   _namedOptionsAccessor.Get(ElementSettings.BibleSettings).FileName)));

            await Task.WhenAll(welcomeTask, plannerTask, imageTask, bibleTask);
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
                _logger.LogWarning(fex, "File not Found: {file}", fex.Message);
            }
            catch (DirectoryNotFoundException dex)
            {
                _logger.LogWarning(dex, "Directory not Found: {dict}", dex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cannot read file: {dict}", ex.Message);
            }
        }

        private async Task UpdateDirectory()
        {
            var syncservice = _syncOptions.FileName;
            if (string.IsNullOrEmpty(syncservice)) return;
            _logger.LogInformation("Start Filesync");
            await _fileUpdater.RunFileSync(_syncOptions);
        }

        #endregion Private Methods
    }
}