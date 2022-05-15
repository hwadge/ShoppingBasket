using Xunit;
using ShoppingBasket;
using ShoppingBasket.Models;
using System.Collections.Generic;

namespace ShoppingBasketTests
{
    public class ShoppingBasketTests
    {

        [Fact]
        public void GivenAddItemSelected_ThenItemShouldBeAdded()
        {
            var sut = new ShoppingBasketCreator();

            var items = new List<BasketItem>();

            sut.AddItems(items);

            var addedItemsResult = sut.GetItems();

            Assert.Equal(addedItemsResult, items);

        }

        [Fact]
        public void GivenItemsInBasket_ThenTotalCostCorrectlyCalculated()
        {
            var sut = new ShoppingBasketCreator();

            var items = new List<BasketItem>();

            var expectedCost = 1;

            sut.AddItems(items);

            var totalCostResult = sut.GetTotalCost();

            Assert.Equal(totalCostResult, expectedCost);
        }

        [Fact]
        public void GivenMultipleOf3BItemsInBasket_ThenPromoApplied()
        {
            var sut = new ShoppingBasketCreator();

            var items = new List<BasketItem>();

            var expectedCost = 1;

            sut.AddItems(items);

            var totalCostResult = sut.GetTotalCost();

            Assert.Equal(totalCostResult, expectedCost);
        }

        [Fact]
        public void GivenMultipleOf2DItemsInBasket_ThenPromoApplied()
        {
            var sut = new ShoppingBasketCreator();

            var items = new List<BasketItem>();

            var expectedCost = 1;

            sut.AddItems(items);

            var totalCostResult = sut.GetTotalCost();

            Assert.Equal(totalCostResult, expectedCost);
        }
    }
}