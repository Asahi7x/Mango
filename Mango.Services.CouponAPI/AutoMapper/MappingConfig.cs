using AutoMapper;
using Mango.Services.CouponAPI.DTOs;
using Mango.Services.CouponAPI.Models;
using Microsoft.Extensions.Logging.Abstractions;

namespace Mango.Services.CouponAPI.AutoMapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps ()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDTO, Coupon>();
                config.CreateMap<Coupon, CouponDTO>();

            }, NullLoggerFactory.Instance);

            return mappingConfig;
        }
    }
}
