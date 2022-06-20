using Microsoft.AspNetCore.Mvc;
using RiseTech.Common;
using RiseTech.Services.Reports.Business.Interfaces;
using RiseTech.Services.Reports.Entities.Dtos.ReportDtos;

namespace RiseTech.Services.Reports.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReportsController : RiseBaseController
	{
		private readonly IReportService _reportService;

		public ReportsController(IReportService ReportService)
		{
			_reportService=ReportService;
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateReportDto createReportDto)
		{
			if (!ModelState.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);

			var response = await _reportService.CreateAsync(createReportDto);
			return CreateActionResultInstance(response);
		}


		[HttpGet]
		[Route("/api/[controller]/GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var response = await _reportService.GetAllAsync();
			return CreateActionResultInstance(response);
		}


		[HttpGet]
		public async Task<IActionResult> GetById(string id)
		{
			var response = await _reportService.GetByIdAsync(id);
			return CreateActionResultInstance(response);
		}


		[HttpPut]
		public async Task<IActionResult> SetStatus(string id)
		{
			if (!ModelState.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);

			var response = await _reportService.SetStatusByIdAsync(id);
			return CreateActionResultInstance(response);
		}

	}
}
