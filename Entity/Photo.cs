using Microsoft.EntityFrameworkCore;

namespace PhotoBooth;
[Keyless]
public class Photo
{
    public List<string> ImagePaths { get; set; }
    public string layoutId { get; set; }
    public string themeId { get; set; }

    
    
}