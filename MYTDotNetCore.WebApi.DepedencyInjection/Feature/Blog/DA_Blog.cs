using Microsoft.EntityFrameworkCore;
using MYTDotNetCore.WebApi.DepedencyInjection.Database;
using MYTDotNetCore.WebApi.DepedencyInjection.Models;

namespace MYTDotNetCore.WebApi.DepedencyInjection.Feature.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;

        public DA_Blog(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BlogListResponseModel> GetBlogList(int pageNo = 1, int pageSize = 10)
        {
            var response = new BlogListResponseModel();
            try
            {
                var query = _context.Blogs.AsNoTracking();
                int totalCount = query.Count();
                int pageCount = totalCount / pageSize;
                if (totalCount % pageSize > 0)
                {
                    pageCount++;
                }
                var lst = await query.Pagination(pageNo, pageSize).ToListAsync();
                if (lst is null)
                    throw new Exception("No Data Found");
                response = new BlogListResponseModel() { DataList = lst };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return response;
        }
    }
}
