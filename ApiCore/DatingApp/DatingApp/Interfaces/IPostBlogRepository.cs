using DatingApp.DTOs;
using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Interfaces
{
    public interface IPostBlogRepository
    {
        Task<int> PostBlog(BlogDetail postDetail,int appuserid);
        Task<int> DeleteBlog(int? postId);
        Task<IEnumerable<BlogDetailDto>> GetBlogsAsync();
        Task<IEnumerable<BlogDetailDto>> GetBlogByIdAsync(int appUserId);
        void UpdateBlog(int Id,BlogDetail blogDetail);
        Task<bool> SaveAllAsync();
    }
}
