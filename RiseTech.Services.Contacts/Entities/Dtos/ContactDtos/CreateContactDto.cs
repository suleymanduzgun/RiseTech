using FluentValidation;

namespace RiseTech.Services.Contacts.Entities.Dtos.ContactDtos
{
	public class CreateContactDto
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Firm { get; set; }
	}


  public class ContactValidator : AbstractValidator<CreateContactDto>
  {
    public ContactValidator()
    {
      RuleFor(contact => contact.FirstName).NotNull().NotEmpty().WithMessage("Lütfen isim bilgisi giriniz.").Length(1, 250);
      RuleFor(contact => contact.LastName).NotNull().NotEmpty().WithMessage("Lütfen soyisim bilgisi giriniz.").Length(1, 250);
      RuleFor(contact => contact.Firm).Length(1, 250);
    }
  }
}
