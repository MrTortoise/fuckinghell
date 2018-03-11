using GildedRose;
using Xunit;

namespace TestProject1
{
    public class RandomItemSpec
    {
        [Fact]
        public void Random_item_will_lose_quality()
        {
            var item = new GenericItem("randomItem", 10, 20);
            item.UpdateItem();

            Assert.Equal(item.Quality, 19);
        }

        [Fact]
        public void Random_item_will_lose_sell_in()
        {
            var item = new GenericItem("randomItem", 10, 20);
            item.UpdateItem();

            Assert.Equal(item.SellIn, 9);
        }

        [Fact]
        public void Random_item_will_lose_2_quality_if_past_sell_by()
        {
            var item = new GenericItem("randomItem", -1, 20);
            item.UpdateItem();

            Assert.Equal(item.Quality, 18);
        }
    }
}