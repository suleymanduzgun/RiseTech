using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos
{
	public class UpdateContactDetailDto
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public string? EmailAddress { get; set; }
		public string? Location { get; set; }
	}


	public class UpdateContactDetailDtoValidator : AbstractValidator<CreateContactDetailDto>
	{
		public UpdateContactDetailDtoValidator()
		{
			RuleFor(contact => contact.PhoneNumber).Length(0, 11);
			RuleFor(contact => contact.EmailAddress).Length(0, 100);
			RuleFor(contact => contact.Location).Length(0, 50);
		}
	}

}
