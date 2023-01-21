using System.Text.RegularExpressions;

namespace hgSoftware.DomainServices.Models
{
    public class BibleInfo
    {
        #region Public Properties

        public string Book { get; set; } = string.Empty;
        public string Chapter { get; set; } = string.Empty;
        public IList<int> Verses => GetVerses(VerseText);
        public string VerseText { get; set; } = string.Empty;

        #endregion Public Properties

        #region Public Methods

        public bool IsEmpty()
            => string.IsNullOrWhiteSpace(Chapter) || string.IsNullOrWhiteSpace(VerseText) || string.IsNullOrWhiteSpace(Book);

        #endregion Public Methods

        #region Private Methods

        private static List<int> GetVerses(string versetext)
        {
            if (!Regex.IsMatch(versetext, "^([0-9]+([-.][0-9]+)?)(&[0-9]+([-.][0-9]+)?)?$")) throw new FormatException(versetext);

            var verses = new List<int>();
            var sections = versetext.Split('&');
            foreach (var section in sections)
            {
                if (Regex.IsMatch(section, "^[0-9]+$"))
                    verses.Add(int.Parse(section));
                if (Regex.IsMatch(section, "^[0-9]+\\.[0-9]+?$"))
                    verses.AddRange(from verse in section.Split('.')
                                    select int.Parse(verse));
                if (Regex.IsMatch(section, "^[0-9]+-[0-9]+?$"))
                {
                    var verse = section.Split('-');
                    for (var i = int.Parse(verse[0]); i <= int.Parse(verse[1]); i++)
                    {
                        verses.Add(i);
                    }
                }
            }
            verses.Sort();
            return verses.Distinct().ToList();
        }

        #endregion Private Methods
    }
}