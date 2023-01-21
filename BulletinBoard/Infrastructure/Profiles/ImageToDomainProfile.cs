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
                .ForMember(dest => dest.Base64Image, opt => opt.MapFrom(src => src.ImageBase64))
                .ForMember(dest => dest.ImageName, opt => opt.MapFrom(src => Path.GetFileName(src.ImagePath)));
        }

        #endregion Public Constructors
    }
}