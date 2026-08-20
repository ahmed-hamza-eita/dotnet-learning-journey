using AutoMapper;
using ECommerce.API.Helper;
using ECommerce.Core.Entities.Basket;
using ECommerce.Core.Helper;
using ECommerce.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]

    public class BasketController : BaseController
    {
        public BasketController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("get-basket-item/{Id}")]
        public async Task<IActionResult> GetBasket(string Id)
        {
            var result = await _unitOfWork.CustomerBasketRepository.GetBasketAsync(Id);

            if (result is null)
                return NotFound(new ResponseAPI(404, $"No basket found with Id: {Id}"));

            return Ok(value: new ResponseAPI(200) { Data = result });

        }


        [HttpPost("update-basket")]
        public async Task<IActionResult> UpdateBasket(CustomerBasket basket)
        {
            var result = await _unitOfWork.CustomerBasketRepository.UpdateBasketAsync(basket);

            return StatusCode(201, new ResponseAPI(201) { Data = result });
        }


        [HttpDelete("delete-basket-item/{Id}")]
        public async Task<IActionResult> DeleteBasket(string Id)
        {
            var result = await _unitOfWork.CustomerBasketRepository.DeleteBasket(Id);
            if (result is false)
                return NotFound(new ResponseAPI(404, $"No basket found with Id: {Id}"));

            return Ok(value: new ResponseAPI(200, "Item Deleted"));
        }
    }
}
