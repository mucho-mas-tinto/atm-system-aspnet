using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AtmSystem.Presentation.Http.Models;

public class CreateDepositRequest
{
    [NotNull]
    [Required]
    public Guid? SessionId { get; set; }

    public decimal Amount { get; set; }
}