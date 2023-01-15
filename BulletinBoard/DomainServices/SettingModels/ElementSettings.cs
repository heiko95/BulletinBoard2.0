namespace hgSoftware.DomainServices.SettingModels
{
    public class ElementSettings
    {
        #region Public Fields

        public const string EventScreenSettings = nameof(EventScreenSettings);
        public const string ImageScreenSettings = nameof(ImageScreenSettings);
        public const string WelcomeScreenSettings = nameof(WelcomeScreenSettings);

        #endregion Public Fields

        #region Public Properties

        public int DisplayCount { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;

        #endregion Public Properties
    }
}