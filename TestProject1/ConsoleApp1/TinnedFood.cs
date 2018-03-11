namespace GildedRose
{
    public class TinnedFood : Item, IUpdateItem
    {
        public TinnedFood(int sellId, int quality)
        {
            Name = ItemName;
            Quality = quality;
            SellIn = sellId;
        }

        public const string ItemName = "Tinned Food";
        public void UpdateItem()
        {
            
        }
    }
}