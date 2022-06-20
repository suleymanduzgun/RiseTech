using FluentValidation;
using RiseTech.Common.Helpers;
using static RiseTech.Common.Enums;

namespace RiseTech.Services.Reports.Entities.Dtos.ReportDtos
{
	public class CreateReportDto
  {
    public DateTime ReportDate { get; set; } = DateTime.Now;
    public string ReportStatus { get; set; } = ReportStatusEnums.Processing.GetEnumDescription();
  }


  public class ContactValidator : AbstractValidator<CreateReportDto>
  {
    public ContactValidator()
    {
      RuleFor(contact => contact.ReportDate).NotNull().NotEmpty();
      RuleFor(contact => contact.ReportStatus).NotNull().NotEmpty();
    }
  }
}
