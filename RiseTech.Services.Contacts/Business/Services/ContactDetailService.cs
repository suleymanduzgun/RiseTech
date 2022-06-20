using AutoMapper;
using MongoDB.Driver;
using RiseTech.Common.Dtos;
using RiseTech.Services.Contacts.Business.Interfaces;
using RiseTech.Services.Contacts.Business.Settings;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;
using RiseTech.Services.Contacts.Entities.Models;
using System.Net;

namespace RiseTech.Services.Contacts.Business.Services
{
	public class ContactDetailService : IContactDetailService
	{
		private readonly IMongoCollection<ContactDetail> _contactDetailCollection;
		private readonly IMapper _mapper;

		public ContactDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);

			_contactDetailCollection=database.GetCollection<ContactDetail>(databaseSettings.ContactDetailCollectionName);
			_mapper=mapper;
		}


		public async Task<OperationResponse<ContactDetailDto>> CreateAsync(CreateContactDetailDto createContactDetail)
		{
			try
			{
				var contactDetail = _mapper.Map<ContactDetail>(createContactDetail);
				await _contactDetailCollection.InsertOneAsync(contactDetail);
				return OperationResponse<ContactDetailDto>.Success(_mapper.Map<ContactDetailDto>(contactDetail), "Kişi Detayı Ekleme İşlemi Başarılı", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ContactDetailDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<EmptyResponse>> DeleteAsync(string id)
		{
			try
			{
				var result = await _contactDetailCollection.DeleteOneAsync(x => x.Id==id);
				return result.DeletedCount > 0
				? OperationResponse<EmptyResponse>.Success(204)
				: OperationResponse<EmptyResponse>.Fail("Kayıt Bulunamadı!", 404);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<EmptyResponse>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<List<ContactDetailDto>>> GetAllAsync()
		{
			try
			{
				var contactDetails = await _contactDetailCollection.Find(ContactDetail => true).ToListAsync();
				return OperationResponse<List<ContactDetailDto>>.Success(_mapper.Map<List<ContactDetailDto>>(contactDetails), "Kişi Detayları Listesi Başarıyla Getirildi", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<List<ContactDetailDto>>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<ContactDetailDto>> GetByIdAsync(string id)
		{
			try
			{
				ContactDetail contactDetail = await _contactDetailCollection.Find<ContactDetail>(x => x.Id==id).FirstOrDefaultAsync();

				return contactDetail is null
					? OperationResponse<ContactDetailDto>.Fail("Kayıt Bulunamadı!", 404)
					: OperationResponse<ContactDetailDto>.Success(_mapper.Map<ContactDetailDto>(contactDetail), $"{id} Idli Kişi Detay Kaydı Getirme İşlemi Başarılı", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ContactDetailDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<ContactDetailDto>> UpdateAsync(UpdateContactDetailDto updateContactDetail)
		{
			try
			{
				var cd = await _contactDetailCollection.Find<ContactDetail>(x => x.Id==updateContactDetail.Id).FirstOrDefaultAsync();
				var contactDetail = _mapper.Map<ContactDetail>(updateContactDetail);
				contactDetail.ContactId=cd.ContactId;

				var result = await _contactDetailCollection.FindOneAndReplaceAsync(x => x.Id == contactDetail.Id, contactDetail);

				if (result is null)
					return OperationResponse<ContactDetailDto>.Fail("Kayıt Bulunamadı!", 404);
				return OperationResponse<ContactDetailDto>.Success(204);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ContactDetailDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}
	}
}
