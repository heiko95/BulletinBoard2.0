using AutoMapper;
using hgSoftware.DomainServices.Models;
using hgSoftware.DomainServices.OutgoingPorts;

namespace hgSoftware.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        #region Private Fields

        private readonly Context _context;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        public EventRepository(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public BibleInfo GetBibleInfoByDate(DateOnly date, TimeOnly time)
        {
            var events = _context.Events.Where(e => e.Date.Day == date.Day && e.Date.Month == date.Month && e.Date.Year == date.Year && !string.IsNullOrEmpty(e.Book))
                                        .ToList();

            if (events.Count == 0) return new BibleInfo();
            if (events.Count == 1) return _mapper.Map<BibleInfo>(events.First());

            return _mapper.Map<BibleInfo>(events
                .Where(x => x.Time.TimeOfDay >= time.ToTimeSpan())
                .OrderBy(x => (x.Time.TimeOfDay - time.ToTimeSpan()).TotalMilliseconds)
                .FirstOrDefault() ?? events.Last());
        }

        public IList<PlannerEvent> GetEventsByDate(DateOnly date)
                    => _mapper.Map<IList<PlannerEvent>>(_context.Events.Where(e => e.Date.Day >= date.Day && e.Date.Month == date.Month && e.Date.Year == date.Year).ToList()) ?? new List<PlannerEvent>();

        #endregion Public Methods
    }
}