using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.DTOs;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly AppDbContext _context;
        private ResponseDto _response;
        private IMapper _mapper;

        public CouponController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _response = new ResponseDto();
            _mapper = mapper;
        }


        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _context.Coupons.ToList();


                _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(coupons);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon coupon = _context.Coupons.First(u => u.CouponId == id);
                _response.Result = _mapper.Map<CouponDTO>(coupon); 
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
