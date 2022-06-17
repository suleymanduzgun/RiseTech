using RiseTech.Services.Contacts.Entities.Dtos.ContactDtos;
using RiseTech.Services.Contacts.Entities.Models;
using FluentValidation.TestHelper;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;
using Xunit;

namespace Services.Contacts.Test.Entities
{
	public class DtosContactDtosTests
	{
		private ContactValidator ContactValidator { get; }
		private CreateContactWithDetailDtoValidator CreateValidator { get; }
		private UpdateContactDtoValidator UpdateValidator { get; }
		public DtosContactDtosTests()
		{
			ContactValidator = new ContactValidator();
			CreateValidator = new CreateContactWithDetailDtoValidator();
			UpdateValidator = new UpdateContactDtoValidator();
		}


		[Fact]
		public void ContactValidator_NotAllowEmptyPostcode()
		{
			var item = new CreateContactDto { FirstName=String.Empty };
			var result = ContactValidator.TestValidate(item);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}


		[Fact]
		public void CreateContactWithDetailDtoValidator_NotAllowEmptyPostcode()
		{
			var item = new CreateContactWithDetailDto { FirstName=String.Empty };
			var result = CreateValidator.TestValidate(item);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}


		[Fact]
		public void UpdateContactDtoValidator_NotAllowEmptyPostcode()
		{
			var item = new UpdateContactDto { FirstName=String.Empty };
			var result = UpdateValidator.TestValidate(item);
			result.ShouldHaveValidationErrorFor(x => x.FirstName);
		}


		[Fact]
		public void ContactDto_Test()
		{
			var dto = new ContactDto
			{
				Id="62a9db6c281d40dd910f22f1",
				FirstName="test",
				LastName="test",
				Firm="test",
			};

			var dto2 = dto;
			dto2.Id = dto.Id;
			dto2.FirstName = dto.FirstName;
			dto2.LastName = dto.LastName;
			dto2.Firm = dto.Firm;
		}


		[Fact]
		public void CreateContactDto_Test()
		{
			CreateContactDto dto = new()
			{
				FirstName="test",
				LastName="test",
				Firm="test",
			};

			var dto2 = dto;
			dto2.FirstName = dto.FirstName;
			dto2.LastName = dto.LastName;
			dto2.Firm = dto.Firm;
		}



		[Fact]
		public void CreateContactWithDetailDto_Test()
		{
			CreateContactDetailWithContactDto detailDto = new()
			{
				PhoneNumber = "5555555555",
				EmailAddress = "test@testy.com",
				Location="İstanbul"
			};
			var detailDto2 = detailDto;
			detailDto2.PhoneNumber = detailDto.PhoneNumber;
			detailDto2.EmailAddress=detailDto.EmailAddress;
			detailDto2.Location = detailDto.Location;

			CreateContactWithDetailDto dto = new()
			{
				FirstName="test",
				LastName="test",
				Firm="test",
				DetailDto=detailDto
			};
			var dto2 = dto;
			dto2.FirstName = dto.FirstName;
			dto2.LastName = dto.LastName;
			dto2.Firm = dto.Firm;
		}


		[Fact]
		public void ContactWithDetailDto_Test()
		{
			List<ContactDetail> detailList = new()
			{ 
				new ContactDetail
				{
					Id="62a873b33453043f189dbc5f",
					ContactId="62a8b557af31d52693e510ea",
					PhoneNumber ="5555555555",
					EmailAddress = "test@test.com",
					Location = "İzmir"
				}
			};

			var detailList2 = detailList;

			ContactWithDetailDto dto = new()
			{
				Id="62a9db6c281d40dd910f22f1",
				FirstName="test",
				LastName="test",
				Firm="test",
				ContactDetail = detailList2
			};

			var dto2 = dto;
			dto2.ContactDetail = detailList;
			dto2.Id = dto.Id;
			dto2.FirstName = dto.FirstName;
			dto2.LastName = dto.LastName;
			dto2.Firm = dto.Firm;
			dto2.ContactDetail = dto.ContactDetail;
		}


		[Fact]
		public void UpdateContactDto_Test()
		{
			var dto = new UpdateContactDto
			{
				Id="62a9db6c281d40dd910f22f1",
				FirstName="test",
				LastName="test",
				Firm="test",
			};

			var dto2 = dto;
			dto2.Id = dto.Id;
			dto2.FirstName = dto.FirstName;
			dto2.LastName = dto.LastName;
			dto2.Firm = dto.Firm;
		}



		[Fact]
		public void ContactDetail_Test()
		{
			var dto = new ContactDetail
			{
				Id="62a9db6c281d40dd910f22f1",
				ContactId="62a9db6c481d40dd910f22f1",
				PhoneNumber="5554449898",
				EmailAddress="test@test.com",
				Location="test",
			};

			var dto2 = dto;
			dto2.Id = dto.Id;
			dto2.ContactId = dto.ContactId;
			dto2.PhoneNumber = dto.PhoneNumber;
			dto2.EmailAddress = dto.EmailAddress;
			dto2.Location = dto.Location;
		}


	}
}
