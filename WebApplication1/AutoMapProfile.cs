using AutoMapper;
using WebApplication1.Data.Models;
using WebApplication1.Data.ViewModel;

namespace WebApplication1
{
    public class AutoMapProfile:Profile
    {
        public AutoMapProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();

            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(evw => evw.DepartmentName, opt => opt.MapFrom(em => em.DepartmentRef.Name))
                .ForMember(evw => evw.NationalityText, opt => opt.MapFrom(em => em.NationalityRef.Text))
                .ReverseMap()
                .ForPath(em => em.DepartmentRef.Name, opt => opt.Ignore())
                .ForPath(em => em.NationalityRef.Text, opt => opt.Ignore());
        }
    }
}
