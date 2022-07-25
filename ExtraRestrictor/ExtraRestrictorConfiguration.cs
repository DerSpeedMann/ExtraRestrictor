using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SpeedMann.ExtraRestrictor
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
                new RestrictedItem { Replace = 40121, Empty = true, Id = 40150 },
                new RestrictedItem { Replace = 40122, Empty = true, Id = 40151 },
                new RestrictedItem { Replace = 40123, Empty = true, Id = 40152 },
                new RestrictedItem { Replace = 40124, Empty = true, Id = 40153 },
                new RestrictedItem { Replace = 40125, Empty = true, Id = 40154 },
                new RestrictedItem { Replace = 40200, KeepAmount = true, Id = 44 },
                new RestrictedItem { Replace = 40201, KeepAmount = true, Id = 1192 },
                new RestrictedItem { Replace = 40202, KeepAmount = true, Id = 43 },
                new RestrictedItem { Replace = 40203, KeepAmount = true, Id = 1193 },
                new RestrictedItem { Replace = 40204, KeepAmount = true, Id = 119 },
                new RestrictedItem { Replace = 40300, KeepAmount = true, Id = 108 },
                new RestrictedItem { Replace = 40301, KeepAmount = true, Id = 100 },
                new RestrictedItem { Replace = 40302, KeepAmount = true, Id = 1006 },
                new RestrictedItem { Replace = 40303, KeepAmount = true, Id = 98 },
                new RestrictedItem { Replace = 40304, KeepAmount = true, Id = 1487 },
                new RestrictedItem { Replace = 40305, KeepAmount = true, Id = 111 },
                new RestrictedItem { Replace = 40306, KeepAmount = true, Id = 478 },
                new RestrictedItem { Replace = 40307, KeepAmount = true, Id = 103 },
                new RestrictedItem { Replace = 40308, KeepAmount = true, Id = 485 },
                new RestrictedItem { Replace = 40309, KeepAmount = true, Id = 1029 },
                new RestrictedItem { Replace = 40310, KeepAmount = true, Id = 1040 },
                new RestrictedItem { Replace = 40350, KeepAmount = true, Id = 1022 },
                new RestrictedItem { Replace = 40351, KeepAmount = true, Id = 1483 },
                new RestrictedItem { Replace = 40352, KeepAmount = true, Id = 1395 },
                new RestrictedItem { Replace = 40353, KeepAmount = true, Id = 17 },
                new RestrictedItem { Replace = 40354, KeepAmount = true, Id = 6 },
                new RestrictedItem { Replace = 40355, KeepAmount = true, Id = 1026 },
                new RestrictedItem { Replace = 40356, KeepAmount = true, Id = 1020 },
                new RestrictedItem { Replace = 40357, KeepAmount = true, Id = 1449 },
                new RestrictedItem { Replace = 40358, KeepAmount = true, Id = 1490 },
                new RestrictedItem { Replace = 40400, KeepAmount = true, Id = 1371 },
                new RestrictedItem { Replace = 40401, KeepAmount = true, Id = 1381 },
                new RestrictedItem { Replace = 40402, KeepAmount = true, Id = 1365 },
                new RestrictedItem { Replace = 40403, KeepAmount = true, Id = 1479 },
                new RestrictedItem { Replace = 40404, KeepAmount = true, Id = 127 },
                new RestrictedItem { Replace = 40405, KeepAmount = true, Id = 123 },
                new RestrictedItem { Replace = 40406, KeepAmount = true, Id = 125 },
                new RestrictedItem { Replace = 40407, KeepAmount = true, Id = 130 },
                new RestrictedItem { Replace = 40408, KeepAmount = true, Id = 1361 },
                new RestrictedItem { Replace = 40409, KeepAmount = true, Id = 1042 },
                new RestrictedItem { Replace = 40450, KeepAmount = true, Id = 489 },
                new RestrictedItem { Replace = 40451, KeepAmount = true, Id = 133 },
                new RestrictedItem { Replace = 40452, KeepAmount = true, Id = 298 },
                new RestrictedItem { Replace = 40453, KeepAmount = true, Id = 20 },
                new RestrictedItem { Replace = 40500, KeepAmount = true, Id = 1384 },
                new RestrictedItem { Replace = 40501, KeepAmount = true, Id = 1003 },
                new RestrictedItem { Replace = 40502, KeepAmount = true, Id = 1005 },
            };
            RestrictedBlueprints = new List<RestrictedBlueprint>
            {
                /*
                //Hells_Fury Military Crafts:

                // Military_40
                new RestrictedBlueprint {ItemId = 40402, BlueprintIndex = 0},
                // AmmoCrateLCMil
                new RestrictedBlueprint {ItemId = 40402, BlueprintIndex = 4},
                // Military_40
                new RestrictedBlueprint {ItemId = 40202, BlueprintIndex = 13},
                // AmmoCrateLCMil
                new RestrictedBlueprint {ItemId = 40122, BlueprintIndex = 13},


                //Hells_Fury Ranger Crafts:
                
                // Ranger_40
                new RestrictedBlueprint {ItemId = 40402, BlueprintIndex = 2},
                // AmmoCrateLCRan
                new RestrictedBlueprint {ItemId = 40402, BlueprintIndex = 3},
                // Ranger_40
                new RestrictedBlueprint {ItemId = 40204, BlueprintIndex = 15},  
                // AmmoCrateLCRan
                new RestrictedBlueprint {ItemId = 40124, BlueprintIndex = 15},
                */

            };
            RestrictByCraftingSupply = new List<ushort>
            {
            };
            RestrictByCraftingOutput = new List<ushort>
            {
            };
            IgnoreAdmins = false;
            NotifyReplace = false;
            NotifyRemove = true;
            NotifyDeclineCraft = true;
        }
    }
}
