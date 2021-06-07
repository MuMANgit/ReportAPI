using AutoMapper;
using ReportAPP.BLL.DTO;
using ReportAPP.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportAPP.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();

            CreateMap<Report, ReportDTO>();
            CreateMap<ReportDTO, Report>();
        }
    }
}
