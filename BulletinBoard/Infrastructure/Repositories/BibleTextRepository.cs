using hgSoftware.DomainServices.OutgoingPorts;

namespace hgSoftware.Infrastructure.Repositories
{
    public class BibleTextRepository : IBibleTextRepository
    {
        #region Private Fields

        private readonly Context _context;

        #endregion Private Fields

        #region Public Constructors

        public BibleTextRepository(Context context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public string GetBibleText(string book, int chapter, int verse)
            => _context.BibleVerses.First(x => x.Book == book && x.Chapter == chapter && x.Verse == verse)?.Text ?? string.Empty;

        #endregion Public Methods
    }
}