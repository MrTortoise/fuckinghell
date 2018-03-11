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
}