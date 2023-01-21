using BulletinBoard.Services.Contracts;
using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.SettingModels;

namespace BulletinBoard.Services
{
    public class BoardElementService : IBoardElementService
    {
        #region Private Fields

        private readonly IBibleTextService _bibleTextService;
        private readonly IImageService _imageService;
        private readonly IInitService _initService;
        private readonly ILogger<IBoardElementService> _logger;
        private readonly IPlannerService _plannerService;
        private readonly IWelcomeService _welcomeService;

        #endregion Private Fields

        #region Public Constructors

        public BoardElementService(
            IWelcomeService welcomeService,
            IImageService imageService,
            IPlannerService plannerService,
            IBibleTextService bibleTextService,
            IInitService initService,
            ILogger<IBoardElementService> logger)
        {
            _welcomeService = welcomeService;
            _imageService = imageService;
            _plannerService = plannerService;
            _bibleTextService = bibleTextService;
            _initService = initService;
            _logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IList<IElement>> GetCurrentElements()
        {
            return await Task.Run(() =>
            {
                _logger.LogInformation("Load Elements");
                var elements = new List<IElement>();
                elements.AddIfNotNull(_welcomeService.GetWelcomePicture());
                elements.AddIfNotNull(_plannerService.GetPlanner());
                elements.AddIfNotNull(_bibleTextService.GetBibleElementOfToday());
                elements.AddRange(_imageService.GetPictures());
                _logger.LogInformation("Load Elements done");
                return elements;
            });
        }

        public SlideSettings GetSlideSettings() => _initService.GetSlideSettings();

        public async Task InitElements()
        {
            _logger.LogInformation("Start Initialisation");
            await _initService.InitializeBulletinBoard();
            _logger.LogInformation("Initialisation done");
        }

        #endregion Public Methods
    }
}