namespace hgSoftware.DomainServices.SettingModels
{
    public class SyncSettings
    {
        #region Public Properties

        public string Arguments { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public bool Hidden { get; set; }
        public bool KillAfterTimeout { get; set; }
        public int Timeout { get; set; }

        #endregion Public Properties
    }
}