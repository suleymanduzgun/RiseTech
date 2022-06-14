using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RiseTech.Services.Contacts.Entities.Dtos.ContactDetailsDtos
{
	public class UpdateContactDetailDto
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public string? EmailAddress { get; set; }
		public string? Location { get; set; }
	}
}
