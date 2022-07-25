using Rocket.Core.Plugins;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Enumerations;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Linq;
using UnityEngine;
using Rocket.API.Collections;
using Rocket.API;
using System.Collections;
using Logger = Rocket.Core.Logging.Logger;
using System;

namespace SpeedMann.ExtraRestrictor
{
    public class ExtraRestrictor : RocketPlugin<ExtraRestrictorConfiguration>
    {
        public static ExtraRestrictor Inst { get; private set; }
        public static ExtraRestrictorConfiguration Conf { get; private set; }
        protected override void Load()
        {
            Inst = this;
            Conf = Configuration.Instance;

            UnturnedPlayerEvents.OnPlayerInventoryAdded += OnInventoryUpdated;
            UnturnedPlayerEvents.OnPlayerWear += OnWear;
            PlayerCrafting.onCraftBlueprintRequested += OnCraft;

            Logger.Log("UloadMags Loaded!");
            Logger.Log("Users with the permission extrarestrictor.bypass will bypass restrictions.");
            Logger.Log($"Ignore admins: {Conf.IgnoreAdmins}");
            Logger.Log($"Notify on item replace: {Conf.NotifyReplace}");
            Logger.Log($"Notify on item remove: {Conf.NotifyRemove}");
            Logger.Log($"Notify on craft declined: {Conf.NotifyDeclineCraft}");

            Logger.Log("Restricted items:");
            Logger.Log("===================================================================");

            foreach (var item in Conf.RestrictedItems
                .Select(x => $"ID: {x.Id} | Name: {Assets.find(EAssetType.ITEM, x.Id)?.name ?? "> INVALID ID <"} | Replace: {(x.Replace == 0 ? "None" : x.Replace.ToString())} | Bypass: {(x.Bypass ?? "None")}"))
                Logger.Log(item);

            Logger.Log("Restricted blueprints:");
            Logger.Log("===================================================================");

            foreach (var item in Conf.RestrictedBlueprints
                .Select(x => $"ItemID: {x.ItemId} | Name: {Assets.find(EAssetType.ITEM, x.ItemId)?.name ?? "> INVALID ID <"} | Blueprint Index: {(x.BlueprintIndex)} | Bypass: {(x.Bypass ?? "None")}"))
                Logger.Log(item);
            Logger.Log("===================================================================");
        }

        protected override void Unload()
        {
            UnturnedPlayerEvents.OnPlayerInventoryAdded -= OnInventoryUpdated;
            UnturnedPlayerEvents.OnPlayerWear -= OnWear;
            PlayerCrafting.onCraftBlueprintRequested -= OnCraft;
        }

        private void OnInventoryUpdated(UnturnedPlayer player, InventoryGroup inventoryGroup, byte inventoryIndex, ItemJar P)
        {
            
            if ((player.IsAdmin && Conf.IgnoreAdmins) || player.GetPermissions().Any(x => x.Name == "extrarestrictor.bypass"))
                return;

            RestrictedItem item = Conf.RestrictedItems.FirstOrDefault(x => x.Id == P.item.id);

            if (item != null && !player.GetPermissions().Any(x => x.Name == item.Bypass))
            {
                player.Inventory.removeItem((byte)inventoryGroup, inventoryIndex);
                if (item.Replace != 0)
                {
                    Item replacement = new Item(item.Replace, true);
                    replacement.amount = item.KeepAmount ? P.item.amount : item.Empty ? (byte)0 : replacement.amount;
                    replacement.durability = item.KeepDurability ? P.item.durability : replacement.durability;

                    if(!player.Inventory.tryAddItem(replacement, P.x, P.y, (byte)inventoryGroup, P.rot))
                    {
                        if (!player.GiveItem(replacement))
                        {
                            player.Inventory.forceAddItem(replacement, false);
                        }
                    }
                    if (Conf.NotifyReplace)
                    {
                        UnturnedChat.Say(player, Util.Translate("item_replaced",
                        Assets.find(EAssetType.ITEM, P.item.id).name, P.item.id,
                        Assets.find(EAssetType.ITEM, item.Replace).name, item.Replace), Color.yellow);
                    }   
                }
                else if (Conf.NotifyRemove)
                {
                    UnturnedChat.Say(player, Util.Translate("item_restricted", Assets.find(EAssetType.ITEM, P.item.id).name, P.item.id), Color.red);
                }
            }
        }

