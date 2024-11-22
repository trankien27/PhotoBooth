using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using PhotoBooth.Context;

namespace PhotoBooth.Service;

public class PhotoService : IPhoto
{
    private readonly MyDbContext _dbContext;

    public List<LayoutPicture> LayoutPictures()
    {
        return _dbContext.LayoutPictures.ToList();
    }
    public PhotoService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void GeneratePhoto(List<string> ImagePaths, int LayoutId, int ThemeId)
    {
        var layout =_dbContext.Layouts.Where(e => e.Id == LayoutId).ToList().First();
        var layoutTheme = _dbContext.LayoutThemes.Where(e => e.Id == ThemeId).ToList().First();
        var layoutPicture = _dbContext.LayoutPictures.Where(e => e.LayoutId == LayoutId).ToList();
        string layoutPath = layout.ImageUrl;
        string layoutThemePath = layoutTheme.ImageUrl;
        var layoutImage = Image.FromFile(layoutPath);
      var layoutThemeImage = Image.FromFile(layoutThemePath);
            
        List<Image> images = new List<Image>();

        for (int i = 0; i < ImagePaths.Count; i++)
        {
            images[i] = Image.FromFile(ImagePaths[i]);
        }
        string outputPath = "C:\\Users\\Kien\\Pictures\\mergepath_to_output_image.png";
        
int width = layout.Width;
int height = layout.Height;
using (var finalImage = new Bitmap(width, height))
{
    using( Graphics g = Graphics.FromImage(finalImage))
    {
        g.DrawImage(layoutImage, 0, 0, width, height);
        for (int i = 0; i < images.Count; i++)
        {
            g.DrawImage(images[i], layoutPicture[i].AxisX, layoutPicture[i].AxisX, layoutPicture[i].Width, layoutPicture[i].Height);
        }
        g.DrawImage(layoutThemeImage,0,0,width,height);
    }
    finalImage.Save(outputPath,ImageFormat.Png);
}



    }
}