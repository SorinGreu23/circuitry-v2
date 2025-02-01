using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services;

public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
    : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(
        GetDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon =
            await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName)
            ?? new Coupon
            {
                ProductName = "No Discount",
                Amount = 0,
                Description = "No discounts were found for the given product",
            };

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<CouponModel> CreateDiscount(
        CreateDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));
        }

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount Successfully Created - ProductName : {ProductName}",
            coupon.ProductName
        );

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<CouponModel> UpdateDiscount(
        UpdateDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request"));
        }

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount Successfully Updated - ProductName : {ProductName}",
            coupon.ProductName
        );

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(
        DeleteDiscountRequest request,
        ServerCallContext context
    )
    {
        var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x =>
            x.ProductName == request.ProductName
        );

        if (coupon is null)
        {
            throw new RpcException(
                new Status(
                    StatusCode.NotFound,
                    $"Discount with ProductName {request.ProductName} was not be found"
                )
            );
        }

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        logger.LogInformation(
            "Discount is successfully deleted. Product name : {ProductName}",
            request.ProductName
        );

        return new DeleteDiscountResponse { Success = true };
    }
}
