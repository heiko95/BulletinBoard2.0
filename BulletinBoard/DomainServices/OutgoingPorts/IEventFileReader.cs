namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IEventFileReader
    {
        #region Public Methods

        void ReadEvents(string filePath);

        #endregion Public Methods
    }
}