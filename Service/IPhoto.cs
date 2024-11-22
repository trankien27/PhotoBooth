using Microsoft.AspNetCore.Mvc;

namespace PhotoBooth.Service;

public interface IPhoto
{
    public void GeneratePhoto(List<String> ImagePaths,int LayoutId,int ThemeId);
}