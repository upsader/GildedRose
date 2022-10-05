using GildedRose.Console;

public abstract class AbstractItem
{
    public Item Item;
    public abstract int MaxQuality { get; }
    public abstract int MinQuality { get; }
    public abstract int SellInDefault { get; }
    public abstract SellInCheckTypeEnum SellInType { get; }
    public abstract int QualityDecrement { get; }
    public abstract int QualityIncrement { get; }
    public abstract int SellInDecrement { get; }
    public abstract int SellInIncrement { get; }
    public AbstractItem(Item item)
    {
        Item = item;
    }

    public abstract void Update();

    public void UpdateIfOverdue()
    {
        switch (SellInType)
        {
            case SellInCheckTypeEnum.Default:
                if (Item.SellIn < SellInDefault && Item.Quality > MinQuality)
                {
                    Item.Quality = Item.Quality - QualityDecrement;
                }
                break;
            case SellInCheckTypeEnum.Overdue:
                if (Item.SellIn < SellInDefault && Item.Quality < MaxQuality)
                {
                    Item.Quality = Item.Quality - Item.Quality;
                }
                break;
            case SellInCheckTypeEnum.Conjured:
                if (Item.SellIn < SellInDefault && Item.Quality > MinQuality)
                {
                    Item.Quality = Item.Quality - QualityDecrement;
                }
                break;
            case SellInCheckTypeEnum.Increased:
                if (Item.SellIn < SellInDefault && Item.Quality < MaxQuality)
                {
                    Item.Quality = Item.Quality + QualityIncrement;
                }
                break;
        }
    }

}