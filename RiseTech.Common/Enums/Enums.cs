using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiseTech.Common
{
	public class Enums
	{
		public enum ReportStatusEnums
		{
			[Description("Hazırlanıyor")]
			Processing = 0,

			[Description("Tamamlandı")]
			Completed = 1,
		}
	}
}
