using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RiseTech.Services.Contacts.Entities.Dtos.ContactDtos
{
	public class UpdateContactDto
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; } = null!;
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string? Firm { get; set; }
	}
}
