using System;
using System.Collections.Generic;
using System.Text;

namespace CP13_var2
{
    public enum ItemRarity { Common, Rare, Epic, Legendary }

    public enum ItemSlot { Weapon, Armor, Accessory }

    public struct Item
    {
        public string Name;
        public ItemRarity Rarity;
        public ItemSlot Slot;

        public override string ToString() => $"{Name} ({Rarity}, {Slot})";
    }
}