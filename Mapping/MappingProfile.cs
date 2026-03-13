using AutoMapper;
using LibraryManagement.DTOs;
using LibraryManagement.Models;
namespace LibraryManagement.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<BookCreateDTO, Book>();
            CreateMap<BookUpdateDTO, Book>();
            CreateMap<RegisterDTO, User>()
                .ForMember(dest => dest.PasswordHash,opt => opt.Ignore());
            CreateMap<User, UserDTO>();
        }


    }
}
