using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RiseTech.Services.Contacts.Entities.Models
{
	public class ContactDetail
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }

		[BsonRepresentation(BsonType.ObjectId)]
		public string ContactId { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public string? EmailAddress { get; set; }
		public string? Location { get; set; }
	}
}
