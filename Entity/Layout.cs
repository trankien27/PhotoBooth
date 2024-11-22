using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PhotoBooth;
[Keyless] 
 

public class Layout
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string ThumbnailUrl { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
        
    
    
}