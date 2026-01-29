using System.ComponentModel.DataAnnotations;

namespace AtmSystem.Presentation.Http.Models;

public class CreateGetOperationHistoryRequest
{
    [Required]
    [Range(minimum: 1, maximum: long.MaxValue)]
    public long AccountId { get; set; }
}