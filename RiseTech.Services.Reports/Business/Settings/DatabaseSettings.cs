namespace RiseTech.Services.Reports.Business.Settings
{
	public class DatabaseSettings : IDatabaseSettings
	{
		public string ReportCollectionName { get; set; } = null!;
		public string ConnectionString { get; set; } = null!;
		public string DatabaseName { get; set; } = null!;
	}
}
