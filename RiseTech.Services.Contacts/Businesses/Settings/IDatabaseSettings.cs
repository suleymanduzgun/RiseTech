﻿namespace RiseTech.Services.Contacts.Businesses.Settings
{
	public interface IDatabaseSettings
	{
		public string ContactCollectionName { get; set; }
		public string ContactDetailCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
