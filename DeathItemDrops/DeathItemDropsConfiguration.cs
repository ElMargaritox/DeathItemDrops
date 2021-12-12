using DeathItemDrops.Models;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeathItemDrops
{
    public class DeathItemDropsConfiguration : IRocketPluginConfiguration
    {
        public int Interval;
        [XmlArrayItem(ElementName = "Items")]
        public List<Item> Items; 
        public void LoadDefaults()
        {
            Interval = 10;
            Items = new List<Item>
            {
                new Item{Id = 15, Amount = 1},
                new Item{Id = 6, Amount = 1},
                new Item{Id = 363, Amount = 1, Permission = "vip"}
            };
        }
    }
}
