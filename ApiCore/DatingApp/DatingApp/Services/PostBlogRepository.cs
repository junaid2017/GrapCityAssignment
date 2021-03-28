using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.Data;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Services
{
    public class PostBlogRepository : IPostBlogRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PostBlogRepository(DataContext context, IUserRepository userRepository, IMapper mapper)
        {
            this._dataContext = context;
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<int> PostBlog(BlogDetail postDetail, int appUserId)
        {
            var PostDetails = new BlogDetail
            {
                AppUserId = appUserId,
                BlogTitle = postDetail.BlogTitle,
                BlogDescription = postDetail.BlogDescription,
                DeletedPost = postDetail.DeletedPost,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            _dataContext.BlogDetails.Add(PostDetails);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogDetailDto>> GetBlogsAsync()
        {
            return await _dataContext.BlogDetails
                  .ProjectTo<BlogDetailDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<BlogDetailDto>> GetBlogByIdAsync(int appUserId)
        {
            return await _dataContext.BlogDetails.ProjectTo<BlogDetailDto>(_mapper.ConfigurationProvider).Where(x => x.AppUserId == appUserId).ToListAsync();
        }

        public async Task<int> DeleteBlog(int? Id)
        {
            var id = await _dataContext.BlogDetails.FindAsync(Id);
            if (id == null)
            {
                return 0;
            }
            try
            {
                _dataContext.BlogDetails.Remove(id);
                return await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return 0;
            }
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public void UpdateBlog(int id, BlogDetail blogDetail)
        {
            var entity = _dataContext.BlogDetails.FirstOrDefault(item => item.Id == id);
            if (entity != null)
            {
                entity.BlogTitle = blogDetail.BlogTitle;
                entity.BlogDescription = blogDetail.BlogDescription;
                entity.UpdatedDate = DateTime.Now;
               // _dataContext.SaveChanges();
            }
        }
    }

}
