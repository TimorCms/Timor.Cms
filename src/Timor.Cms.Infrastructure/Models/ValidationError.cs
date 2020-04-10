namespace Timor.Cms.Infrastructure.Models
{
    public class ValidationError
    {
        public ValidationError(string field, string errorMessage)
        {
            this.Field = field;
            this.ErrorMessage = errorMessage;
        }

        public string Field { get; set; }

        public string ErrorMessage { get; set; }
    }
}