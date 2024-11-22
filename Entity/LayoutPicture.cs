using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PhotoBooth;


public class LayoutPicture
{
    [Key]
    public int Id  { get; set; }
    public int LayoutId { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int AxisX { get; set; }
    public int AxisY { get; set; }
}