using Microsoft.AspNetCore.Mvc;
using Moq;
using RiseTech.Common.Dtos;
using RiseTech.Services.Contacts.Business.Interfaces;
using RiseTech.Services.Contacts.Controllers;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;
using System.Net;
using Xunit;

namespace Services.Contacts.Test.Controller
{
	public class ContactDetailsControllerTests
	{
		readonly ContactDetailsController controller;
		readonly Mock<IContactDetailService> _service;

		public ContactDetailsControllerTests()
		{
			_service = new Mock<IContactDetailService>();
			controller = new ContactDetailsController(_service.Object);
		}


		[Fact]
		public async void ContactDetailsController_Create_Success()
		{
			_service.Setup(x => x.CreateAsync(It.IsAny<CreateContactDetailDto>())).ReturnsAsync(new OperationResponse<ContactDetailDto> { StatusCodeTemp=(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.Create(new CreateContactDetailDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactDetailsController_Create_ModelStateInvalid()
		{
			controller.ModelState.AddModelError("Telefon Numarası","Telefon numarası maksimum 11 karakter olmalı!");

			var result = await controller.Create(new CreateContactDetailDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
		}


		[Fact]
		public async void ContactDetailsController_Delete_Success()
		{
			_service.Setup(x => x.DeleteAsync(It.IsAny<string>())).ReturnsAsync(new OperationResponse<EmptyResponse> {StatusCodeTemp =(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.Delete("62a8b77f996fea8613167416") as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactDetailsController_GetAll_Success()
		{
			_service.Setup(x => x.GetAllAsync()).ReturnsAsync(new OperationResponse<List<ContactDetailDto>> { StatusCodeTemp=(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.GetAll() as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactDetailsController_GetById_Success()
		{
			_service.Setup(x => x.GetByIdAsync(It.IsAny<string>())).ReturnsAsync(new OperationResponse<ContactDetailDto> { StatusCodeTemp =(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.GetById("62a8b77f996fea8613167416") as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactDetailsController_Update_Success()
		{
			_service.Setup(x => x.UpdateAsync(It.IsAny<UpdateContactDetailDto>())).ReturnsAsync(new OperationResponse<ContactDetailDto> { StatusCodeTemp=(int)HttpStatusCode.OK, IsSuccessfulTemp = true });

			var result = await controller.Update(new UpdateContactDetailDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.OK, result?.StatusCode);
		}


		[Fact]
		public async void ContactDetailsController_Update_ModelStateInvalid()
		{
			controller.ModelState.AddModelError("Telefon Numarası", "Telefon numarası maksimum 11 karakter olmalı!");

			var result = await controller.Update(new UpdateContactDetailDto()) as ObjectResult;

			Assert.Equal((int)HttpStatusCode.BadRequest, result?.StatusCode);
		}


	}
}
