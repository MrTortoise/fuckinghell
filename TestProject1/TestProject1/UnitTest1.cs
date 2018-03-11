using GildedRose;
using Xunit;

namespace TestProject1
{
    public class TinnedFoodSpec
    {
        [Fact]
        public void Tinned_food_will_not_have_quality_change()
        {
            var tinnedFood = new TinnedFood(10, 20);
            tinnedFood.UpdateItem();

            Assert.Equal(tinnedFood.Quality, 20);
        }

        [Fact]
        public void Tinned_food_does_not_reduce_sell_in()
        {
            var tinnedFood = new TinnedFood(10, 20);
            tinnedFood.UpdateItem();

            Assert.Equal(tinnedFood.SellIn, 10);
        }
    }
}