namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IBibleFileReader
    {
        #region Public Methods

        void ReadBible(string filePath);

        #endregion Public Methods
    }
}