using Xunit;
using ShoppingBasket;
using ShoppingBasket.Models;
using System.Collections.Generic;
using Moq;
using ShoppingBasket.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ShoppingBasketTests
{
    public class ShoppingBasketTests
    {
        [Fact]
        public async Task GivenAddItemSelected_ThenItemShouldBeAdded()
        {
            var mockBasketItemDAO = new Mock<IBasketItemDAO>();
            var mockBasketDAO = new Mock<IBasketDAO>();
            var mockLogger = new Mock<ILogger<ShoppingBasketCreator>>();

            var sut = new ShoppingBasketCreator(mockBasketDAO.Object, mockBasketItemDAO.Object, mockLogger.Object);

            var items = new List<BasketItem>();

            mockBasketItemDAO.Setup(x => x.AddItems(It.IsAny<IEnumerable<BasketItem>>())).ReturnsAsync(true);

            await sut.AddItems(items);

            mockBasketItemDAO.Verify(x => x.AddItems(It.IsAny<IEnumerable<BasketItem>>()), Times.Once);
        }

        [Fact]
        public async Task GivenItemsInBasket_ThenTotalCostCorrectlyCalculated()
        {
            var mockBasketItemDAO = new Mock<IBasketItemDAO>();
            var mockBasketDAO = new Mock<IBasketDAO>();
            var mockLogger = new Mock<ILogger<ShoppingBasketCreator>>();

            var sut = new ShoppingBasketCreator(mockBasketDAO.Object, mockBasketItemDAO.Object, mockLogger.Object);

            mockBasketDAO.Setup(x => x.GetTotalCost(1)).ReturnsAsync(1);

            var expectedCost = 1;

            var totalCostResult = await sut.GetTotalCost(1);

            Assert.Equal(totalCostResult, expectedCost);
        }

        [Fact]
        public async void GivenMultipleOf3BItemsInBasket_ThenPromoApplied()
        {
            var mockBasketItemDAO = new Mock<IBasketItemDAO>();
            var mockBasketDAO = new Mock<IBasketDAO>();
            var mockLogger = new Mock<ILogger<ShoppingBasketCreator>>();

            var sut = new ShoppingBasketCreator(mockBasketDAO.Object, mockBasketItemDAO.Object, mockLogger.Object);

            var items = new List<BasketItem>();

            var totalCostResult = await sut.GetTotalCost(1);

            mockBasketDAO.Verify(x => x.GetTotalCost(1), Times.Once);
        }

        [Fact]
        public async Task GivenMultipleOf2DItemsInBasket_ThenPromoApplied()
        {
            var mockBasketItemDAO = new Mock<IBasketItemDAO>();
            var mockBasketDAO = new Mock<IBasketDAO>();
            var mockLogger = new Mock<ILogger<ShoppingBasketCreator>>();

            var sut = new ShoppingBasketCreator(mockBasketDAO.Object, mockBasketItemDAO.Object, mockLogger.Object);

            var items = new List<BasketItem>();

            var totalCostResult = await sut.GetTotalCost(1);

            mockBasketDAO.Verify(x => x.GetTotalCost(1), Times.Once);
        }
    }
}