using GildedRose.Console;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdateQualityTests
    {
        [Fact]
        public void QualityDegradesTwiceAsFastWhenSellInHasPassed()
        {
            var program = new Program();

            program.Items = new List<Item> {
                new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 10 }
            };

            program.UpdateQuality();

            var item = program.Items.First();

            Assert.Equal(8, item.Quality);
        }
    }
}
