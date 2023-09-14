using System.ComponentModel.DataAnnotations;
namespace Airport_Playareas.Models
{
    public class NormalizeUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string url = value.ToString();
                if (!string.IsNullOrEmpty(url))
                {
                    if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                    {
                        url = "https://" + url;
                    }
                    validationContext.ObjectInstance.GetType().GetProperty(validationContext.MemberName).SetValue(validationContext.ObjectInstance, url);
                }
            }
            return ValidationResult.Success;
        }
    }
}
