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
                
            };
        }
    }
}
