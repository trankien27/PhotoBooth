using Microsoft.AspNetCore.Mvc;
using PhotoBooth.Service;

namespace PhotoBooth.Controllers;
[ApiController]
[Route("photo/[controller]")]
public class PhotoController : ControllerBase
{
    PhotoService _photoService;

    // public PhotoController(PhotoService photoService)
    // {
    //     _photoService = photoService;
    // }
    [HttpPost]
    public IActionResult GenPhoto([FromBody] List<string> photos, int LayoutId, int ThemeId)
    {
        try
        {
            _photoService.GeneratePhoto(photos, LayoutId, ThemeId);
            return Ok(LayoutId);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}