using System;
using GildedRose;
using Xunit;

namespace TestProject1
{
    public class FruitSpec
    {
        [Fact]
        public void Quality_will_increase_when_less_50_and_sellin_GET_11()
        {
            var fruit = Program.CreateFruit(11, 20);
            Program.UpdateItem(fruit);

            Assert.Equal(21, fruit.Quality);
        }

        [Fact]
        public void Quality_will_increase_twice_when_less_50_and_sellin_GET_6()
        {
            var fruit = Program.CreateFruit(6, 20);
            Program.UpdateItem(fruit);

            Assert.Equal(22, fruit.Quality);
        }

        [Fact]
        public void Quality_will_increase_thrice_when_less_50_and_sellin_GET_6()
        {
            var fruit = Program.CreateFruit(5, 20);
            Program.UpdateItem(fruit);

            Assert.Equal(23, fruit.Quality);
        }
        
        [Fact]
        public void Quality_will_not_increase_past_50()
        {
            var fruit = Program.CreateFruit(5, 48);
            Program.UpdateItem(fruit);

            Assert.Equal(50, fruit.Quality);
        }

        [Fact]
        public void Fruit_will_lose_sellin()
        {
            var fruit = Program.CreateFruit(0,15);
            Program.UpdateItem(fruit);
            
            Assert.Equal(-1,fruit.SellIn);
        }
    }
}