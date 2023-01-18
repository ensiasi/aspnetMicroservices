// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this
using AutoMapper;
using Discount.Grpc.Entities;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mapper
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon,CouponModel>().ReverseMap();
        }
    }
}
