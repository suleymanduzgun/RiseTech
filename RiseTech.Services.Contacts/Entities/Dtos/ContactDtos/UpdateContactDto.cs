using FluentValidation;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RiseTech.Services.Contacts.Entities.Dtos.ContactDtos
{
	public class UpdateContactDto
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Firm { get; set; }
  }


  public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
  {
    public UpdateContactDtoValidator()
    {
      RuleFor(contact => contact.Id).NotNull().NotEmpty();
      RuleFor(contact => contact.FirstName).NotNull().NotEmpty().WithMessage("Lütfen isim bilgisi giriniz.").Length(1, 250);
      RuleFor(contact => contact.LastName).NotNull().NotEmpty().WithMessage("Lütfen soyisim bilgisi giriniz.").Length(1, 250);
      RuleFor(contact => contact.Firm).Length(1, 250);
    }
  }
}
