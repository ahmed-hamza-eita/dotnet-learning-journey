using AutoMapper;
using ECommerce.API.Helper;
using ECommerce.Core.DTO;
using ECommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("get-all")]
        public async Task<ActionResult> GetAllProducts()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync(p => p.Category);

                if (!products.Any())
                    return NotFound(new ResponseAPI(404));

                var result = _mapper.Map<List<ProductDTO>>(products);
                return Ok(new ResponseAPI(200) { Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpGet("get-by-id/{id}", Name = nameof(GetProductById))]
        public async Task<ActionResult> GetProductById(int id)
        {
            try
            {
                var Product = await _unitOfWork.ProductRepository.GetByIdAsync(id, P => P.Category, h => h.Photos);
                if (Product is null)
                    return NotFound(new ResponseAPI(404));

                var result = _mapper.Map<ProductDTO>(Product);
                return Ok(new ResponseAPI(200) { Data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpPost("add-product")]
        public async Task<ActionResult> AddProduct(AddProductDTO dto)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.AddAsync(dto);
                return Ok(new ResponseAPI(201) { Data = product });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }

        }

        [HttpPut("update-product")]
        public async Task<ActionResult> UpdateProduct(UpdateProductDTO dto)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.UpdateAsync(dto);
                return Ok(new ResponseAPI(201));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }

        }
    }
}
