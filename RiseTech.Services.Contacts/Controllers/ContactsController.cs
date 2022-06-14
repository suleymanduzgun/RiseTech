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


		[HttpPost]
		[Route("/api/[controller]/CreateWithDetail")]
		public async Task<IActionResult> CreateWithDetail(CreateContactWithDetailDto createContactWithDetailDto)
		{
			if (!ModelState.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);

			var response = await _contactService.CreateWithDetailAsync(createContactWithDetailDto);
			return CreateActionResultInstance(response);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			var response = await _contactService.DeleteAsync(id);
			return CreateActionResultInstance(response);
		}


		[HttpGet]
		[Route("/api/[controller]/GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var response = await _contactService.GetAllAsync();
			return CreateActionResultInstance(response);
		}


		[HttpGet]
		[Route("/api/[controller]/GetAllWithDetail")]
		public async Task<IActionResult> GetAllWithDetail()
		{
			var response = await _contactService.GetAllWithDetailAsync();
			return CreateActionResultInstance(response);
		}


		[HttpGet]
		public async Task<IActionResult> GetById(string id)
		{
			var response = await _contactService.GetByIdAsync(id);
			return CreateActionResultInstance(response);
		}


		[HttpGet]
		[Route("/api/[controller]/GetByIdWithDetail/{id}")]
		public async Task<IActionResult> GetByIdWithDetail(string id)
		{
			var response = await _contactService.GetByIdWithDetailAsync(id);
			return CreateActionResultInstance(response);
		}


		[HttpPut]
		public async Task<IActionResult> Update(UpdateContactDto updateContactDto)
		{
			var response = await _contactService.UpdateAsync(updateContactDto);
			return CreateActionResultInstance(response);
		}

	}
}
