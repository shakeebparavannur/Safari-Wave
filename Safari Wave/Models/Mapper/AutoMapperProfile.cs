using AutoMapper;
using Safari_Wave.Models.DTOs;
using Safari_Wave.Models.DTOs.Booking;
using Safari_Wave.Models.DTOs.Enquiry;
using Safari_Wave.Models.DTOs.Order;
using Safari_Wave.Models.DTOs.Review;
using Safari_Wave.Models.DTOs.Users;

namespace Safari_Wave.Models.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Package, GetPackageDto>().ReverseMap();
            CreateMap<Package, CreatePackageDto>().ReverseMap();
            CreateMap<Booking, BookingResponseIdDTO>().
                ForMember(dest => dest.Package, opt => opt.MapFrom(src => src.Package)).
                ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User)).ReverseMap();
            CreateMap<UserDTO, UserDatum>().ReverseMap();
            CreateMap<Order, MakeOrderDTO>().ReverseMap();
            CreateMap<CreateUserDTO, UserDatum>().ReverseMap();
            CreateMap<UpdateUserDTO, UserDatum>().ReverseMap();
            CreateMap<BookingResponseDTO, Booking>().ReverseMap();
            CreateMap<CreateBookingDTO, Booking>().ReverseMap();
            CreateMap<CreateBookingDTO, BookingResponseDTO>().ReverseMap();
            CreateMap<BookingUpdateDTO, BookingResponseDTO>().ReverseMap();
            CreateMap<CreateEnquiryDTO, Enquiry>().ReverseMap();
            CreateMap<UpdateEnquiryDTO, Enquiry>().ReverseMap();
            CreateMap<ReviewReqDTO, Review>().ReverseMap();

        }
    }
}
