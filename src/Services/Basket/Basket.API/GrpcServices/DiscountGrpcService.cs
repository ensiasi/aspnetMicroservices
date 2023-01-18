// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using Discount.Grpc.Protos;
using Grpc.Core;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountGrpcClient;
        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountGrpcClient)
        {
            _discountGrpcClient = discountGrpcClient ?? throw new ArgumentNullException(nameof(discountGrpcClient));
        }
        public async Task<CouponModel> GetDiscount(string  productName)
        {
            var request = new GetDiscountRequest { ProductName=productName};
            return  await _discountGrpcClient.GetDiscountAsync(request);
        }
    }
}
