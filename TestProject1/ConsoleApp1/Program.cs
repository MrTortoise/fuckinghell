using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
            var ItemsInStore = new List<Item>
            {
                new Item {Name = "Standard Item", SellIn = 10, Quality = 20},
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

            var app = new Program(ItemsInStore);


            app.UpdateQuality();

            System.Console.ReadKey();
        }


        IList<Item> Items;

        public Program(IList<Item> items)
        {
            Items = items;
        }


        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];

                ProcessItems(item);
            }
        }

        private void ProcessItems(Item item)
        {
            if (item.Name != "Fine Wine" && item.Name != "Fruit" && item.Name != "Tinned Food")
            {
                ReduceQuality(item);
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    IncreaseFruitQuality(item);
                }
            }

            ReduceSellInIfNotTinnedFood(item);

            if (item.SellIn < 0)
            {
                if (item.Name != "Fine Wine")
                {
                    if (item.Name != "Fruit")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Tinned Food")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private void IncreaseFruitQuality(Item item)
        {
            if (item.Name == "Fruit")
            {
                if (item.SellIn < 11)
                {
                    IfQualityLessThan50IncreaseQuality(item);
                }

                if (item.SellIn < 6)
                {
                    IfQualityLessThan50IncreaseQuality(item);
                }
            }
        }

        private void ReduceSellInIfNotTinnedFood(Item item)
        {
            if (item.Name != "Tinned Food")
            {
                item.SellIn = item.SellIn - 1;
            }
        }

        private void IfQualityLessThan50IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private void ReduceQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }
}