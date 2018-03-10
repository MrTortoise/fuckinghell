using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class Program
    {
        public const string StandardItem = "Standard Item";
        public const string FineWine = "Fine Wine";
        public const string TinnedFood = "Tinned Food";
        public const string Fruit = "Fruit";
        public const string Salad = "Salad";

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var ItemsInStore = new List<Item>
            {
                CreateStandardItem(),
                CreateFineWine(2, 0),
                new Item {Name = TinnedFood, SellIn = 0, Quality = 80},
                CreateFruit(15, 20),
                new Item {Name = Salad, SellIn = 3, Quality = 6}
            };

            var app = new Program(ItemsInStore);


            app.UpdateItems();

            System.Console.ReadKey();
        }

        public static Item CreateFruit(int sellIn, int quality)
        {
            return new Item
            {
                Name = Fruit,
                SellIn = sellIn,
                Quality = quality
            };
        }

        public static Item CreateFineWine(int sellIn, int quality)
        {
            return new Item {Name = FineWine, SellIn = sellIn, Quality = quality};
        }

        private static Item CreateStandardItem()
        {
            return new Item {Name = StandardItem, SellIn = 10, Quality = 20};
        }


        IList<Item> Items;

        public Program(IList<Item> items)
        {
            Items = items;
        }


        public void UpdateItems()
        {
            foreach (var item in Items)
            {
                UpdateItem(item);
            }
        }

        public static void UpdateItem(Item item)
        {
            switch (item.Name)
            {
                case FineWine:
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }

                    break;
                case Fruit:
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }

                    break;
                case TinnedFood:
                    break;
                default:
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }

                    break;
            }


            if (item.Name != TinnedFood)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn >= 0) return;

            if (item.Name != FineWine)
            {
                if (item.Name != Fruit)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != TinnedFood)
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
}