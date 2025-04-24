using AutoMapper;
using Leave_Management_System.Entities;

namespace Leave_Management_System.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequests, LeaveRequestDto>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FullName))
                .ForMember(dest => dest.EmployeeDepartment, opt => opt.MapFrom(src => src.Employee.Department))
                .ForMember(dest => dest.LeaveType, opt => opt.MapFrom(src => src.LeaveType.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                .ForMember(dest => dest.Reason, opt => opt.MapFrom(src => src.Reason));
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
