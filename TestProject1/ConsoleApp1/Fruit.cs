namespace GildedRose
{
    public class Fruit : Item, IUpdateItem
    {
        private const int MaxQuality = 50;
        public const string ItemName = "Fruit";
        
        public Fruit(int sellIn, int quality)
        {
            Quality = quality;
            SellIn = sellIn;
            Name = ItemName;
        }

        public void UpdateItem()
        {
            if (BelowMaxQuality())
            {
                Quality = Quality + 1;

                if (SellIn < 11)
                {
                    if (Quality < MaxQuality)
                    {
                        Quality = Quality + 1;
                    }
                }

                if (SellIn < 6)
                {
                    if (Quality < MaxQuality)
                    {
                        Quality = Quality + 1;
                    }
                }
            }

            DecreaseSellIn();

            if (NotPassedSellByDate()) return;

            Quality = Quality - Quality;
        }
        
        private bool BelowMaxQuality()
        {
            return Quality < MaxQuality;
        }
        
        private bool NotPassedSellByDate()
        {
            return SellIn >= 0;
        }

        private void DecreaseSellIn()
        {
            SellIn = SellIn - 1;
        }
    }
}