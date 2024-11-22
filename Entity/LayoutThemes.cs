using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PhotoBooth;
[Keyless] 
public class LayoutThemes
{
    [Key]public int Id { get; set; }
    public string LayoutId{get;set;}
    public string ImageUrl{get;set;}
    
}