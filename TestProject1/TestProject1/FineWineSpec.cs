using GildedRose;
using Xunit;

namespace TestProject1
{
    public class FineWineSpec
    {
        [Fact]
        public void FineWineWillGainQuality()
        {
            var item = new FineWine(2, 0);
            item.UpdateItem();
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void FineWineSellInReducesOnUpdate()
        {
            var item = new FineWine(2, 0);
            item.UpdateItem();
            Assert.Equal(1, item.SellIn);
        }

        [Fact]
        public void FineWine_When_sell_in_zero_quality_increases()
        {
            var item = new FineWine(0, 0);
            
            item.UpdateItem();
            Assert.Equal(2, item.Quality);
            Assert.Equal(-1,item.SellIn);
            
            item.UpdateItem();
            Assert.Equal(4, item.Quality);
            Assert.Equal(-2,item.SellIn);
        }

        [Fact]
        public void FineWine_Quality_will_not_exceed_50_with_positive_sellin()
        {
            var item = new FineWine(5, 50);
            
            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(4,item.SellIn);
        }
        
        [Fact]
        public void FineWine_Quality_will_not_exceed_50_with_negative_sellin()
        {
            var item = new FineWine(-1, 50);
            
            item.UpdateItem();
            Assert.Equal(50, item.Quality);
            Assert.Equal(-2,item.SellIn);
        }
    }
}