using AutoMapper;
using hgSoftware.DomainServices.Models;
using hgSoftware.Infrastructure.Models;

namespace hgSoftware.Infrastructure.Profiles
{
    public class EventToDomainProfile : Profile
    {
        #region Public Constructors

        public EventToDomainProfile()
        {
            {
                CreateMap<Event, PlannerEvent>()
                    .ForMember(dest => dest.BibleText, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.Book) ? $"{src.Book} {src.Chapter}, {src.Verse}" : string.Empty))
                    .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => new DateTime(src.Date.Year,
                                                                                              src.Date.Month,
                                                                                              src.Date.Day,
                                                                                              src.Time.Hour,
                                                                                              src.Time.Minute,
                                                                                              src.Time.Second)))

                    .ForMember(dest => dest.Date, opt => opt.Ignore())
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => string.Concat(src.EventDescription, " ", src.AdditionalInfo).Trim()))
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

                CreateMap<Event, BibleInfo>()
                   .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book!.Replace(" ", "")))
                   .ForMember(dest => dest.Chapter, opt => opt.MapFrom(src => src.Chapter))
                   .ForMember(dest => dest.VerseText, opt => opt.MapFrom(src => src.Verse));
            }
        }

        #endregion Public Constructors
    }
}