using AutoMapper;
using MBApplication.Data;
using MBApplication.ViewModels;

namespace MBApplication.MappingProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() : this("MappingProfile")
        {
        }

        protected AutoMapperProfile(string profileName) : base(profileName)
        {
            CreateMap<Family, FamilyViewModel>().ReverseMap();
            CreateMap<Member, MemberViewModel>().ReverseMap();
            CreateMap<Membership, MembershipViewModel>().ReverseMap();
            CreateMap<Premise, PremiseViewModel>().ReverseMap();
        }
    }
}
