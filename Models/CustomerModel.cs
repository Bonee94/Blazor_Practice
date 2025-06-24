using System.ComponentModel.DataAnnotations;

public class Customer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Phone is required")]
    public string Phone { get; set; } = "";

    [RequireAtLeastOneJob]
    public List<Job> Jobs { get; set; } = new();
}


public class RequireAtLeastOneJobAttribute : ValidationAttribute
{
    public RequireAtLeastOneJobAttribute()
    {
        ErrorMessage = "A Service Type and Note are required.";
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is List<Job> jobList)
        {
            if (jobList.Count > 0)
            {
                return ValidationResult.Success;
            }
        }

        return new ValidationResult(ErrorMessage);
    }
}
