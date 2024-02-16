using AutoMapper;
using ManagementSystem.Data.Dtos.Employees;
using ManagementSystem.Data.Entities.Employees;

namespace ManagementSystem.Business.AutoMapperConfiguration
{
    public class ManagementSystemMapperProfile : Profile
    {
        public ManagementSystemMapperProfile() 
        {
            CreateMappings();
        }

        private void CreateMappings()
        {
            CreateMap<Employee, EmployeeDto>()
                .ReverseMap()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
