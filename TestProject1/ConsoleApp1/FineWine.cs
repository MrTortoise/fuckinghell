namespace GildedRose
{
    public class FineWine : Item, IUpdateItem
    {
        private const int MaxQuality = 50;
        
        public FineWine(int sellIn, int quality)
        {
            Quality = quality;
            SellIn = sellIn;
            Name = ItemName;
        }

        public const string ItemName = "Fine Wine";
        public void UpdateItem()
        {
            if (Quality < MaxQuality)
            {
                Quality = Quality + 1;
            }


            SellIn = SellIn - 1;
            if (SellIn >= 0) return;

            if (Quality < MaxQuality)
            {
                Quality = Quality + 1;
            }
        }
    }
}