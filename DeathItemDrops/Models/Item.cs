using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DeathItemDrops.Models
{
    public class Item
    {
        [XmlText]
        public ushort Id { get; set; }
        [XmlAttribute("Amount")]
        public byte Amount { get; set; }
        [XmlAttribute("Permission")]
        public string Permission { get; set; }
    }
}
