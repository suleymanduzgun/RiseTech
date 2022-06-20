using System.ComponentModel;
using System.Reflection;

namespace RiseTech.Common.Helpers
{
	public static class EnumHelper
	{
		public static string GetEnumDescription(this Enum enumValue)
		{
			FieldInfo? fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
			if (fieldInfo == null)
				return enumValue.ToString();

			var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
			return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
		}
	}
}
