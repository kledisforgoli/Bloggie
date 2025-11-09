using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();//kthen nje list te gjitha blogposteve

        Task<BlogPost?> GetAsync(Guid id);//kthen nje post te vetem bazuar ne ID

        Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);//kthen bazuar ne urlhandle

        Task<BlogPost> AddAsync(BlogPost blogPost);//shtohet nje post i ri ne db

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);//update i blogut ekzistues
        
        Task<BlogPost?> DeleteAsync(Guid id);//fshin nje post te vetem bazuar ne ID
    }
}
