using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AtmSystem.Presentation.Http.Models;

public class CreateCheckBalanceRequest
{
    [NotNull]
    [Required]
    public Guid? SessionId { get; set; }
}