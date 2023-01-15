namespace BulletinBoard.Data
{
    public class ImageElement : IElement
    {
        #region Public Properties

        public string Base64Image { get; set; }
        public Guid Id { get; }

        #endregion Public Properties
    }
}