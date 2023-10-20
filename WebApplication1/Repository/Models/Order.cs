using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebApplication1;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string CustomerName { get; set; }
    
    public string CustomerAddress { get; set; }
    
    public bool GiftWrap { get; set; }
    
    public IList<Product> Products { get; set; }

    [NotMapped]
    public decimal Price => Products.Sum(p => p.Price);
}