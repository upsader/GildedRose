using GildedRose.Console;

public class LegendaryItem : AbstractItem
{
    public override int MaxQuality { get; }
    public override int MinQuality { get; }
    public override int SellInDefault { get; }
    public override SellInCheckTypeEnum SellInType { get; }
    public override int QualityDecrement { get; }
    public override int QualityIncrement { get; }
    public override int SellInDecrement { get; }
    public override int SellInIncrement { get; }

    public LegendaryItem(Item item) : base(item) { }

    public override void Update() { }
}