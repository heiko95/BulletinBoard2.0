using AutoMapper;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.OutgoingPorts;

namespace Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        #region Private Fields

        private readonly Context _context;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        public ImageRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public IList<ImageElement> GetImages()
        {
            return _mapper.Map<IList<ImageElement>>(_context.Images);
        }

        public ImageElement? GetWelcomeImage()
        {
            if (_context.WelcomeImage == null) return null;
            return _mapper.Map<ImageElement>(_context.WelcomeImage);
        }

        #endregion Public Methods
    }
}