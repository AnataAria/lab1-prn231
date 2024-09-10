using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities;

public class Product
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId {get; set;}
    [Required]
    [StringLength(40)]
    public string ProductName {get; set;}
    [Required]
    public int CategoryId {get; set;}
    [Required]
    public int UnitsInStock {get; set;}
    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice {get; set;}
    public virtual Category Category {get; set;}
}
