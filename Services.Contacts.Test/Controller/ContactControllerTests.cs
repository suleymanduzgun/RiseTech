using Microsoft.AspNetCore.Mvc;
using Moq;
using RiseTech.Common.Dtos;
using RiseTech.Services.Contacts.Businesses.Interfaces;
using RiseTech.Services.Contacts.Controllers;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDtos;
using System.Net;
using Xunit;

namespace Services.Contacts.Test.Controller
{
	public class ContactControllerTests
	{
		readonly ContactsController controller;
		readonly Mock<IContactService> _service;

		public ContactControllerTests()
		{
			_service = new Mock<IContactService>();
			controller = new ContactsController(_service.Object);
		}


		[Fact]
		public async void ContactsController_Create_Success()
		{
			_service.Setup(x => x.CreateAsync(It.IsAny<CreateContactDto>())).ReturnsAsync(new OperationResponse<ContactDto> { StatusCodeTemp=(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.Create(new CreateContactDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_Create_ModelStateInvalid()
		{
			controller.ModelState.AddModelError("Telefon Numarası","Telefon numarası maksimum 11 karakter olmalı!");

			var result = await controller.Create(new CreateContactDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_CreateWithDetail_Success()
		{
			_service.Setup(x => x.CreateWithDetailAsync(It.IsAny<CreateContactWithDetailDto>())).ReturnsAsync(new OperationResponse<ContactWithDetailDto> { StatusCodeTemp=(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.CreateWithDetail(new CreateContactWithDetailDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_CreateWithDetail_ModelStateInvalid()
		{
			controller.ModelState.AddModelError("Telefon Numarası", "Telefon numarası maksimum 11 karakter olmalı!");

			var result = await controller.CreateWithDetail(new CreateContactWithDetailDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_Delete_Success()
		{
			_service.Setup(x => x.DeleteAsync(It.IsAny<string>())).ReturnsAsync(new OperationResponse<EmptyResponse> {StatusCodeTemp =(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.Delete("62a8b77f996fea8613167416") as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_GetAll_Success()
		{
			_service.Setup(x => x.GetAllAsync()).ReturnsAsync(new OperationResponse<List<ContactDto>> { StatusCodeTemp=(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.GetAll() as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_GetAllWithDetail_Success()
		{
			_service.Setup(x => x.GetAllWithDetailAsync()).ReturnsAsync(new OperationResponse<List<ContactWithDetailDto>> { StatusCodeTemp=(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.GetAllWithDetail() as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_GetById_Success()
		{
			_service.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new OperationResponse<ContactDto> { StatusCodeTemp =(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.GetById("62a8b77f996fea8613167416") as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_GetByIdWithDetail_Success()
		{
			_service.Setup(x => x.GetByIdWithDetailAsync(It.IsAny<string>())).ReturnsAsync(new OperationResponse<ContactWithDetailDto> { StatusCodeTemp =(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.GetByIdWithDetail("62a8b77f996fea8613167416") as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_Update_Success()
		{
			_service.Setup(x => x.UpdateAsync(It.IsAny<UpdateContactDto>())).ReturnsAsync(new OperationResponse<ContactDto> { StatusCodeTemp=(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.Update(new UpdateContactDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactsController_Update_ModelStateInvalid()
		{
			controller.ModelState.AddModelError("Telefon Numarası", "Telefon numarası maksimum 11 karakter olmalı!");

			var result = await controller.Update(new UpdateContactDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
		}


	}
}
