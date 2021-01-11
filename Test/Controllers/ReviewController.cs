using System;
using System.Linq;
using System.Threading.Tasks;
using bookshelf.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bookshelf.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("/Reviews")]
    [FormatFilter]
    
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly BookDBContext _context;

        public ReviewController(ILogger<ReviewController> logger, BookDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet("/Reviews")]
        [Produces("application/json")]
        public IActionResult Get()
        {
            var result = _context.Reviews.Join(
                _context.Users,
                review => review.User.Id,
                user => user.Id,
                (review, user) => new
                {
                    review,
                    user
                }).Join(
                _context.Books,
                combined => combined.review.Book.Id,
                book => book.Id,
                (combined, book) => new
                {
                    Review = combined.review,
                    User = combined.user,
                    Book = book,
                }).Join(_context.Authors,
                nested => nested.Book.Author.Id,
                author => author.Id,
                (nested, author) => new
                {
                    Review = nested.Review,
                    User = nested.User,
                    Book = nested.Book,
                    Author = author
                });
            return Ok(result.ToList());
        }
        
        [HttpGet("/Reviews/{id}")]
        [Produces("application/json")]
        public IActionResult GetReview(Guid id)
        {
            var result = _context.Reviews.Join(
                _context.Users,
                review => review.User.Id,
                user => user.Id,
                (review, user) => new
                {
                    review,
                    user
                }).Join(
                _context.Books,
                combined => combined.review.Book.Id,
                book => book.Id,
                (combined, book) => new
                {
                    Review = combined.review,
                    User = combined.user,
                    Book = book,
                }).Join(_context.Authors,
                nested => nested.Book.Author.Id,
                author => author.Id,
                (nested, author) => new
                {
                    ReviewId = nested.Review.Id,
                    Review = nested.Review,
                    User = nested.User,
                    Book = nested.Book,
                    Author = author
                }).Where(fullReview => fullReview.ReviewId == id);
            return Ok(result);
        }
        
        [HttpDelete("/Reviews/{id}")]
        public async Task<IActionResult> DeleteReview(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpPost("/Reviews/review={rev}&user={user}&book={book}")]
        public async Task<ActionResult<Review>> AddReview(string rev, Guid user, Guid book)
        {
            var review = new Review
            {
                 UserReview = $"{rev}",
                 User = _context.Users.Find(user),
                 Book = _context.Books.Find(book)
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}