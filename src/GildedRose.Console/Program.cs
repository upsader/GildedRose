using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Program
    {
        public List<AbstractItem> Items;

        public Program(List<AbstractItem> items)
        {
            Items = items;
        }

        static void Main(string[] args)
        {
            List<AbstractItem> items = new List<AbstractItem>()
            {
                new DefaultItem(new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }),
                new ConjuredItem(new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }),
                new IncreasedItem(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }),
                new IncreasedWithOptionsItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }, new int[2]{11, 3}),
                new LegendaryItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 })
            };

            var app = new Program(items);

            app.UpdateQuality();
            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {

            foreach (var item in Items)
            {
                item.Update();
                item.UpdateIfOverdue();
            }
        }

        public enum SellInCheckTypeEnum : int
        {
            Default = 0,
            Overdue = 1,
            Conjured = 2,
            Increased = 3
        }
        public abstract class AbstractItem
        {
            public Item Item;
            public abstract int MaxQuality { get;}
            public abstract int MinQuality { get;}
            public abstract int SellInDefault { get;}
            public abstract  SellInCheckTypeEnum SellInType { get;}
            public abstract int QualityDecrement { get;}
            public abstract int QualityIncrement { get;}
            public abstract int SellInDecrement { get;}
            public abstract int SellInIncrement { get;}
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
        public class ConjuredItem : AbstractItem
        {
            public override int MaxQuality { get;}
            public override int MinQuality { get; }
            public override int SellInDefault { get;}
            public override SellInCheckTypeEnum SellInType { get; }
            public override int QualityDecrement { get;}
            public override int QualityIncrement { get;}
            public override int SellInDecrement { get;}
            public override int SellInIncrement { get;}

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

        public class IncreasedItem : AbstractItem
        {
            public override int MaxQuality { get; }
            public override int MinQuality { get; }
            public override int SellInDefault { get; }
            public override SellInCheckTypeEnum SellInType { get; }
            public override int QualityDecrement { get; }
            public override int QualityIncrement { get; }
            public override int SellInDecrement { get; }
            public override int SellInIncrement { get; }

            public IncreasedItem(Item item) : base(item)
            {
                MaxQuality = 50;
                MinQuality = 0;
                SellInDefault = 0;
                SellInType = SellInCheckTypeEnum.Increased;
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
                }
                else
                {
                   throw new Exception($"Item Quality could not be greater than {MaxQuality}");
                }
            }
        }

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
    }
    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }
}
