using BulletinBoard.Data;
using BulletinBoard.Services.Contracts;

namespace BulletinBoard.Services
{
    public class BoardElementService : IBoardElementService
    {
        #region Private Fields

        private readonly IBibleTextService _bibleTextService;
        private readonly IImageService _imageService;
        private readonly IPlannerService _plannerService;
        private readonly IWelcomeService _welcomeService;

        #endregion Private Fields

        #region Public Constructors

        public BoardElementService(
            IWelcomeService welcomeService,
            IImageService imageService,
            IPlannerService plannerService,
            IBibleTextService bibleTextService)
        {
            _welcomeService = welcomeService;
            _imageService = imageService;
            _plannerService = plannerService;
            _bibleTextService = bibleTextService;
        }

        #endregion Public Constructors

        #region Public Methods

        public IList<IElement> GetCurrentElements()
        {
            var elements = new List<IElement>();
            elements.Add(_welcomeService.GetWelcomePicture());
            elements.Add(_bibleTextService.GetBibleElementOfToday());
            elements.Add(_plannerService.GetPlanner());
            elements.AddRange(_imageService.GetPictures());
            return elements;
        }

        #endregion Public Methods
    }
}