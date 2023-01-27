using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.DomainServices.SettingModels;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace hgSoftware.Infrastructure.Updater
{
    public class FileUpdater : IFileUpdater
    {
        #region Private Fields

        private readonly ILogger<IFileUpdater> _logger;

        #endregion Private Fields

        #region Public Constructors

        public FileUpdater(ILogger<IFileUpdater> logger)
        {
            _logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task RunFileSync(SyncSettings syncSettings)
        {
            var filename = syncSettings.FileName;
            if (!File.Exists(filename))
            {
                _logger.LogError("Sync Service {service} not found", filename);
            }
            await Task.Run(() =>
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = filename,
                        Arguments = syncSettings.Arguments,
                        RedirectStandardOutput = true,
                        CreateNoWindow = syncSettings.Hidden
                    }
                };

                process.Start();
                process.WaitForExit(syncSettings.Timeout);
                process.Refresh();
                if (!process.HasExited)
                {
                    _logger.LogWarning("Sync Service {service} Timeout", filename);
                    if (syncSettings.KillAfterTimeout)
                    {
                        process.Kill();
                        _logger.LogWarning("Sync Service {service} killed", filename);
                    }
                    return;
                }
                _logger.LogInformation("Sync Service {service} done", filename);
                return;
            });
        }

        #endregion Public Methods
    }
}