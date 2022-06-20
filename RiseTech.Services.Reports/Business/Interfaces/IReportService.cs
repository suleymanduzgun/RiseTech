using RiseTech.Common.Dtos;
using RiseTech.Services.Reports.Entities.Dtos.ReportDtos;

namespace RiseTech.Services.Reports.Business.Interfaces
{
	public interface IReportService
	{
		Task<OperationResponse<ReportDto>> GetByIdAsync(string id);
		Task<OperationResponse<List<ReportDto>>> GetAllAsync();
		Task<OperationResponse<ReportDto>> SetStatusByIdAsync(string id);
		Task<OperationResponse<ReportDto>> CreateAsync(CreateReportDto createReport);
	}
}
