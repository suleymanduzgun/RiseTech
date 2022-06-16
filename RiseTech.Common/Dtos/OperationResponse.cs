using System.Text.Json.Serialization;

namespace RiseTech.Common.Dtos
{
	public class OperationResponse<T>
	{
		public T? Data { get; set; }

		[JsonIgnore]
		public int StatusCode { get; private set; }

		[JsonIgnore]
		public int StatusCodeTemp { get { return StatusCode; } set { StatusCode = value; } }

		[JsonIgnore]
		public bool IsSuccessful { get; private set; }

		[JsonIgnore]
		public bool IsSuccessfulTemp { get { return IsSuccessful; } set { IsSuccessful = true; } }

		public List<string>? ErrorMessages { get; set; }
		public string? Message { get; set; }


		public static OperationResponse<T> Success(T data, string message, int statusCode)
		{
			return new OperationResponse<T> { Data = data, Message=message, StatusCode = statusCode, IsSuccessful=true };
		}

		public static OperationResponse<T> Success(string message, int statusCode)
		{
			return new OperationResponse<T> { Data = default(T), Message=message, StatusCode = statusCode, IsSuccessful=true };
		}

		public static OperationResponse<T> Success(int statusCode)
		{
			return new OperationResponse<T> { Data = default(T), StatusCode = statusCode, IsSuccessful=true };
		}

		public static OperationResponse<T> Fail(List<string> errorMessages, int statusCode)
		{
			return new OperationResponse<T> { ErrorMessages = errorMessages, StatusCode = statusCode, IsSuccessful=false };
		}

		public static OperationResponse<T> Fail(string errorMessage, int statusCode)
		{
			return new OperationResponse<T> { ErrorMessages = new List<string>() { errorMessage }, StatusCode = statusCode, IsSuccessful=false };
		}
	}
}
