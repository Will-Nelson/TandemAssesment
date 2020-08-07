using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Repository.Model;
using TandemAssesment.Model;

namespace TandemAssesment.Factory
{
    
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserModel, UserViewModel>()
                .ForMember(dest => dest.FullName,
               opts => opts.MapFrom(src => src.FirstName + " " + src.MiddleName +" " + src.LastName));
            CreateMap<UserSaveModel, UserModel>();
        }
    }
}
