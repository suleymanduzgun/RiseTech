using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RiseTech.Services.Contacts.Entities.Models;

namespace RiseTech.Services.Contacts.Entities.Dtos.ContactDtos
{
	public class ContactWithDetailDto
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Firm { get; set; }
		public List<ContactDetail>? ContactDetail { get; set; }
	}
}
