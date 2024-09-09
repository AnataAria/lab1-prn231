using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Models.Entities;

public class Category {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CategoryId {get; set;}
    [Required]
    [StringLength(40)]
    public string CategoryName {get; set;}
    public virtual ICollection<Product> Products {get; set;}
}