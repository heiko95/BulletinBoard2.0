using CsvHelper;
using CsvHelper.Configuration;
using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.Infrastructure.Models;
using System.Globalization;
using System.Text;

namespace hgSoftware.Infrastructure.FileReaders
{
    public class EventFileReader : IEventFileReader
    {
        #region Private Fields

        private readonly Context _context;

        #endregion Private Fields

        #region Public Constructors

        public EventFileReader(Context context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public void ReadEvents(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
            _context.Events.Clear();

            using var reader = new StreamReader(filePath);
            var configuration = new CsvConfiguration(new CultureInfo("de-DE"))
            {
                Encoding = Encoding.UTF8,
                Delimiter = ";",
                HasHeaderRecord = false
            };

            var csv = new CsvReader(reader, configuration);
            while (csv.Read())
            {
                var @event = new Event
                {
                    Date = csv.GetField<DateTime>(0),
                    Time = csv.GetField<DateTime>(1),
                    EventDescription = csv.GetField(2),
                    AdditionalInfo = csv.GetField(3),
                    Person = csv.GetField(4),
                    Location = csv.GetField(5),
                    Book = csv.GetField(6),
                    Chapter = csv.GetField(7),
                    Verse = csv.GetField(8)
                };

                _context.Events.Add(@event);
            }
        }

        #endregion Public Methods
    }
}