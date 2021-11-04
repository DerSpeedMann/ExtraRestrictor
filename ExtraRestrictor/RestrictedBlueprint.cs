using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ExtraConcentratedJuice.ExtraRestrictor
{
    public class RestrictedBlueprint
    {
        [XmlText]
        public ushort ItemId { get; set; }
        [XmlAttribute("BlueprintIndex")]
        public byte BlueprintIndex { get; set; }
        [XmlAttribute("BypassPermission")]
        public string Bypass { get; set; }

        public RestrictedBlueprint() { }
    }
}
