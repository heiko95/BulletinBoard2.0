﻿using AutoMapper;
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

        public BibleInfo GetBibleInfoByDate(int day, int month, int year)
            => _mapper.Map<BibleInfo>(_context.Events.FirstOrDefault(e => e.Date.Day == day && e.Date.Month == month && e.Date.Year == year)) ?? new BibleInfo();

        public IList<PlannerEvent> GetEventsByDate(int day, int month, int year)
                    => _mapper.Map<IList<PlannerEvent>>(_context.Events.Where(e => e.Date.Day >= day && e.Date.Month == month && e.Date.Year == year).ToList()) ?? new List<PlannerEvent>();

        #endregion Public Methods
    }
}