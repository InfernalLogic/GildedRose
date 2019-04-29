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

        [Theory]
        [InlineData("+5 Dexterity Vest")]
        [InlineData("Elixir of the Mongoose")]
        [InlineData("Sulfuras, Hand of Ragnaros")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert")]
        [InlineData("Conjured Mana Cake")]
        public void QualityOfAnItemIsNeverNegative(string productName)
        {
            var item = new Item
            {
                Quality = 0,
                SellIn = 0,
                Name = productName
            };

            Program.UpdateItem(item);
            Assert.True(item.Quality >= 0);
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

        [Theory]
        [InlineData("Aged Brie")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert")]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 2, 48)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 10, 49)]
        public void QualityOfAnItemIsNeverGreaterThan50(string itemName, int sellIn = 2, int initialQuality = 50)
        {
            var item = new Item
            {
                Quality = initialQuality,
                SellIn = sellIn,
                Name = itemName
            };

            Program.UpdateItem(item);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void Sulfuras_QualityDoesNotDecrease()
        {
            int quality = 1;
            var item = new Item
            {
                Quality = quality,
                SellIn = 1,
                Name = "Sulfuras, Hand of Ragnaros"
            };

            Program.UpdateItem(item);
            Assert.Equal(quality, item.Quality);
        }

        [Fact]
        public void Sulfuras_SellInDoesNotDecrease()
        {
            int sellIn = 1;
            var item = new Item
            {
                Quality = 1,
                SellIn = sellIn,
                Name = "Sulfuras, Hand of Ragnaros"
            };

            Program.UpdateItem(item);
            Assert.Equal(sellIn, item.SellIn);
        }

        
        [Theory]
        [InlineData(11,11)]
        [InlineData(12, 10)]
        [InlineData(13,5)]
        [InlineData(12,6)]
        [InlineData(0,0)]
        [InlineData(13,1)]
        public void BackStagePasses_QualityIncreases(int expectedQuality, int sellIn)
        {
            var item = new Item
            {
                Quality = 10,
                SellIn = sellIn,
                Name = "Backstage passes to a TAFKAL80ETC concert"
            };

            Program.UpdateItem(item);
            Assert.Equal(expectedQuality, item.Quality);
        }
    }
}