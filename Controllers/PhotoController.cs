using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoBooth.Context;
using PhotoBooth.Service;

namespace PhotoBooth.Controllers;
[ApiController]
[Route("photo/[controller]")]
public class PhotoController : ControllerBase
{

    private readonly MyDbContext _dbcontext;
    

    public PhotoController(MyDbContext dbContext)
    {

        _dbcontext = dbContext;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LayoutPicture>>> LayoutPicture()
    {
        return await _dbcontext.LayoutPictures.ToListAsync();
    }
    [HttpPost]
    public IActionResult GenPhoto([FromBody]string folderImage, int LayoutId, int ThemeId)
    {
        try
        {
            var layout =_dbcontext.Layouts.Where(e => e.Id == LayoutId).ToList().First();
            var layoutTheme = _dbcontext.LayoutThemes.Where(e => e.Id == ThemeId).ToList().First();
            var layoutPicture = _dbcontext.LayoutPictures.Where(e => e.LayoutId == LayoutId).ToList();
            string layoutPath = "D:\\Work\\PhotoBooth"+layout.ImageUrl;
            string layoutThemePath = "D:\\Work\\PhotoBooth"+layoutTheme.ImageUrl;
            var layoutImage = Image.FromFile(layoutPath);
            var layoutThemeImage = Image.FromFile(layoutThemePath);
            string[] ImagePaths = Directory.GetFiles(folderImage, "*.png");
            List<Image> images = new List<Image>(ImagePaths.Length);
            Console.WriteLine(layoutPicture.Count());
     
            for (int i = 0; i < ImagePaths.Length; i++)
            {
                images.Add(Image.FromFile(ImagePaths[i]));
            
            }
            Console.WriteLine(images.Count());
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
                        g.DrawImage(images[i], layoutPicture[i].AxisX, layoutPicture[i].AxisY, layoutPicture[i].Width, layoutPicture[i].Height);
                    }
                    g.DrawImage(layoutThemeImage,0,0,width,height);
                }
                finalImage.Save(outputPath,ImageFormat.Png);
            }

            return Ok(outputPath);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}