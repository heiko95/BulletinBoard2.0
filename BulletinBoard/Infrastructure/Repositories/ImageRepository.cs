using AutoMapper;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.OutgoingPorts;

namespace hgSoftware.Infrastructure.Repositories
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

        public IList<ImageElement> GetImages(int maxCount)
        {
            return _mapper.Map<IList<ImageElement>>(_context.Images.Take(maxCount).ToList());
        }

        public ImageElement? GetWelcomeImage()
        {
            if (_context.WelcomeImage == null) return null;
            return _mapper.Map<ImageElement>(_context.WelcomeImage);
        }

        #endregion Public Methods
    }
}