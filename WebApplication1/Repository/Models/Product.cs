using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string? Description { get; set; }
    
    public decimal Price { get; set; }

    public long CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}