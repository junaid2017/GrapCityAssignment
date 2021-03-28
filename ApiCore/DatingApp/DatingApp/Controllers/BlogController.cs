using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DatingApp.Data;
using DatingApp.DTOs;
using DatingApp.Entities;
using DatingApp.Extensions;
using DatingApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Controllers
{
    public class BlogController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogController(IUserRepository userRepository,IPostBlogRepository blogRepository,IMapper mapper)
        {
            this._userRepository = userRepository;
            this._blogRepository = blogRepository;
            this._mapper = mapper;
        }
        [Authorize]
        [HttpPost("CreateBlog")]
        public async Task<ActionResult> PostBlog([FromBody]BlogDetail postDetails)
        {
            var user = await _userRepository.GetUserByUserNameAsync(User.GetUsername());
            var appuserid = user.Id;
            var result=await _blogRepository.PostBlog(postDetails, appuserid);
            if (result.Equals(1))
                return Ok();
            else return BadRequest();
        }
        [Authorize]
        [HttpGet("GetBlogs")]
        public async Task<ActionResult> GetBlogs()
        {
            var user = await _userRepository.GetUserByUserNameAsync(User.GetUsername());
            var users = await _blogRepository.GetBlogsAsync();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("GetBlogs/{appuserId}")]
        public async Task<ActionResult> GetBlogById(int appuserId)
        {
            var users = await _blogRepository.GetBlogByIdAsync(appuserId);
            return Ok(users);
        }

        [Authorize]
        [HttpDelete("DeleteBlog/{Id}")]
        public async Task<ActionResult> DeleteBlog(int? Id)
        {
            var result = await _blogRepository.DeleteBlog(Id);
            if (result.Equals(1))
               return Ok();
            else
               return BadRequest();
        }
       
        [Authorize]
        [HttpPut("PutBlog")]
        public async Task<ActionResult> PutBlog([FromBody] BlogDetail blogDetails)
        {
            int id = blogDetails.Id;
            _blogRepository.UpdateBlog(id, blogDetails);
            if (await _blogRepository.SaveAllAsync()) return Ok();
            else
                return BadRequest();
        }

    }
}
