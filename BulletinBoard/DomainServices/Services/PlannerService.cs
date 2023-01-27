using hgSoftware.DomainServices.IncomingPorts;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.OutgoingPorts;
using hgSoftware.DomainServices.SettingModels;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace hgSoftware.DomainServices.Services
{
    public class PlannerService : IPlannerService
    {
        #region Private Fields

        private readonly int _eventCount;
        private readonly IEventRepository _eventRepository;

        #endregion Private Fields

        #region Public Constructors

        public PlannerService(IEventRepository eventRepository, IOptionsMonitor<ElementSettings> namedOptionsAccessor)
        {
            _eventCount = namedOptionsAccessor.Get(ElementSettings.EventScreenSettings).DisplayCount;
            _eventRepository = eventRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        public PlannerElement? GetPlanner()
        {
            var plannerElement = new PlannerElement();

            var currentMonthDate = DateTime.Now;
            var nextMonthData = currentMonthDate.AddMonths(1);
            var currentMonth = new PlannerSection(CreateMonth(new DateOnly(currentMonthDate.Year, currentMonthDate.Month, currentMonthDate.Day), _eventCount), month: currentMonthDate.ToString("MMMM", new CultureInfo("de-DE")));
            var nextMonthEventCount = _eventCount - currentMonth.Events.Count;
            var followingMonth = new PlannerSection(CreateMonth(new DateOnly(nextMonthData.Year, nextMonthData.Month, 1), nextMonthEventCount), month: nextMonthData.ToString("MMMM", new CultureInfo("de-DE")));

            if (currentMonth.Events.Count > 0) plannerElement.AddPlannerSection(currentMonth);
            if (followingMonth.Events.Count > 0) plannerElement.AddPlannerSection(followingMonth);

            if (plannerElement.PlannerSections.Count == 0) return null;
            return plannerElement;
        }

        #endregion Public Methods

        #region Private Methods

        private IList<PlannerEvent> CreateMonth(DateOnly date, int count)
        {
            var eventElements = _eventRepository.GetEventsByDate(date).OrderBy(e => e.DateTime).GroupBy(e => e.DateTime.Day).ToList();
            var result = new List<PlannerEvent>();
            var elementCount = count;

            foreach (var eventElement in eventElements)
            {
                var first = eventElement.FirstOrDefault();
                if (first != null)
                {
                    first.Day = first.DateTime.ToString("ddd", new CultureInfo("de-DE"));
                    first.Date = first.DateTime.ToString("dd");
                }
                if (elementCount < eventElement.Count()) return result;
                elementCount = elementCount - eventElement.Count();
                result.AddRange(eventElement);
            }
            return result;
        }

        #endregion Private Methods
    }
}