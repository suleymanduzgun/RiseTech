using Microsoft.AspNetCore.Mvc;
using RiseTech.Common.Dtos;

namespace RiseTech.Common
{
	public class RiseBaseController : ControllerBase
	{
		public static IActionResult CreateActionResultInstance<T>(OperationResponse<T> response)
		{
			return new ObjectResult(response) { StatusCode=response.StatusCode };
		}
	}
}
