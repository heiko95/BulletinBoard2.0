using CsvHelper;
using CsvHelper.Configuration;
using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.Infrastructure.Models;
using System.Globalization;
using System.Text;

namespace hgSoftware.Infrastructure.FileReaders
{
    public class BibleFileReader : IBibleFileReader
    {
        #region Private Fields

        private readonly Context _context;

        #endregion Private Fields

        #region Public Constructors

        public BibleFileReader(Context context)
        {
            _context = context;
        }

        #endregion Public Constructors

        #region Public Methods

        public void ReadBible(string filePath)
        {
            if (!File.Exists(filePath)) throw new FileNotFoundException(filePath);
            _context.BibleVerses.Clear();

            using var reader = new StreamReader(filePath);
            var configuration = new CsvConfiguration(new CultureInfo("de-DE"))
            {
                Encoding = Encoding.UTF8,
                Delimiter = ";",
                HasHeaderRecord = false
            };

            var csv = new CsvReader(reader, configuration);
            var headerRecord = csv.Read(); // Read Header Row
            while (csv.Read())
            {
                _context.BibleVerses.Add(new BibleVerse(csv.GetField(1)!,
                                                csv.GetField<int>(2),
                                                csv.GetField<int>(3)!,
                                                csv.GetField(4)!));
            }
        }

        #endregion Public Methods
    }
}