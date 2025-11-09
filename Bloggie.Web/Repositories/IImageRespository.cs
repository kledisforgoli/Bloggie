namespace Bloggie.Web.Repositories
{
    public interface IImageRespository
    {
        Task<string> UploadAsync(IFormFile file);//kthen nje URL te img te ngarkuar
    }
}
