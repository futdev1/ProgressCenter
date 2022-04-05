using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
