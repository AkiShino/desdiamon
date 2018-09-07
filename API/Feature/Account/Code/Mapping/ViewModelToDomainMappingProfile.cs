using Api.Foundation.Data.Dtos;
using Api.Foundation.Data.Model;
using AutoMapper;
using System;

namespace Api.Feature.Account.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
        [Obsolete("Create a constructor and configure inside of your profile's constructor instead. Will be removed in 6.0")]
        protected void Configure()
        {
            CreateMap<UserInfoDto, M_User>();
        }
    }
}