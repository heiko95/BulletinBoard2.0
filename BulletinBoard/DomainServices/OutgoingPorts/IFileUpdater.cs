using hgSoftware.DomainServices.SettingModels;

namespace hgSoftware.DomainServices.OutgoingPorts;

public interface IFileUpdater
{
    #region Public Methods

    Task RunFileSync(SyncSettings syncSettings);

    #endregion Public Methods
}