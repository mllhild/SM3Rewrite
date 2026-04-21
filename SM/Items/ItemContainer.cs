using System.Collections.Generic;
using System.Linq;

namespace SM3Rewrite
{
    public class ItemContainer : EntityLvl2
    {
        public Dictionary<string, ItemStack> itemStacks = new Dictionary<string, ItemStack>();
        public Dictionary<string, Equipment> equipments = new Dictionary<string, Equipment>();
        public void AddItemstack(ItemStack stack) { itemStacks[stack.ID] = stack; }
        public void RemoveItemstack(ItemStack stack) { itemStacks.Remove(stack.ID); }
        public void MergeItemStacks()
        {
            var merged = new Dictionary<string, ItemStack>();

            foreach (var stack in itemStacks.Values)
            {
                if (merged.TryGetValue(stack.itemType, out var existing))
                {
                    existing.count += stack.count;
                }
                else
                {
                    merged[stack.itemType] = new ItemStack
                    {
                        itemType = stack.itemType,
                        count = stack.count
                    };
                }
            }

            itemStacks = merged;
        }
        public IOrderedEnumerable<KeyValuePair<string, Equipment>> SortEquipment() {
            var sorted = equipments.OrderBy(e => e.Value.name);
            return sorted; 
        }
        public IOrderedEnumerable<KeyValuePair<string, ItemStack>> SortItems()
        {
            MergeItemStacks();
            var sorted = itemStacks.OrderBy(e => e.Value.itemType);
            return sorted;
        }

    }
}
