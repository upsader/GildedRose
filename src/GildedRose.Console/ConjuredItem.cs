using GildedRose.Console;
using static GildedRose.Console.Program;
using System;

public class ConjuredItem : AbstractItem
{
    public override int MaxQuality { get; }
    public override int MinQuality { get; }
    public override int SellInDefault { get; }
    public override SellInCheckTypeEnum SellInType { get; }
    public override int QualityDecrement { get; }
    public override int QualityIncrement { get; }
    public override int SellInDecrement { get; }
    public override int SellInIncrement { get; }

    public ConjuredItem(Item item) : base(item)
    {
        MaxQuality = 50;
        MinQuality = 1;
        SellInDefault = 0;
        SellInType = SellInCheckTypeEnum.Conjured;
        QualityDecrement = 2;
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