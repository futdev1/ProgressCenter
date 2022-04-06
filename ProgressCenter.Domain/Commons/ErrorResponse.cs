using System.Text.Json.Serialization;

namespace ProgressCenter.Domain.Commons
{
    public class ErrorResponse
    {
        [JsonIgnore]
        public int? Code { get; set; }
        public string Message { get; set; }
        public ErrorResponse(int? code = null, string message = null)
        {
            Code = code;
            Message = message;
        }
    }
}
