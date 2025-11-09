using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogPostCommentRepository
    {
        //metoda AddSync merr nje komet te ri dhe e shton ne DB
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);

        //metoda Get merr nje blogPostId dhe kthen te gjitha komentet qe i perkasin atij blogpost
        Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId);
    }
}
