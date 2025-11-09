using CloudinaryDotNet;
using CloudinaryDotNet.Actions;//biblioteka per ngarkimin dhe menaxhimin e eimazheve

namespace Bloggie.Web.Repositories
{
    public class CloudinaryImageRepository : IImageRespository
    {
        private readonly IConfiguration configuration;
        private readonly Account account;

        //konstruktori duke marre CloudName ApiKey ApiSecret
        public CloudinaryImageRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            account = new Account(
                configuration.GetSection("Cloudinary")["CloudName"],
                configuration.GetSection("Cloudinary")["ApiKey"],
                configuration.GetSection("Cloudinary")["ApiSecret"]);
        }

        //metoda per ngarkimin e img
        public async Task<string> UploadAsync(IFormFile file)
        {
            var client = new Cloudinary(account);


            //parametrat e ngarkimit

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                DisplayName = file.FileName
            };

            //ngarkimi i skedarit

            var uploadResult = await client.UploadAsync(uploadParams);

            //verifikimi i suksesit te ngarkimot

            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUri.ToString();
            }

            return null;
        }
    }
}
