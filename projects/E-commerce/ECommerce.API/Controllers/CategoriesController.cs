using AutoMapper;
using ECommerce.API.Helper;
using ECommerce.Core.DTO;
using ECommerce.Core.Entities.Products;
using ECommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
                if (!categories.Any())
                    return NotFound(new ResponseAPI(404, $"No categories found"));

                return Ok(value: new ResponseAPI(200) { Data = categories });

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }


        [HttpGet("get-by-id/{id}", Name = nameof(GetCategoryById))]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
                if (category is null)
                    return NotFound(new ResponseAPI(404, $"No category found with Id: {id}"));

                return Ok(value: new ResponseAPI(200) { Data = category });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpPost("add-category")]
        public async Task<ActionResult> AddCategory(CategoryDTO categoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDto);
                await _unitOfWork.CategoryRepository.AddAsync(category);
                await _unitOfWork.SaveChangesAsync();

                return CreatedAtRoute(nameof(GetCategoryById), new { id = category.Id }
                                               , new ResponseAPI(201) { Data = category });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }
    }
}
