using GildedRose;
using Xunit;

namespace TestProject1
{
    public class FineWineSpec
    {
        [Fact]
        public void FineWineWillGainQuality()
        {
            var item = Program.CreateFineWine(2, 0);
            Program.UpdateItem(item);
            Assert.Equal(1, item.Quality);
        }

        [Fact]
        public void FineWineSellInReducesOnUpdate()
        {
            var item = Program.CreateFineWine(2, 0);
            Program.UpdateItem(item);
            Assert.Equal(1, item.SellIn);
        }

        [Fact]
        public void FineWine_When_sell_in_zero_quality_increases()
        {
            var item = Program.CreateFineWine(0, 0);
            
            Program.UpdateItem(item);
            Assert.Equal(2, item.Quality);
            Assert.Equal(-1,item.SellIn);
            
            Program.UpdateItem(item);
            Assert.Equal(4, item.Quality);
            Assert.Equal(-2,item.SellIn);
        }

        [Fact]
        public void FineWine_Quality_will_not_exceed_50_with_positive_sellin()
        {
            var item = Program.CreateFineWine(5, 50);
            
            Program.UpdateItem(item);
            Assert.Equal(50, item.Quality);
            Assert.Equal(4,item.SellIn);
        }
        
        [Fact]
        public void FineWine_Quality_will_not_exceed_50_with_negative_sellin()
        {
            var item = Program.CreateFineWine(-1, 50);
            
            Program.UpdateItem(item);
            Assert.Equal(50, item.Quality);
            Assert.Equal(-2,item.SellIn);
        }
    }
}