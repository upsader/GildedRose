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

        [Theory]
        [InlineData(10, 20, 9, 18)]
        [InlineData(-1, 10, -2, 6)]
        public void Update_Conjured_Items(int passedSellIn, int passedQuality, int expectedSellIn, int expectedQuality)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
                {
                    new ConjuredItem(new Item { Name = "Conjured Mana Cake", SellIn = passedSellIn, Quality = passedQuality }),
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
        public void Update_Conjured_Items_Throws(int passedSellIn, int passedQuality)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
                {
                    new ConjuredItem(new Item { Name = "Conjured Mana Cake", SellIn = passedSellIn, Quality = passedQuality }),
                };

            Program app = new Program(items);

            //ACT
            Assert.Throws<Exception>(() => app.UpdateQuality());
        }

        [Theory]
        [InlineData(10, 20, 9, 21)]
        [InlineData(-1, 10, -2, 12)]
        public void Update_Increased_Items(int passedSellIn, int passedQuality, int expectedSellIn, int expectedQuality)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
                {
                    new IncreasedItem(new Item { Name = "Aged Brie", SellIn = passedSellIn, Quality = passedQuality }),
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
        public void Update_Increased_Items_Throws(int passedSellIn, int passedQuality)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
                {
                    new IncreasedItem(new Item { Name = "Aged Brie", SellIn = passedSellIn, Quality = passedQuality }),
                };

            Program app = new Program(items);

            //ACT
            Assert.Throws<Exception>(() => app.UpdateQuality());
        }

        [Theory]
        [InlineData(15, 20, new int[2] {11, 3}, 14, 21)]
        [InlineData(15, 20, new int[2] {20, 16}, 14, 23)]
        [InlineData(-1, 20, new int[2] {11, 6}, -2, 0)]
        [InlineData(10, 30, new int[3] {11, 6, 3}, 9, 32)]
        [InlineData(3, 30, new int[3] {11, 6, 4 }, 2, 34)]
        public void Update_IncreasedWithOptions_Items(int passedSellIn, 
                                                      int passedQuality, 
                                                      int[] passedOptions, 
                                                      int expectedSellIn, 
                                                      int expectedQuality)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
                {
                    new IncreasedWithOptionsItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = passedSellIn, Quality = passedQuality }, passedOptions),
                };

            Program app = new Program(items);


            //ACT
            app.UpdateQuality();

            //ASSERT
            Assert.Equal(expectedSellIn, items[0].Item.SellIn);
            Assert.Equal(expectedQuality, items[0].Item.Quality);
        }

        [Theory]
        [InlineData(15, 51, new int[2] { 11, 3 })]
        [InlineData(15, -1, new int[2] { 20, 16 })]
        public void Update_IncreasedWithOptions_Items_Trows(int passedSellIn,
                                                      int passedQuality,
                                                      int[] passedOptions)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
                {
                    new IncreasedWithOptionsItem(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = passedSellIn, Quality = passedQuality }, passedOptions),
                };

            Program app = new Program(items);

            //ACT
            Assert.Throws<Exception>(() => app.UpdateQuality());
        }

        [Theory]
        [InlineData(0, 80, 0, 80)]
        [InlineData(-3, -3, -3, -3)]
        public void Update_Legendary_Items(int passedSellIn, int passedQuality, int expectedSellIn, int expectedQuality)
        {
            //ARRANGE
            List<AbstractItem> items = new List<AbstractItem>()
                {
                    new LegendaryItem(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = passedSellIn, Quality = passedQuality })
                };

            Program app = new Program(items);

            //ACT
            app.UpdateQuality();

            //ASSERT
            Assert.Equal(expectedSellIn, items[0].Item.SellIn);
            Assert.Equal(expectedQuality, items[0].Item.Quality);
        }
    }
}
