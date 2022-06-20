using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RiseTech.Services.Reports.Entities.Models
{
	public class Report
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
		public DateTime ReportDate { get; set; }
		public string ReportStatus { get; set; } = null!;
	}
}
