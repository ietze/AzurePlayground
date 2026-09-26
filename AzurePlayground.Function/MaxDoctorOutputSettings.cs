using System.ComponentModel.DataAnnotations;

namespace AzurePlayground.Function;

public class MaxDoctorOutputSettings
{
    [Required]
    [Range(1, 100)]
    public int Number { get; set; }
}