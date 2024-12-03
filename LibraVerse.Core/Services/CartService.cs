using LibraVerse.Core.Contracts;
using LibraVerse.Core.Models.ViewModels.Cart;
using LibraVerse.Core.Models.QueryModels.Cart;
using LibraVerse.Data.Models.Carts;
using LibraVerse.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using LibraVerse.Data.Models.Mappings;

namespace LibraVerse.Core.Services
{
    public class CartService : ICartService
    {
        private readonly LibraDbContext _context;

        public CartService(LibraDbContext context)
        {
            _context = context;
        }

        public async Task<CartServiceModel> GetCartAsync(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.BooksCarts)
                .ThenInclude(bc => bc.Book)
                .Include(c => c.EventsCarts)
                .ThenInclude(ec => ec.Event)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return new CartServiceModel
                {
                    Items = new List<CartItemViewModel>()
                };
            }

            var cartItems = cart.BooksCarts.Select(bc => new CartItemViewModel
            {
                Id = bc.Book.Id,
                ProductName = bc.Book.Title,
                Quantity = 1, // Assuming quantity is 1 for simplicity
                Price = bc.Book.Price,
                DateAdded = bc.Book.DateAdded
            }).ToList();

            cartItems.AddRange(cart.EventsCarts.Select(ec => new CartItemViewModel
            {
                Id = ec.Event.Id,
                ProductName = ec.Event.Topic,
                Quantity = 1, // Assuming quantity is 1 for simplicity
                Price = ec.Event.TicketPrice,
                DateAdded = ec.Event.DateAdded
            }));

            return new CartServiceModel
            {
                Items = cartItems
            };
        }

        public async Task<CartItemViewModel> GetCartItemDetailsAsync(int id)
        {
            var bookCart = await _context.BooksCarts
                .Include(bc => bc.Book)
                .FirstOrDefaultAsync(bc => bc.Book.Id == id);

            if (bookCart != null)
            {
                return new CartItemViewModel
                {
                    Id = bookCart.Book.Id,
                    ProductName = bookCart.Book.Title,
                    Quantity = 1, // Assuming quantity is 1 for simplicity
                    Price = bookCart.Book.Price,
                    DateAdded = bookCart.Book.DateAdded
                };
            }

            var eventCart = await _context.EventsCarts
                .Include(ec => ec.Event)
                .FirstOrDefaultAsync(ec => ec.Event.Id == id);

            if (eventCart != null)
            {
                return new CartItemViewModel
                {
                    Id = eventCart.Event.Id,
                    ProductName = eventCart.Event.Topic,
                    Quantity = 1, // Assuming quantity is 1 for simplicity
                    Price = eventCart.Event.TicketPrice,
                    DateAdded = eventCart.Event.DateAdded
                };
            }

            return null;
        }

        public async Task AddToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await _context.Carts
                .Include(c => c.BooksCarts)
                .Include(c => c.EventsCarts)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };

                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }

            // Assuming productId can belong to either a book or an event
            var book = await _context.Books.FindAsync(productId);
            if (book != null)
            {
                var bookCart = new BookCart
                {
                    BookId = book.Id,
                    CartId = cart.Id
                };

                await _context.BooksCarts.AddAsync(bookCart);
                await _context.SaveChangesAsync();
                return;
            }

            var eventItem = await _context.Events.FindAsync(productId);
            if (eventItem != null)
            {
                var eventCart = new EventCart
                {
                    EventId = eventItem.Id,
                    CartId = cart.Id
                };

                await _context.EventsCarts.AddAsync(eventCart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCartItemAsync(string? name, int cartItemId, int quantity)
        {
            // Assuming that the quantity is always 1 for simplicity
            // Implementation can be expanded based on actual requirements
        }

        public async Task RemoveFromCartAsync(string userId, int cartItemId)
        {
            var cart = await _context.Carts
                .Include(c => c.BooksCarts)
                .Include(c => c.EventsCarts)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null) return;

            var bookCart = cart.BooksCarts.FirstOrDefault(bc => bc.BookId == cartItemId);
            if (bookCart != null)
            {
                _context.BooksCarts.Remove(bookCart);
                await _context.SaveChangesAsync();
                return;
            }

            var eventCart = cart.EventsCarts.FirstOrDefault(ec => ec.EventId == cartItemId);
            if (eventCart != null)
            {
                _context.EventsCarts.Remove(eventCart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCartAsync(string userId)
        {
            var cart = await _context.Carts
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CartItemViewModel>> GetCartItemsAsync(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.BooksCarts)
                .ThenInclude(bc => bc.Book)
                .Include(c => c.EventsCarts)
                .ThenInclude(ec => ec.Event)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return new List<CartItemViewModel>();
            }

            var cartItems = cart.BooksCarts.Select(bc => new CartItemViewModel
            {
                Id = bc.Book.Id,
                ProductName = bc.Book.Title,
                Quantity = 1, // Assuming quantity is 1 for simplicity
                Price = bc.Book.Price,
                DateAdded = bc.Book.DateAdded
            }).ToList();

            cartItems.AddRange(cart.EventsCarts.Select(ec => new CartItemViewModel
            {
                Id = ec.Event.Id,
                ProductName = ec.Event.Topic,
                Quantity = 1, // Assuming quantity is 1 for simplicity
                Price = ec.Event.TicketPrice,
                DateAdded = ec.Event.DateAdded
            }));

            return cartItems;
        }

        public async Task<int> GetCartItemCountAsync(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.BooksCarts)
                .Include(c => c.EventsCarts)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                return 0;
            }

            int bookCount = cart.BooksCarts.Count;
            int eventCount = cart.EventsCarts.Count;

            return bookCount + eventCount;
        }
    }
}
