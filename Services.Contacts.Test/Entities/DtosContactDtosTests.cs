using RiseTech.Services.Contacts.Entities.Dtos.ContactDtos;
using RiseTech.Services.Contacts.Entities.Models;
using FluentValidation.TestHelper;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;
using Xunit;

namespace Services.Contacts.Test.Entities
{
	public class DtosContactDtosTests
	{
		private ContactValidator contactValidator { get; }
		private CreateContactWithDetailDtoValidator createValidator { get; }
		private UpdateContactDtoValidator updateValidator { get; }
		public DtosContactDtosTests()
		{
			contactValidator = new ContactValidator();
			createValidator = new CreateContactWithDetailDtoValidator();
			updateValidator = new UpdateContactDtoValidator();
		}


		[Fact]
		public void ContactValidator_NotAllowEmptyPostcode()
		{
			var item = new CreateContactDto { FirstName=String.Empty };
			var result = contactValidator.TestValidate(item);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}


		[Fact]
		public void CreateContactWithDetailDtoValidator_NotAllowEmptyPostcode()
		{
			var item = new CreateContactWithDetailDto { FirstName=String.Empty };
			var result = createValidator.TestValidate(item);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}


		[Fact]
		public void UpdateContactDtoValidator_NotAllowEmptyPostcode()
		{
			var item = new UpdateContactDto { FirstName=String.Empty };
			var result = updateValidator.TestValidate(item);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}


		[Fact]
		public async Task ContactDto_Test()
		{
			var dto = new ContactDto
			{
				Id="62a9db6c281d40dd910f22f1",
				FirstName="test",
				LastName="test",
				Firm="test",
			};


			var id = dto.Id;
			var _FirstName = dto.FirstName;
			var _LastName = dto.LastName;
			var _Firm = dto.Firm;
		}


		[Fact]
		public async Task CreateContactDto_Test()
		{
			var dto = new CreateContactDto
			{
				FirstName="test",
				LastName="test",
				Firm="test",
			};


			var _FirstName = dto.FirstName;
			var _LastName = dto.LastName;
			var _Firm = dto.Firm;
		}



		[Fact]
		public async Task CreateContactWithDetailDto_Test()
		{
			var detailDto = new CreateContactDetailWithContactDto
			{
				PhoneNumber = "5555555555",
				EmailAddress = "test@testy.com",
				Location="İstanbul"
			};

			var dto = new CreateContactWithDetailDto
			{
				FirstName="test",
				LastName="test",
				Firm="test",
				DetailDto=detailDto
			};

			var _FirstName = dto.FirstName;
			var _LastName = dto.LastName;
			var _Firm = dto.Firm;

			var detailPhoneNumber = detailDto.PhoneNumber;
			var detailEmailAddress = detailDto.EmailAddress;
			var detailLocation = detailDto.Location;
			var detail = detailDto;
		}


		[Fact]
		public async Task ContactWithDetailDto_Test()
		{
			ContactDetail detail = new ContactDetail
			{
				Id="62a873b33453043f189dbc5f",
				ContactId="62a8b557af31d52693e510ea",
				PhoneNumber ="5555555555",
				EmailAddress = "test@test.com",
				Location = "İzmir"
			};

			var dto = new ContactWithDetailDto
			{
				Id="62a9db6c281d40dd910f22f1",
				FirstName="test",
				LastName="test",
				Firm="test",
				ContactDetail = detail
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


		[Fact]
		public async Task UpdateContactDto_Test()
		{
			var dto = new UpdateContactDto
			{
				Id="62a9db6c281d40dd910f22f1",
				FirstName="test",
				LastName="test",
				Firm="test",
			};


			var id = dto.Id;
			var _FirstName = dto.FirstName;
			var _LastName = dto.LastName;
			var _Firm = dto.Firm;
		}



	}
}
