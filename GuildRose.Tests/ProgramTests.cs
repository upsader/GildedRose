using GildedRose.Console;
using static GildedRose.Console.Program;

namespace GildedRose.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Update_Default_Items()
        {
            //ARRANGE
            List<MarkedItem> markedItems = new List<MarkedItem>()
                {
                    new MarkedItem {
                                    Item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
                                    },
                    new MarkedItem {
                                    isDefault = false,
                                    isQualityIncreases = true,
                                    ItemType = (int)ItemType.Increased,
                                    Item = new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }
                                    },
                    new MarkedItem {
                                    Item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 }
                                    },
                    new MarkedItem {
                                    isDefault = false,
                                    isChangeable = false,
                                    Item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
                                    },
                    new MarkedItem {
                                    isDefault = false,
                                    isQualityIncreasesWithOptions = true,
                                    ItemType = (int)ItemType.Overdue,
                                    IncreaseOptions = new int[2]{11,6},
                                    Item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
                                    },
                    new MarkedItem {
                                    QualityDecrement = 2,
                                    isDefault = false,
                                    isConjured = true,
                                    ItemType = (int)ItemType.Conjured,
                                    Item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                    }
                };

            Program app = new Program(markedItems);


            //ACT

            app.UpdateDefault(app.markedItems[0]);

            //ASSERT

            Assert.Equal(9, app.markedItems[0].Item.SellIn);
        }
    }
}