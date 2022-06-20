using AutoMapper;
using MongoDB.Driver;
using Moq;
using RiseTech.Services.Contacts.Business.Settings;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;
using RiseTech.Services.Contacts.Entities.Models;
using Xunit;

namespace Services.Contacts.Test.Businesses
{
	public class ContactDetailServiceTests
	{
		//readonly Mock<IMongoCollection<ContactDetail>> _contactDetailCollection;
		//readonly Mock<IMapper> _mapper;
		//readonly Mock<IDatabaseSettings> _databaseSettings;

		//public ContactDetailServiceTests(IDatabaseSettings databaseSettings)
		//{
		//	_mapper = new Mock<IMapper>();
		//	_databaseSettings = (Mock<IDatabaseSettings>?)databaseSettings;

		//	var client = new MongoClient(_databaseSettings?.Object.ConnectionString);
		//	var database = client.GetDatabase(_databaseSettings.Object.DatabaseName);

		//	_contactDetailCollection= (Mock<IMongoCollection<ContactDetail>>)database.GetCollection<ContactDetail>(_databaseSettings.Object.ContactDetailCollectionName);

		//}



		//[Fact]
		//public async void ContactDetailService_Create_Success()
		//{
		//	_mapper.Setup(x => x.Map(It.IsAny<CreateContactDetailDto>(), It.IsAny<ContactDetail>())).Returns(new ContactDetail());


		//				await _contactDetailCollection.Object.InsertOneAsync(new ContactDetail());
		//	// as ObjectResult;

		//}

	}
}
