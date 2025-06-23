using System.ComponentModel.DataAnnotations;

public class Job
{
    [Required(ErrorMessage = "Service type is required.")]
    public string ServiceType { get; set; } = "";

    [Required(ErrorMessage = "Completion date is required.")]
    public DateTime DateCompleted { get; set; }

    [Required(ErrorMessage = "Note is required.")]
    public string Note { get; set; } = "";
}
