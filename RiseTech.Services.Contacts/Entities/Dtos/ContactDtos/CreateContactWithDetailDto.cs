using FluentValidation;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;

namespace RiseTech.Services.Contacts.Entities.Dtos.ContactDtos
{
	public class CreateContactWithDetailDto
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Firm { get; set; }
		public CreateContactDetailWithContactDto DetailDto { get; set; } = new CreateContactDetailWithContactDto();
	}

	public class CreateContactWithDetailDtoValidator : AbstractValidator<CreateContactWithDetailDto>
	{
		public CreateContactWithDetailDtoValidator()
		{
			RuleFor(contact => contact.FirstName).NotNull().NotEmpty().WithMessage("Lütfen isim bilgisi giriniz.").Length(1, 250);
			RuleFor(contact => contact.LastName).NotNull().NotEmpty().WithMessage("Lütfen soyisim bilgisi giriniz.").Length(1, 250);
			RuleFor(contact => contact.Firm).Length(1, 250);

			RuleFor(contact => contact.DetailDto.PhoneNumber).Length(0, 11);
			RuleFor(contact => contact.DetailDto.EmailAddress).Length(0, 100).EmailAddress();
			RuleFor(contact => contact.DetailDto.Location).Length(0, 50);
		}
	}

}
