using System.Text.Json;

namespace Timor.Cms.Infrastructure.Models
{
    public class ExceptionResult
    {
        public string ErrorMessage { get; set; }

        public string ErrorDetail { get; set; }

        public string DebugInfo { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
