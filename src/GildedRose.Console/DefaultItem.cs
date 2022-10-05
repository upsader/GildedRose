using GildedRose.Console;
using System;

public class DefaultItem : AbstractItem
{

    public override int MaxQuality { get; }
    public override int MinQuality { get; }
    public override int SellInDefault { get; }
    public override SellInCheckTypeEnum SellInType { get; }
    public override int QualityDecrement { get; }
    public override int QualityIncrement { get; }
    public override int SellInDecrement { get; }
    public override int SellInIncrement { get; }
    public DefaultItem(Item item) : base(item)
    {
        MaxQuality = 50;
        MinQuality = 0;
        SellInDefault = 0;
        SellInType = SellInCheckTypeEnum.Default;
        QualityDecrement = 1;
        QualityIncrement = 1;
        SellInDecrement = 1;
        SellInIncrement = 1;
    }
    public override void Update()
    {
        if (Item.Quality > MaxQuality) throw new Exception($"Item Quality could not be greater than {MaxQuality}");

        if (Item.Quality > MinQuality)
        {
            Item.Quality = Item.Quality - QualityDecrement;
            Item.SellIn = Item.SellIn - SellInDecrement;
        }
        else
        {
            throw new Exception($"Item Quality could not be less than {MinQuality}");
        }
    }
}