namespace LibraVerse.Core.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LibraVerse.Core.Models.QueryModels.Cart;
    using LibraVerse.Core.Models.ViewModels.Cart;

    public interface ICartService
    {
        Task<CartServiceModel> GetCartAsync(string userId);
        Task AddToCartAsync(string userId, int productId, int quantity);
        Task UpdateCartItemAsync(string? name, int cartItemId, int quantity);
        Task RemoveFromCartAsync(string userId, int productId);
        Task<IEnumerable<CartItemViewModel>> GetCartItemsAsync(string userId);
        Task<int> GetCartItemCountAsync(string userId);
        Task<CartItemViewModel> GetCartItemDetailsAsync(int id);
        Task RemoveCartAsync(string userId);
    }
}
