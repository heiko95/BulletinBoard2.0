namespace BulletinBoard.Data
{
    public class BibleTextElement : IElement
    {
        #region Public Properties

        public string BiblePassage { get; set; }
        public string BibleText { get; set; }
        public Guid Id { get; }

        #endregion Public Properties
    }
}