using Microsoft.Extensions.Logging;
using ShoppingBasket.Interfaces;
using ShoppingBasket.Models;

namespace ShoppingBasket
{
    public class ShoppingBasketCreator
    {
        private readonly IBasketDAO _basketDAO;
        private readonly IBasketItemDAO _basketItemDAO;
        private readonly ILogger<ShoppingBasketCreator> _logger;

        public ShoppingBasketCreator(IBasketDAO basketDAO, IBasketItemDAO basketItemDAO, ILogger<ShoppingBasketCreator> logger)
        {
            _basketDAO = basketDAO;
            _basketItemDAO = basketItemDAO;
            _logger = logger;
        }

        public async Task<bool> CreateBasket(Basket basket)
        {
            try
            {
                await _basketDAO.CreateBasket(basket);
            }
            catch (Exception ex)
            {
                _logger.LogError("Create basket error!", ex);
                return false;
            }

            return true;
        }

        public async Task<bool> AddItems(IEnumerable<BasketItem> items)
        {
            try
            {
                await _basketItemDAO.AddItems(items);
            }
            catch (Exception ex)
            {
                _logger.LogError("Add items error!", ex);
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<BasketItem>?> GetItems(IEnumerable<int> ids)
        {
            try
            {
                return await _basketItemDAO.GetItems(ids);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get items error!", ex);
                return null;
            }
        }

        public async Task<bool> DeleteItems(IEnumerable<int> ids)
        {
            try
            {
                await _basketItemDAO.DeleteItems(ids);
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete items error!", ex);
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteBasket(int id)
        {
            try
            {
                await _basketDAO.DeleteBasket(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete basket error!", ex);
                return false;
            }

            return true;
        }

        public async Task<double?> GetTotalCost(int id)
        {
            try
            {
                return await _basketDAO.GetTotalCost(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("Get total cost error!", ex);
                return null;
            }
        }
    }
}
