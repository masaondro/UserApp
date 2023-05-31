using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserCRUD.Contracts.User;
using UserCRUD.Domain.User;

namespace UserCRUD.Infrastructure.MapProfiles
{
    /// <summary>
    /// Профиль маппера для User.
    /// </summary>
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>(MemberList.None)
                .ForMember(d => d.Guid, map => map.MapFrom(s => s.Id))
                .ForMember(d => d.Login, map => map.MapFrom(s => s.Login))
                .ForMember(d => d.Password, map => map.MapFrom(s => s.Password))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
                .ForMember(d => d.Gender, map => map.MapFrom(s => s.Gender))
                .ForMember(d => d.Birthday, map => map.MapFrom(s => s.Birthday))
                .ForMember(d => d.Admin, map => map.MapFrom(s => s.Admin))
                .ForMember(d => d.CreatedOn, map => map.MapFrom(s => DateTime.UtcNow))
                .ForMember(d => d.CreatedBy, map => map.MapFrom(s => s.CreatedBy))
                .ForMember(d => d.ModifiedOn, map => map.MapFrom(s => s.ModifiedOn))
                .ForMember(d => d.ModifiedBy, map => map.MapFrom(s => s.ModifiedBy))
                .ForMember(d => d.RevokedOn, map => map.MapFrom(s => s.RevokedOn))
                .ForMember(d => d.RevokedBy, map => map.MapFrom(s => s.RevokedBy));
        }
    }
}
