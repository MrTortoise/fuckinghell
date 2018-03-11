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
        public const string Salad = "Salad";
        private const int MaxQuality = 50;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var ItemsInStore = new List<Item>
            {
                CreateStandardItem(),
                CreateFineWine(2, 0),
                CreateTinnedFood(0, 80),
                CreateFruit(15, 20),
                new Item {Name = Salad, SellIn = 3, Quality = 6}
            };

            var app = new Program(ItemsInStore);


            app.UpdateItems();

            System.Console.ReadKey();
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
            if (wine.Quality < MaxQuality)
            {
                wine.Quality = wine.Quality + 1;
            }


            wine.SellIn = wine.SellIn - 1;
            if (wine.SellIn >= 0) return;

            if (wine.Quality < MaxQuality)
            {
                wine.Quality = wine.Quality + 1;
            }
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

        public static void UpdateItem(TinnedFood item)
        {
        }

        public static void UpdateItem(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }


            item.SellIn = item.SellIn - 1;


            if (item.SellIn >= 0) return;

            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        public static Item CreateGenericItem(string randomitem, int sellIn, int quality)
        {
            return new Item {Name = randomitem, Quality = quality, SellIn = sellIn};
        }

        public static TinnedFood CreateTinnedFood(int sellIn, int quality)
        {
            return new TinnedFood(sellIn, quality);
        }

        public static FineWine CreateFineWine(int sellIn, int quality)
        {
            return new FineWine(sellIn, quality);
        }

        private static Item CreateStandardItem()
        {
            return new Item {Name = StandardItem, SellIn = 10, Quality = 20};
        }

        private static Fruit CreateFruit(int sellIn, int quality)
        {
            return new Fruit(sellIn, quality);
        }
    }
}