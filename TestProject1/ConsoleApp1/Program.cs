﻿using System;
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
                if (Items[i].Name != "Fine Wine" && Items[i].Name != "Fruit")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Tinned Food")
                        {
                            Items[i].Quality = Items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (Items[i].Name == "Fruit")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Tinned Food")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Fine Wine")
                    {
                        if (Items[i].Name != "Fruit")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Tinned Food")
                                {
                                    Items[i].Quality = Items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
            }
        }

    }
}