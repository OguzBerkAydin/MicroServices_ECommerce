using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommerce.Comment.Context;
using ECommerce.Comment.Entities;

namespace ECommerce.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        // GET: api/UserComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserComment>>> GetUserComments()
        {
            return await _context.UserComments.ToListAsync();
        }
		[HttpGet("ByProductId/{id}")]
		public async Task<IActionResult> GetUserComments(string id)
		{
			var comments = await _context.UserComments.Where(c => c.ProductId == id).ToListAsync();
			return Ok(comments);
		}

		// GET: api/UserComments/5
		[HttpGet("{id}")]
        public async Task<ActionResult<UserComment>> GetUserComment(int id)
        {
            var userComment = await _context.UserComments.FindAsync(id);

            if (userComment == null)
            {
                return NotFound();
            }

            return userComment;
        }
        [HttpPost]
        public async Task<IActionResult> PostUserComment(UserComment userComment)
        {
            _context.UserComments.Add(userComment);
            await _context.SaveChangesAsync();
            return Ok("Comment added successfully");
        }
        [HttpPut]
		public async Task<IActionResult> PutUserComment(UserComment userComment)
		{
			_context.UserComments.Update(userComment);
			await _context.SaveChangesAsync();
			return Ok("Comment updated successfully");
		}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserComment(int id)
            {
            var userComment = await _context.UserComments.FindAsync(id);
            if (userComment == null)
            {
                return NotFound();
            }
            _context.UserComments.Remove(userComment);
            await _context.SaveChangesAsync();
            return Ok("Comment deleted successfully");
		}

	}
}
