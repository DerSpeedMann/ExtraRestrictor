# ExtraRestrictor
Item restriction plugin loosely based off of LeeIzAZombie's ItemRestrictions, but using events instead of constant checks for no lag. Also has group based restrictions.

Documentation available here: https://iceplugins.xyz/ExtraRestrictor

## Restrict Items:

RestrictedItems allows to list item ids to be restricted (removed or replaced) 

- Replace: alows to set an item id to replace the original item with (0 = only remove original item)
- KeepAmount: allows to repace while keeping the original items amount (magazine capacity and so on)
- Empty allows: to repace with an empty item (amount = 0)
- KeepDurability: allows to repace while keeping the original items durability
```xml
<Item Replace="40200" KeepAmount="true" KeepDurability="false" Empty="false">44</Item>
```

## Restrict Blueprints:

RestrictedBlueprint allows to restrict blueprints for items by id and index (disable crafting)
- BlueprintIndex: the index of the blueprint (Blueprint_0_... would be index 0)
```xml
<RestrictedBlueprint BlueprintIndex="1">1169</RestrictedBlueprint>
```


##  Settings for Ammo Crates ( Unload Magazines ) Remastered Mod

```xml
<?xml version="1.0" encoding="utf-8"?>
<ExtraRestrictorConfiguration xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <RestrictedItems>
    <Item Replace="40200" KeepAmount="true" KeepDurability="false" Empty="false">44</Item>
    <Item Replace="40201" KeepAmount="true" KeepDurability="false" Empty="false">1192</Item>
    <Item Replace="40202" KeepAmount="true" KeepDurability="false" Empty="false">43</Item>
    <Item Replace="40203" KeepAmount="true" KeepDurability="false" Empty="false">1193</Item>
    <Item Replace="40204" KeepAmount="true" KeepDurability="false" Empty="false">119</Item>
    <Item Replace="40300" KeepAmount="true" KeepDurability="false" Empty="false">108</Item>
    <Item Replace="40301" KeepAmount="true" KeepDurability="false" Empty="false">100</Item>
    <Item Replace="40302" KeepAmount="true" KeepDurability="false" Empty="false">1006</Item>
    <Item Replace="40303" KeepAmount="true" KeepDurability="false" Empty="false">98</Item>
    <Item Replace="40304" KeepAmount="true" KeepDurability="false" Empty="false">1487</Item>
    <Item Replace="40305" KeepAmount="true" KeepDurability="false" Empty="false">111</Item>
    <Item Replace="40306" KeepAmount="true" KeepDurability="false" Empty="false">478</Item>
    <Item Replace="40307" KeepAmount="true" KeepDurability="false" Empty="false">103</Item>
    <Item Replace="40308" KeepAmount="true" KeepDurability="false" Empty="false">485</Item>
    <Item Replace="40309" KeepAmount="true" KeepDurability="false" Empty="false">1029</Item>
    <Item Replace="40310" KeepAmount="true" KeepDurability="false" Empty="false">1040</Item>
    <Item Replace="40350" KeepAmount="true" KeepDurability="false" Empty="false">1022</Item>
    <Item Replace="40351" KeepAmount="true" KeepDurability="false" Empty="false">1483</Item>
    <Item Replace="40352" KeepAmount="true" KeepDurability="false" Empty="false">1395</Item>
    <Item Replace="40353" KeepAmount="true" KeepDurability="false" Empty="false">17</Item>
    <Item Replace="40354" KeepAmount="true" KeepDurability="false" Empty="false">6</Item>
    <Item Replace="40355" KeepAmount="true" KeepDurability="false" Empty="false">1026</Item>
    <Item Replace="40356" KeepAmount="true" KeepDurability="false" Empty="false">1020</Item>
    <Item Replace="40357" KeepAmount="true" KeepDurability="false" Empty="false">1449</Item>
    <Item Replace="40358" KeepAmount="true" KeepDurability="false" Empty="false">1490</Item>
    <Item Replace="40400" KeepAmount="true" KeepDurability="false" Empty="false">1371</Item>
    <Item Replace="40401" KeepAmount="true" KeepDurability="false" Empty="false">1381</Item>
    <Item Replace="40402" KeepAmount="true" KeepDurability="false" Empty="false">1365</Item>
    <Item Replace="40403" KeepAmount="true" KeepDurability="false" Empty="false">1479</Item>
    <Item Replace="40404" KeepAmount="true" KeepDurability="false" Empty="false">127</Item>
    <Item Replace="40405" KeepAmount="true" KeepDurability="false" Empty="false">123</Item>
    <Item Replace="40406" KeepAmount="true" KeepDurability="false" Empty="false">125</Item>
    <Item Replace="40407" KeepAmount="true" KeepDurability="false" Empty="false">130</Item>
    <Item Replace="40408" KeepAmount="true" KeepDurability="false" Empty="false">1361</Item>
    <Item Replace="40409" KeepAmount="true" KeepDurability="false" Empty="false">1042</Item>
    <Item Replace="40450" KeepAmount="true" KeepDurability="false" Empty="false">489</Item>
    <Item Replace="40451" KeepAmount="true" KeepDurability="false" Empty="false">133</Item>
    <Item Replace="40452" KeepAmount="true" KeepDurability="false" Empty="false">298</Item>
    <Item Replace="40453" KeepAmount="true" KeepDurability="false" Empty="false">20</Item>
    <Item Replace="40500" KeepAmount="true" KeepDurability="false" Empty="false">1384</Item>
    <Item Replace="40501" KeepAmount="true" KeepDurability="false" Empty="false">1003</Item>
    <Item Replace="40502" KeepAmount="true" KeepDurability="false" Empty="false">1005</Item>
    <Item Replace="40121" KeepAmount="false" KeepDurability="false" Empty="true">40150</Item>
    <Item Replace="40123" KeepAmount="false" KeepDurability="false" Empty="true">40151</Item>
    <Item Replace="40122" KeepAmount="false" KeepDurability="false" Empty="true">40152</Item>
    <Item Replace="40125" KeepAmount="false" KeepDurability="false" Empty="true">40153</Item>
    <Item Replace="40124" KeepAmount="false" KeepDurability="false" Empty="true">40154</Item>
  </RestrictedItems>
  <RestrictedBlueprints />
  <IgnoreAdmins>false</IgnoreAdmins>
  <NotifyReplace>false</NotifyReplace>
  <NotifyRemove>true</NotifyRemove>
  <NotifyDeclineCraft>true</NotifyDeclineCraft>
</ExtraRestrictorConfiguration>
```
