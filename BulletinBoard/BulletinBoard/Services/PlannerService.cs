using BulletinBoard.Data;
using BulletinBoard.Services.Contracts;

namespace BulletinBoard.Services
{
    public class PlannerService : IPlannerService
    {
        #region Public Methods

        public PlannerElement GetPlanner()
        {
            return DefaultData();
        }

        #endregion Public Methods

        #region Private Methods

        private IList<PlannerEvent> CreateTestElements(int count, string month)
        {
            if (count < 0 || count > 9) count = 9;
            var elements = new List<PlannerEvent>();

            for (var i = 0; i < count; i++)
            {
                elements.Add(new PlannerEvent()
                {
                    Day = Day.So,
                    Date = $"0{count}.{month}",
                    Time = "09:30",
                    Description = "Gottestdienst",
                    BibleText = "2. Mose 2,2",
                    Location = "Desertred"
                });
            }
            return elements;
        }

        private PlannerElement DefaultData()
        {
            return new PlannerElement()
            {
                CurrentMonth = new PlannerSection()
                {
                    Month = "Januar",
                    Events = CreateTestElements(7, "01")
                },
                FollowingMonth = new PlannerSection()
                {
                    Month = "Februar",
                    Events = CreateTestElements(3, "02")
                }
            };
        }

        #endregion Private Methods
    }
}