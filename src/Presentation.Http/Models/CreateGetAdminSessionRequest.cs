using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AtmSystem.Presentation.Http.Models;

public class CreateGetAdminSessionRequest
{
    [NotNull]
    [Required]
    [MinLength(11)]
    [MaxLength(11)]
    public string? Password { get; set; }
}