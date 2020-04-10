using System.Collections.Generic;

namespace Timor.Cms.Infrastructure.Models
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            
        }
        
        public ValidationResult(IEnumerable<ValidationError> validationErrors)
        {
            IsValid = false;
            ValidationErrors = validationErrors;
        }
        
        public bool IsValid { get; set; }
        
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }
}
