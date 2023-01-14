using BulletinBoard.Data;

namespace BulletinBoard.Services.Contracts
{
    public interface IBibleTextService
    {
        #region Public Methods

        BibleTextElement GetBibleElementOfToday();

        #endregion Public Methods
    }
}