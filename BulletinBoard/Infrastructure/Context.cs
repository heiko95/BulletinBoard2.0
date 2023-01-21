using hgSoftware.Infrastructure.Models;

namespace hgSoftware.Infrastructure
{
    public class Context
    {
        #region Public Properties

        public IList<BibleVerse> BibleVerses { get; set; } = new List<BibleVerse>();
        public IList<Event> Events { get; set; } = new List<Event>();
        public IList<Image> Images { get; set; } = new List<Image>();
        public Image? WelcomeImage { get; set; }

        #endregion Public Properties
    }
}