using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RiseTech.Services.Contacts.Entities.Models;

namespace RiseTech.Services.Contacts.Entities.Dtos.ContactDtos
{
	public class CreateContactWithDetailDto
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Firm { get; set; }
		public ContactDetail ContactDetail { get; set; } = new ContactDetail();
	}

	public class CreateContactWithDetailDtoValidator : AbstractValidator<CreateContactWithDetailDto>
	{
		public CreateContactWithDetailDtoValidator()
		{
			RuleFor(contact => contact.FirstName).NotNull().NotEmpty().WithMessage("Lütfen isim bilgisi giriniz.").Length(1, 250);
			RuleFor(contact => contact.LastName).NotNull().NotEmpty().WithMessage("Lütfen soyisim bilgisi giriniz.").Length(1, 250);
			RuleFor(contact => contact.Firm).Length(1, 250);

			RuleFor(contact => contact.ContactDetail.PhoneNumber).Length(0, 11);
			RuleFor(contact => contact.ContactDetail.EmailAddress).Length(0, 100);
			RuleFor(contact => contact.ContactDetail.Location).Length(0, 50);
		}
	}

}
