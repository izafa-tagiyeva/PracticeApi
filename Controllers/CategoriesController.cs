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
        public async Task<IActionResult> Read(CategoryItemDto dto)
        {
            return Ok($"Category {dto}");
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto dto)
        {
            await _context.Categories.AddAsync(new Entities.Categories
            {
                Name = dto.Name,
            });
            await _context.SaveChangesAsync();
            return Ok("Category created succesfully");
        }
       

        [HttpPut]
        public async Task<IActionResult> Update(int? id, string name)
        {

            if (!id.HasValue) throw new ArgumentNullException("Code cannot be null or empty");

            var data = await _context.Categories.FindAsync(id);

            if (data is null) throw new KeyNotFoundException("Data not found for the given code");
           
            data.Name= name;


            await _context.SaveChangesAsync();
            return Ok("Category updated succesfully");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {

            if (!id.HasValue) throw new ArgumentNullException("Code cannot be null or empty");

            var data = await _context.Categories.FindAsync(id);

            if (data is null) throw new KeyNotFoundException("Data not found for the given code");
            _context.Categories.Remove(data);
            await _context.SaveChangesAsync();
            return Ok("Category deleted succesfully");
        }
    }
}
