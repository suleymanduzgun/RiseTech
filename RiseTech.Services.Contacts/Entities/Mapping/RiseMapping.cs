using AutoMapper;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos;
using RiseTech.Services.Contacts.Entities.Dtos.ContactDtos;
using RiseTech.Services.Contacts.Entities.Models;

namespace RiseTech.Services.Contacts.Entities.Mapping
{
	public class RiseMapping : Profile
	{
		public RiseMapping()
		{
			//Contacts Maplama
			CreateMap<Contact, ContactDto>().ReverseMap();
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, CreateContactWithDetailDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();
			CreateMap<Contact, ContactWithDetailDto>().ReverseMap();


			//ContactDetails Maplama
			CreateMap<ContactDetail, ContactDetailDto>().ReverseMap();
			CreateMap<ContactDetail, CreateContactDetailDto>().ReverseMap();
			CreateMap<ContactDetail, UpdateContactDetailDto>().ReverseMap();
			CreateMap<ContactDetail, CreateContactDetailWithContactDto>().ReverseMap();

		}
	}
}
