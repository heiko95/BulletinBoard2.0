namespace hgSoftware.Infrastructure.Models
{
    public class Event
    {
        #region Public Properties

        public string? AdditionalInfo { get; set; }
        public string? Book { get; set; }
        public string? Chapter { get; set; }
        public DateTime Date { get; set; }
        public string? EventDescription { get; set; }
        public string? Location { get; set; }
        public string? Person { get; set; }
        public DateTime Time { get; set; }
        public string? Verse { get; set; }

        #endregion Public Properties
    }
}