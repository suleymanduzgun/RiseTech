using RiseTech.Services.Contacts.Businesses.Settings;
using Xunit;

namespace Services.Contacts.Test.Businesses
{
	public class SettingsTests
	{
		[Fact]
		public void DatabaseSettings_Test()
		{
			var dto = new DatabaseSettings
			{
				ContactCollectionName="62a9db6c281d40dd910f22f1",
				ContactDetailCollectionName="test",
				ConnectionString="test",
				DatabaseName="test",
			};

			var dto2 = dto;
			dto2.ContactCollectionName = dto.ContactCollectionName;
			dto2.ContactDetailCollectionName = dto.ContactDetailCollectionName;
			dto2.ConnectionString = dto.ConnectionString;
			dto2.DatabaseName = dto.DatabaseName;
		}
	}
}
