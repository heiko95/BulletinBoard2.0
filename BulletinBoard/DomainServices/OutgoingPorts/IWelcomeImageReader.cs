namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IWelcomeImageReader
    {
        #region Public Methods

        void ReadImage(string filePath);

        #endregion Public Methods
    }
}