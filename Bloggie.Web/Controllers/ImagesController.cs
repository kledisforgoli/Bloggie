using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bloggie.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ImagesController : ControllerBase
    {
        private readonly IImageRespository imageRespository;
        //Repository per ngarkimin dhe menaxhimin e imazheve.


        public ImagesController(IImageRespository imageRespository)
        {
            this.imageRespository = imageRespository;
        }


        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)//parametri per te marre nje file nga useri
        {
            // thirrja per ngarkim
            var imageURL = await imageRespository.UploadAsync(file);

            if (imageURL == null)
            {
                return Problem("Sometihng went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }

            return new JsonResult(new { link = imageURL });
        }
    }
}
