using Microsoft.AspNetCore.Mvc;
using RiseTech.Common;
using RiseTech.Services.Contacts.Businesses.Interfaces;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDtos;

namespace RiseTech.Services.Contacts.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : RiseBaseController
	{
		private readonly IContactService _contactService;

		public ContactsController(IContactService contactService)
		{
			_contactService=contactService;
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateContactDto createContactDto)
		{
			if (!ModelState.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);

			var response = await _contactService.CreateAsync(createContactDto);
			return CreateActionResultInstance(response);
		}


	}
}
