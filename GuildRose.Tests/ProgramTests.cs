using GildedRose.Console;
using static GildedRose.Console.Program;

namespace GildedRose.Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(10, 20, 9, 19)]
        [InlineData(-1, 5, -2, 3)]
        public void Update_Default_Items(int passedSellIn, int passedQuality, int expectedSellIn, int expectedQuality)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
            {
                new DefaultItem(new Item {Name = "+5 Dexterity Vest", SellIn = passedSellIn, Quality = passedQuality }),
            };

            Program app = new Program(items);

            //ACT
            app.UpdateQuality();

            //ASSERT
            Assert.Equal(expectedSellIn, items[0].Item.SellIn);
            Assert.Equal(expectedQuality, items[0].Item.Quality);
        }

        [Theory]
        [InlineData(-1, -1)]
        [InlineData(10, 52)]
        public void Update_Default_Items_Throws(int passedSellIn, int passedQuality)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
            {
                new DefaultItem(new Item {Name = "+5 Dexterity Vest", SellIn = passedSellIn, Quality = passedQuality }),
            };

            Program app = new Program(items);

            //ACT
            Assert.Throws<Exception>(() => app.UpdateQuality());
        }

        //    [Fact]
        //    public void Update_Conjured_Items()
        //    {
        //        //ARRANGE
        //        List<AbstractItem> items = new List<AbstractItem>()
        //        {
        //            new ConjuredItem(new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }),
        //        };

        //        Program app = new Program(items);


        //        //ACT

        //        app.UpdateQuality();

        //        //ASSERT

        //        Assert.Equal(-2, items[0].Item.SellIn);
        //        Assert.Equal(18, items[0].Item.Quality);
        //    }

        //    [Fact]
        //    public void Update_Increased_Items()
        //    {
        //        //ARRANGE
        //        List<AbstractItem> items = new List<AbstractItem>()
        //        {
        //            new IncreasedItem(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }),
        //        };

        //        Program app = new Program(items);


        //        //ACT

        //        app.UpdateQuality();

        //        //ASSERT

        //        Assert.Equal(-2, items[0].Item.SellIn);
        //        Assert.Equal(18, items[0].Item.Quality);
        //    }

        //    [Fact]
        //    public void Update_IncreasedWithOptions_Items()
        //    {
        //        //ARRANGE
        //        List<AbstractItem> items = new List<AbstractItem>()
        //        {
        //            new IncreasedWithOptionsItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }, new int[2]{11, 3}),
        //        };

        //        Program app = new Program(items);


        //        //ACT

        //        app.UpdateQuality();

        //        //ASSERT

        //        Assert.Equal(-2, items[0].Item.SellIn);
        //        Assert.Equal(18, items[0].Item.Quality);
        //    }

        //    [Fact]
        //    public void Update_Legendary_Items()
        //    {
        //        //ARRANGE
        //        List<AbstractItem> items = new List<AbstractItem>()
        //        {
        //            new LegendaryItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 })
        //        };

        //        Program app = new Program(items);


        //        //ACT

        //        app.UpdateQuality();

        //        //ASSERT

        //        Assert.Equal(-2, items[0].Item.SellIn);
        //        Assert.Equal(18, items[0].Item.Quality);
        //    }
        //}
    }
}