using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdateQualityTests
    {
        [Fact]
        public void QualityDegradesByOne_WhenSellByDateIsNotPast()
        {
            var item = new Item
            {
                Quality = 1,
                SellIn = 1
            };

            Program.UpdateItem(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void SellInDegradesByOne_WhenSellByDateIsNotPast()
        {
            var item = new Item
            {
                Quality = 1,
                SellIn = 1
            };

            Program.UpdateItem(item);
            Assert.Equal(0, item.SellIn);
        }

        [Fact]
        public void QualityDegradesTwiceAsFast_WhenSellByDateIsPast()
        {
            var item = new Item
            {
                Quality = 2,
                SellIn = 0
            };

            Program.UpdateItem(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void QualityOfAnItemIsNeverNegative()
        {
            var item = new Item
            {
                Quality = 0,
                SellIn = 0
            };

            Program.UpdateItem(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void QualityOfAgedBrieIncreases_AsTimeGoesBy()
        {
            var item = new Item
            {
                Quality = 0,
                SellIn = 1,
                Name = "Aged Brie"
            };

            Program.UpdateItem(item);
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void QualityOfAgedBrieIncreasesByTwo_AfterExpiration()
        {
            var item = new Item
            {
                Quality = 0,
                SellIn = 0,
                Name = "Aged Brie"
            };

            Program.UpdateItem(item);
            Assert.Equal(2, item.Quality);
        }

        [Fact]
        public void QualityOfAnItemIsNeverGreaterThan50()
        {
            var item = new Item
            {
                Quality = 49,
                SellIn = 0,
                Name = "Aged Brie"
            };

            Program.UpdateItem(item);
            Assert.Equal(2, item.Quality);
        }
    }
}