
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using real_estate.DTO;

namespace real_estate.Service
{
    public class CloudinaryImageUploadService : IImageUploadService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryImageUploadService()
        {
            DotEnv.Load();
            string cloudName = Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME");
            string apiKey = Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY");
            string apiSecret = Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET");

            if (string.IsNullOrEmpty(cloudName) || string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(apiSecret))
            {
                throw new Exception("Cloudinary credentials are missing in .env file.");
            }

            var account = new Account(cloudName, apiKey, apiSecret);
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }
        public async Task<List<string>> UploadAsync(ICollection<IFormFile> files)
        {
            var imageUrls = new List<string>();

            foreach (var file in files)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                var uploadparams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, memoryStream),
                };

                var result = await _cloudinary.UploadAsync(uploadparams);

                if (result.Error != null)
                {
                    throw new Exception($"Cloudinary error occured: {result.Error.Message}");
                }

                imageUrls.Add(result.Url.ToString());
            }

            return imageUrls;
        }


        public async Task DeleteImagesAsync(List<string> publicIds)
        {
            foreach (var publicId in publicIds)
            {
                var deletionParams = new DeletionParams(publicId);
                var result = await _cloudinary.DestroyAsync(deletionParams);

                if (result.Result != "ok")
                {
                    throw new Exception($"Failed to delete image with PublicId: {publicId}");
                }
            }
        }
    }
}
