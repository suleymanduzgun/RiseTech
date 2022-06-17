using RiseTech.Services.Contacts.Entities.Models;
using Xunit;

namespace Services.Contacts.Test.Entities
{
	public class ModelsContactTests
	{
		[Fact]
		public void Contact_Test()
		{
			List<ContactDetail> detail = new()
			{
				new ContactDetail
				{
					Id ="62a8b715996fea8613167414",
					ContactId ="62a8b72e996fea8613167415",
					PhoneNumber ="5555555555",
					EmailAddress="test@test.com",
					Location ="Mardin"
				},
			};
			var detail2 = detail.ToList();

			var dto = new Contact
			{
				Id="62a9db6c281d40dd910f22f1",
				FirstName="test",
				LastName="test",
				Firm="test",
				ContactDetail=detail2
			};

			var dto2 = dto;
			dto2.ContactDetail = dto.ContactDetail;
			dto2.Id=dto.Id;
			dto2.FirstName=dto.FirstName;
			dto2.LastName=dto.LastName;
			dto2.Firm=dto.Firm;
			Assert.Equal(dto, dto2);
		}


	}
}
