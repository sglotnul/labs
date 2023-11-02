using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1;

public record OrderForm
{
    [Required]
    public string Name { get; init; }
    
    public string? Line1 { get; init; }
    
    public string? Line2 { get; init; }
    
    public string? Line3 { get; init; }
    
    [Required]
    public string City { get; init; }
    
    public string? State { get; init; }
    
    [Required]
    public string Zip { get; init; }
    
    [Required]
    public string Country { get; init; }
    
    [Required]
    public bool GiftWrap { get; init; }
    
    [Required]
    public IEnumerable<long> OrderIds { get; init; }
}