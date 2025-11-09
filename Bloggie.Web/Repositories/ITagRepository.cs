using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync(//metode per te marre te gjtiha tags
            string? searchQuery = null,
            string? sortBy = null,
            string? sortDirection = null,
            int pageNumber = 1,
            int pageSize = 100);

        Task<Tag?> GetAsync(Guid id);//merr tag bazuar ne ID

        Task<Tag> AddAsync(Tag tag);//shton nje tag te ri

        Task<Tag?> UpdateAsync(Tag tag);//perditesim i tagut

        Task<Tag?> DeleteAsync(Guid id);//fshin tagun

        Task<int> CountAsync();//merr nr e pergjithshem te tageve

    }
}
