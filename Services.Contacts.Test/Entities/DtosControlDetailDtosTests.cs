using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;
using FluentValidation.TestHelper;

namespace Services.Contacts.Test.Entities
{
	public class DtosControlDetailDtosTests
	{
		private CreateContactDetailDtoValidator createValidator { get; }
		private UpdateContactDetailDtoValidator updateValidator { get; }
		public DtosControlDetailDtosTests()
		{
			createValidator = new CreateContactDetailDtoValidator();
			updateValidator = new UpdateContactDetailDtoValidator();
		}


		[Fact]
		public void CreateContactDetailDtoValidator_NotAllowEmptyPostcode()
		{
			var item = new CreateContactDetailDto { PhoneNumber="123456789012" };
			var result = createValidator.TestValidate(item);
			result.ShouldHaveValidationErrorFor(x => x.PhoneNumber);
		}


		[Fact]
		public void UpdateContactDetailDtoValidator_NotAllowEmptyPostcode()
		{
			var item = new CreateContactDetailDto { EmailAddress="123456789012" };
			var result = updateValidator.TestValidate(item);
			result.ShouldHaveValidationErrorFor(x => x.EmailAddress);
		}


		[Fact]
		public async Task ContactDetailDto_Test()
		{
			var dto = new ContactDetailDto
			{
				Id="62a873b33453043f189dbc5f",
				ContactId="62a9db6c281d40dd910f22f1",
				EmailAddress="test@test.com",
				Location="İstanbul",
				PhoneNumber="5555555555",
			};

			var _Id = dto.Id;
			var _ContactId = dto.ContactId;
			var _EmailAddress = dto.EmailAddress;
			var _Location = dto.Location;
			var _PhoneNumber = dto.PhoneNumber;
		}


		[Fact]
		public async Task CreateContactDetailDto_Test()
		{
			var dto = new CreateContactDetailDto
			{
				ContactId="62a9db6c281d40dd910f22f1",
				EmailAddress="test@test.com",
				Location="İstanbul",
				PhoneNumber="5555555555",
			};

			var _ContactId = dto.ContactId;
			var _EmailAddress = dto.EmailAddress;
			var _Location = dto.Location;
			var _PhoneNumber = dto.PhoneNumber;
		}




		[Fact]
		public async Task CreateContactDetailWithContactDto_Test()
		{
			var dto = new CreateContactDetailWithContactDto
			{
				EmailAddress="test@test.com",
				Location="İstanbul",
				PhoneNumber="5555555555",
			};

			var _EmailAddress = dto.EmailAddress;
			var _Location = dto.Location;
			var _PhoneNumber = dto.PhoneNumber;
		}




		[Fact]
		public async Task UpdateContactDetailDto_Test()
		{
			var dto = new UpdateContactDetailDto
			{
				Id="62a9db6c281d40dd910f22f1",
				EmailAddress="test@test.com",
				Location="İstanbul",
				PhoneNumber="5555555555",
			};


			var _id = dto.Id;
			var _EmailAddress = dto.EmailAddress;
			var _Location = dto.Location;
			var _PhoneNumber = dto.PhoneNumber;
		}





	}
}
