using AutoMapper;
using BusisLevel.ModelDTO;
using DBLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusisLevel.Util
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Student, StudentDTO>().ForMember(x => x.GroupName, opt => opt.MapFrom(x => x.Groups.Name));
            CreateMap<StudentDTO, Student>().ForMember(x => x.Groups, opt => opt.MapFrom(x => new Groups { Name = x.GroupName }));
            CreateMap<GroupDTO, Groups>();
            CreateMap<Groups, GroupDTO>();
        }
    }
}
