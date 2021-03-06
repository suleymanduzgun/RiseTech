namespace RiseTech.Services.Contacts.Business.Settings
{
	public class DatabaseSettings : IDatabaseSettings
	{
		public string ContactCollectionName { get; set; } = null!;
		public string ContactDetailCollectionName { get; set; } = null!;
		public string ConnectionString { get; set; } = null!;
		public string DatabaseName { get; set; } = null!;
	}
}
