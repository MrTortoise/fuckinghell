namespace GildedRose
{
    public class GenericItem : Item, IUpdateItem
    {
        public GenericItem(string name, int sellin, int quality)
        {
            Name = name;
            SellIn = sellin;
            Quality = quality;
        }

        public void UpdateItem()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }


            SellIn = SellIn - 1;


            if (SellIn >= 0) return;

            if (Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}