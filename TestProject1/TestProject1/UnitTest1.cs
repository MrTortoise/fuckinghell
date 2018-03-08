using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using GildedRose;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
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
        }
    }
}

