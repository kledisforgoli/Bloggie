using Microsoft.AspNetCore.Identity;

namespace Bloggie.Web.Repositories
{
    public interface IUserRepository
    {
        //metoda per te marre te gjthe user nga sistemi dhe kthen nje liste te users
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
