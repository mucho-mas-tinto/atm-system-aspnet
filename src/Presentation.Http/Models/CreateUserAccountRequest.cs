using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AtmSystem.Presentation.Http.Models;

public class CreateUserAccountRequest
{
    [Required]
    [Range(minimum: 1, maximum: long.MaxValue)]
    public long AccountId { get; set; }

    [NotNull]
    [Required]
    [MinLength(4)]
    [MaxLength(4)]
    public string? PinCode { get; set; }
}