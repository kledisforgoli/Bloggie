using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);//kthen nr total te likes per nje post

        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);//kthen te gjitha like per nje post

        Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);//shtohet nje pelqim per nje blogpost
    }
}
