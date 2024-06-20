﻿using BlazorEshop.Shared;
using BlazorEshop.Shared.DTO;

namespace BlazorEshop.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly BlazoreshopDbContex _context;

        public CartService(BlazoreshopDbContex context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<CartProductResponseDTO>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponseDTO>>
            {
                Data = new List<CartProductResponseDTO>()
            };

            foreach (var item in cartItems)
            {
                var product = await _context.Products
                    .Where(p => p.Id == item.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null)
                {
                    continue;
                }

                var productVariant = await _context.ProductVariants
                    .Where(v => v.ProductId == item.ProductId
                        && v.ProductTypeId == item.ProductTypeId)
                    .Include(v => v.ProductType)
                    .FirstOrDefaultAsync();

                if (productVariant == null)
                {
                    continue;
                }

                var cartProduct = new CartProductResponseDTO
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageUrl,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }

            return result;
        }

        public async Task<ServiceResponse<List<CartProductResponseDTO>>> StoreCartItems(List<CartItem> cartItems, int userId)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = userId);
            _context.CartItems.AddRange(cartItems);
            await _context.SaveChangesAsync();

            return await GetCartProducts(await _context.CartItems.Where(ci => ci.UserId == userId).ToListAsync());
        }
    }
}
