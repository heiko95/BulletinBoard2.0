using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;

namespace hgSoftware.DomainServices.Services
{
    public class BibleTextService : IBibleTextService
    {
        #region Public Methods

        public BibleTextElement GetBibleElementOfToday()
        {
            //TODO
            return DefaultData();
        }

        #endregion Public Methods

        #region Private Methods

        private BibleTextElement DefaultData()
        {
            return new BibleTextElement()
            {
                BiblePassage = "2. Mose 2,2",
                BibleText = "2 Und sie ward schwanger und gebar einen Sohn. Und als sie sah, dass es ein feines Kind war, verbarg sie ihn drei Monate."
            };
        }

        #endregion Private Methods
    }
}