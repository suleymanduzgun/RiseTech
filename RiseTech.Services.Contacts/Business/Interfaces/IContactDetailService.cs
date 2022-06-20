using RiseTech.Common.Dtos;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;

namespace RiseTech.Services.Contacts.Business.Interfaces
{
	public interface IContactDetailService
	{
		Task<OperationResponse<ContactDetailDto>> GetByIdAsync(string id);
		Task<OperationResponse<List<ContactDetailDto>>> GetAllAsync();
		Task<OperationResponse<ContactDetailDto>> CreateAsync(CreateContactDetailDto createContactDetail);
		Task<OperationResponse<ContactDetailDto>> UpdateAsync(UpdateContactDetailDto updateContactDetail);
		Task<OperationResponse<EmptyResponse>> DeleteAsync(string id);
	}
}
