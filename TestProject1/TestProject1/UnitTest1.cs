using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
=======
>>>>>>> timetravel
using GildedRose;
using Xunit;

namespace TestProject1
{
    public class FruitSpec
    {
        [Fact]
        public void Quality_will_increase_when_less_50_and_sellin_GET_11()
        {
<<<<<<< HEAD
            var standardItem = "Standard Item";
            var ItemsInStore = new List<Item>
            {
                new Item {Name = standardItem, SellIn = 10, Quality = 20},
                new Item {Name = "Fine Wine", SellIn = 2, Quality = 0},
                new Item {Name = "Tinned Food", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Fruit",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Salad", SellIn = 3, Quality = 6}
            };


            var master = SerialiseItems(ItemsInStore);

            var app = new Program(ItemsInStore);
            app.UpdateQuality();

            var result = SerialiseItems(ItemsInStore);
            var expected = "Standard Item199Fine Wine11Tinned Food800Fruit2114Salad52";
            
            Assert.Equal(expected,result);

        }

        private string SerialiseItems(List<Item> itemsInStore)
        {
            return itemsInStore.Aggregate(string.Empty, (s, item) => { return s + SerialiseItem(item); });
        }

        private string SerialiseItem(Item item)
        {
            return item.Name + item.Quality.ToString() + item.SellIn.ToString();
=======
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
>>>>>>> timetravel
        }
    }
}

