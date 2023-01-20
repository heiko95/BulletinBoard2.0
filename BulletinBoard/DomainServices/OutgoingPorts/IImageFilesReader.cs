namespace hgSoftware.DomainServices.OutgoingPorts
{
    public interface IImageFilesReader
    {
        #region Public Methods

        void ReadImages(string folderpath);

        #endregion Public Methods
    }
}