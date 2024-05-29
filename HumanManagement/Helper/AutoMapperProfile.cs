using AutoMapper;
using HumanManagement.DataAccess.DTOs;
using HumanManagement.DataAccess.Models;
using System.Security.Claims;

namespace HumanManagement.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, LoginDTO>();
            CreateMap<Attachment, AttachmentDTO>().ReverseMap();
            CreateMap<Claim, ClaimDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
