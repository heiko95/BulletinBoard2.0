using BulletinBoard.Services.Contracts;
using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;

namespace BulletinBoard.Services
{
    public class BoardElementService : IBoardElementService
    {
        #region Private Fields

        private readonly IBibleTextService _bibleTextService;
        private readonly IImageService _imageService;
        private readonly IInitService _initService;
        private readonly IPlannerService _plannerService;
        private readonly IWelcomeService _welcomeService;

        #endregion Private Fields

        #region Public Constructors

        public BoardElementService(
            IWelcomeService welcomeService,
            IImageService imageService,
            IPlannerService plannerService,
            IBibleTextService bibleTextService,
            IInitService initService)
        {
            _welcomeService = welcomeService;
            _imageService = imageService;
            _plannerService = plannerService;
            _bibleTextService = bibleTextService;
            _initService = initService;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IList<IElement>> GetCurrentElements()
        {
            return await Task.Run(() =>
            {
                var elements = new List<IElement>();
                elements.AddIfNotNull(_welcomeService.GetWelcomePicture());
                elements.AddIfNotNull(_plannerService.GetPlanner());
                elements.AddIfNotNull(_bibleTextService.GetBibleElementOfToday());
                elements.AddRange(_imageService.GetPictures());
                return elements;
            });
        }

        public async Task InitElements()
        {
            await _initService.InitializeBulletinBoard();
        }

        #endregion Public Methods
    }
}