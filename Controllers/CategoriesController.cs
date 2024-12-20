using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice.DAL;
using Practice.DTOs.Categories;

namespace Practice.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController(PracticeDbContext _context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Read()
        {
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            await _context.Categories.AddAsync(new Entities.Categories
            {
                Name = dto.Name,
            });
            await _context.SaveChangesAsync();
            return Ok();
        }
       

        [HttpPut]
        public async Task<IActionResult> Update(int? id)
        {

            if (!id.HasValue) throw new ArgumentNullException("Code cannot be null or empty");

            var data = await _context.Categories.FindAsync(id);

            if (data is null) throw new KeyNotFoundException("Data not found for the given code");
            CategoryUpdateDto _dto = new();
            _dto.Name=data.Name;


            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {

            if (!id.HasValue) throw new ArgumentNullException("Code cannot be null or empty");

            var data = await _context.Categories.FindAsync(id);

            if (data is null) throw new KeyNotFoundException("Data not found for the given code");
            _context.Categories.Remove(data);
            return Ok();
        }
    }
}
