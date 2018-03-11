using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class Fruit : Item
    {
        public Fruit(int sellIn, int quality)
        {
            Quality = quality;
            SellIn = sellIn;
            Name = ItemName;
        }

        public const string ItemName = "Fruit";
    }

    public class FineWine : Item
    {
        public FineWine(int sellIn, int quality)
        {
            Quality = quality;
            SellIn = sellIn;
            Name = ItemName;
        }

        public const string ItemName = "Fine Wine";
    }

    public class Program
    {
        public const string StandardItem = "Standard Item";
        public const string TinnedFood = "Tinned Food";
        public const string Salad = "Salad";
        private const int MaxQuality = 50;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var ItemsInStore = new List<Item>
            {
                CreateStandardItem(),
                CreateFineWine(2, 0),
                new Item {Name = TinnedFood, SellIn = 0, Quality = 80},
                new Fruit(15, 20),
                new Item {Name = Salad, SellIn = 3, Quality = 6}
            };

            var app = new Program(ItemsInStore);


            app.UpdateItems();

            System.Console.ReadKey();
        }

        public static FineWine CreateFineWine(int sellIn, int quality)
        {
            return new FineWine(sellIn, quality);
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

        public static void UpdateItem(FineWine wine)
        {
            
        }

        public static void UpdateItem(Fruit fruit)
        {
            if (BelowMaxQuality(fruit))
            {
                fruit.Quality = fruit.Quality + 1;

                if (fruit.SellIn < 11)
                {
                    if (fruit.Quality < MaxQuality)
                    {
                        fruit.Quality = fruit.Quality + 1;
                    }
                }

                if (fruit.SellIn < 6)
                {
                    if (fruit.Quality < MaxQuality)
                    {
                        fruit.Quality = fruit.Quality + 1;
                    }
                }
            }

            DecreaseSellIn(fruit);

            if (NotPassedSellByDate(fruit)) return;

            fruit.Quality = fruit.Quality - fruit.Quality;
        }

        private static bool NotPassedSellByDate(Item item)
        {
            return item.SellIn >= 0;
        }

        private static void DecreaseSellIn(Item fruit)
        {
            fruit.SellIn = fruit.SellIn - 1;
        }

        private static bool BelowMaxQuality(Fruit fruit)
        {
            return fruit.Quality < MaxQuality;
        }

        public static void UpdateItem(Item item)
        {
            switch (item.Name)
            {
                case FineWine.ItemName:
                    if (item.Quality < MaxQuality)
                    {
                        item.Quality = item.Quality + 1;
                    }

                    break;
                case Fruit.ItemName:
                    throw new InvalidOperationException("Fruit is supposed to be handled in its own handler");

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
            if (item.Name != FineWine.ItemName)
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
                if (item.Quality < MaxQuality)
                {
                    item.Quality = item.Quality + 1;
                }
            }
        }
    }
}