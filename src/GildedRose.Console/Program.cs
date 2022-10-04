using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

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


            UpdateQuality(markedItems);
            System.Console.ReadKey();

        }


        public static void CheckForOverdue(MarkedItem item, int type)
        {
            switch (type)
            {
                case (int)ItemType.Default:
                    if (item.Item.SellIn < MarkedItem.sellInDefault && item.Item.Quality > MarkedItem.minQuality)
                    {
                        item.Item.Quality = item.Item.Quality - item.QualityDecrement;
                    }
                    break;
                case (int)ItemType.Overdue:
                    if (item.Item.SellIn < MarkedItem.sellInDefault && item.Item.Quality < MarkedItem.maxQuality)
                    {
                        item.Item.Quality = item.Item.Quality - item.Item.Quality;
                    }
                    break;
                case (int)ItemType.Conjured:
                    if (item.Item.SellIn < MarkedItem.sellInDefault && item.Item.Quality > MarkedItem.ConjuredMinQualityValue)
                    {
                        item.Item.Quality = item.Item.Quality - item.QualityDecrement;
                    }
                    break;
                case (int)ItemType.Increased:
                    if (item.Item.SellIn < MarkedItem.sellInDefault && item.Item.Quality < MarkedItem.maxQuality)
                    {
                        item.Item.Quality = item.Item.Quality + item.QualityIncrement;
                    }
                    break;
            }

        }
        public static void UpdateDefault(MarkedItem item)
        {
            if (item.isDefault && item.Item.Quality > MarkedItem.minQuality)
            {
                item.Item.Quality = item.Item.Quality - item.QualityDecrement;
                item.Item.SellIn = item.Item.SellIn - item.SellInDecrement;
            }
        }

        public static void UpdateConjured(MarkedItem item)
        {
            if (item.isConjured && item.Item.Quality > MarkedItem.ConjuredMinQualityValue)
            {
                item.Item.Quality = item.Item.Quality - item.QualityDecrement;
                item.Item.SellIn = item.Item.SellIn - item.SellInDecrement;
            }
        }

        public static void UpdateIncreased(MarkedItem item)
        {
            if (item.isQualityIncreases && item.Item.Quality < MarkedItem.maxQuality)
            {
                item.Item.Quality = item.Item.Quality + item.QualityIncrement;
                item.Item.SellIn = item.Item.SellIn - item.SellInDecrement;
            }

        }

        public static void UpdateIncreasedWithOptions(MarkedItem item)
        {
            if (item.isQualityIncreasesWithOptions && item.IncreaseOptions != null && item.Item.Quality < MarkedItem.maxQuality)
            {
                item.Item.Quality = item.Item.Quality + item.QualityIncrement;
                item.Item.SellIn = item.Item.SellIn - item.SellInDecrement;

                if (item.Item.Quality < MarkedItem.maxQuality)
                {
                    item.Item.Quality = item.Item.Quality + item.QualityIncrement;

                    for (int i = 0; i < item.IncreaseOptions.Count(); i++)
                    {
                        if (item.Item.SellIn < item.IncreaseOptions[i])
                        {
                            if (item.Item.Quality < MarkedItem.maxQuality)
                            {
                                item.Item.Quality = item.Item.Quality + item.QualityIncrement;
                            }
                        }
                    }
                }
            }

        }

        public static void UpdateQuality(List<MarkedItem> Items)
        {

            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].isChangeable)
                {
                    UpdateDefault(Items[i]);
                    UpdateConjured(Items[i]);
                    UpdateIncreased(Items[i]);
                    UpdateIncreasedWithOptions(Items[i]);

                    CheckForOverdue(Items[i], Items[i].ItemType);
                }

                //if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                //{
                //    if (Items[i].Quality > 0)
                //    {
                //        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                //        {
                //            Items[i].Quality = Items[i].Quality - 1;
                //        }
                //    }
                //}
                //else
                //{
                //    if (Items[i].Quality < 50)
                //    {
                //        Items[i].Quality = Items[i].Quality + 1;

                //        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                //        {
                //            if (Items[i].SellIn < 11)
                //            {
                //                if (Items[i].Quality < 50)
                //                {
                //                    Items[i].Quality = Items[i].Quality + 1;
                //                }
                //            }

                //            if (Items[i].SellIn < 6)
                //            {
                //                if (Items[i].Quality < 50)
                //                {
                //                    Items[i].Quality = Items[i].Quality + 1;
                //                }
                //            }
                //        }
                //    }
                //}

                //if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                //{
                //    Items[i].SellIn = Items[i].SellIn - 1;
                //}

                //if (Items[i].SellIn < 0)
                //{
                //    if (Items[i].Name != "Aged Brie")
                //    {
                //        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                //        {
                //            if (Items[i].Quality > 0)
                //            {
                //                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                //                {
                //                    Items[i].Quality = Items[i].Quality - 1;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                //        }
                //    }
                //    else
                //    {
                //        if (Items[i].Quality < 50)
                //        {
                //            Items[i].Quality = Items[i].Quality + 1;
                //        }
                //    }
                //}
            }
        }
    }

    enum ItemType : int
    {
        Default = 0,
        Overdue = 1,
        Conjured = 2,
        Increased = 3
    }
    public class MarkedItem
    {
        /// <summary>
        /// maxValue = 50
        /// </summary>
        public static int maxQuality = 50;
        /// <summary>
        /// minValue = 0
        /// </summary>
        public static int minQuality = 0;
        /// <summary>
        /// minValue = 2
        /// </summary>
        public static int ConjuredMinQualityValue = 1;
        /// <summary>
        /// value = 0
        /// </summary>
        public static int sellInDefault = 0;
        public bool isDefault { get; set; } = true;
        public bool isChangeable { get; set; } = true;
        public bool isConjured { get; set; } = false;
        public bool isQualityIncreases { get; set; } = false;
        public bool isQualityIncreasesWithOptions { get; set; } = false;
        public int[] IncreaseOptions { get; set; }
        public int ItemType { get; set; } = 0;
        public int QualityDecrement { get; set; } = 1;
        public int QualityIncrement { get; set; } = 1;
        public int SellInDecrement { get; set; } = 1;
        public int SellInIncrement { get; set; } = 1;
        public Item Item;

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
