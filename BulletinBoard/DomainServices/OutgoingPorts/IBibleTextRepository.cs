namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IBibleTextRepository
    {
        #region Public Methods

        string GetBibleText(string book, int chapter, int verse);

        #endregion Public Methods
    }
}