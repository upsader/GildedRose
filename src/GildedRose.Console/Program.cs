using System.Collections.Generic;

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
                new IncreasedWithOptionsItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }, new int[2]{11, 3}),
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
    }
}
