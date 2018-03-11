namespace GildedRose
{
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
}