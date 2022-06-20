using AutoMapper;
using RiseTech.Services.Reports.Entities.Dtos.ReportDtos;
using RiseTech.Services.Reports.Entities.Models;

namespace RiseTech.Services.Reports.Entities.Mapping
{
	public class ReportMapping : Profile
	{
		public ReportMapping()
		{
			//Contacts Maplama
			CreateMap<Report, ReportDto>().ReverseMap();
			CreateMap<Report, CreateReportDto>().ReverseMap();
		}
	}
}
