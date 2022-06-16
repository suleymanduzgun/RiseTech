using RiseTech.Services.Contacts.Entities.Models;
using Xunit;

namespace Services.Contacts.Test.Entities
{
	public class ModelsContactTests
	{
		[Fact]
		public void Contact_Test()
		{
			ContactDetail? detail = new ContactDetail
			{
				Id ="62a8b715996fea8613167414",
				ContactId ="62a8b72e996fea8613167415",
				PhoneNumber ="5555555555",
				EmailAddress="test@test.com",
				Location ="Mardin"
			};

			var dto = new Contact
			{
				Id="62a9db6c281d40dd910f22f1",
				FirstName="test",
				LastName="test",
				Firm="test",
				ContactDetail=detail
			};

			var id = dto.Id;
			var _FirstName = dto.FirstName;
			var _LastName = dto.LastName;
			var _Firm = dto.Firm;
			var detailId = detail.Id;
			var detailContactId = detail.ContactId;
			var detailPhoneNumber = detail.PhoneNumber;
			var detailEmailAddress = detail.EmailAddress;
			var detailLocation = detail.Location;
			var _detail = dto.ContactDetail;
		}


	}
}
