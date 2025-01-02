using System.ComponentModel.DataAnnotations;

namespace Ven.Shared.Entities;

public class Country
{
    [Key]
    public int CountryId { get; set; }

    [Required(ErrorMessage = "El Campo {0} es obligatorio")]
    [MaxLength(100, ErrorMessage = "El campo {0} no puede ser mayor a {1}")]
    [Display(Name = "Pais")]
    public string Name { get; set; } = null!;
}