        private void OnWear(UnturnedPlayer player, UnturnedPlayerEvents.Wearables wear, ushort id, byte? quality)
        {
            
            if ((player.IsAdmin && Conf.IgnoreAdmins) || player.GetPermissions().Any(x => x.Name == "extrarestrictor.bypass"))
                return;

            RestrictedItem item = Conf.RestrictedItems.FirstOrDefault(x => x.Id == id);

            if (item != null && !player.GetPermissions().Any(x => x.Name == item.Bypass))
            {
                // Gotta wait until the next frame for the item to be removed
                switch (wear)
                {
                    #region WearSwitch
                    case UnturnedPlayerEvents.Wearables.Backpack:
                        StartCoroutine(InvokeOnNextFrame(() =>
                        player.Player.clothing.askWearBackpack(0, 0, new byte[0], true)));
                        break;
                    case UnturnedPlayerEvents.Wearables.Glasses:
                        StartCoroutine(InvokeOnNextFrame(() =>
                        player.Player.clothing.askWearGlasses(0, 0, new byte[0], true)));
                        break;
                    case UnturnedPlayerEvents.Wearables.Hat:
                        StartCoroutine(InvokeOnNextFrame(() =>
                        player.Player.clothing.askWearHat(0, 0, new byte[0], true)));
                        break;
                    case UnturnedPlayerEvents.Wearables.Mask:
                        StartCoroutine(InvokeOnNextFrame(() =>
                        player.Player.clothing.askWearMask(0, 0, new byte[0], true)));
                        break;
                    case UnturnedPlayerEvents.Wearables.Pants:
                        StartCoroutine(InvokeOnNextFrame(() =>
                        player.Player.clothing.askWearPants(0, 0, new byte[0], true)));
                        break;
                    case UnturnedPlayerEvents.Wearables.Shirt:
                        StartCoroutine(InvokeOnNextFrame(() =>
                        player.Player.clothing.askWearShirt(0, 0, new byte[0], true)));
                        break;
                    case UnturnedPlayerEvents.Wearables.Vest:
                        StartCoroutine(InvokeOnNextFrame(() =>
                        player.Player.clothing.askWearVest(0, 0, new byte[0], true)));
                        break;
                    #endregion
                }
            }
        }

        private IEnumerator InvokeOnNextFrame(System.Action action)
        {
            yield return new WaitForFixedUpdate();
            action();
        }

        private void OnCraft(PlayerCrafting crafting, ref ushort itemID, ref byte blueprintIndex, ref bool shouldAllow)
        {
            UnturnedPlayer player = UnturnedPlayer.FromPlayer(crafting.player);

            if ((player.IsAdmin && Conf.IgnoreAdmins) || player.GetPermissions().Any(x => x.Name == "extrarestrictor.bypass"))
                return;

            Blueprint blueprint = ((ItemAsset)Assets.find(EAssetType.ITEM, itemID)).blueprints[blueprintIndex];
            ushort innerItemId = itemID;
            byte innerBlueprintIdx = blueprintIndex;
            bool restricted = false;

            foreach (BlueprintSupply supply in blueprint.supplies)
            {
                if (Conf.RestrictByCraftingSupply.Contains(supply.id))
                {
                    restricted = true;
                    break;
                }
            }
            if (!restricted)
            {
                foreach (BlueprintOutput output in blueprint.outputs)
                {
                    if (Conf.RestrictByCraftingOutput.Contains(output.id))
                    {
                        restricted = true;
                        break;
                    }
                }
            }


            RestrictedBlueprint restBlueprint = Conf.RestrictedBlueprints.FirstOrDefault(x => x.ItemId == innerItemId && x.BlueprintIndex == innerBlueprintIdx);
            if( restBlueprint != null) {
                restricted = true;
            }
            // check if blueprint is restricted and is not bypassed
            if (restricted && (restBlueprint == null || !player.GetPermissions().Any(x => x.Name == restBlueprint.Bypass)))
            {
                shouldAllow = false;

                if (Conf.NotifyDeclineCraft)
                {
                    UnturnedChat.Say(player, Util.Translate("blueprint_restricted", Assets.find(EAssetType.ITEM, innerItemId).name, innerItemId), Color.red);
                }
            }
        }

        public override TranslationList DefaultTranslations =>
            new TranslationList
            {
                { "item_restricted", "You do not have access to this restricted item. ({0}, {1})" },
                { "item_replaced", "The Item {0} ({1}) was replaced with {2} ({3})." },
                { "blueprint_restricted", "You do not have access to this Crafting Recipe ({0}, {1})." }
            };
    }
}
