using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RiseTech.Services.Reports.Entities.Dtos.ReportDtos
{
	public class ReportDto
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
		public DateTime ReportDate { get; set; }
		public string ReportStatus { get; set; } = null!;
	}
}
