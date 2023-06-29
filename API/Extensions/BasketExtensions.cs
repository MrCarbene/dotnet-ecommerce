using System.Linq;
using Core.Dtos;
using Core.Entities;

namespace API.Extensions
{
    public static class BasketExtensions
    {
        public static BasketDto MapBasketToDto(this Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                PaymentIntentId = basket.PaymentIntentId,
                ClientSecret = basket.ClientSecret,
                Items = basket.Items
                    .Select(
                        item =>
                            new BasketItemDto
                            {
                                ProductId = item.ProductId,
                                Name = item.Product.Name,
                                Price = item.Product.Price,
                                PictureUrl = item.Product.PictureUrl,
                                Type = item.Product.Type,
                                Brand = item.Product.Brand,
                                Quantity = item.Quantity
                            }
                    )
                    .ToList()
            };
        }
    }
}