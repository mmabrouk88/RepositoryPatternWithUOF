using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOF.Core.Interfaces;
using RepositoryPatternWithUOF.Core.Models;

namespace RepositoryPatternWithUOF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
       // private readonly IBaseRepository<Author> _atuhorsRepo;
        private readonly IUnitOfWork _unitOfWork;
        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("GetById")]
        public IActionResult GetById() {
            return Ok(_unitOfWork.Authors.GetById(1)) ;
        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(1));
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_unitOfWork.Authors.GetAll());
        }
   
    }
}
