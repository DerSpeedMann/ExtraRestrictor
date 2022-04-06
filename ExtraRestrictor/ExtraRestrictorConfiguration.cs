using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ExtraConcentratedJuice.ExtraRestrictor
{
    public class ExtraRestrictorConfiguration : IRocketPluginConfiguration
    {
        [XmlArrayItem(ElementName = "Item")]
        public List<RestrictedItem> RestrictedItems;
        public List<RestrictedBlueprint> RestrictedBlueprints;
        [XmlArrayItem(ElementName = "RestrictedSupply")]
        public List<ushort> RestrictByCraftingSupply;
        [XmlArrayItem(ElementName = "RestrictedOutput")]
        public List<ushort> RestrictByCraftingOutput;

        public bool IgnoreAdmins;
        public bool NotifyReplace;
        public bool NotifyRemove;
        public bool NotifyDeclineCraft;

        public void LoadDefaults()
        {
            RestrictedItems = new List<RestrictedItem>
            {
                new RestrictedItem { Bypass = "bypass.explosives", Id = 519 },
                new RestrictedItem { Replace = 6, Id = 17 },
                new RestrictedItem { Id = 1441 }
            };
            RestrictedBlueprints = new List<RestrictedBlueprint>
            {
                new RestrictedBlueprint {ItemId = 121, BlueprintIndex = 0}
            };
            RestrictByCraftingSupply = new List<ushort>
            {
                67
            };
            RestrictByCraftingOutput = new List<ushort>
            {
                66
            };
            IgnoreAdmins = false;
            NotifyReplace = false;
            NotifyRemove = true;
            NotifyDeclineCraft = true;
        }
    }
}
