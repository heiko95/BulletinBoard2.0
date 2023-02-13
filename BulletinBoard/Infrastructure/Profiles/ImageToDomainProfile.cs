using AutoMapper;
using hgSoftware.DomainServices.Models;
using hgSoftware.Infrastructure.Models;

namespace hgSoftware.Infrastructure.Profiles
{
    public class ImageToDomainProfile : Profile
    {
        #region Public Constructors

        public ImageToDomainProfile()
        {
            CreateMap<Image, ImageElement>()
                .ForMember(dest => dest.Base64Image,
                           opt => opt.MapFrom(src => src.ImageBase64))

                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.ImageName))

                .ForMember(dest => dest.Date,
                               opt => opt.MapFrom(src => src.ImageDate));

            CreateMap<Image, WelcomeElement>()
               .ForMember(dest => dest.Base64Image,
                          opt => opt.MapFrom(src => src.ImageBase64))

               .ForMember(dest => dest.Name,
                          opt => opt.MapFrom(src => src.ImageName));
        }

        #endregion Public Constructors
    }
}