using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathItemDrops.Models
{
    public class Item
    {
        public ushort Id { get; set; }
        public byte Amount { get; set; }
        public string Permission { get; set; }
    }
}
