using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.IncomingPorts
{
    public interface IBibleTextService
    {
        #region Public Methods

        BibleTextElement GetBibleElementOfToday();

        #endregion Public Methods
    }
}