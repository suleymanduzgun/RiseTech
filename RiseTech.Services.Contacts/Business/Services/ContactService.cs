using AutoMapper;
using MongoDB.Driver;
using RiseTech.Common.Dtos;
using RiseTech.Services.Contacts.Business.Interfaces;
using RiseTech.Services.Contacts.Business.Settings;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDtos;
using RiseTech.Services.Contacts.Entities.Models;
using System.Net;

namespace RiseTech.Services.Contacts.Business.Services
{
	public class ContactService : IContactService
	{
		private readonly IMongoCollection<Contact> _contactCollection;
		private readonly IMongoCollection<ContactDetail> _contactDetailCollection;
		private readonly IMapper _mapper;

		public ContactService(IMapper mapper, IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);

			_contactCollection=database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
			_contactDetailCollection=database.GetCollection<ContactDetail>(databaseSettings.ContactDetailCollectionName);
			_mapper=mapper;
		}


		public async Task<OperationResponse<ContactDto>> CreateAsync(CreateContactDto createContact)
		{
			try
			{
				var contact = _mapper.Map<Contact>(createContact);
				await _contactCollection.InsertOneAsync(contact);
				return OperationResponse<ContactDto>.Success(_mapper.Map<ContactDto>(contact), "Kişi Ekleme İşlemi Başarılı", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ContactDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<ContactWithDetailDto>> CreateWithDetailAsync(CreateContactWithDetailDto createContact)
		{
			try
			{
				var contact = _mapper.Map<Contact>(createContact);
				await _contactCollection.InsertOneAsync(contact);

				var contactDetail = _mapper.Map<ContactDetail>(createContact.DetailDto);
				if (contact.Id != null)
					contactDetail.ContactId = contact.Id;

				await _contactDetailCollection.InsertOneAsync(contactDetail);

				var dto = new ContactWithDetailDto
				{
					Id = contact.Id,
					FirstName=contact.FirstName,
					LastName=contact.LastName,
					Firm=contact.Firm,
					ContactDetail = new List<ContactDetail> { contactDetail }
				};

				return OperationResponse<ContactWithDetailDto>.Success(dto, "Kişinin Detay Bilgileriyle Ekleme İşlemi Başarılı", 200);

			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ContactWithDetailDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<EmptyResponse>> DeleteAsync(string id)
		{
			try
			{
				// I. Adım  => Detay Bilgilerini Sil.
				var detailResult = _contactDetailCollection.DeleteManyAsync(x => x.ContactId==id);

				// II. Adım => Rehberden kişiyi Sil.
				var result = await _contactCollection.DeleteOneAsync(x => x.Id==id);
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


		public async Task<OperationResponse<List<ContactDto>>> GetAllAsync()
		{
			try
			{
				var contacts = await _contactCollection.Find(Contact => true).ToListAsync();
				return OperationResponse<List<ContactDto>>.Success(_mapper.Map<List<ContactDto>>(contacts), "Kişi Listesi Başarıyla Getirildi", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<List<ContactDto>>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<List<ContactWithDetailDto>>> GetAllWithDetailAsync()
		{
			try
			{
				var contacts = await _contactCollection.Find(Contact => true).ToListAsync() ?? new List<Contact>();

				if (contacts.Any())
					foreach (var contact in contacts)
						contact.ContactDetail = await _contactDetailCollection.Find(x => x.ContactId==contact.Id).ToListAsync();

				return OperationResponse<List<ContactWithDetailDto>>.Success(_mapper.Map<List<ContactWithDetailDto>>(contacts), "Kişi Listesi Başarıyla Getirildi", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<List<ContactWithDetailDto>>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<ContactDto>> GetByIdAsync(string id)
		{
			try
			{
				Contact contact = await _contactCollection.Find<Contact>(x => x.Id==id).FirstOrDefaultAsync();
				if (contact is null)
					return OperationResponse<ContactDto>.Fail("Kayıt Bulunamadı!", 404);

				return OperationResponse<ContactDto>.Success(_mapper.Map<ContactDto>(contact), $"{id} Idli Kişi Kaydı Getirme İşlemi Başarılı", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ContactDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<ContactWithDetailDto>> GetByIdWithDetailAsync(string id)
		{
			try
			{
				Contact contact = await _contactCollection.Find<Contact>(x => x.Id==id).FirstOrDefaultAsync();
				if (contact is null)
					return OperationResponse<ContactWithDetailDto>.Fail("Kayıt Bulunamadı!", 404);

				contact.ContactDetail = await _contactDetailCollection.Find(x => x.ContactId==contact.Id).ToListAsync();
				return OperationResponse<ContactWithDetailDto>.Success(_mapper.Map<ContactWithDetailDto>(contact), $"{id} Idli Kişi Kaydı Getirme İşlemi Başarılı", 200);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ContactWithDetailDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


		public async Task<OperationResponse<ContactDto>> UpdateAsync(UpdateContactDto updateContact)
		{
			try
			{
				var contact = _mapper.Map<Contact>(updateContact);
				var result = await _contactCollection.FindOneAndReplaceAsync(x => x.Id ==contact.Id, contact);

				if (result is null)
					return OperationResponse<ContactDto>.Fail("Kayıt Bulunamadı!", 404);
				return OperationResponse<ContactDto>.Success(204);
			}
			catch (WebException we)
			{
				HttpWebResponse? response = ((HttpWebResponse?)we.Response);
				HttpStatusCode wRespStatusCode = response == null ? HttpStatusCode.Ambiguous : response.StatusCode;
				return OperationResponse<ContactDto>.Fail(we.Message, wRespStatusCode.GetHashCode());
			}
		}


	}
}
