using AutoMapper;
using MongoDB.Driver;
using RiseTech.Common.Dtos;
using RiseTech.Common.Helpers;
using RiseTech.Services.Reports.Business.Interfaces;
using RiseTech.Services.Reports.Business.Settings;
using RiseTech.Services.Reports.Entities.Dtos.ReportDtos;
using RiseTech.Services.Reports.Entities.Models;
using System.Net;
using static RiseTech.Common.Enums;

namespace RiseTech.Services.Reports.Business.Services
{
	public class ReportService : IReportService
	{
		private readonly IMongoCollection<Report> _reportCollection;
		private readonly IMapper _mapper;

		public ReportService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);

			_reportCollection=database.GetCollection<Report>(databaseSettings.ReportCollectionName);
			_mapper=mapper;
		}


		public async Task<OperationResponse<ReportDto>> CreateAsync(CreateReportDto createReport)
		{
			try
			{
				var Report = _mapper.Map<Report>(createReport);
				await _reportCollection.InsertOneAsync(Report);
				return OperationResponse<ReportDto>.Success(_mapper.Map<ReportDto>(Report), "Rapor Ekleme İşlemi Başarılı", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ReportDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<List<ReportDto>>> GetAllAsync()
		{
			try
			{
				var Reports = await _reportCollection.Find(Report => true).ToListAsync();
				return OperationResponse<List<ReportDto>>.Success(_mapper.Map<List<ReportDto>>(Reports), "Rapor Listesi Başarıyla Getirildi", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<List<ReportDto>>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<ReportDto>> GetByIdAsync(string id)
		{
			try
			{
				Report Report = await _reportCollection.Find<Report>(x => x.Id==id).FirstOrDefaultAsync();
				if (Report is null)
					return OperationResponse<ReportDto>.Fail("Kayıt Bulunamadı!", 404);

				return OperationResponse<ReportDto>.Success(_mapper.Map<ReportDto>(Report), $"{id} Idli Rapor Kaydı Getirme İşlemi Başarılı", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ReportDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}

		public async Task<OperationResponse<ReportDto>> SetStatusByIdAsync(string id)
		{
			try
			{
				Report Report = await _reportCollection.Find<Report>(x => x.Id==id).FirstOrDefaultAsync();
				if (Report is null)
					return OperationResponse<ReportDto>.Fail("Kayıt Bulunamadı!", 404);

				Report.ReportStatus = ReportStatusEnums.Completed.GetEnumDescription();

				var result = await _reportCollection.FindOneAndReplaceAsync(x => x.Id ==Report.Id, Report);

				return OperationResponse<ReportDto>.Success(204);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ReportDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


	}
}
