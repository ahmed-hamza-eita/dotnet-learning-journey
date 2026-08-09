using ECommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
                if (!categories.Any())
                    return NotFound();
                return Ok(categories);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (category is null)
                    return NotFound($"No category found with Id: {id}");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
