using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOF.Core.Interfaces;
using RepositoryPatternWithUOF.Core.Models;

namespace RepositoryPatternWithUOF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetById")]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _unitOfWork.Books.GetByIdAsync(1));
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }
        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { AuthorId = 2, Title = "My New Book" });
            _unitOfWork.Complete();
            return Ok(book);
        }
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();

            _unitOfWork.Books.Add(book);
            _unitOfWork.Complete();

            return Ok(book);
        }
        [HttpGet("FindAll")]
        public IActionResult FindAll()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("Book"),new string[] { "Author"}));
        }
    }
}
