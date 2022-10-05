using GildedRose.Console;
using System.Linq;
using System;

public class IncreasedWithOptionsItem : AbstractItem
{
    public override int MaxQuality { get; }
    public override int MinQuality { get; }
    public override int SellInDefault { get; }
    public override SellInCheckTypeEnum SellInType { get; }
    public override int QualityDecrement { get; }
    public override int QualityIncrement { get; }
    public override int SellInDecrement { get; }
    public override int SellInIncrement { get; }
    /// <summary>
    /// SellIn options
    /// </summary>
    public int[] Options { get; }
    public IncreasedWithOptionsItem(Item item, int[] options) : base(item)
    {
        Options = options;
        MaxQuality = 50;
        MinQuality = 0;
        SellInDefault = 0;
        SellInType = SellInCheckTypeEnum.Overdue;
        QualityDecrement = 1;
        QualityIncrement = 1;
        SellInDecrement = 1;
        SellInIncrement = 1;
    }
    public override void Update()
    {
        if (Item.Quality < MinQuality) throw new Exception($"Item Quality could not be less than {MinQuality}");

        if (Item.Quality < MaxQuality)
        {
            Item.Quality = Item.Quality + QualityIncrement;
            Item.SellIn = Item.SellIn - SellInDecrement;

            for (int i = 0; i < Options.Count(); i++)
            {
                if (Item.SellIn < Options[i])
                {
                    if (Item.Quality < MaxQuality)
                    {
                        Item.Quality = Item.Quality + QualityIncrement;
                    }
                }
            }
        }
        else
        {
            throw new Exception($"Item Quality could not be greater than {MaxQuality}");
        }
    }

}