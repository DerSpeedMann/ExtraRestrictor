using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ExtraConcentratedJuice.ExtraRestrictor
{
    public class RestrictedItem
    {
        [XmlText]
        public ushort Id { get; set; }
        [XmlAttribute("BypassPermission")]
        public string Bypass { get; set; }
        [XmlAttribute("Replace")]
        public int Replace { get; set; }
        [XmlAttribute("KeepAmount")]
        public bool KeepAmount { get; set; }
        [XmlAttribute("KeepDurability")]
        public bool KeepDurability { get; set; }
        [XmlAttribute("Empty")]
        public bool Empty { get; set; }
        
        public RestrictedItem() { }
    }
}
