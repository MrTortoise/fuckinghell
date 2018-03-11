using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public interface IUpdateItem
    {
        void UpdateItem();
    }

    public class Program
    {
        public const string StandardItem = "Standard Item";
        public const string Salad = "Salad";


        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var ItemsInStore = new List<IUpdateItem>
            {
                new GenericItem(StandardItem, 10, 20),
                new FineWine(2, 0),
                new TinnedFood(0, 80),
                new Fruit(15, 20),
                new GenericItem(Salad, 3, 6)
            };

            var app = new Program(ItemsInStore);


            app.UpdateItems();

            System.Console.ReadKey();
        }


        IList<IUpdateItem> Items;

        public Program(IList<IUpdateItem> items)
        {
            Items = items;
        }


        public void UpdateItems()
        {
            foreach (var item in Items)
            {
                item.UpdateItem();
            }
        }
    }
}