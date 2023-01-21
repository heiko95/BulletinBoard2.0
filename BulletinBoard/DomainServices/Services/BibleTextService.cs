using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.OutgoingPorts;
using Microsoft.Extensions.Logging;
using System.Text;

namespace hgSoftware.DomainServices.Services
{
    public class BibleTextService : IBibleTextService
    {
        #region Private Fields

        private readonly IBibleTextRepository _bibleTextRepository;
        private readonly IEventRepository _eventRepository;
        private readonly ILogger<IBibleTextService> _logger;

        #endregion Private Fields

        #region Public Constructors

        public BibleTextService(IEventRepository eventRepository,
                                IBibleTextRepository bibleTextRepository,
                                ILogger<IBibleTextService> logger)
        {
            _eventRepository = eventRepository;
            _bibleTextRepository = bibleTextRepository;
            _logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        public BibleTextElement? GetBibleElementOfToday()
        {
            var date = DateTime.Now;
            var bibleInfo = _eventRepository.GetBibleInfoByDate(date.Day, date.Month, date.Year);

            if (bibleInfo.IsEmpty()) return null;

            try
            {
                var bibeltextElement = new BibleTextElement
                {
                    BiblePassage = $"{bibleInfo.Book} {bibleInfo.Chapter}, {bibleInfo.VerseText}"
                };

                var builder = new StringBuilder();
                foreach (var verse in bibleInfo.Verses)
                {
                    builder.Append(_bibleTextRepository.GetBibleText(bibleInfo.Book, int.Parse(bibleInfo.Chapter), verse)).Append(" ");
                }
                bibeltextElement.BibleText = builder.ToString();
                return bibeltextElement;
            }
            catch (FormatException ex)
            {
                _logger.LogWarning(ex, "BibelVerse has Wrong Format: {verse}", ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Cannot Create BibleElement: {Error}", ex.Message);
                return null;
            }
        }

        #endregion Public Methods
    }
}