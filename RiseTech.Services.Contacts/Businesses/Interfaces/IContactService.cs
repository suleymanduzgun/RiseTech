using RiseTech.Common.Dtos;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDtos;
using RiseTech.Services.Contacts.Entities.Models;

namespace RiseTech.Services.Contacts.Businesses.Interfaces
{
	public interface IContactService
	{
		Task<OperationResponse<ContactDto>> GetByIdAsync(string id);
		Task<OperationResponse<ContactWithDetailDto>> GetByIdWithDetailAsync(string id);
		Task<OperationResponse<List<ContactDto>>> GetAllAsync();
		Task<OperationResponse<List<ContactWithDetailDto>>> GetAllWithDetailAsync();
		Task<OperationResponse<ContactDto>> CreateAsync(CreateContactDto createContact);
		Task<OperationResponse<ContactWithDetailDto>> CreateWithDetailAsync(CreateContactWithDetailDto createContact);
		Task<OperationResponse<ContactDto>> UpdateAsync(UpdateContactDto updateContact);
		Task<OperationResponse<EmptyResponse>> DeleteAsync(string id);
	}
}
