using real_estate.DTO;

namespace real_estate.Service
{
    public interface IImageUploadService
    {
        Task<List<string>> UploadAsync(ICollection<IFormFile> files);
        Task DeleteImagesAsync(List<string> publicIds);

    }
}
