using Microsoft.AspNetCore.Mvc;
using RiseTech.Common;
using RiseTech.Services.Contacts.Businesses.Interfaces;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;

namespace RiseTech.Services.Contacts.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactDetailsController : RiseBaseController
	{
		private readonly IContactDetailService _contactDetailService;

		public ContactDetailsController(IContactDetailService contactDetailService)
		{
			_contactDetailService=contactDetailService;
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateContactDetailDto createContactDetailDto)
		{
			if (!ModelState.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);

			var response = await _contactDetailService.CreateAsync(createContactDetailDto);
			return CreateActionResultInstance(response);
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			var response = await _contactDetailService.DeleteAsync(id);
			return CreateActionResultInstance(response);
		}


		[HttpGet]
		[Route("/api/[controller]/GetAll")]
		public async Task<IActionResult> GetAll()
		{
			var response = await _contactDetailService.GetAllAsync();
			return CreateActionResultInstance(response);
		}


		[HttpGet]
		public async Task<IActionResult> GetById(string id)
		{
			var response = await _contactDetailService.GetByIdAsync(id);
			return CreateActionResultInstance(response);
		}


		[HttpPut]
		public async Task<IActionResult> Update(UpdateContactDetailDto updateContactDetailDto)
		{
			if (!ModelState.IsValid)
				return StatusCode(StatusCodes.Status400BadRequest, ModelState);

			var response = await _contactDetailService.UpdateAsync(updateContactDetailDto);
			return CreateActionResultInstance(response);
		}


	}
}
