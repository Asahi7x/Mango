using Mango.Services.CouponAPI.Data;
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
        public CouponController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public object Get()
        {
            try
            {
                IEnumerable<Coupon> coupons = _context.Coupons.ToList();
                return coupons;
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon coupon = _context.Coupons.First(u => u.CouponId == id);
                return coupon;
            }
            catch (Exception)
            {

                throw;
            }

            return null;
        }
    }
}
