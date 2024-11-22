using Microsoft.AspNetCore.Mvc;

namespace PhotoBooth.Service;

public interface IPhoto
{
    public List<LayoutPicture> LayoutPictures();
    public void GeneratePhoto(List<String> ImagePaths,int LayoutId,int ThemeId);
}